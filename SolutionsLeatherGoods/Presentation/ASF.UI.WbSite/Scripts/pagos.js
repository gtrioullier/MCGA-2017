new Card({
    form: document.getElementById('form'),
    container: '.card-wrapper'
});


$('#Importe').keypress(function (e) {
    if (e.which != 46 && e.which != -1 && (e.which < 48 || e.which > 57)) 
    {
        return false;
    }
});

$('#name').keypress(function (e) {
    if ((e.which < 65 || e.which > 90) && (e.which < 97 || e.which > 122) && e.which != 32 &&  (e.which < 192 || e.which > 253)) {
        return false;
    }
});