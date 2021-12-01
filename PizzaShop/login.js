function login(e) {

    e.preventDefault();
    
    const data = {
        username: document.getElementById('username').value,
        password: document.getElementById('password').value,
    }

    const baseUrl = 'https://localhost:44342/api';
    let req = new Request(baseUrl + '/user',
        ({
            method: 'POST',
            headers: { 'Content-Type': 'application/json', },
            body: JSON.stringify(data)
        }));
    fetch(req)
        .then(res => {
            res.json().then(json => {
                localStorage.setItem('token', json.token);
                localStorage.setItem('id', json.id);
                localStorage.setItem('userName', json.userName);
            })
            redirectAction(res)
        })
        .catch(err => {
            console.log(err);
        });
}
//let btn = document.querySelector('#logBtn');
//btn.addEventListener('click', login);
document.getElementById('form-log').addEventListener('submit', login);



function redirectAction(response) {
        if (response.status == 200) {
            window.location.href="product.html";
        } else {
            let message = "Neispravan unos. Pokusajte ponovo.";
            let error = document.createElement("h3");
            error.textContent = message;
            let doc = document.querySelector(".log");
            doc.appendChild(error);
            let productContainer = document.querySelector(".error");
            productContainer.innerHTML = '';
            productContainer.innerHTML += `<i class="far fa-hand-paper"></i>`;
        }
}
