
Ext.view.NodeCache.override({
    insert: function (insertPoint, nodes) {
        var me = this,
            elements = me.elements,
            i,
            nodeCount = nodes.length;

        var width = me.getWidth(elements);
        if (me.count) {


            if (insertPoint < me.count) {
                for (i = me.endIndex + nodeCount; i >= insertPoint + nodeCount; i--) {
                    elements[i] = elements[i - nodeCount];
                    elements[i].setAttribute('data-recordIndex', i);
                }
            }
            me.endIndex = me.endIndex + nodeCount;
        }

        else {
            me.startIndex = insertPoint;
            me.endIndex = insertPoint + nodeCount - 1;
        }


        for (i = 0; i < nodeCount; i++, insertPoint++) {
            var tables = nodes[i].getElementsByTagName('table');
            if (tables && tables.length > 0) {
                tables[0].style.width = width + 'px';
            }
            elements[insertPoint] = nodes[i];
            elements[insertPoint].setAttribute('data-recordIndex', insertPoint);
        }
        me.count += nodeCount;
    },




    getWidth: function (elements) {
        var width = 0;
        if (elements) {
            for (var element in elements) {
                width = elements[element].clientWidth;
                break;
            }

        }
        return width;
    },



    scroll: function (newRecords, direction, removeCount) {
        var me = this,
            elements = me.elements,
            recCount = newRecords.length,
            i, el, removeEnd,
            newNodes,
            nodeContainer = me.view.getNodeContainer(),
            frag = document.createDocumentFragment();
        var width = me.getWidth(elements);

        if (direction == -1) {
            for (i = (me.endIndex - removeCount) + 1; i <= me.endIndex; i++) {
                el = elements[i];
                delete elements[i];
                el.parentNode.removeChild(el);
            }
            me.endIndex -= removeCount;


            newNodes = me.view.bufferRender(newRecords, me.startIndex -= recCount);
            for (i = 0; i < recCount; i++) {
                elements[me.startIndex + i] = newNodes[i];
                var tables = newNodes[i].getElementsByTagName('table');
                if (tables && tables.length > 0) {
                    tables[0].style.width = width + 'px';
                }
                frag.appendChild(newNodes[i]);
            }
            nodeContainer.insertBefore(frag, nodeContainer.firstChild);
        }


        else {
            removeEnd = me.startIndex + removeCount;
            for (i = me.startIndex; i < removeEnd; i++) {
                el = elements[i];
                delete elements[i];
                el.parentNode.removeChild(el);
            }
            me.startIndex = i;


            newNodes = me.view.bufferRender(newRecords, me.endIndex + 1);
            for (i = 0; i < recCount; i++) {
                elements[me.endIndex += 1] = newNodes[i];
                var tables = newNodes[i].getElementsByTagName('table');
                if (tables && tables.length > 0) {
                    tables[0].style.width = width + 'px';
                }
                frag.appendChild(newNodes[i]);
            }
            nodeContainer.appendChild(frag);
        }

        me.count = me.endIndex - me.startIndex + 1;
    }
});
