(function() {
    var textArray = new Array();

    function getText(element, depth=256) {
	    if (element == "" || typeof(element) == "undefined" || depth < 0)
		    return -1;	
	depth--;
	
	if (element.nodeType == 3 && element.nodeValue != "\n")
		textArray.push(element.nodeValue);	
	
	for (var nodes = element.childNodes, i=0; i<nodes.length; i++)
		getText(nodes[i], depth);

        return textArray;
    }
})();
