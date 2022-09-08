function solve() {
  let input = document.getElementById("text").value.split(" ").map(e => e.toLowerCase());
  const transformTo = document.getElementById("naming-convention").value;
  let result = document.getElementById("result");
  if (transformTo == "Camel Case") {
    input = input.map(e => e.charAt(0).toUpperCase() + e.slice(1));
    input[0] = input[0].toLowerCase();
  }
  else if (transformTo == "Pascal Case") {
    input = input.map(e => e.charAt(0).toUpperCase() + e.slice(1));
  }
  else {
    result.textContent = "Error!";
    return;
  }
  result.textContent = input.join("");
}