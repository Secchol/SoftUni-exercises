function sumTable() {
    let tableItems = Array.from(document.querySelectorAll("tr")).slice(1, -1).map(e => e.lastElementChild.textContent);
    tableItems = tableItems.map(e => Number(e));
    const sum = tableItems.reduce((accumulator, value) => { return accumulator + value; }, 0);
    document.getElementById("sum").textContent = sum;
}