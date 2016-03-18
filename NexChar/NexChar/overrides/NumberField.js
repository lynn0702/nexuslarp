Ext.override(Ext.form.NumberField, {
    setValue: function (v) {
        var dp = this.decimalPrecision;
        if (dp < 0 || !this.allowDecimals) {
            dp = 0;
        }
        v = this.fixPrecision(v);
        v = Ext.isNumber(v) ? v : parseFloat(String(v).replace(this.decimalSeparator, "."));
        v = isNaN(v) ? '' : String(v.toFixed(dp)).replace(".", this.decimalSeparator);
        return Ext.form.NumberField.superclass.setValue.call(this, v);
    }
});

Ext.override(Ext.form.field.Date, {
    invalidText: "{0} is not a valid date - it must be in the format MM/DD/YYYY"
});

Ext.override(Ext.form.field.Text, {
    regex: /^\S+/
});