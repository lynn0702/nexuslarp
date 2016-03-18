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
                {
                    title: 'Manage Payer 1099s',
                    view: 'payerslist',
                    name: 'payerslist',
                    hidden: false,
                    permission: 'AdminVendor1099s',
                    header: {
                        cls: 'navheader',
                        view: 'payerslist'
                    }
                }
            ]
        }
        );
        this.callParent(arguments);
    }
});