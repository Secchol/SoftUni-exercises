function solve() {
    const addButton = document.getElementById("add-worker");
    addButton.addEventListener("click", onClick);
    function onClick(ev) {
        ev.preventDefault();

        const firstName = document.getElementById("fname");
        const lastName = document.getElementById("lname");
        const email = document.getElementById("email");
        const birth = document.getElementById("birth");
        const position = document.getElementById("position");
        const salary = document.getElementById("salary");
        const tbody = document.getElementById("tbody");
        if (!firstName.value || !lastName.value || !email.value || !birth.value || !position.value || !salary.value) {
            return;
        }
        const tr = document.createElement("tr");
        const firstNameTd = document.createElement("td");
        firstNameTd.textContent = firstName.value;
        const secondNameTd = document.createElement("td");
        secondNameTd.textContent = lastName.value;
        const emailTd = document.createElement("td");
        emailTd.textContent = email.value;
        const birthTd = document.createElement("td");
        birthTd.textContent = birth.value;
        const positionTd = document.createElement("td");
        positionTd.textContent = position.value;
        const salaryTd = document.createElement("td");
        salaryTd.textContent = salary.value;
        const buttons = document.createElement("td");
        const fireButton = document.createElement("button");
        fireButton.classList.add("fired");
        fireButton.textContent = "Fired";
        const editButton = document.createElement("button");
        editButton.classList.add("edit");
        editButton.textContent = "Edit";
        buttons.appendChild(fireButton);
        buttons.appendChild(editButton);
        tr.appendChild(firstNameTd);
        tr.appendChild(secondNameTd);
        tr.appendChild(emailTd);
        tr.appendChild(birthTd);
        tr.appendChild(positionTd);
        tr.appendChild(salaryTd);
        tr.appendChild(buttons);
        tbody.appendChild(tr);
        document.getElementById("sum").textContent = (Number(document.getElementById("sum").textContent) + Number(salary.value)).toFixed(2);
        firstName.value = "";
        lastName.value = "";
        email.value = "";
        birth.value = "";
        position.value = "";
        salary.value = "";

        editButton.addEventListener("click", edit);
        function edit(ev) {
            ev.preventDefault();
            firstName.value = firstNameTd.textContent;
            lastName.value = secondNameTd.textContent;
            email.value = emailTd.textContent;
            birth.value = birthTd.textContent;
            position.value = positionTd.textContent;
            salary.value = salaryTd.textContent;
            ev.target.parentElement.parentElement.remove();
            document.getElementById("sum").textContent = (Number(document.getElementById("sum").textContent) - Number(salary.value)).toFixed(2);
        }

        fireButton.addEventListener("click", fire);
        function fire(ev) {
            ev.preventDefault();
            ev.target.parentElement.parentElement.remove();
            document.getElementById("sum").textContent = (Number(document.getElementById("sum").textContent) - Number(salaryTd.textContent)).toFixed(2);
        }


    }
}
solve()