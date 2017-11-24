$(function () {

    var model = 

    $.fn.stars = function () {
        return $(this).each(function () {
            // Get the value
            // val viene en el modelo. lo cargo desde un label.
            var str = ($('#avgStars').text())
            var res = str.replace(",", ".");
            var val = parseFloat(res);
            // Make sure that the value is in 0 - 5 range, multiply to get width
            var size = Math.max(0, (Math.min(5, val))) * 32;
            // Create stars holder
            var $span = $('<span />').width(size);
            // Replace the numerical value with stars
            $(this).html($span);
        });
    }

    $('span.stars').stars();

    $('#stars li').on('mouseover', function () {
        var onStar = parseInt($(this).data('value'), 10); // The star currently mouse on

        // Now highlight all the stars that's not after the current hovered star
        $(this).parent().children('li.star').each(function (e) {
            if (e < onStar) {
                $(this).addClass('hover');
            }
            else {
                $(this).removeClass('hover');
            }
        });

    }).on('mouseout', function () {
        $(this).parent().children('li.star').each(function (e) {
            $(this).removeClass('hover');
        });
    });

    /* 2. Action to perform on click */
    $('#stars li').on('click', function () {
        var onStar = parseInt($(this).data('value'), 10); // The star currently selected
        var stars = $(this).parent().children('li.star');

        for (i = 0; i < stars.length; i++) {
            $(stars[i]).removeClass('selected');
        }

        for (i = 0; i < onStar; i++) {
            $(stars[i]).addClass('selected');
        }

        // Rating value tiene que ir como parámetro a modificar el rating del producto tabla rating
        var ratingValue = parseInt($('#stars li.selected').last().data('value'), 10);
        //var clientId = $('#clientId').val();
        var productId = parseInt($(this).parent().children('input').val());
        $.ajax({
            url:'/Ratings/Rating/UpdateRate',
            datatype: 'json',
            data: { Areas: 'Ratings', rate: ratingValue, productId: productId },
            error: function (xhr, ajaxOptions, thrownError) {
                swal("Falló al cargar rating", ratingValue, "error");
            }
        });

        // JUST RESPONSE (Not needed)
        var msg = "";
        if (ratingValue > 1) {
            msg = "Thanks! You rated this " + ratingValue + " stars.";
        }
        else {
            msg = "We will improve ourselves. You rated this " + ratingValue + " stars.";
        }
        responseMessage(msg);
    });

    function responseMessage(msg) {
        swal(msg, "", "success");
    }
});