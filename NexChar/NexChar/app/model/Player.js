Ext.define('NexChar.FrontEnd.model.Player', {
    extend: 'Ext.data.Model',
    proxy: {
        type: 'ajax',
        url: '/api/player',
        reader: {
            type: 'json'
        },
        limitParam: false,
        pageParam: false,
        startParam: false
    },
    fields: [
       "id"
,"firstName"
,"lastName"
,"vaultKey"
,"workTimeBank"
,"eepTotal"
,"emailAddress"
,"displayName"
    ],
    idProperty: 'id'
});