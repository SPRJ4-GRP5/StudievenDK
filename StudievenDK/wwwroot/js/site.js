// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const detailView = document.querySelector('.detail');
const detailTitle = document.querySelector('.detail-title');
const masterItems = document.querySelectorAll('.master-item');
function select(selected) {
    //Remove active class from all master-items
    for (var item of masterItems) {
        item.classList.remove('active-item');
    }
    //Make selected tab active
    selected.classList.add('active-item');
    //Set the content of the detail to the innerHTML of the selected item
    detailTitle.innerHTML = selected.innerHTML;

    let id = selected.getAttribute('data-id');
    let el = document.getElementById('Edit-Id');
    el.value = id; 
}
