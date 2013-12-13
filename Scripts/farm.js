window.onload = function () {
    for (var ii = 0; ii < document.links.length; ii++)
        document.links[ii].onfocus = function () { this.blur() }
}

$(document).ready(function () {
    var remark = $("#lblRemark");
    if (remark.text() == "") {
        remark.parent().hide();
    }
});