$('a').click(function () {
    $('#carusel').load("products/product/fillcarusel/?categoria=" + this.id, function(){
        $('#lightSlider').lightSlider({
            slideMargin: 4
        });
    });
});