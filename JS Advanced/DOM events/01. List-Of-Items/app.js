function addItem() {
    const list = document.getElementById("items");
    const newItemText = document.getElementById("newItemText").value;
    const newItem = document.createElement("li");
    newItem.textContent = newItemText;
    list.appendChild(newItem);
    document.getElementById("newItemText").value = "";
}