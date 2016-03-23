Ext.define('NexChar.FrontEnd.model.Organization', {
    extend: 'Ext.data.Model',
    proxy: {
        type: 'ajax',
        url: '/api/organization',
        reader: {
            type: 'json'
        },
        limitParam: false,
        pageParam: false,
        startParam: false
    },
    fields: [
       "name"
, "tier"
, "abbreviation"
,"type"
    ],
    idProperty: 'name'
});
