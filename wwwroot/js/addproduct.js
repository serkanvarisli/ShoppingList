$(document).ready(function () {
    // Radyo düðmesine týklandýðýnda
    $('input[name="addProductDetailRadio"]').change(function () {
        if ($(this).prop("id") === "addProductDetailRadio") {
            $('#hiddenProductDetailContainer').show();
        } else {
            $('#hiddenProductDetailContainer').hide();
        }
    });
});