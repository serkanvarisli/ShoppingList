$(document).ready(function () {
    // Radyo d��mesine t�kland���nda
    $('input[name="addProductDetailRadio"]').change(function () {
        if ($(this).prop("id") === "addProductDetailRadio") {
            $('#hiddenProductDetailContainer').show();
        } else {
            $('#hiddenProductDetailContainer').hide();
        }
    });
});