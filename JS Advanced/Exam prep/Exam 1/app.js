window.addEventListener("load", solve);

function solve() {
  const publishButton = document.getElementById("publish");
  publishButton.addEventListener("click",onClick);
  function onClick(event){
    event.preventDefault();
    const inputFields = Array.from(event.target.parentElement.getElementsByTagName("input"));
    const fuelSelector = document.getElementById("fuel");
    let isFalse = false;
    inputFields.forEach((el)=>{
      if (el.value==""){
       isFalse = true;
      }
    })
    if (fuelSelector.value==""){
      isFalse = true;
    }
    if (isFalse){
      return;
    }
    const make = inputFields[0];
    const model = inputFields[1];
    const year = inputFields[2];
    const originalCost = inputFields[3];
    const sellingPrice = inputFields[4];
    if (Number(originalCost.value)>Number(sellingPrice.value)){
      return;
    }
    const body = document.getElementById("table-body");
    const tr = document.createElement("tr");
    tr.classList.add("row");
    const makeTd = document.createElement("td");
    makeTd.textContent = make.value;
    const modelTd = document.createElement("td");
    modelTd.textContent = model.value;
    const yearTd = document.createElement("td");
    yearTd.textContent = year.value;
    const fuelTd = document.createElement("td");
    fuelTd.textContent = fuelSelector.value;
    const originalCostTd = document.createElement("td");
    originalCostTd.textContent = originalCost.value;
    const sellingPriceTd = document.createElement("td");
    sellingPriceTd.textContent = sellingPrice.value;
    const editButton = document.createElement("button");
    editButton.classList.add("action-btn");
    editButton.textContent="Edit";
    const sellButton = document.createElement("button");
    sellButton.classList.add("action-btn");
    sellButton.textContent = "Sell";
    const buttonTd = document.createElement("td");
    buttonTd.appendChild(editButton);
    buttonTd.appendChild(sellButton);
    tr.appendChild(makeTd);
    tr.appendChild(modelTd);
    tr.appendChild(yearTd);
    tr.appendChild(fuelTd);
    tr.appendChild(originalCostTd);
    tr.appendChild(sellingPriceTd);
    tr.appendChild(buttonTd);
    body.appendChild(tr);
    make.value = "";
    model.value = "";
    year.value = "";
    fuelSelector.value = "";
    originalCost.value = "";
    sellingPrice.value = "";
    editButton.addEventListener("click",editClick)
    function editClick(ev){
      
      
      const info = ev.target.parentElement.parentElement.getElementsByTagName("td");
      make.value = info[0].textContent;
      model.value = info[1].textContent;
      year.value = info[2].textContent;
      fuelSelector.value = info[3].textContent;
      originalCost.value = info[4].textContent;
      sellingPrice.value = info[5].textContent;
      ev.target.parentElement.parentElement.parentElement.removeChild(ev.target.parentElement.parentElement);
    }
    sellButton.addEventListener("click",sellClick);
    function sellClick(ev){
      
      const profit = document.getElementById("profit");
      const ul = document.getElementById("cars-list");
      const li = document.createElement("li");
      li.classList.add("each-list");
      const currentTr = ev.target.parentElement.parentElement;
      const currentTrInfo = currentTr.getElementsByTagName("td");
      const makeModelSpan = document.createElement("span");
      makeModelSpan.textContent = currentTrInfo[0].textContent + " " + currentTrInfo[1].textContent;
      const yearSpan = document.createElement("span");
      yearSpan.textContent = currentTrInfo[2].textContent;
      const profitSpan =document.createElement("span"); 
      profitSpan.textContent = (Number(currentTrInfo[5].textContent)-Number(currentTrInfo[4].textContent)).toFixed(2);
      li.appendChild(makeModelSpan);
      li.appendChild(yearSpan);
      li.appendChild(profitSpan);
      ul.appendChild(li);
      profit.textContent = (Number(profit.textContent)+Number(profitSpan.textContent)).toFixed(2);
      ev.target.parentElement.parentElement.parentElement.removeChild(ev.target.parentElement.parentElement);

    }

  }
}
