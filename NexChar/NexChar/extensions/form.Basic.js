Ext.form.Basic.override({
    
    loadRecord: function (record) {
        if (!record) {
            return;
        }
        this._record = record;
        if (record.getData) {
            return this.setValues(record.getData());
        } else {
            return this.setValues(record);
        }
        
    },

    setValues: function(values) {
        var me = this,
            v, vLen, val, field;

        
        function setVal(fieldId, val) {
            if (typeof val == 'object') {
                
                var form = me.owner.query('[sourceObject=' + fieldId + ']');
                if (form[0]) {
                    form[0].loadRecord(val);
                }
              
            }

            var field = me.findField(fieldId);
            if (field) {
                field.setValue(val);
                if (me.trackResetOnLoad) {
                    field.resetOriginalValue();
                }
            }
        }


        Ext.suspendLayouts();
        if (Ext.isArray(values)) {

            vLen = values.length;

            for (v = 0; v < vLen; v++) {
                val = values[v];

                setVal(val.id, val.value);
            }
        } else {

            Ext.iterate(values, setVal);
        }
        Ext.resumeLayouts(true);
        return this;
    },

    getValues: function(asString, dirtyOnly, includeEmptyText, useDataValues) {
        var values = {},
            fields = this.getFields().items,
            f,
            fLen = fields.length,
            isArray = Ext.isArray,
            field, data, val, bucket, name;

        for (f = 0; f < fLen; f++) {
            
            field = fields[f];
            if (field.ownerCt.sourceObject && field.ownerCt.sourceObject != this.owner.sourceObject) {

                continue;
            }

            if (!dirtyOnly || field.isDirty()) {
                data = field[useDataValues ? 'getModelData' : 'getSubmitData'](includeEmptyText);

                if (Ext.isObject(data)) {
                    for (name in data) {
                        if (data.hasOwnProperty(name)) {
                            val = data[name];

                            if (includeEmptyText && val === '') {
                                val = field.emptyText || '';
                            }

                            if (values.hasOwnProperty(name)) {
                                bucket = values[name];

                                if (!isArray(bucket)) {
                                    bucket = values[name] = [bucket];
                                }

                                if (isArray(val)) {
                                    values[name] = bucket.concat(val);
                                } else {
                                    bucket.push(val);
                                }
                            } else {
                                values[name] = val;
                            }
                        }
                    }
                }
            }
        }

        var forms = this.owner.query('form[sourceObject]');
        for (var form in forms) {
            var theForm = forms[form];
            values[theForm.sourceObject] = theForm.getForm().getValues();
        }

        

        if (asString) {
            values = Ext.Object.toQueryString(values);
        }
        return values;
    },

    

    updateRecord: function(record) {
        record = record || this._record;
        if (!record) {
            return this;
        }

        var values = [];
        values = this.getFieldValues();

        var obj = {};
        for (var name in record.data) {
            if (values.hasOwnProperty(name)) {
                if (record.get(name) && typeof record.get(name) == 'object') {

                    obj[name] = Ext.merge(record.get(name), (values[name]));

                } else
                {
                    obj[name] = values[name];
                }
            }
        }

        record.beginEdit();
        record.set(obj);
        record.endEdit();

        return values;
    },
    findField: function (id) {
        return this.getFields().findBy(function (f) {

            return f.id === id || f.getName() === id;
        });
    }
});

Ext.container.Monitor.override({
    onContainerAdd: function (ct, preventChildren) {

        if (ct.sourceObject) {
            preventChildren = true;
        }
        var me = this,
            items, len,
            handleAdd = me.handleAdd,
            handleRemove = me.handleRemove,
            i, comp;

        if (ct.isContainer) {
            ct.on('add', handleAdd, me);
            ct.on('dockedadd', handleAdd, me);
            ct.on('remove', handleRemove, me);
            ct.on('dockedremove', handleRemove, me);
        }

        if (preventChildren !== true) {
            items = ct.query(me.selector);
            for (i = 0, len = items.length; i < len; ++i) {
                comp = items[i];
                me.onItemAdd(comp.ownerCt, comp);
            }
        }

        items = ct.query('container');
        for (i = 0, len = items.length; i < len; ++i) {
            me.onContainerAdd(items[i], true);
        }

    }
});