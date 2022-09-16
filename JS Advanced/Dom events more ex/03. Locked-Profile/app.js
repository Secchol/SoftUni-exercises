function lockedProfile() {
    const main = document.getElementById("main");
    main.addEventListener("click", showMore);

    function showMore(event) {
        if (event.target.tagName == "BUTTON" && event.target.parentElement.getElementsByTagName("div")[0].id != "block" && event.target.parentElement.getElementsByTagName("input")[1].checked) {
            event.target.parentElement.getElementsByTagName("div")[0].id = "block";
            event.target.textContent = "Hide it";
        }
        else if (event.target.tagName == "BUTTON" && event.target.parentElement.getElementsByTagName("div")[0].id == "block" && event.target.parentElement.getElementsByTagName("input")[1].checked) {
            event.target.parentElement.getElementsByTagName("div")[0].id = "userHiddenFields";
            event.target.textContent = "Show more";
        }
    }


}