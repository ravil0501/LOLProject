// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
window.addEventListener('DOMContentLoaded', function () {
    var inputElements = document.querySelectorAll('.simulateInfoInput');
    inputElements.forEach(function (inputElement) {
        var value = sessionStorage.getItem(inputElement.id);
        if (value !== null) {
            inputElement.value = value;
        }
    });

    inputElements.forEach(function (inputElement) {
        inputElement.addEventListener('input', function () {
            sessionStorage.setItem(inputElement.id, inputElement.value);
        });
    });
});
// Write your JavaScript code.
