Ext.define('NexChar.FrontEnd.store.Characters', {
    extend: 'Ext.data.Store',
    autoLoad: false,
    requires: 'NexChar.FrontEnd.model.Character',
    model: 'NexChar.FrontEnd.model.Character'
});