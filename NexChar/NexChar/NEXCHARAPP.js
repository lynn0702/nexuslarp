Ext.Ajax.defaultHeaders = {
    'Accept': 'application/json'
};

function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results == null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}

var disableCaching = getParameterByName('dc');
if (disableCaching == 'false') {
    disableCaching = false;
} else {
    disableCaching = true;
}


Ext.Loader.setConfig({
    disableCaching: false,

    enabled: true
});

Ext.Loader.setPath('Ext.ux', 'extensions');

Ext.Ajax.on('requestexception', function (conn, response, options) {
    Ext.Msg.alert('Error', Ext.decode(response.responseText).ExceptionMessage);
}, this);

Ext.application({
    name: 'NexChar.FrontEnd',
    selectedOrganizationalUnit: null,
    permissionsForSelectedUnit: null,
    appFolder: '/app',
    controllers: [
        'Admin',
        'App',
        'Character'
    ],
    stores: [
        'Skills'
    ],

    refs: [{
        selector: '#mainContent',
        ref: 'mainContent'
    },
    {
        selector: '#centerContent',
        ref: 'centerContent'
    }],
    getState: function () {
        return this.getStateStore();
    },
    launch: function () {
        var me = this;
        this.setHistoryTracking();
        Ext.History.on('change', me.onHistoryChange, me);
        Ext.create('Ext.container.Viewport', {
            layout: 'fit',
         //   renderTo: Ext.get('appDiv'),
            items: [
                new NexChar.FrontEnd.view.App()
            ]
        });
    },
    getOrgUnit: function (orgID) {
        var me = this;
        var store = me.getOrganizationalUnitDictionaryStore();

        return store.getById(orgID);
    },
    getPayer1099: function (payerID) {
        var me = this;
        var store = me.getPayer1099Store();

        return store.getById(payerID);
    }, setHistoryTracking: function () {
        this.appState = new Ext.ux.AppState();
        Ext.util.History.init();
    },
    anySearchFieldIsDirty: function (form) {
        var searchFields = form.query('field[cls~=searchfield]');
        if (!form.isValid()) {
            return false;
        }

        for (var i = 0, length = searchFields.length; i < length; i++) {
            if (searchFields[i].isDirty()) {
                return true;
            }
        }
        return false;
    },
    addHistory: function (panel, view, config, record, callback) {
        if (!this.historyChange && view) {
            this.addingHistory = true;
            Ext.util.History.add(view, true);
            this.appState.addStateObject(view, 'config', config);
            this.appState.addStateObject(view, 'record', record);
            this.appState.addStateObject(view, 'callback', callback);
            this.saveAppState(panel, this.currentView);


        }
        this.historyChange = false;
    },
    saveAppState: function (panel, view) {

        this.appState.saveFormState(panel, view);
    },
    changeCenterContent: function (view, config, record, callback) {
        this.getMainContent().collapse();
        var centerContentPanel = this.getCenterContent();

        this.addHistory(centerContentPanel, view, config, record, callback);

        this.clearCenterContentPanel();

        this.currentView = view;


        if (typeof view == "string") {
            panelContents = {
                xtype: view
            };
            if (record) {
                panelContents.listeners = {
                    'beforerender': function (form) {
                        form.loadRecord(record);
                    }
                };
            }

            if (config) {
                Ext.merge(panelContents, config);
            }
        } else {
            panelContents = view;
            if (record) {
                panelContents.loadRecord(record);
            }
        }

        centerContentPanel.add(panelContents);
        if (callback) {
            callback();
        }

    },
    changeContent: function (view, config, record, callback) {


        var mainContentPanel = this.getMainContent();

        this.addHistory(mainContentPanel, view, config, record, callback);

        this.clearMainContentPanel();

        this.currentView = view;


        if (typeof view == "string") {
            panelContents = {
                xtype: view
            };
            if (record) {
                panelContents.listeners = {
                    'beforerender': function (form) {
                        form.loadRecord(record);
                    }
                };
            }

            if (config) {
                Ext.merge(panelContents, config);
            }
        } else {
            panelContents = view;
            if (record) {
                panelContents.loadRecord(record);
            }
        }

        mainContentPanel.add(panelContents);
        if (callback) {
            callback();
        }
        mainContentPanel.expand();
    },

    clearMainContentPanel: function () {
        var mainContentPanel = this.getMainContent();
        mainContentPanel.removeAll();
    },
    clearCenterContentPanel: function() {
        var centerContentPanel = this.getCenterContent();
        centerContentPanel.removeAll();
    },

    getPermission: function (permissionName) {
        //var allowed = false;
        //var userSecurityStore = this.getUserSecurityStore();

        //var securityRecord = userSecurityStore.findRecord('name', permissionName, 0, false, false, true);

        //if (securityRecord) {
        //    allowed = securityRecord.get('allowed');
        //}
        //return allowed;
    },
    onHistoryChange: function (token, options) {
        if (this.addingHistory) {
            this.addingHistory = false;
            return;
        }
        var mainContentPanel = this.getMainContent();

        if (token === null) {
            this.clearMainContentPanel();
            this.setHistoryTracking();
            return;
        }
        this.historyChange = true;
        var config = this.appState.getStateObject(token, 'config');
        var record = this.appState.getStateObject(token, 'record');
        var callback = this.appState.getStateObject(token, 'callback');

        this.changeContent(token, config, record, callback);

        this.appState.loadFormState(mainContentPanel, token);
    }
});