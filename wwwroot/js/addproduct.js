$(document).ready(function () {
    // Radyo düğmesine tıklandığında
    $('input[name="addProductDetailRadio"]').change(function () {
        if ($(this).prop("id") === "addProductDetailRadio") {
            $('#hiddenProductDetailContainer').show();
        } else {
            $('#hiddenProductDetailContainer').hide();
        }
    });
});