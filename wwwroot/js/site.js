// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
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

//