function create(words) {
   const content = document.getElementById("content");
   for (word of words) {
      const div = document.createElement("div");
      const p = document.createElement("p");
      p.textContent = word;
      p.style.display = "none";
      div.appendChild(p);
      content.appendChild(div);
   }
   content.addEventListener("click", onClick);
   function onClick(event) {
      if (event.target.tagName = "DIV") {
         event.target.children[0].style.display = "inline";
      }
   }
}