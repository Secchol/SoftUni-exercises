function solve() {
  const [generateButton, buyButton] = Array.from(document.getElementsByTagName("button"));
  generateButton.addEventListener("click", generate);
  buyButton.addEventListener("click", buy);

  function generate() {
    const input = JSON.parse(document.querySelector("textarea").value);
    input.forEach(obj => {
      const tr = document.createElement("tr");
      let td1 = document.createElement("td");
      let img = document.createElement("img");
      img.src = obj.img;
      td1.appendChild(img);
      tr.appendChild(td1);
      let td2 = document.createElement("td");
      let name = document.createElement("p");
      name.textContent = obj.name;
      td2.appendChild(name);
      tr.appendChild(td2);
      let td3 = document.createElement("td");
      let price = document.createElement("p");
      price.textContent = obj.price;
      td3.appendChild(price);
      tr.appendChild(td3);
      let td4 = document.createElement("td");
      let decFactor = document.createElement("p");
      decFactor.textContent = obj.decFactor;
      td4.appendChild(decFactor);
      tr.appendChild(td4);
      let td5 = document.createElement("td");
      let checkbox = document.createElement("input");
      checkbox.type = "checkbox";
      td5.appendChild(checkbox);
      tr.appendChild(td5);
      document.getElementsByTagName("tbody")[0].appendChild(tr);
    })
  }

  function buy() {
    let boughtFurniture = [];
    let furnitureSum = 0;
    let decFactorSum = 0;
    let objCount = 0;
    for (let obj of Array.from(document.querySelectorAll("tbody tr"))) {
      if (obj.querySelector("input").checked) {
        const objInfo = Array.from(obj.querySelectorAll("p"));
        boughtFurniture.push(objInfo[0].textContent);
        furnitureSum += Number(objInfo[1].textContent);
        decFactorSum += Number(objInfo[2].textContent);
        objCount++;
      }
    }
    const textareaBuy = document.querySelectorAll("textarea")[1];
    textareaBuy.value += `Bought furniture: ${boughtFurniture.join(", ")}\r\n`
    textareaBuy.value += `Total price: ${furnitureSum.toFixed(2)}\r\n`;
    textareaBuy.value += `Average decoration factor: ${(decFactorSum / objCount)}`;

  }

}
