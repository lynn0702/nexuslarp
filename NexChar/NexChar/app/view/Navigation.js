Ext.define('NexChar.FrontEnd.view.Navigation', {
    extend: 'Ext.form.Panel',
    alias: 'widget.navigation',
    border: false,
    width: '250',
    titleCollapse: true,
    layout: {
        type: 'accordion',
        align: 'stretch',
        titleCollapse: true,
        animate: false
    },
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
                    xtype: 'charactersearch',
                    name: 'characterSearch',
                    header: {
                        cls: 'navheader',
                        view: 'characterssearchresults'
                    },
                    maintainState: true,
                    hidden: false,
                    permission: 'Logistics',
                    view: 'characterssearchresults'

                },
                 {
                     xtype: 'adminnavigation',
                     name: 'adminNavigation',
                     header: {
                         cls: 'navheader',
                         view: 'adminmanage'
                     },
                     maintainState: true,
                     hidden: false,
                     permission: 'AdminLogistics',
                     view: 'adminmanage'
                 }
            ]
        });
        this.callParent(arguments);
    }
});
