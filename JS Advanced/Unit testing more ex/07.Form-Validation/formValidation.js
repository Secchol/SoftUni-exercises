function validate() {
    document.getElementById("company").addEventListener("change", () => {
        const companyInfo = document.getElementById("companyInfo");
        if (document.getElementById("company").checked == true) {
            companyInfo.style.display = "block"
        }
        else if (document.getElementById("company").checked == false) {
            companyInfo.style.display = "none";
        }
    })
    document.getElementById("submit").addEventListener("click", OnClick);
    function OnClick(event) {
        event.preventDefault();
        let invalidFields = [];
        const checkBox = document.querySelector("#company");
        const username = document.getElementById("username");
        const usernamePatt = /^[A-Za-z0-9]{3,20}$/
        if (!usernamePatt.test(username.value)) {
            invalidFields.push(username);
        }
        const email = document.getElementById("email");
        const emailPatt = /^[^@.]+@[^@]*\.[^@]+$/
        if (!emailPatt.test(email.value)) {
            invalidFields.push(email);
        }
        const password = document.getElementById("password");
        const confirmPass = document.getElementById("confirm-password");
        const passPatt = /^[\w]{5,15}$/;
        if (!passPatt.test(password.value) || confirmPass.value !== password.value) {
            invalidFields.push(password);
            invalidFields.push(confirmPass);
        }

        if (checkBox.checked) {
            const companyId = document.getElementById("companyNumber");
            const companyPattern = /^[0-9]{4}$/
            if (!companyPattern.test(companyId.value)) {
                invalidFields.push(companyId);
            }
        }

        invalidFields.forEach(field => field.style.borderColor = "red");
        invalidFields.length == 0 ? document.querySelector("#valid").style.display = "block" :
            document.querySelector("#valid").style.block = "none";
    }


}
