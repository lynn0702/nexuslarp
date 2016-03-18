Ext.define('NexChar.FrontEnd.view.character.SearchResults', {
    extend: 'Ext.grid.Panel',
    border: 0,
    alias: 'widget.charactersearchresults',
    store: 'CharacterSearches',
    title: '1099 Search Results',
    hideCollapseTool: true,
    forceFit: true,
    plugins: [
    {
        ptype: 'bufferedrenderer',
        synchronousRender: true
    }],
    initComponent: function () {
        var me = this;
        this.dockedItems = [
        {
               padding: '10 10 0 4',
               dock: 'top',
               weight: -2,
               xtype: 'resultcountdisplay',
               name: 'characterResultCounts',
               labelWidth: 45,
               value: 0
           }
           ];

        this.fbar = {
            items: [
            {
                xtype: 'button',
                margin: 1,
                name: 'createCharacter',
                text: 'Create',
                flex: 0,
                hidden: false,
                cls: 'secureField createForm',
                permission: 'CreateCharacters'
            },
            { xtype: 'component', flex: 1 }],
            weight: -2,
            dock: 'bottom'
        };

        this.columns = [
            { header: 'Character Name', dataIndex: 'characterName', xtype: 'clickablecell', name: 'characterSearchLink' },
            {
                header: 'Player Name',
                dataIndex: 'playerName'
            },
            {
                header: 'E-Mail',
                dataIndex: 'email'
            }, {
                header: 'Vault',
                dataIndex: 'vaultKey',
                name: 'vaultLink',
                xtype: 'clickablecell',
                renderer: this.renderVault,
                width: 55
            }
        ];

        this.callParent(arguments);
    },
    renderProperty: function (object, property) {
        if (object) {
            return (object[property]);
        }
        return;
    },
    renderVault: function (type, metadata, record) {
        if (record.get('vaultKey') == '') {
            return '';
        }
        return 'Open';
    }
});