/*Calcular el gran total del carrito*/
$(function () {
    var i = $('#count').val();
    var total = 0;
    for (var j = 0; j < i ; j++) {
        total = parseFloat(total) + parseFloat($('#subtotal' + j).val());
    }
    document.getElementById("total").value = "$ " + total;

    if (i == 0) {
        $('#BuyBtn').hide();
    } else {
        $('#BuyBtn').show();
    }
});