Ext.define('NexChar.FrontEnd.model.Character', {
    extend: 'Ext.data.Model',
    proxy: {
        type: 'ajax',
        url: '/api/character',
        reader: {
            type: 'json'
        },
        limitParam: false,
        pageParam: false,
        startParam: false
    },
    fields: [
        "id"
,"characterName"
,"player_ID"
,"playerDocument"
,"creationDate"
,"lastUpdate"
,"apTotal"
,"mpTotal"
,"sigTotal"
,"hitPoints"
,"chosenClass"
,"hasUsedChartDiscount"
,"hasAppliedStartingRacials"
, "organizationMembershipDocuments"
,"characterSkillDocuments"
    ],
    idProperty: 'id'
});