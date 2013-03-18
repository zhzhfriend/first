/// <reference path="jquery-1.5.1-vsdoc.js" />
$(document).ready(function () {
    $('input, select, textarea').focus(function () {
        $(this).toggleClass('focus');
    });
    $('input, select, textarea').blur(function () {
        $(this).toggleClass('focus');
    });
});