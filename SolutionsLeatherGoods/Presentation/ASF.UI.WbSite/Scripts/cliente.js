$(function () {
    $('#cliente').load("/clients/client/getClient/?aspnetuser=" + $('#user').val());
});