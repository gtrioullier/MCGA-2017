$('a').click(function () {
    $('#carusel').load("products/product/fillcarusel/?categoria=" + this.id);

    $('.carousel .item').each(function () {
        var next = $(this).next();
        if (!next.length) {
            next = $(this).siblings(':first');
        }
        next.children(':first-child').clone().appendTo($(this));
        if (next.next().length > 0) {
            next.next().children(':first-child').clone().appendTo($(this));
        }
        else {
            $(this).siblings(':fisrt').children(':first-child').clone().appendTo($(this));
        }
    });

    $('#myCarousel').on('slid', '', checkitem);

    $(document).ready(function () {
        checkitem();
    });

    function checkitem() {
        var $this = $('#myCarousel');
        if ($('carousel-inner .item:first').hasClass('active')) {
            $this.children('.left.carousel-control').hide();
        }
        else {
            $this.children('.carousel-control').show();
        }
    };

});