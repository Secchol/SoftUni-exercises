window.addEventListener('load', solve);

function solve() {
    document.getElementById("add").addEventListener("click", onClick);
    function onClick(ev) {
        ev.preventDefault();
        const model = document.getElementById("model");
        const year = document.getElementById("year");
        const description = document.getElementById("description");
        const price = document.getElementById("price");
        if (!model.value || !year.value || !description.value || !price.value || price.value < 0 || year.value < 0) {
            return;
        }
        const furnitureList = document.getElementById("furniture-list");
        const infoTr = document.createElement("tr");
        infoTr.classList.add("info");
        const modelTd = document.createElement("td");
        modelTd.textContent = model.value;
        const priceTd = document.createElement("td");
        priceTd.textContent = Number(price.value).toFixed(2);
        const buttonsTd = document.createElement("td");
        const moreBtn = document.createElement("button");
        moreBtn.classList.add("moreBtn");
        moreBtn.textContent = "More Info";
        const buyBtn = document.createElement("button");
        buyBtn.classList.add("buyBtn");
        buyBtn.textContent = "Buy it";
        buttonsTd.appendChild(moreBtn);
        buttonsTd.appendChild(buyBtn);
        infoTr.appendChild(modelTd);
        infoTr.appendChild(priceTd);
        infoTr.appendChild(buttonsTd);

        const hiddenTr = document.createElement("tr");
        hiddenTr.classList.add("hide");
        const yearTd = document.createElement("td");
        yearTd.textContent = `Year: ${year.value}`;
        const descriptionTd = document.createElement("td");
        descriptionTd.setAttribute("colspan", "3");
        descriptionTd.textContent = `Description: ${description.value}`;
        hiddenTr.appendChild(yearTd);
        hiddenTr.appendChild(descriptionTd);
        furnitureList.appendChild(infoTr);
        furnitureList.appendChild(hiddenTr);

        moreBtn.addEventListener("click", moreInfo);
        function moreInfo(ev) {
            ev.preventDefault();
            if (ev.target.textContent == "More Info") {
                moreBtn.textContent = "Less Info";
                hiddenTr.style.display = "contents";
            }
            else if (ev.target.textContent == "Less Info") {
                moreBtn.textContent = "More Info";
                hiddenTr.style.display = "none";
            }
        }
        buyBtn.addEventListener("click", buyItem);
        function buyItem(ev) {
            ev.preventDefault();
            const totalPrice = document.getElementsByClassName("total-price")[0];
            totalPrice.textContent = (Number(totalPrice.textContent) + Number(priceTd.textContent)).toFixed(2);
            ev.target.parentElement.parentElement.remove();
        }






        model.value = "";
        year.value = "";
        description.value = "";
        price.value = "";
    }
}
