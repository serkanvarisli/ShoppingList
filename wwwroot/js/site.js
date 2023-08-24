﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
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


//Alışveriş işlemleri jquery
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

// Edit Product Page
const editproduct = document.getElementById('editproduct');
const saveproduct = document.getElementById('saveproduct');
const myInput1 = document.getElementById('tb1');
const myInput2 = document.getElementById('tb2');
const myInput3 = document.getElementById('tb3');
const myInput4 = document.getElementById('tb4');


editproduct.addEventListener('click', function () {
    myInput1.readOnly = false;
    myInput2.readOnly = false;
    myInput3.readOnly = false;
    myInput4.readOnly = false;
    saveproduct.hidden = false;
    editproduct.hidden = true;
});

saveproduct.addEventListener('click', function () {
    myInput1.readOnly = true;
    myInput2.readOnly = true;
    myInput3.readOnly = true;
    myInput4.readOnly = true;
    saveproduct.hidden = true;
    editproduct.hidden = false;

});



