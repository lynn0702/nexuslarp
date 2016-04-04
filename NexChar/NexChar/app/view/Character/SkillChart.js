Ext.define('NexChar.FrontEnd.view.character.SkillChart', {
    extend: 'Ext.form.Panel',
    alias: 'widget.skillchart',
    layout: {
        type: 'vbox'
    },
    defaults: {
        labelWidth: 200,
        padding: 1
    },
    flex: 1,
    collapsible: true,
    collapsed: true,
    animCollapse: false,
    titleCollapse: true,
    listeners: {
        beforeexpand: {
            fn: function(){ this.doLayout()}
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