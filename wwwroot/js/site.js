// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Ürün detay kontainer

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




