function solve() {
  const sections = Array.from(document.getElementsByTagName("section"));
  const body = document.getElementById("quizzie");
  body.addEventListener("click", onClick);
  let rightAnswers = 0;
  let currentSection = 0;
  const result = document.querySelector("#results li h1");
  function onClick(event) {
    if (event.target.classList.contains("answer-text")) {
      sections[currentSection].className = "none";
      const answer = event.target.textContent;
      if (answer == "onclick" || answer == "JSON.stringify()" || answer == "A programming API for HTML and XML documents") {
        rightAnswers++;
      }
      sections[currentSection].className = "hidden";
      if (currentSection != 2) {
        sections[++currentSection].className = "none";
      }
      else {
        if (rightAnswers == 3) {
          result.textContent = "You are recognized as top JavaScript fan!";

        }
        else {
          result.textContent = `You have ${rightAnswers} right answers`;

        }
        document.querySelector("h1").appendChild(document.querySelector("#results li").appendChild(result));
      }
    }
  }
}
