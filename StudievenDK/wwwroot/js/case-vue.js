
vm = new Vue({
    el: '#VueApp',
    data: {
        cases: []
    },
    methods: {
        buildURL(url) {
            return '/image/' + url;
        },
        //showImage(event) {
        //    let el = event.currentTarget;
           
        //}
    },

    mounted() {
    // get current case
        fetch('/Cases/currentCase').then(function (response) {
            if (response.status !== 200) {
                console.log('looks like there was a problem. Status Code: ' + response.status);
                return;
            };
            //build the html 
            response.json().then(function (cases) {
                vm.case = cases;
            })
                .catch(function (err) {
                })
        });
    }
});