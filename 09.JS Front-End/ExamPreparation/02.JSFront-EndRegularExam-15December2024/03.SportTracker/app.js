function solve() {
    const BASE_URL = 'http://localhost:3030/jsonstore/workout/';

    const workoutInput = document.getElementById('workout');
    const locationInput = document.getElementById('location');
    const dateInput = document.getElementById('date');

    const addBtn = document.getElementById('add-workout');
    const editBtn = document.getElementById('edit-workout');
    const loadBtn = document.getElementById('load-workout');

    const list = document.getElementById('list');

    let currentEditId = null;

    loadBtn.addEventListener('click', loadWorkouts);
    addBtn.addEventListener('click', addWorkout);
    editBtn.addEventListener('click', editWorkout);

    editBtn.disabled = true;

    // LOAD
    async function loadWorkouts() {
        list.innerHTML = '';
        editBtn.disabled = true;
        addBtn.disabled = false;

        const response = await fetch(BASE_URL);
        const data = await response.json();

        for (const id in data) {
            list.appendChild(createWorkoutElement(data[id]));
        }
    }

    // CREATE
    async function addWorkout() {
        const workout = workoutInput.value.trim();
        const location = locationInput.value.trim();
        const date = dateInput.value.trim();

        if (!workout || !location || !date) {
            return;
        }

        await fetch(BASE_URL, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ workout, location, date })
        });

        clearInputs();
        loadWorkouts();
    }

    // EDIT (PUT)
    async function editWorkout() {
        const workout = workoutInput.value.trim();
        const location = locationInput.value.trim();
        const date = dateInput.value.trim();

        if (!workout || !location || !date || !currentEditId) {
            return;
        }

        await fetch(BASE_URL + currentEditId, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                workout,
                location,
                date,
                _id: currentEditId
            })
        });

        currentEditId = null;
        editBtn.disabled = true;
        addBtn.disabled = false;

        clearInputs();
        loadWorkouts();
    }

    // CREATE DOM ELEMENT
    function createWorkoutElement(data) {
        const container = document.createElement('div');
        container.className = 'container';

        const h2 = document.createElement('h2');
        h2.textContent = data.workout;

        const h3Date = document.createElement('h3');
        h3Date.textContent = data.date;

        const h3Location = document.createElement('h3');
        h3Location.textContent = data.location;

        const btnDiv = document.createElement('div');
        btnDiv.className = 'buttons-container';

        const changeBtn = document.createElement('button');
        changeBtn.className = 'change-btn';
        changeBtn.textContent = 'Change';

        const deleteBtn = document.createElement('button');
        deleteBtn.className = 'delete-btn';
        deleteBtn.textContent = 'Delete';

        btnDiv.appendChild(changeBtn);
        btnDiv.appendChild(deleteBtn);

        container.appendChild(h2);
        container.appendChild(h3Date);
        container.appendChild(h3Location);
        container.appendChild(btnDiv);

        changeBtn.addEventListener('click', () => {
            workoutInput.value = data.workout;
            locationInput.value = data.location;
            dateInput.value = data.date;

            currentEditId = data._id;

            editBtn.disabled = false;
            addBtn.disabled = true;

            list.removeChild(container);
        });

        deleteBtn.addEventListener('click', async () => {
            await fetch(BASE_URL + data._id, {
                method: 'DELETE'
            });
            loadWorkouts();
        });

        return container;
    }

    function clearInputs() {
        workoutInput.value = '';
        locationInput.value = '';
        dateInput.value = '';
    }
}

solve();
