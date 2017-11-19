/*Calcular el subtotal de cada línea*/
function calcular(i) {
    var cantidad = $("#quantity" + i).val()
    var precio = $("#price" + i).val();

    var subtotal = Number(cantidad) * Number(precio);

    document.getElementById("subtotal" + i).value = parseFloat(subtotal);
    document.getElementById("btnsubmit").disabled = false;
}