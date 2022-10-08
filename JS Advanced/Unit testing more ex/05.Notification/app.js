function notify(message) {

  const displayDiv = document.getElementById("notification");
  displayDiv.textContent = message;
  displayDiv.style.display = "block";
  displayDiv.addEventListener("click", clickMessage);
  function clickMessage(event) {
    displayDiv.style.display = "none";
  }
}