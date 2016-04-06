Ext.define('NexChar.FrontEnd.controller.App', {
        extend: 'Ext.app.Controller',
        views: [
            'App',
            'ResultCountDisplay',
            'Navigation',
            'character.SkillChart',
            'character.CharacterPanel'
        ],
        stores: ['Skills'],
        refs: [
        {
            selector: '#mainContent',
            ref: 'mainContent'
        },
        {
            selector: '#centerContent',
            ref: 'centerContent'
        },
        {
            selector: '#characterPanel',
            ref: 'characterPanel'
        },
        {
            selector: '#westContent',
            ref: 'westContent'
        },
        {
            selector: '[name=navigationcontent]',
            ref: 'navigationContent'
        },
        {
            selector: '[cls*=navigation]',
            ref: 'navPanels'
        }
    ],
    init: function() {
        var me = this;


        Ext.data.StoreManager.on('add', function(index, store) {
            store.on('beforeload', me.onStoreBeforeLoad.bind(me));
            store.on('load', me.onStoreLoad);
        });
        this.application.on({
            maskcontent: this.onMaskContent,
            scope: this
        });
        this.application.on({
            unmaskcontent: this.onUnmaskContent,
            scope: this
        });
        this.getSkillsStore().addListener('load', this.onSkillsLoad, this);
        this.control({

            'app': {
                'afterrender': function () {
                    //this.loadUserSecurity();
                }
            },
            '[cls*=secureField]': {
              //  afterrender: this.hideOrShowFieldByPermission.bind(this)
            },
            'clickablecell':{
                'click': function (grid, cell, rowIndex, cellIndex, event, record) {
                    var dataIndex = grid.getGridColumns()[cellIndex].dataIndex;
                    
                    if (record) {
                        record[dataIndex + 'Clicked'] = true;
                    }
                }
            },
            '[cls*=navheader]': {
                click: this.onNavigationButtonClick.bind(this)
            },
            'datefield[cls*=minfield]': {
                change: function(field, newMinValue) {
                    var maxFieldName = field.maxField;
                    if (!maxFieldName) {
                        return;
                    }
                    var maxField = Ext.ComponentQuery.query('datefield[name=' + maxFieldName + ']')[0];
                    if (Ext.isDate(newMinValue)) {

                        if (maxField) {

                            maxField.setMinValue(newMinValue);
                        }
                    } else {
                        maxField.setMinValue(null);
                    }
                }
            },
            'datefield[cls*=maxfield]': {
                change: function(field, newMaxValue) {
                    var minFieldName = field.minField;
                    if (!minFieldName) {
                        return;
                    }
                    var minField = Ext.ComponentQuery.query('datefield[name=' + minFieldName + ']')[0];
                    if (Ext.isDate(newMaxValue)) {

                        if (minField) {
                            minField.setMaxValue(newMaxValue);
                        }
                    } else {
                        minField.setMaxValue(null);
                    }
                }
            },
            'numberfield[cls*=minfield]': {
                change: function(field, newMinValue) {
                    var maxFieldName = field.maxField;
                    if (!maxFieldName) {
                        return;
                    }
                    var maxField = Ext.ComponentQuery.query('numberfield[name=' + maxFieldName + ']')[0];
                    if (Ext.isNumeric(newMinValue)) {

                        if (maxField) {
                            maxField.setMinValue(newMinValue);
                        }
                    } else {
                        maxField.setMinValue(null);
                    }
                }
            },
            'numberfield[cls*=maxfield]': {
                change: function(field, newMaxValue) {
                    var minFieldName = field.minField;
                    if (!minFieldName) {
                        return;
                    }
                    var minField = Ext.ComponentQuery.query('numberfield[name=' + minFieldName + ']')[0];
                    if (Ext.isNumeric(newMaxValue)) {

                        if (minField) {
                            minField.setMaxValue(newMaxValue);
                        }
                    } else {
                        minField.setMaxValue(null);
                    }
                }
            }
        });
    },
    onMaskContent: function() {
        var mainContent = this.getMainContent();
        mainContent.setLoading(true);
    },
    onUnmaskContent: function() {
        var mainContent = this.getMainContent();
        mainContent.setLoading(false);
    },
//ToDo revist security and implement by user
    loadUserSecurity: function() {
        var userSecurityStore = this.getUserSecurityStore();
        userSecurityStore.load({
            callback: this.enforceSecurity.bind(this)
        });
    },
    enforceSecurity: function(){
        var secureFields = Ext.ComponentQuery.query('[cls*=secureField]');
        for (var i = 0, length = secureFields.length; i < length; i++) {
            this.hideOrShowFieldByPermission(secureFields[i]);

        }
    },
    hideOrShowField: function(field, show) {
        if (show) {
            field.show();
        } else {
            field.hide();
        }
    },
    hideOrShowFieldByPermission: function (secureField) {
        if (secureField.permission) {
            var allowed = this.application.getPermission(secureField.permission);
            this.hideOrShowField(secureField, allowed);
        }
    },
    onNavigationButtonClick: function (button) {
        if (button.navigationView) {
            var navigationPanel = this.getNavigationContent();
            navigationPanel.removeAll(true);
            navigationPanel.add({ xtype: button.navigationView });
        }
        if (button.view) {
            Ext.each(this.getWestContent().items.items, function (item) {
                if(button.up().getItemId() !== item.getItemId())
                {item.collapse();}
            });
            this.application.getMainContent().setTitle(button.title);
            this.application.changeContent(button.view, button.config);
        }

    },
    onStoreBeforeLoad: function (store, operation) {
        this.abortCurrentRequest(store);
        store.lastLoadOperation = operation;
    },
    onStoreLoad: function(store) {
        store.lastLoadOperation = null;
    },
    abortCurrentRequest:function(store) {
        if (store.loading && store.lastLoadOperation) {
            var requests = Ext.Ajax.requests;
            for (var request in requests) {
                if (requests.hasOwnProperty(request) && requests[request].options == store.lastLoadOperation.request) {
                    Ext.Ajax.abort(requests[request]);
                }
            }
        }
    },
    onSkillsLoad: function (store, records, successful) {
        var me = this;
        if (successful) {
            $.each(records, function() {
                switch (this.data.type) {
                    case "Granted Chart":
                        var newGrantedChart = Ext.create('NexChar.FrontEnd.view.character.SkillChart',
                        {
                            title: this.data.name,
                            id: this.data.skillKey
                        });

                        me.getCharacterPanel().add(newGrantedChart);
                        break;
                    //case "HiddenPrereq":
                    //    $("#hiddenprereqlist").append('<option class="dropdown-item"  data-toggle="tooltip" data-placement="bottom" title="' + this.description + '">' + this.name + '</option>');
                    //    break;
                    //case "Logistics Entry":
                    //    $("#logisticsentrylist").append('<option class="dropdown-item"  data-toggle="tooltip" data-placement="bottom" title="' + this.description + '">' + this.name + '</option>');
                    //    break;
                    case "Purchased Chart":
                        var newPurchasedChart = Ext.create('NexChar.FrontEnd.view.character.SkillChart',
                        {
                            title: this.data.name +' '+ this.data.rank,
                            id: this.data.skillKey
                        });

                        if (Ext.getCmp(this.data.name)) {
                            Ext.getCmp(this.data.name).add(newPurchasedChart);
                        } else {
                            me.getCharacterPanel().add(Ext.create('NexChar.FrontEnd.view.character.CharacterPanel',
                            {
                                title: this.data.name,
                                id: this.data.name
                            })).add(newPurchasedChart);
                        }

                        break;
                    //case "Race":
                    //    $("#raceslist").append('<option class="dropdown-item"  data-toggle="tooltip" data-placement="bottom" title="' + this.description + '">' + this.name + '</option>');
                    //    break;
                    default:
                }

            });
        }

        me.getCharacterPanel().doLayout();
        $.each(records, function () {
            switch (this.data.type) {
                case "ChartSkill":
                    var newSkill = Ext.create('Ext.form.field.Checkbox',
                    {
                        id: this.data.skillKey
                    });
                    if (Ext.getCmp(this.data.chart) && Ext.getCmp(this.data.name + this.data.chart)) {
                        Ext.getCmp(this.data.name + this.data.chart).add(newSkill);
                    } else if (Ext.getCmp(this.data.chart) && !Ext.getCmp(this.data.name + this.data.chart)) {
                        Ext.getCmp(this.data.chart).add(Ext.create('Ext.form.CheckboxGroup',
                        {
                            fieldLabel: this.data.name,
                            labelWidth: 200,
                            id: this.data.name + this.data.chart,
                            width: '100%',
                            columnWidth: 15,
                            columns: 40,
                            height: 40,
                            padding: 0,
                            border: 1
                        }));
                        Ext.getCmp(this.data.name + this.data.chart).add(newSkill);
                    } else {
                        alert(this.data.skillKey + ' is missing a chart value ');
                    }
                
                    break;
                default:
            }
        });
        me.getCharacterPanel().doLayout();
    }
});