// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const detailView = document.querySelector('.detail');
const detailTitle = document.querySelector('.detail-title');
const masterItems = document.querySelectorAll('.master-item');
for(var item of masterItems) {
	item.classList.remove('active-item');
	item.addEventListener('click', select);
}

function select(selected) {
    //Remove active class from all master-items
    for (var item of masterItems) {
        item.classList.remove('active-item');
    }
    //Make selected tab active
    selected.currentTarget.classList.add('active-item');
    //Set the content of the detail to the innerHTML of the selected item
    detailTitle.innerHTML = selected.currentTarget.innerHTML;
   
    let id = selected.currentTarget.getAttribute('data-id');
    let el = document.getElementById('Edit-Id');
    el.value = id;

    let deleteID = document.getElementById('Delete-Id');
    deleteID.value = id;

    get(`/Cases/GetCaseInfo/${id}`); 


}

async function get(urls) {
	let response = await fetch(urls,
		{
			method: 'GET',
			headers: {
				'Content-Type': 'application/json'
			}
		});
	if (response.ok)
		vm.item = await response.json();
	else {
		alert('ERROR' + response.statusText);
	}
};

var vm = new Vue({
	el: '#app',
	data: {
		item: {
			text: '',
			deadline: '',
			courseName_fk: '',
			pictureName: ''

		}
	},
	methods: {
		buildUrl(url) {
			return '~/images/' + url;
		}
    }

})