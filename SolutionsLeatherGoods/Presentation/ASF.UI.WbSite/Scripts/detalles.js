$('button').click(function () {
    if (this.value == "eliminarLinea") {
        //elimino el detalle deseado
        $.ajax({
            type: "POST",
            url: "/CartsItems/CartItem/removeDetail",
            dataType: "Json",
            data: { cartItemId: $('#Id' + this.id).val() },
            success: function (value) { //value contiene el mensaje 
                location.reload();
                alert(value);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert("Falló al cargar el carrito con id: ");
            }
        });
    } else if (this.value == "agregarDetalle"){
        //agrego 1 a cantidad
        $.ajax({
            type: "POST",
            url: "/CartsItems/CartItem/addItem",
            dataType: "Json",
            data: {cartItemId: $('#Id'+this.id).val()},
            success: function (value) { //value la cantidad nueva
                location.reload();
                alert("Nueva cantidad: " + value);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert("Falló al cargar el carrito con id: ");
            }
        });
    }
    else {
        //saco 1 a cantidad
        $.ajax({
            type: "POST",
            url: "/CartsItems/CartItem/removeItem",
            dataType: "Json",
            data: { cartItemId: $('#Id' + this.id).val() },
            success: function (value) { //value la cantidad nueva
                location.reload();
                alert("Nueva cantidad: " + value);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert("Falló al cargar el carrito con id: ");
            }
        });
    }
});