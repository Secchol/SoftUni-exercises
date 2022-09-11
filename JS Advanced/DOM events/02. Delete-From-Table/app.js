function deleteByEmail() {
    const emails = Array.from(document.querySelectorAll("tbody tr"));
    const input = document.querySelector("input").value;
    let isFound = false;
    for (let email of emails) {
        if (email.children[1].textContent == input) {
            isFound = true;
            email.parentElement.removeChild(email);
            break;
        }
    }
    const result = document.getElementById("result");
    isFound ? result.textContent = "Deleted." : result.textContent = "Not found.";

    document.querySelector("input").value = "";


}