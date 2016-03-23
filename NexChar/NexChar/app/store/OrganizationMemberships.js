Ext.define('NexChar.FrontEnd.store.OrganizationMemberships', {
    extend: 'Ext.data.Store',
    autoLoad: false,
    requires: 'NexChar.FrontEnd.model.OrganizationMembership',
    model: 'NexChar.FrontEnd.model.OrganizationMembership'
});