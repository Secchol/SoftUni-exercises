function validate() {
    const input = document.getElementsByTagName("input")[0];
    input.addEventListener("change", validateEmail);
    function validateEmail() {
        const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        const match = input.value.match(re);
        if (match === null) {
            input.classList.add("error");
        }
        else {
            input.classList.remove("error");
        }
    }
}