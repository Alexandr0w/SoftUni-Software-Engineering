window.addEventListener("load", solve);

function solve() {
    const eventInput = document.getElementById("event");
    const noteInput = document.getElementById("note");
    const dateInput = document.getElementById("date");

    const saveBtn = document.getElementById("save");
    const deleteBtn = document.querySelector(".delete");

    const upcomingList = document.getElementById("upcoming-list");
    const eventsList = document.getElementById("events-list");

    saveBtn.addEventListener("click", function () {
        const eventName = eventInput.value.trim();
        const note = noteInput.value.trim();
        const date = dateInput.value.trim();

        if (!eventName || !note || !date) {
            return;
        }

        // li
        const li = document.createElement("li");
        li.className = "event-item";

        // div
        const div = document.createElement("div");

        // article
        const article = document.createElement("article");

        const pName = document.createElement("p");
        pName.textContent = `Name: ${eventName}`;

        const pNote = document.createElement("p");
        pNote.textContent = `Note: ${note}`;

        const pDate = document.createElement("p");
        pDate.textContent = `Date: ${date}`;

        article.appendChild(pName);
        article.appendChild(pNote);
        article.appendChild(pDate);

        // buttons
        const editBtn = document.createElement("button");
        editBtn.textContent = "Edit";
        editBtn.className = "edit";

        const doneBtn = document.createElement("button");
        doneBtn.textContent = "Done";
        doneBtn.className = "done";

        div.appendChild(article);
        div.appendChild(editBtn);
        div.appendChild(doneBtn);

        li.appendChild(div);
        upcomingList.appendChild(li);

        // clear inputs
        eventInput.value = "";
        noteInput.value = "";
        dateInput.value = "";

        editBtn.addEventListener("click", function () {
            eventInput.value = eventName;
            noteInput.value = note;
            dateInput.value = date;

            upcomingList.removeChild(li);
        });

        doneBtn.addEventListener("click", function () {
            div.removeChild(editBtn);
            div.removeChild(doneBtn);

            upcomingList.removeChild(li);
            eventsList.appendChild(li);
        });
    });

    deleteBtn.addEventListener("click", function () {
        while (eventsList.firstChild) {
            eventsList.removeChild(eventsList.firstChild);
        }
    });
}



