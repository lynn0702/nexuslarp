Ext.define('Ext.ux.AppState', {

    constructor: function(config) {
        var me = this;
        me.historicState = {};
    },
    addStateObject: function(view, objectName, object) {
        if (!this.historicState[view]) {
            this.historicState[view] = {};
        }
        this.historicState[view][objectName] = object;
    },
    getStateObject: function(view, objectName) {
        if (this.historicState[view] && this.historicState[view][objectName]) {
            return this.historicState[view][objectName];
        }
        return null;
    },
    saveFormState: function (panel, token) {
        var items = panel.items.items;
        for (var i = 0, length = items.length; i < length; i++) {
            var item = items[i];
            if (item.getValues && item.maintainState) {
                this.historicState[token] = {};
                this.historicState[token][item.name] = item.getValues();
                return;
            } else {
                if (item.items && item.items.items && item.items.items.length > 0) {
                    this.saveFormState(item, token);
                }
            }
        }
    },
    loadFormState: function(panel, token) {
        var items = panel.items.items;
        for (var i = 0, length = items.length; i < length; i++) {
            var item = items[i];
            if (item.getForm && item.maintainState) {
                var form = item.getForm();
                var values = this.historicState[token][item.name];
                form.setValues(values);
                return;
            } else {
                if (item.items && item.items.items && item.items.items.length > 0) {
                    this.loadFormState(item, token);
                }
            }
        }
    }
});