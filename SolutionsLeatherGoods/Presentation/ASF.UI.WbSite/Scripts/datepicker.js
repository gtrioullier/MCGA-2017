//Proporiona un calendario para elegir una fecha
$('#OrderDate').datepicker(
    {
        //dateFormat: "dd/mm/yy",
        dateFormat: 'yy-mm-dd',
        numberOfMonths: 1,
        dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sa'],
        monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo',
            'Junio', 'Julio', 'Agosto', 'Septiembre',
            'Octubre', 'Noviembre', 'Diciembre']
    }).val('');