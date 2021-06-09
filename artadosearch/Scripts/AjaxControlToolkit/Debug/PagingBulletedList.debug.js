Type.registerNamespace('Sys.Extended.UI');

Sys.Extended.UI.PagingBulletedListBehavior = function(element) {
    // The PagingBulletedListBehavior provides sorting and paging of a bulleted list
    // "element" - DOM element the behavior is associated with
    Sys.Extended.UI.PagingBulletedListBehavior.initializeBase(this, [element]);

    this._indexSizeValue = 1;
    this._separatorValue = ' - ';

    //From Server Componant
    this._heightValue = null;
    this._maxItemPerPage = null;
    this._clientSortValue = false;
    this._selectIndexCssClassValue = null;
    this._unselectIndexCssClassValue = null;

    // Local
    this._tabValue = new Array();
    this._tabValueObject = new Array();
    this._tabIndex = new Array();
    this._divContent = null;
    this._divContentIndex = null;
    this._divContentUl = null;
    this._prevIndexSelected = null;
    this._indexSelected = 0;

    // Event
    this._clickIndex = null;
}

Sys.Extended.UI.PagingBulletedListBehavior.prototype = {

    initialize: function() {
        Sys.Extended.UI.PagingBulletedListBehavior.callBaseMethod(this, 'initialize');

        // ClientState
        var clientState = this.get_ClientState();
        if(clientState) {
            var stateItems = clientState.split(";");

            if(stateItems.length) {
                this._indexSelected = stateItems[0];

                if(stateItems[1] == "null")
                    this._indexSizeValue = null;
                else
                    this._indexSizeValue = stateItems[1];

                if(stateItems[2] == "null")
                    this._maxItemPerPage = null;
                else
                    this._maxItemPerPage = stateItems[2];

                if(stateItems[3] == "true")
                    this._clientSortValue = true;
                else
                    this._clientSortValue = false;
            }
        }

        var e = this.get_element();
        // Div content
        this._divContent = document.createElement('div');
        // Insert div
        e.parentNode.insertBefore(this._divContent, e);

        var liElements = e.childNodes;

        // Create the OnClick Index
        this._clickIndex = Function.createDelegate(this, this._onIndexClick);

        var inner, index;

        this._divContentIndex = document.createElement('DIV');
        this._divContentIndex.style.marginBottom = '5px';
        this._divContent.appendChild(this._divContentIndex);

        // Extract LI elements in _tabValueObject
        for(var i = 0 ; i < liElements.length; i++) {
            if(liElements[i].nodeName == 'LI') {
                if((liElements[i].firstChild) && (liElements[i].firstChild.innerHTML))
                    inner = liElements[i].firstChild.innerHTML;
                else
                    inner = liElements[i].innerHTML;

                this._tabValueObject[this._tabValueObject.length] = { text: inner, obj: liElements[i], index: i };
            }
        }

        // Sort if need
        if(this._clientSortValue)
            this._tabValueObject.sort(this.liElementSortText);

        // Generate Index and dispatch in TabIndex and TabValue
        this._generateIndexAndTabForView();

        // Remove LI
        this._removeChilds(e.childNodes);

        // Add DIV for Index
        this._divContentUl = document.createElement('DIV');

        //Height of DivContent
        this._changeHeightDivContent();

        //Re-insert LI
        this._divContentUl.appendChild(e);
        this._divContent.appendChild(this._divContentUl);

        this._updateIndexAndView(this._indexSelected);
    },

    _changeHeightDivContent: function() {
        // Change the height of the list
        if(this._heightValue) {
            this._divContentUl.style.overflow = 'scroll';
            this._divContentUl.style.height = (this._heightValue) + 'px';
        } else {
            this._divContentUl.style.overflow = '';
            this._divContentUl.style.height = '';
        }
    },

    _createAHrefIndex: function(indexText, indexNumber) {
        // Create an index and display it above the list
        // "indexText" - text of the index
        // "indexNumber" - index
        // returns seperator element appended after the new index (so it can be removed later if last)
        var spanSeparator;
        var aIndex;

        // Create a for Index
        aIndex = document.createElement('a');
        aIndex.href = '';

        // Add _unSelectIndexCssClass by default
        if(this._unselectIndexCssClassValue)
            Sys.UI.DomElement.addCssClass(aIndex, this._unselectIndexCssClassValue);
        aIndex.innerHTML = indexText;
        aIndex.tag = indexNumber;

        // Attach event
        $addHandler(aIndex, 'click', this._clickIndex);

        // Save a Object in _tabIndex
        this._tabIndex[this._tabIndex.length] = aIndex;
        this._divContentIndex.appendChild(aIndex);

        // Add SPAN
        spanSeparator = document.createElement('SPAN');

        // Add FEFF carater for not delete the first or last space 
        spanSeparator.innerHTML = '\uFEFF' + this._separatorValue + '\uFEFF';
        this._divContentIndex.appendChild(spanSeparator);

        // Return Separator for remove the last one
        return spanSeparator;
    },

    liElementSortText: function(x, y) {
        // Sort function to compare two strings
        // "x" - object (of the form {text, index})
        // "y" - object (of the form {text, index})
        // returns -1 if the first is less than the second, 0 if they are equal, 1 if the first is greater than the second

        //Sort by text
        if(x.text.toLowerCase() == y.text.toLowerCase()) {
            return 0;
        } else {
            if(x.text.toLowerCase() < y.text.toLowerCase())
                return -1;
            else
                return 1;
        }
    },

    liElementSortIndex: function(x, y) {
        // Sort function to compare two indices
        // "x" - object (of the form {text, index})
        // "y" - object (of the form {text, index})
        // returns -1 if the first is less than the second, 0 if they are equal, 1 if the first is greater than the second

        //Sort by index (init order)
        return x.index - y.index;
    },

    _generateIndexAndTabForView: function() {
        // Create the indices

        this._deleteTabIndexAndTabValue();
        this._tabValue = new Array();
        this._tabIndex = new Array();
        var lastSpanSeparator;

        this._removeChilds(this._divContentIndex.childNodes);

        // Cut array _tabValueObject in _tabValue with 1 dimension per 1 index
        if(this._maxItemPerPage) {
            // If _maxItemPerPage index generation become automatique
            if(this._maxItemPerPage > 0) {
                var j = -1;

                for(var i = 0; i < this._tabValueObject.length; i++) {
                    if((i % this._maxItemPerPage) == 0) {
                        index = this._tabValueObject[i].text;
                        this._tabValue[++j] = new Array();
                        lastSpanSeparator = this._createAHrefIndex(index, j);
                    }
                    this._tabValue[j][this._tabValue[j].length] = this._tabValueObject[i].obj;
                }
            }
        } else {
            //if Generate index with _indexSizeValue
            if(this._indexSizeValue > 0) {
                var currentIndex = '';
                var j = -1;

                for(var i = 0; i < this._tabValueObject.length; i++) {
                    index = this._tabValueObject[i].text.substr(0, this._indexSizeValue).toUpperCase();

                    if(currentIndex != index) {
                        this._tabValue[++j] = new Array();
                        lastSpanSeparator = this._createAHrefIndex(index, j);
                        currentIndex = index;
                    }
                    this._tabValue[j][this._tabValue[j].length] = this._tabValueObject[i].obj;
                }
            }
        }

        //Remove last SpanSeparator
        if(lastSpanSeparator)
            this._divContentIndex.removeChild(lastSpanSeparator);
    },

    _deleteTabIndexAndTabValue: function() {
        // Delete the indices

        //Remove Event
        if(this._clickIndex) {
            for(var i = 0; i < this._tabIndex.length; i++) {
                var aIndex = this._tabIndex[i];

                if(aIndex)
                    $removeHandler(aIndex, 'click', this._clickIndex);
            }

            this._changeHandler = null;
        }

        // Delete _tabIndex
        delete this._tabIndex;

        // Delete Dimention two _tabValue[x]
        for(var i = 0; i < this._tabValue.length; i++)
            delete this._tabValue[i];

        // Delete _tabValue
        delete this._tabValue;
    },

    dispose: function() {
        this._deleteTabIndexAndTabValue();
        delete this._tabValueObject;

        Sys.Extended.UI.PagingBulletedListBehavior.callBaseMethod(this, 'dispose');
    },

    _removeChilds: function(eChilds) {
        for(var i = 0; eChilds.length; i++)
            eChilds[0].parentNode.removeChild(eChilds[0]);
    },

    _renderHtml: function(index) {
        // Display the elements for the given index
        // "index" - index
        var e = this.get_element();

        this._removeChilds(e.childNodes);
        for(var i = 0; i < this._tabValue[index].length; i++)
            e.appendChild(this._tabValue[index][i]);

        // Position scroll to top
        this._divContentUl.scrollTop = 0;
    },

    _selectIndex: function(index) {
        // Select the first index

        //Add Style Select to first Index
        if(this._tabIndex.length > 0) {
            if(this._unselectIndexCssClassValue)
                Sys.UI.DomElement.removeCssClass(this._tabIndex[index], this._unselectIndexCssClassValue);
            if(this._selectIndexCssClassValue)
                Sys.UI.DomElement.addCssClass(this._tabIndex[index], this._selectIndexCssClassValue);

            // Save previous Select Index
            this._prevIndexSelected = this._tabIndex[index];

            // Invoke IndexChange
            this.raise_indexChanged(this._tabIndex[index]);
        }
    },

    _onIndexClick: function(evt) {
        // Handle click events raised when the index is changed
        // "evt" - event info

        var e = this.get_element();

        // Get the control that raised the event
        var aIndex = evt.target;

        //Change Style for selected index
        if(this._selectIndexCssClassValue)
            Sys.UI.DomElement.removeCssClass(this._prevIndexSelected, this._selectIndexCssClassValue);
        if(this._unselectIndexCssClassValue)
            Sys.UI.DomElement.addCssClass(this._prevIndexSelected, this._unselectIndexCssClassValue);
        if(this._unselectIndexCssClassValue)
            Sys.UI.DomElement.removeCssClass(aIndex, this._unselectIndexCssClassValue);
        if(this._selectIndexCssClassValue)
            Sys.UI.DomElement.addCssClass(aIndex, this._selectIndexCssClassValue);

        // Save previous index selected
        this._prevIndexSelected = aIndex;

        // Clear
        this._renderHtml(aIndex.tag);

        // Invoke IndexChange
        this.raise_indexChanged(aIndex);

        evt.preventDefault();
    },

    /// <summary>
    /// Fires when the selected index changes
    /// </summary>
    /// <event add="add_indexChanged" remove="remove_indexChanged" raise="raise_indexChanged" />
    /// <member name="cE:AjaxControlToolkit.PagingBulletedListExtender.indexChanged" />
    add_indexChanged: function(handler) {
        this.get_events().addHandler('indexChanged', handler);
    },
    remove_indexChanged: function(handler) {
        this.get_events().removeHandler('indexChanged', handler);
    },
    raise_indexChanged: function(eventArgs) {
        // Update the selected index
        this._indexSelected = eventArgs.tag;

        var handler = this.get_events().getHandler('indexChanged');
        if(handler) {
            if(!eventArgs)
                eventArgs = Sys.EventArgs.Empty;
            handler(this, eventArgs);
        }

        this.set_ClientState(eventArgs.tag + ";" + this.get_indexSize() + ";" + this.get_maxItemPerPage() + ";" + this.get_clientSort());
    },
    raiseIndexChanged: function(eventArgs) {
        Sys.Extended.Deprecated("raiseIndexChanged(eventArgs)", "raise_indexChanged(eventArgs)");
        this.raise_indexChanged(eventArgs);
    },

    /// <summary>
    /// DOM elements of the indices
    /// </summary>
    /// <getter>get_tabIndex</getter>
    /// <member name="cP:AjaxControlToolkit.PagingBulletedListExtender.tabIndex" />
    get_tabIndex: function() {
        return this._tabIndex;
    },

    /// <summary>
    /// DOM elements of items to display for each index
    /// </summary>
    /// <getter>get_tabValue</getter>
    /// <member name="cP:AjaxControlToolkit.PagingBulletedListExtender.tabValue" />
    get_tabValue: function() {
        return this._tabValue;
    },

    _updateIndexAndView: function(index) {
        // Regenerate the tables of indices and display

        // Re-Generate TabIndex and TabValue
        this._generateIndexAndTabForView()

        // Select clientState index or default select first index
        if(this._tabIndex.length > 0) {
            if(index < this._tabIndex.length) {
                this._renderHtml(this._tabIndex[index].tag);
                this._selectIndex(index);
            } else {
                this._renderHtml(this._tabIndex[0].tag);
                this._selectIndex(0);
            }
        }
    },

    /// <summary>
    /// Bulleted list height
    /// </summary>
    /// <getter>get_height</getter>
    /// <setter>set_height</setter>
    /// <member name="cP:AjaxControlToolkit.PagingBulletedListExtender.height" />
    get_height: function() {
        return this._heightValue;
    },
    set_height: function(value) {
        if(this._heightValue != value) {
            this._heightValue = value;

            if(this.get_isInitialized())
                // Change Height in the DOM
                this._changeHeightDivContent();

            this.raisePropertyChanged('height');
        }
    },

    get_Height: function() {
        Sys.Extended.Deprecated("get_Height()", "get_height()");
        return this.get_height();
    },
    set_Height: function(value) {
        Sys.Extended.Deprecated("set_Height(value)", "set_height(value)");
        this.set_height(value);
    },

    /// <summary>
    /// The number of characters in the index headings (ignored if MaxItemPerPage is set)
    /// </summary>
    /// <getter>get_indexSize</getter>
    /// <setter>set_indexSize</setter>
    /// <member name="cP:AjaxControlToolkit.PagingBulletedListExtender.indexSize" />
    get_indexSize: function() {
        return this._indexSizeValue;
    },
    set_indexSize: function(value) {
        if(this._indexSizeValue != value) {
            // Clear ClientState to set 0 index
            this.set_ClientState("0;" + value + ";" + this.get_maxItemPerPage() + ";" + this.get_clientSort());

            this._indexSizeValue = value;
            if(this.get_isInitialized())
                //Update TabIndex and TabValue and Select first Index
                this._updateIndexAndView(0);

            this.raisePropertyChanged('indexSize');
        }
    },

    get_IndexSize: function() {
        Sys.Extended.Deprecated("get_IndexSize()", "get_indexSize()");
        return this.get_indexSize();
    },
    set_IndexSize: function(value) {
        Sys.Extended.Deprecated("set_IndexSize(value)", "set_indexSize(value)");
        this.set_indexSize(value);
    },

    /// <summary>
    /// Maximum number of items per page (ignores the IndexSize property)
    /// </summary>
    /// <getter>get_maxItemPerPage</getter>
    /// <setter>set_maxItemPerPage</setter>
    /// <member name="cP:AjaxControlToolkit.PagingBulletedListExtender.maxItemPerPage" />
    get_maxItemPerPage: function() {
        return this._maxItemPerPage;
    },
    set_maxItemPerPage: function(value) {
        if(this._maxItemPerPage != value) {
            // Clear ClientState to set 0 index
            this.set_ClientState("0;" + this.get_indexSize() + ";" + value + ";" + this.get_clientSort());

            this._maxItemPerPage = value;
            if(this.get_isInitialized())
                //Update TabIndex and TabValue and Select first Index
                this._updateIndexAndView(0);

            this.raisePropertyChanged('maxItemPerPage');
        }
    },

    get_MaxItemPerPage: function() {
        Sys.Extended.Deprecated("get_MaxItemPerPage()", "get_maxItemPerPage()");
        return this.get_maxItemPerPage();
    },
    set_MaxItemPerPage: function(value) {
        Sys.Extended.Deprecated("set_MaxItemPerPage(value)", "set_maxItemPerPage(value)");
        this.set_maxItemPerPage(value);
    },

    /// <summary>
    /// Separator text to be placed between indices
    /// </summary>
    /// <getter>get_separator</getter>
    /// <setter>set_separator</setter>
    /// <member name="cP:AjaxControlToolkit.PagingBulletedListExtender.separator" />
    get_separator: function() {
        return this._separatorValue;
    },
    set_separator: function(value) {
        if(this._separatorValue != value) {
            if(value)
                this._separatorValue = value;
            else
                this._separatorValue = '';

            if(this.get_isInitialized())
                // Update TabIndex and TabValue and Select first Index
                this._updateIndexAndView(0);

            this.raisePropertyChanged('separator');
        }
    },

    get_Separator: function() {
        Sys.Extended.Deprecated("get_Separator()", "get_separator()");
        return this.get_separator();
    },
    set_Separator: function(value) {
        Sys.Extended.Deprecated("set_Separator(value)", "set_separator(value)");
        this.set_separator(value);
    },

    /// <summary>
    /// Determines whether or not items should be sorted on the client side
    /// </summary>
    /// <getter>get_clientSort</getter>
    /// <setter>set_clientSort</setter>
    /// <member name="cP:AjaxControlToolkit.PagingBulletedListExtender.clientSort" />
    get_clientSort: function() {
        return this._clientSortValue;
    },
    set_clientSort: function(value) {
        if(this._clientSortValue != value) {
            this._clientSortValue = value;

            if(this.get_isInitialized()) {
                // Clear ClientState to set 0 index
                this.set_ClientState("0;" + this.get_indexSize() + ";" + this.get_maxItemPerPage() + ";" + value);

                if(this._clientSortValue)
                    this._tabValueObject.sort(this.liElementSortText);
                else
                    this._tabValueObject.sort(this.liElementSortIndex);

                // Update TabIndex and TabValue and Select first Index
                this._updateIndexAndView(0);
            }

            this.raisePropertyChanged('clientSort');
        }
    },

    get_ClientSort: function() {
        Sys.Extended.Deprecated("get_ClientSort()", "get_clientSort()");
        return this.get_clientSort();
    },
    set_ClientSort: function(value) {
        Sys.Extended.Deprecated("set_ClientSort(value)", "set_clientSort(value)");
        this.set_clientSort(value);
    },

    /// <summary>
    /// A CSS class for the selected index
    /// </summary>
    /// <getter>get_selectIndexCssClass</getter>
    /// <setter>set_selectIndexCssClass</setter>
    /// <member name="cP:AjaxControlToolkit.PagingBulletedListExtender.selectIndexCssClass" />
    get_selectIndexCssClass: function() {
        return this._selectIndexCssClassValue;
    },
    set_selectIndexCssClass: function(value) {
        if(this._selectIndexCssClassValue != value) {
            this._selectIndexCssClassValue = value;
            this.raisePropertyChanged('selectIndexCssClass');
        }
    },

    get_SelectIndexCssClass: function() {
        Sys.Extended.Deprecated("get_SelectIndexCssClass()", "get_selectIndexCssClass()");
        return this.get_selectIndexCssClass();
    },
    set_SelectIndexCssClass: function(value) {
        Sys.Extended.Deprecated("set_SelectIndexCssClass(value)", "set_selectIndexCssClass(value)");
        this.set_selectIndexCssClass(value);
    },

    /// <summary>
    /// A CSS class for indices that aren't selected
    /// </summary>
    /// <getter>get_unselectIndexCssClass</getter>
    /// <setter>set_unselectIndexCssClass</setter>
    /// <member name="cP:AjaxControlToolkit.PagingBulletedListExtender.unselectIndexCssClass" />
    get_unselectIndexCssClass: function() {
        return this._unselectIndexCssClassValue;
    },
    set_unselectIndexCssClass: function(value) {
        if(this._unselectIndexCssClassValue != value) {
            this._unselectIndexCssClassValue = value;
            this.raisePropertyChanged('unselectIndexCssClass');
        }
    },

    get_UnselectIndexCssClass: function() {
        Sys.Extended.Deprecated("get_UnselectIndexCssClass()", "get_unselectIndexCssClass()");
        return this.get_unselectIndexCssClass();
    },
    set_UnselectIndexCssClass: function(value) {
        Sys.Extended.Deprecated("set_UnselectIndexCssClass(value)", "set_unselectIndexCssClass(value)");
        this.set_unselectIndexCssClass(value);
    }
}

Sys.Extended.UI.PagingBulletedListBehavior.registerClass('Sys.Extended.UI.PagingBulletedListBehavior', Sys.Extended.UI.BehaviorBase);