function addItem() {
    const list = document.getElementById("items");
    const newItemText = document.getElementById("newItemText").value;
    const newItem = document.createElement("li");
    newItem.textContent = newItemText;
    const btn = document.createElement("a");
    btn.textContent = "[Delete]";
    btn.href = "#";
    newItem.appendChild(btn);

    list.appendChild(newItem);
    btn.addEventListener("click", onDelete);
    document.getElementById("newItemText").value = "";

    function onDelete(event) {
        event.target.parentElement.remove();
    }
}
