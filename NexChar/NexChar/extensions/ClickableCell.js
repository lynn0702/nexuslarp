Ext.define('Ext.ux.ClicakableCellColumn', {
    extend: 'Ext.grid.column.Column',
    alias: 'widget.clickablecell',
    tdCls: 'clickableCell',


    initComponent: function() {
        var me = this,
            renderer,
            listeners;

        if (me.header != null) {
            me.text = me.header;
            me.header = null;
        }

        if (!me.triStateSort) {
            me.possibleSortStates.length = 2;
        }

        // A group header; It contains items which are themselves Headers
        if (me.columns != null) {
            me.isGroupHeader = true;

            //<debug>
            if (me.dataIndex) {
                Ext.Error.raise('Ext.grid.column.Column: Group header may not accept a dataIndex');
            }
            if ((me.width && me.width !== Ext.grid.header.Container.prototype.defaultWidth) || me.flex) {
                Ext.Error.raise('Ext.grid.column.Column: Group header does not support setting explicit widths or flexs. The group header width is calculated by the sum of its children.');
            }
            //</debug>

            // The headers become child items
            me.items = me.columns;
            me.columns = me.flex = me.width = null;
            me.cls = (me.cls||'') + ' ' + me.groupHeaderCls;

            // A group cannot be sorted, or resized - it shrinkwraps its children
            me.sortable = me.resizable = false;
            me.align = 'center';
        } else {
            // Flexed Headers need to have a minWidth defined so that they can never be squeezed out of existence by the
            // HeaderContainer's specialized Box layout, the ColumnLayout. The ColumnLayout's overridden calculateChildboxes
            // method extends the available layout space to accommodate the "desiredWidth" of all the columns.
            if (me.flex) {
                me.minWidth = me.minWidth || Ext.grid.plugin.HeaderResizer.prototype.minColWidth;
            }
        }
        me.addCls(Ext.baseCSSPrefix + 'column-header-align-' + me.align);

        renderer = me.renderer;
        if (renderer) {
            // When specifying a renderer as a string, it always resolves
            // to Ext.util.Format
            if (typeof renderer == 'string') {
                me.customRenderer = Ext.util.Format[renderer];
            } else {
                me.customRenderer = renderer;
            }
            me.hasCustomRenderer = true;
        } 
            me.scope = me;
            me.renderer = me.defaultRenderer;
        

        // Initialize as a HeaderContainer
        me.callParent(arguments);

        listeners = {
            element:        me.clickTargetName,
            click:          me.onTitleElClick,
            contextmenu:    me.onTitleElContextMenu,
            mouseenter:     me.onTitleMouseOver,
            mouseleave:     me.onTitleMouseOut,
            scope:          me
        };
        if (me.resizable) {
            listeners.dblclick = me.onTitleElDblClick;
        }
        me.on(listeners);
    },


    defaultRenderer: function (value, metaData, record, rowIndex, colIndex) {
        if (this.customRenderer) {
            value = this.customRenderer.apply(this, arguments);
        }
        var name = metaData.column.dataIndex;
        if (record && record[name + 'Clicked']) {
            metaData.tdCls += ' visitedCell';
        }
        return value;
    }
});