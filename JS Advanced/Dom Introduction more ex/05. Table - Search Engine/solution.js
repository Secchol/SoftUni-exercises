function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);
   let tableRows = Array.from(document.querySelectorAll("tbody tr"));
   let input = document.getElementById("searchField");

   function onClick() {

      for (row of tableRows) {
         row.classList.remove("select");
         if (row.innerHTML.includes(input.value)) {
            row.className = "select";
         }
      }
      input.value = "";
   }
}