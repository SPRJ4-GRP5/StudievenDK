// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function myFunction() {
    var x = document.getElementById('myDIV');
    if (x.style.display === 'none') {
        x.style.display = 'block';
    }
    else
    {
        x.style.display = 'none';
    }
}

function rotateTriangle() {
    var img = document.getElementById('triangle');
    if (img.style.transform === 'rotate(0deg)') {
        img.style.transform = 'rotate(180deg)';
    }
    else {
        img.style.transform = 'rotate(0deg)'
    }

   
}