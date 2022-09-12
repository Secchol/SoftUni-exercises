function focused() {
    const inputs = Array.from(document.querySelectorAll("input"));
    for (input of inputs) {
        input.addEventListener("focus", onFocus);
        input.addEventListener("blur", onBlur)
    }
    function onFocus(event) {
        event.target.parentElement.classList.add("focused");
    }
    function onBlur(event) {
        event.target.parentElement.classList.remove("focused");
    }
}