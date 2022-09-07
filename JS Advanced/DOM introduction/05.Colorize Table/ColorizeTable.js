function colorize() {
    const rowElements = Array.from(document.querySelectorAll("table tr:nth-child(2n)"));
    for (element of rowElements) {
        element.style.backgroundColor = "Teal";
    }
}