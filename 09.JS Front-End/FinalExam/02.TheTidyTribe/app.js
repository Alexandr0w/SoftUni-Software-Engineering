window.addEventListener("load", solve);

function solve() {
  const placeInput = document.getElementById('place');
  const actionInput = document.getElementById('action');
  const personInput = document.getElementById('person');

  const addBtn = document.getElementById('add-btn');
  const taskList = document.getElementById('task-list');
  const doneList = document.getElementById('done-list');

  addBtn.addEventListener('click', function () {
      const place = placeInput.value.trim();
      const action = actionInput.value.trim();
      const person = personInput.value.trim();

      if (place === '' || action === '' || person === '') {
          return;
      }

      const li = document.createElement('li');
      li.className = 'clean-task';

      const article = document.createElement('article');

      const pPlace = document.createElement('p');
      pPlace.textContent = `Place:${place}`;

      const pAction = document.createElement('p');
      pAction.textContent = `Action:${action}`;

      const pPerson = document.createElement('p');
      pPerson.textContent = `Person:${person}`;

      article.appendChild(pPlace);
      article.appendChild(pAction);
      article.appendChild(pPerson);

      const btnDiv = document.createElement('div');
      btnDiv.className = 'buttons';

      const editBtn = document.createElement('button');
      editBtn.className = 'edit';
      editBtn.textContent = 'Edit';

      const doneBtn = document.createElement('button');
      doneBtn.className = 'done';
      doneBtn.textContent = 'Done';

      btnDiv.appendChild(editBtn);
      btnDiv.appendChild(doneBtn);

      li.appendChild(article);
      li.appendChild(btnDiv);

      taskList.appendChild(li);

      placeInput.value = '';
      actionInput.value = '';
      personInput.value = '';

      editBtn.addEventListener('click', function () {
          placeInput.value = place;
          actionInput.value = action;
          personInput.value = person;

          taskList.removeChild(li);
      });

      doneBtn.addEventListener('click', function () {
          taskList.removeChild(li);

          const doneLi = document.createElement('li');

          const doneArticle = document.createElement('article');
          doneArticle.appendChild(pPlace);
          doneArticle.appendChild(pAction);
          doneArticle.appendChild(pPerson);

          const deleteBtn = document.createElement('button');
          deleteBtn.className = 'delete';
          deleteBtn.textContent = 'Delete';

          doneLi.appendChild(doneArticle);
          doneLi.appendChild(deleteBtn);

          doneList.appendChild(doneLi);

          deleteBtn.addEventListener('click', function () {
              doneList.removeChild(doneLi);
          });
      });
  });
}
