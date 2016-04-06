Ext.define('NexChar.FrontEnd.view.character.CharacterPanel', {
    extend: 'Ext.form.Panel',
    alias: 'widget.characterpanel',
    titleCollapse: true,
    layout: {
        type: 'accordion',
        align: 'stretch',
        titleCollapse: true,
        animate: false
    },
    width: '100%',
    padding: 1,
    border: 1
    , listeners: {
        beforeexpand: {
            fn: function () { this.doLayout() }
        }
    },
    initComponent: function () {
        Ext.apply(this, {
                //items: [
                //    {
                //        xtype: 'skillchart',
                //        id: 'characterSummary',
                //        title: 'Character Summary',
                //        items: [
                //            {
                //                fieldLabel: 'Character Name',
                //                name: 'characterName',
                //                xtype: 'textfield'
                //            }, {
                //                fieldLabel: 'Player Name',
                //                xtype: 'textfield',
                //                name: 'playerName'
                //            },
                //            {
                //                fieldLabel: 'Vault',
                //                xtype: 'textfield',
                //                name: 'vaultKey'
                //            }
                //        ]
                //    }
                //]
            }
        );
      //  this.doLayout();
        this.callParent(arguments);
    }
});