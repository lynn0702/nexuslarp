Ext.define('NexChar.FrontEnd.view.admin.Navigation', {
    extend: 'Ext.form.Panel',
    alias: 'widget.adminnavigation',
    title: 'Admin',
    layout: {
        type: 'vbox'
    },
    collapsible: false,
    collapsed: true,
    animCollapse: false,
    defaults: {
        xtype: 'panel',
        cls: 'secureField navigation',
        width: '100%',
        titleCollapse: true,
        animate: false,
        collapsible: true,
        hideCollapseTool: true
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