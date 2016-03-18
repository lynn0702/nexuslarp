Ext.define('NexChar.FrontEnd.controller.Character', {
    extend: 'Ext.app.Controller',
    views: [
        'character.Search',
        'character.SearchResults'
    ],
    stores: [
        'Characters'
    ],
    models: [
        'Character'
    ],
    refs: [
         {
            selector: '#mainContent',
            ref: 'mainContent'
        }, {
            selector: '#centerContent',
            ref: 'centerContent'
        }
    ],

    init: function() {
        var me = this;
        me.control({

        });
    }
  
});