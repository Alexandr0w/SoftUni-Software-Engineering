async function loadCommits() {
    const usernameInputEl = document.getElementById('username');
    const repoInputEl = document.getElementById('repo');
    const commitsUlEl = document.getElementById('commits');

    const username = usernameInputEl.value.trim();
    const repo = repoInputEl.value.trim();

    const res = await fetch(`https://api.github.com/repos/${username}/${repo}/commits`);
    
    commitsUlEl.innerHTML = '';

    if (!res.ok) {
        const liEl = document.createElement('li');
        liEl.textContent = `Error: ${res.status} (Not Found)`;
        commitsUlEl.appendChild(liEl);
        return;
    }
    
    const data = await res.json();

    for (const commitObj of data) {
        const liEl = document.createElement('li');
        liEl.textContent = `${commitObj.commit.author.name}: ${commitObj.commit.message}`;
        commitsUlEl.appendChild(liEl);
    }
} 