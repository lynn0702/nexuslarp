Ext.define('Ext.ux.ConfigurableCheckedValueCheckColumn', {
    extend: 'Ext.grid.column.CheckColumn',
    alias: 'widget.configurablecheckedvaluecheckcolumn',
    checkedValue: true,

    renderer: function(value, meta) {
        var cssPrefix = Ext.baseCSSPrefix,
            cls = [cssPrefix + 'grid-checkcolumn'];

        if (this.disabled) {
            meta.tdCls += ' ' + this.disabledCls;
        }
        if (value == this.checkedValue) {
            cls.push(cssPrefix + 'grid-checkcolumn-checked');
        }
        return '<img class="' + cls.join(' ') + '" src="' + Ext.BLANK_IMAGE_URL + '"/>';
    }
});