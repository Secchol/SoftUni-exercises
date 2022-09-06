function extractText() {
    let items = Array.from(document.querySelectorAll("li"));
    let resultArea = document.getElementById("result");
    resultArea.value = items.map(e => e.textContent).join("\n");

}
