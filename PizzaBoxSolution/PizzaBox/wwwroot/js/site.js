// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$("topSelect").change(function () {
    if ($("select option:selected").length > 5) {
        //your code here
        Alert("You are not allowd to select more than 5 toppings");
    }
});