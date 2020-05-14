
//var app = new Vue({
//    el: '#app',
//    data: {
//        information: 'This is case information'
//    }
//});

//new Vue({
//    el: '#Description',
//    data: {
//        description: 'Data her!!!'
//},
//    methods: {

//}
//});

//var url = '/Cases';
//document.getElementById('get-caseId').addEventListener('click', getCase);

var vm = new Vue({
    el: '#app',
    data: {
        form: {
            Text: ''
            //Picture: '',
            //Course: '',
            //Deadline: ''
            
        }
    },
    methods: {
        async getCase() {
            //let caseId = CaseObject.currentTarget.getAttribute('data-id').value;
            //let caseId = this.dataset.id;
            let caseId = this.form.id;
            let container = document.getElementById('list-cases');
            let cases = await get(`/Cases/${caseId}`);
            for (let info of cases) {
                let row = document.createElement("tr");
                //let str = `<tr><td>${info.Subject}</td>`;
                if (info.Text) {
                    str += `<td>${info.Text}</td>`;
                }

                //str += `<td>${info.picture}`;
                str += `</tr>`;
                row.innerHTML = str;
                container.appendChild(row);

            }
        },
        async get(urls) {
            let response = await fetch(urls, {
                method: 'GET',
                body: JSON.stringify(this.form),
                headers: new Headers( {
                    'Content-Type': 'application/json'
                }).then((res) => {
                    return res.json()
                }).then((data) => this.form(data))
                .catch(error => console.log('ERROR'))
                }
            );
            //return await response.text();

        }
    }
});