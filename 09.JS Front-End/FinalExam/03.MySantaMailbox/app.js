const ENDPOINTS = {
    GIFTS: 'http://localhost:3030/jsonstore/gifts',
    GIFT_BY_ID: (id) => `http://localhost:3030/jsonstore/gifts/${id}`,
};

const giftList = document.getElementById('gift-list');
const loadPresentsBtn = document.getElementById('load-presents');
const addPresentBtn = document.getElementById('add-present');
const editPresentBtn = document.getElementById('edit-present');

const giftInput = document.getElementById('gift');
const forWhomInput = document.getElementById('for-whom');
const priceInput = document.getElementById('price');

let currentGiftId = null;

function attachEventListeners() {
    loadPresentsBtn.addEventListener('click', loadPresents);
    addPresentBtn.addEventListener('click', onAddPresent);
    editPresentBtn.addEventListener('click', onEditPresent);

    editPresentBtn.disabled = true;
}

async function loadPresents() {
    giftList.innerHTML = '';

    try {
        const response = await fetch(ENDPOINTS.GIFTS);
        const data = await response.json();

        const gifts = Object.values(data);

        gifts.forEach(gift => {
            const giftElement = createGiftElement(gift);
            giftList.appendChild(giftElement);
        });

    } catch (error) {
        console.error('Error loading presents:', error);
    }
}

function createGiftElement(gift) {
    const giftBox = document.createElement('div');
    giftBox.className = 'gift-box';

    const contentDiv = document.createElement('div');
    contentDiv.className = 'content';

    const giftP = document.createElement('p');
    giftP.textContent = gift.gift;

    const priceP = document.createElement('p');
    priceP.textContent = gift.price;

    const forWhomP = document.createElement('p');
    forWhomP.textContent = gift.forWhom;

    contentDiv.appendChild(giftP);
    contentDiv.appendChild(priceP);
    contentDiv.appendChild(forWhomP);

    const buttonsContainer = document.createElement('div');
    buttonsContainer.className = 'buttons-container';

    const changeBtn = document.createElement('button');
    changeBtn.className = 'change-btn';
    changeBtn.textContent = 'Change';
    changeBtn.addEventListener('click', () => onChange(gift, giftBox));

    const deleteBtn = document.createElement('button');
    deleteBtn.className = 'delete-btn';
    deleteBtn.textContent = 'Delete';
    deleteBtn.addEventListener('click', () => onDelete(gift._id));

    buttonsContainer.appendChild(changeBtn);
    buttonsContainer.appendChild(deleteBtn);

    giftBox.appendChild(contentDiv);
    giftBox.appendChild(buttonsContainer);

    return giftBox;
}

async function onAddPresent(event) {
    event.preventDefault();

    const newGift = {
        gift: giftInput.value,
        forWhom: forWhomInput.value,
        price: priceInput.value,
    };

    if (Object.values(newGift).some(x => x.trim() === '')) {
        return;
    }

    try {
        const response = await fetch(ENDPOINTS.GIFTS, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(newGift),
        });

        if (response.ok) {
            clearInputs();
            await loadPresents();
        }

    } catch (error) {
        console.error('Error adding gift:', error);
    }
}

function onChange(gift, giftBoxElement) {
    giftInput.value = gift.gift;
    forWhomInput.value = gift.forWhom;
    priceInput.value = gift.price;

    giftBoxElement.remove();

    currentGiftId = gift._id;

    editPresentBtn.disabled = false;
    addPresentBtn.disabled = true;
}

async function onEditPresent(event) {
    event.preventDefault();

    const editedGift = {
        gift: giftInput.value,
        forWhom: forWhomInput.value,
        price: priceInput.value,
        _id: currentGiftId
    };

    if (!currentGiftId) return;

    try {
        const response = await fetch(ENDPOINTS.GIFT_BY_ID(currentGiftId), {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(editedGift),
        });

        if (response.ok) {
            clearInputs();
            resetFormState();
            await loadPresents();
        }

    } catch (error) {
        console.error('Error editing gift:', error);
    }
}

async function onDelete(id) {
    try {
        const response = await fetch(ENDPOINTS.GIFT_BY_ID(id), {
            method: 'DELETE',
        });

        if (response.ok) {
            await loadPresents();
        }

    } catch (error) {
        console.error('Error deleting gift:', error);
    }
}

function clearInputs() {
    giftInput.value = '';
    forWhomInput.value = '';
    priceInput.value = '';
}

function resetFormState() {
    currentGiftId = null;
    editPresentBtn.disabled = true;
    addPresentBtn.disabled = false;
}

attachEventListeners();