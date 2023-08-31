//Alýþveriþ iþlemleri jquery
$(document).ready(function () {
    $('#startShopping').click(function () {
        $('#startShopping').hide();
        $('#endShopping').show();
        $('#addPruductNav').hide();
        $('#removeProduct').hide();
        $('#addProduct').hide();
        $('#bought').show();
        $('#afterShopping').show();
        $('#beforeShopping').hide();

    });
});

$(document).ready(function () {
    $('#endShopping').click(function () {
        $('#endShopping').hide();
        $('#startShopping').show();
        $('#addPruductNav').show();
        $('#removeProduct').show();
        $('#addProduct').show();
        $('#bought').hide();
        $('#afterShopping').hide();
        $('#beforeShopping').show();
    });
});
