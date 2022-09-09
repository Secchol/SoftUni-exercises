function solve() {
  const input = document.getElementById("input").value.split(".").filter(x => x.length > 0);
  let output = document.getElementById("output");
  while (input.length > 0) {
    let currentSentences = input.splice(0, 3).join(". ") + ".";
    let p = document.createElement("p");
    p.textContent = currentSentences;
    output.appendChild(p);
  }

}