Ext.define('NexChar.FrontEnd.view.ResultCountDisplay', {
    extend: 'Ext.form.field.Display',
    alias: 'widget.resultcountdisplay',
    fieldLabel: 'Results',
    labelWidth: 45,
    value: '0',
    store: null,
    defaultNothingFoundValue: 'none found',
    renderer: function (value) {
        if (Ext.isNumber(value)) {
            return Ext.util.Format.number(value, '0,000');
        }
        return value;
    },
    listeners: {
        'afterrender': function(me) {
            me.mon(me.getStore(), 'datachanged', me.onStoreDataChanged.bind(me));
            me.mon(me.getStore(), 'clear', me.onStoreClear.bind(me));
            me.setCount('0');
        }
    },
    initComponent: function () {
        this.callParent(arguments);
    },
    onStoreDataChanged: function () {
        this.setCount();
    },
    onStoreClear: function () {
        this.setValue('0');
    },
    setCount: function(nothingFoundValue) {
        var store = this.getStore();
        
        if (!store) {
            return;
        }
        var count = store.getCount();

        var message = this.defaultNothingFoundValue;
        if (nothingFoundValue != null) {
            message = nothingFoundValue;
        }

        if (count > 0) {
            message = count.toString();
        }
        
        this.setValue(message);
    },

    getStore: function () {
        if (!this.store) {
            if (this.ownerCt && this.ownerCt.getStore && this.ownerCt.getStore()) {
                this.store = this.ownerCt.getStore();
            } 
        }
        return this.store;
    }
});