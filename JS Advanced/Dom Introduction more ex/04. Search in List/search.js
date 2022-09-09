function search() {
   const cities = Array.from(document.getElementsByTagName("li"));
   const text = document.getElementById("searchText").value;
   const result = document.getElementById("result");
   result.textContent = "";
   for (city of cities) {

      city.style.textDecoration = "none";
      city.style.fontWeight = "none";


   }

   let matchCount = 0;
   for (city of cities) {
      if (city.textContent.indexOf(text) != -1) {
         city.style.textDecoration = "underline";
         city.style.fontWeight = "bold";
         matchCount++;
      }
   }
   result.textContent = `${matchCount} matches found`;

}
