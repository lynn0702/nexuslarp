Ext.define('NexChar.FrontEnd.view.App', {
    extend: 'Ext.panel.Panel',
    alias: 'widget.app',
    layout: {
        type: 'border'
    },
    border: 1,
    initComponent: function () {
        var me = this;
        //me.loadMask = new Ext.LoadMask(this, {
        //    store: 'UserSecurity'
        //});

        Ext.apply(this, {
            items: [
                {
                    flex: 1,
                    cls: 'appTitle',
                    title:'NexusLARP - Character Builder',
                     xtype: 'navigation',
                     id:'westContent',
                     region: 'west',
                     width: '20%',
                     border: 0,
                     collapsible: true,
                     animCollapse: false,
                     layout: {
                         type: 'vbox',
                         align: 'left'
                     }
                },
             {
                 xtype: 'panel',
                 region: 'center',
                 id: 'centerContent',
                 layout: {
                     type:'fit'
                 },
                 flex: 0,
                 border: 1
             },
             {
                     xtype: 'panel',
                     id: 'mainContent',
                     region:'east',
                     layout: {
                         type:'fit'
                     },
                     titleCollapse: true,
                     collapsible: true,
                     animCollapse: false,
                     flex: 1,
                     border: 1
              }
                
            ]
        });
        this.callParent(arguments);
    }
});