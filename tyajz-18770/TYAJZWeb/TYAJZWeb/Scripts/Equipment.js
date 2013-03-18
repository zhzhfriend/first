/// <reference path="jquery-1.5.1-vsdoc.js" />
$(document).ready(function () {
    $('#IsLocal').click(function () {
        if ($(this).attr('checked') == true) {
            ShowLocalItems();
        }
        else {
            ShowExternalItems();
        }
    });

    ShowLocalItems();
    $('#Eq_MadeDate').datepicker();
});

function ShowExternalItems() {
    $('.LocalItem').css('display', 'none');
    $('.ExternalItem').css('display', '');
}
function ShowLocalItems() {
    $('.LocalItem').css('display', '');
    $('.ExternalItem').css('display', 'none');
}