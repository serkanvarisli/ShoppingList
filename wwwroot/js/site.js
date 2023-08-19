﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//showPassword login page

$(function () {
    $("#showPassword").change(function () {
        var checked = $(this).is(":checked");
        if (checked) {
            $("#password").attr("type", "text");
            var metin = document.getElementById("showText").innerHTML;

            // Belirli bir metni değiştir
            var yeniMetin = metin.replace("Şifreyi Göster ", "Şifreyi Gizle ");

            // Metni güncelle
            document.getElementById("showText").innerHTML = yeniMetin;
        } else {
            $("#password").attr("type", "password");
            var metin = document.getElementById("showText").innerHTML;

            var yeniMetin = metin.replace("Şifreyi Gizle ", "Şifreyi Göster ");

            // Metni güncelle
            document.getElementById("showText").innerHTML = yeniMetin;
        }
    });
});

// repassword login page
$(function () {
    $("#showPassword").change(function () {
        var checked = $(this).is(":checked");
        if (checked) {
            $("#repassword").attr("type", "text");
            var metin = document.getElementById("showText").innerHTML;

            // Belirli bir metni değiştir
            var yeniMetin = metin.replace("Şifreyi Göster ", "Şifreyi Gizle ");

            // Metni güncelle
            document.getElementById("showText").innerHTML = yeniMetin;
        } else {
            $("#repassword").attr("type", "password");
            var metin = document.getElementById("showText").innerHTML;

            var yeniMetin = metin.replace("Şifreyi Gizle ", "Şifreyi Göster ");

            // Metni güncelle
            document.getElementById("showText").innerHTML = yeniMetin;
        }
    });
});
// admin login
$(function () {
    $("#showPassword").change(function () {
        var checked = $(this).is(":checked");
        if (checked) {
            $("#adminpassword").attr("type", "text");
            var metin = document.getElementById("showText").innerHTML;

            // Belirli bir metni değiştir
            var yeniMetin = metin.replace("Şifreyi Göster ", "Şifreyi Gizle ");

            // Metni güncelle
            document.getElementById("showText").innerHTML = yeniMetin;
        } else {
            $("#adminpassword").attr("type", "password");
            var metin = document.getElementById("showText").innerHTML;

            var yeniMetin = metin.replace("Şifreyi Gizle ", "Şifreyi Göster ");

            // Metni güncelle
            document.getElementById("showText").innerHTML = yeniMetin;
        }
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
