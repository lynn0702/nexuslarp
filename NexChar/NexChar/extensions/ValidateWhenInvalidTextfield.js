Ext.define('Ext.ux.ValidateWhenInvalidTextfield',  {
    extend: 'Ext.form.field.Text',
    alias: 'widget.validatewheninvalidtextfield',
    onChange: function (newVal, oldVal) {
        if (this.validateOnChange || this.valid===false) {
            this.validate();
        } else

            this.checkDirty();
    },
    
    validate: function () {
        var me = this,
            isValid = me.isValid();
        if (isValid !== me.wasValid) {
            me.wasValid = isValid;
            me.fireEvent('validitychange', me, isValid);
        }
        this.valid = isValid;
        return isValid;
    }
});