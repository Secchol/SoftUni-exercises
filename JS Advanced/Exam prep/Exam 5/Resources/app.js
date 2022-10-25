window.addEventListener('load', solve);

function solve() {
    const addButton = document.getElementById("add-btn");
    addButton.addEventListener("click", onClick);
    function onClick(ev) {
        ev.preventDefault();
        const genre = document.getElementById("genre");
        const name = document.getElementById("name");
        const author = document.getElementById("author");
        const date = document.getElementById("date");
        if (!genre.value || !name.value || !author.value || !date.value) {
            return;
        }

        const div = document.getElementsByClassName("all-hits-container")[0];
        const hitDiv = document.createElement("div");
        hitDiv.classList.add("hits-info");
        const img = document.createElement("img");
        img.setAttribute("src", "./static/img/img.png");
        const genreH2 = document.createElement("h2");
        genreH2.textContent = `Genre: ${genre.value}`;
        const nameH2 = document.createElement("h2");
        nameH2.textContent = `Name: ${name.value}`;
        const authorH2 = document.createElement("h2");
        authorH2.textContent = `Author: ${author.value}`;
        const dateH3 = document.createElement("h3");
        dateH3.textContent = `Date: ${date.value}`;
        const saveButton = document.createElement("button");
        saveButton.classList.add("save-btn");
        saveButton.textContent = "Save song";
        const likeButton = document.createElement("button");
        likeButton.classList.add("like-btn");
        likeButton.classList.add("addedLater");
        console.log(likeButton.classList);
        likeButton.textContent = "Like song";

        const deleteButton = document.createElement("button");
        deleteButton.classList.add("delete-btn");
        deleteButton.textContent = "Delete";

        hitDiv.appendChild(img);
        hitDiv.appendChild(genreH2);
        hitDiv.appendChild(nameH2);
        hitDiv.appendChild(authorH2);
        hitDiv.appendChild(dateH3);
        hitDiv.appendChild(saveButton);
        hitDiv.appendChild(likeButton);
        hitDiv.appendChild(deleteButton);
        div.appendChild(hitDiv);

        genre.value = "";
        name.value = "";
        author.value = "";
        date.value = "";

        likeButton.addEventListener("click", like);
        function like(ev) {
            ev.preventDefault();
            const p = document.getElementsByClassName("likes")[0].querySelector("p");
            let currentLikes = Number(p.textContent.split(": ")[1]);
            p.textContent = `Total Likes: ${++currentLikes}`;
            likeButton.disabled = true;

        }

        saveButton.addEventListener("click", save);
        function save(ev) {
            ev.preventDefault();
            const buttons = Array.from(ev.target.parentElement.getElementsByTagName("button"));
            ev.target.parentElement.remove();
            buttons.forEach(button => {
                button.remove();
            });
            hitDiv.appendChild(deleteButton);

            document.getElementsByClassName("saved-container")[0].appendChild(hitDiv);

        }


        deleteButton.addEventListener("click", deleteBtn);
        function deleteBtn(ev) {
            ev.preventDefault();
            ev.target.parentElement.remove();

        }
    }
}