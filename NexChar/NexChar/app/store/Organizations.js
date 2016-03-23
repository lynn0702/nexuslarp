Ext.define('NexChar.FrontEnd.store.Organizations', {
    extend: 'Ext.data.Store',
    autoLoad: false,
    requires: 'NexChar.FrontEnd.model.Organization',
    model: 'NexChar.FrontEnd.model.Organization'
});