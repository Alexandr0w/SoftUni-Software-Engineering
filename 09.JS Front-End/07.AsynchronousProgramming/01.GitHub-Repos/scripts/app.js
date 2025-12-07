async function loadRepos() {
   const divElement = document.getElementById('res');

   const res = await fetch("https://api.github.com/users/testnakov/repos");
   const data = await res.text();

   divElement.textContent = data;
}