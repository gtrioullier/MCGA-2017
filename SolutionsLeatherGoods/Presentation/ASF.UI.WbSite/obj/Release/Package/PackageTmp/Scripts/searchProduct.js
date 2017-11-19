//obtiene los productos para el autocomplete
$('#productSearch')
    .autocomplete({
        autoSelect: true,
        autoFocus: true,
        minLength: 3,
        source: function (request, response) {
            $.ajax({
                url: '/Products/Product/GetProducts',
                datatype: 'json',
                data: { Areas: 'Products', term: request.term },
                success: function (data) {
                    response($.map(data,
                        function (item) {
                            return {
                                value: item.Description + ', $' + item.Price,
                                Rowid: item.Rowid
                            };
                        }));
                },
                messages: {
                    noResults: "", results: ""
                }
            });
        },
        select: function (event, ui) {
            //_self abre la página del producto en el mismo tab. Si sacamos _self lo abre en un nuevo tab.
            window.open("/Products/Product/Sell/" + ui.item.Rowid, "_self");
        }
    });