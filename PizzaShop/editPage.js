const baseUrl = 'https://localhost:44342/api';
function editStudents(id) {
    let token = localStorage.getItem('token')
    let headers = {
        'Authorization': 'Bearer ' + token
    };
    let inputId = document.querySelector('#inputId');
    const data = {
      name: document.getElementById('name').value,
      address: document.getElementById('address').value,
      email: document.getElementById('email').value
    }
    if (!id) {
      id = inputId.value;
    }
    const req = new Request(baseUrl + '/Customer/id',
      ({
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', headers},
        body: JSON.stringify(data)
      }));
    fetch(req)
      .then(res => {
        console.log(res);
      })
      .catch(err => {
        console.log(err);
      })
  }
  
 

  const editBtn = document.querySelector('#editBtn');
  editBtn.addEventListener('click', function () {
    editStudents();
  })

  function postStudent(e) {
    e.preventDefault();
    let token = localStorage.getItem('token')
    let headers = {
        'Authorization': 'Bearer ' + token
    };
    const data = {
      name: document.getElementById('name').value,
      address: document.getElementById('address').value,
      email: document.getElementById('email').value,
    }
  
    let req = new Request(baseUrl + '/Customer/id',
      ({
        method: 'POST',
        headers: { 'Content-Type': 'application/json', headers},
        body: JSON.stringify(data)
      }));
    fetch(req)
      .then(res => {
        console.log(res);
        //getProducts();
      })
      .catch(err => {
        console.log(err);
      });
  }

  document.getElementById('form').addEventListener('submit', postStudent);


  document.getElementById("log-out").addEventListener("click", logOut);

    function logOut() {
    localStorage.clear();
    window.location.href="login.html";
    }