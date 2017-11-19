//obtiene los clientes para el autocomplete
$('#CustomerName')
    .autocomplete({
        autoSelect: true,
        autoFocus: true,
        minLength: 3,
        source: function (request, response) {
            $.ajax({
                url: '/Orders/Order/GetClients',
                datatype: 'json',
                data: { Areas: 'Orders', term: request.term },
                success: function (data) {
                    response($.map(data,
                        function (item) {
                            return {
                                value: item.LastName + ', ' + item.FirstName,
                                Id: item.Id
                            };
                        }));
                },
                messages: {
                    noResults: "", results: ""
                }
            });
        },
        select: function (event, ui) {
            $('#ClientId').val(ui.item.Id);
        }
    });