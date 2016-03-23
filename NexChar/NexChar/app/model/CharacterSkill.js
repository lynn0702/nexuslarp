Ext.define('NexChar.FrontEnd.model.CharacterSkill', {
    extend: 'Ext.data.Model',
    proxy: {
        type: 'ajax',
        url: '/api/characterskill',
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
,"skill_SkillKey"
,"datePurchased"
,"apSpent"
,"hitPointsEarned"
    ],
    idProperty: 'id'
});