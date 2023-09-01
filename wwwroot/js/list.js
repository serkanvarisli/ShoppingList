$(document).ready(function () {
    $("#endShopping").click(function () {
        var selectedItems = [];
        $("input[name='selectedItems']:checked").each(function () {
            selectedItems.push($(this).val());
        });

        
            $.ajax({
                url: '/Home/DeleteSelectedItems', // Silme iþlemi yapýlacak action'ýn yolunu belirtin
                type: 'POST',
                data: { selectedItems: selectedItems },
                success: function (result) {
                    // Silme iþlemi baþarýlýysa sayfayý yenileyebilirsiniz veya baþka bir iþlem yapabilirsiniz.
                },
                error: function () {
                    alert('Silme islemi sirasýnda bir hata oluþtu.');
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
