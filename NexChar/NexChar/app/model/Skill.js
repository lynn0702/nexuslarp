Ext.define('NexChar.FrontEnd.model.Skill', {
    extend: 'Ext.data.Model',
    proxy: {
        type: 'ajax',
        url: '/api/skills/getfilteredlist',
        reader: {
            type: 'json'
        },
        limitParam: false,
        pageParam: false,
        startParam: false
    },
    fields: [
        "skillKey"
        , "name"
        , "rank"
        , "type"
        , "baseAPCost"
        , "classType"
        , "description"
        , "bgpCost"
        , "prereqs"
        , "prohibited"
        , "chart"
    ],
    idProperty: 'skillKey'
});