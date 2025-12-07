async function loadRepos() {
	const usernameInputElement = document.getElementById('username');
	const reposUlElement = document.getElementById('repos');

	const username = usernameInputElement.value.trim();

	const rest = await fetch(`https://api.github.com/users/${username}/repos`);
	const data = await rest.json();
	console.log(data);

	reposUlElement.innerHTML = '';

	for (let repoObj of data) {
		const liElement = document.createElement('li');
		const aElement = document.createElement('a');

		aElement.textContent = repoObj.full_name;
		aElement.href = repoObj.html_url;

		liElement.appendChild(aElement);
		reposUlElement.appendChild(liElement);
	}
}