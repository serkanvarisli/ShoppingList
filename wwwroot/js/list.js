$(document).ready(function () {
    $("#endShopping").click(function () {
        var selectedItems = [];
        $("input[name='selectedItems']:checked").each(function () {
            selectedItems.push($(this).val());
        });

        
            $.ajax({
                url: '/Home/DeleteSelectedItems', // Silme i�lemi yap�lacak action'�n yolunu belirtin
                type: 'POST',
                data: { selectedItems: selectedItems },
                success: function (result) {
                    // Silme i�lemi ba�ar�l�ysa sayfay� yenileyebilirsiniz veya ba�ka bir i�lem yapabilirsiniz.
                },
                error: function () {
                    alert('Silme islemi siras�nda bir hata olu�tu.');
                    location.reload();

                }
            });
                    

    });

    $('#startShopping').click(function () {
        $('.beforeShopping').hide();
        $('.afterShopping').show();
        $('.removeProduct').hide();
        $('.bought').show();
        $('#endShopping').show();
        $('#startShopping').hide();
    });

    $('#endShopping').click(function () {
        $('.beforeShopping').show();
        $('.afterShopping').hide();
        $('.removeProduct').show();
        $('.bought').hide();
        $('#endShopping').hide();
        $('#startShopping').show();
    });
});
