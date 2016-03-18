Ext.define('NexChar.FrontEnd.view.character.Search', {
    extend: 'Ext.form.Panel',
    alias: 'widget.charactersearch',
    title: 'Search Characters',
    layout: {
        type: 'vbox'
    },
    defaults: {
        labelWidth: 110,
        padding: 1
    },
    collapsible: true,
    collapsed: true,
    animCollapse: false,

    fbar: [{

            type: 'button',
            margin: 2,
            name: 'searchCharacter',
            text: 'Search',
            flex: 0
        }, {
            type: 'button',
            margin: 2,

            name: 'resetCharacter',
            text: 'Reset',
            flex: 0
        },
    { xtype: 'component', flex: 1 }],
    initComponent: function () {
        Ext.apply(this, {
                items: [
                    {
                        fieldLabel: 'Character Name',
                        name: 'characterName',
                        cls: 'searchfield',
                        xtype: 'textfield',
                        listeners: {
                            afterrender: function (field) {
                                field.focus();
                            }
                        }
                    }, {
                        fieldLabel: 'Player Name',
                        xtype: 'textfield',
                        name: 'w9Name',
                        cls: 'searchfield'
                    }, {
                        fieldLabel: 'Event',
                        xtype: 'textfield',
                        name: 'eventSearch',
                        cls: 'searchfield'
                    }
                ]
            }
        );
        this.callParent(arguments);
    }
});