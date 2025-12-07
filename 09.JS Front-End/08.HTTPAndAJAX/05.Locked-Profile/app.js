function lockedProfile() {

    let baseUrl = 'http://localhost:3030/jsonstore/advanced/profiles';
    let profileClass = document.getElementsByClassName('profile')[0];
    let main = document.getElementById('main');


    fetch(baseUrl)
        .then((res) => res.json())
        .then((data) => {
            for (i = 0; i < Object.entries(data).length - 1; i++) {
                const clone = profileClass.cloneNode(true);
                main.appendChild(clone);
            }
            for (i = 0; i < Object.entries(data).length; i++) {
                let userName = document.getElementsByName('user1Username')[i];
                userName.setAttribute('value', Object.entries(data)[i][1].username);
                let userEmail = document.getElementsByName('user1Email')[i];
                userEmail.setAttribute('value', Object.entries(data)[i][1].email);
                let userAge = document.getElementsByName('user1Age')[i];
                userAge.setAttribute('value', Object.entries(data)[i][1].age);
                let buttonCheck = document.getElementsByTagName("button")[i];
                buttonCheck.addEventListener('click', showHide);
            }

        });


    function showHide(event) {
        let button = event.target;
        let profile = button.parentNode;
        let moreInformation = profile.getElementsByTagName("div")[0];
        let lockStatus = profile.querySelector('input[type="radio"]:checked').value;

        if (lockStatus === "unlock") {
            if (button.textContent === "Show more") {
                moreInformation.style.display = "inline-block";
                button.textContent = "Hide it";
            } else if (button.textContent === "Hide it") {
                moreInformation.style.display = "none";
                button.textContent = "Show more";
            }

        }
    }

}