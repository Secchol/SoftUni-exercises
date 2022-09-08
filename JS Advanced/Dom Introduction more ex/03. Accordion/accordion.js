function toggle() {
    let button = Array.from(document.getElementsByClassName("button"))[0];
    const text = document.getElementById("extra");
    if (button.textContent == "More") {
        button.textContent = "Less";
        text.style.display = "block";
    }
    else if (button.textContent == "Less") {
        button.textContent = "More";
        text.style.display = "none";

    }
}