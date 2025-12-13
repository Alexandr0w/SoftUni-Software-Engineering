window.addEventListener("load", solve);

function solve() {
  const emailInput = document.getElementById('email');
  const eventInput = document.getElementById('event');
  const locationInput = document.getElementById('location');

  const nextBtn = document.getElementById('next-btn');
  const previewList = document.getElementById('preview-list');
  const eventList = document.getElementById('event-list');

  nextBtn.addEventListener('click', onNext);

  function onNext() {
      const email = emailInput.value.trim();
      const eventName = eventInput.value.trim();
      const location = locationInput.value.trim();

      if (!email || !eventName || !location) {
          return;
      }

      const li = document.createElement('li');
      li.className = 'application';

      const article = document.createElement('article');

      const h4 = document.createElement('h4');
      h4.textContent = email;

      const pEvent = document.createElement('p');
      pEvent.textContent = `Event:${eventName}`;

      const pLocation = document.createElement('p');
      pLocation.textContent = `Location:${location}`;

      article.appendChild(h4);
      article.appendChild(pEvent);
      article.appendChild(pLocation);

      const editBtn = document.createElement('button');
      editBtn.className = 'action-btn edit';
      editBtn.textContent = 'Edit';

      const applyBtn = document.createElement('button');
      applyBtn.className = 'action-btn apply';
      applyBtn.textContent = 'Apply';

      li.appendChild(article);
      li.appendChild(editBtn);
      li.appendChild(applyBtn);

      previewList.appendChild(li);
      nextBtn.disabled = true;

      emailInput.value = '';
      eventInput.value = '';
      locationInput.value = '';

      editBtn.addEventListener('click', () => {
          emailInput.value = email;
          eventInput.value = eventName;
          locationInput.value = location;

          previewList.removeChild(li);
          nextBtn.disabled = false;
      });

      applyBtn.addEventListener('click', () => {
          previewList.removeChild(li);
          li.removeChild(editBtn);
          li.removeChild(applyBtn);
          eventList.appendChild(li);
          nextBtn.disabled = false;
      });
  }
}

