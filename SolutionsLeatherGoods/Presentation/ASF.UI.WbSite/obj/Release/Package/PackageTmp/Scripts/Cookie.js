$(function () {
    //tomado de w3schools
    var cartId = getCookie("cartCookie");
    if (cartId != "") {
        //leo la cookie y cargo el carrito con ese id
        // acá debo cargar el carrito correspondiente
        $('#cartAnchor').attr("href", "/Carts/Cart/Details/" + cartId);
        alert("Welcome again " + cartId);
        //getCart(cartId);
    } else {
        // obtengo el id del carrito que deseo guardar en la cookie desde la base
        cartId = getCartId();
    }


    function setCookie(cname, cvalue, exdays) {
        var d = new Date();
        d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
        var expires = "expires=" + d.toString();
        document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
    }

    function getCookie(cname) {
        var name = cname + "=";
        var decodedCookie = decodeURIComponent(document.cookie);
        var ca = decodedCookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == ' ') {
                c = c.substring(1);
            }
            if (c.indexOf(name) == 0) {
                return c.substring(name.length, c.length);
            }
        }
        return "";
    }

    function getCartId() {
        $.ajax({
            type: "POST",
            url: "/Carts/Cart/getCartId",
            dataType: "Json",
            success: function (cvalue) { //cvalue contiene el id del carrito nuevo
                if (cvalue != "" && cvalue != null) {
                    setCookie("cartCookie", cvalue, 1);
                }
                $('#cartAnchor').attr("href", "/Carts/Cart/Details/" + cvalue);
                alert("Nuevo carrito con id: " + cvalue);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert("Falló al cargar el carrito con id: " + cvalue);
            }
        });
    }

    function getCart(id) {
        $.ajax({
            type: "POST",
            url: "/Carts/Cart/getCart",
            data:{id: id},
            dataType: "Json",
            success: function (id) { //id contiene el id del carrito guardado  la última vez que se visitó la página
                alert("Recuperé el carrito con id: "+id);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert("Falló al cargar el carrito con id: " + id);
            }
        });
    }

});