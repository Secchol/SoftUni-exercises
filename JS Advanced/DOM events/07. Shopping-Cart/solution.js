function solve() {
    let bodyEl = document.getElementsByClassName("shopping-cart")[0];
    const textArea = document.getElementsByTagName("textarea")[0];
    bodyEl.addEventListener("click", buy);
    bodyEl.addEventListener("click", checkout);
    const productsList = [];
    let productsSum = 0;
    function buy(event) {
        if (event.target.classList.contains("add-product")) {
            const p = document.createElement("p");
            const parent = event.target.parentElement.parentElement;
            const name = parent.querySelector(".product-title").textContent;
            const productPrice = Number(parent.querySelector(".product-line-price").textContent);
            if (!productsList.some(el => el == name)) {
                productsList.push(name);
            }
            productsSum += productPrice;
            p.textContent = `Added ${name} for ${productPrice.toFixed(2)} to the cart.\n`;
            textArea.appendChild(p);
            textArea.value += p.textContent;

        }
    }
    function checkout(event) {
        if (event.target.classList.contains("checkout")) {
            const p = document.createElement("p");
            p.textContent = `You bought ${productsList.join(", ")} for ${productsSum.toFixed(2)}.`;
            textArea.appendChild(p);
            textArea.value += p.textContent;
            bodyEl.removeEventListener("click", buy);
            bodyEl.removeEventListener("click", checkout);



        }
    }
}