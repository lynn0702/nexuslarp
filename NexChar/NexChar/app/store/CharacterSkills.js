Ext.define('NexChar.FrontEnd.store.CharacterSkills', {
    extend: 'Ext.data.Store',
    autoLoad: false,
    requires: 'NexChar.FrontEnd.model.CharacterSkill',
    model: 'NexChar.FrontEnd.model.CharacterSkill'
});