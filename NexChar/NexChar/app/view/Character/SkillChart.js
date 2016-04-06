Ext.define('NexChar.FrontEnd.view.character.SkillChart', {
    extend: 'Ext.form.Panel',
    alias: 'widget.skillchart',
    layout: {
        type: 'vbox'//,
      //  align: 'stretch'
    },
    width: '100%',
    height: '100%',
    autoScroll: true,
    padding:1,
    collapsible: true,
    collapsed: true,
    animCollapse: false,
    titleCollapse: true,
    
        border: 1
    ,listeners: {
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