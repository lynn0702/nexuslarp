Ext.define('NexChar.FrontEnd.model.OrganizationMembership', {
    extend: 'Ext.data.Model',
    proxy: {
        type: 'ajax',
        url: '/api/organizationmembership',
        reader: {
            type: 'json'
        },
        limitParam: false,
        pageParam: false,
        startParam: false
    },
    fields: [
       "id"
,"character_id"
,"organization_Name"
    ],
    idProperty: 'id'
});
