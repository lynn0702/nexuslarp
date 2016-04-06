Ext.define('NexChar.FrontEnd.view.character.CharacterSummary', {
    extend: 'Ext.form.Panel',
    alias: 'widget.charactersummary',
    titleCollapse: true,
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
            items: [

            ]
        }
        );
        this.callParent(arguments);
    }
});