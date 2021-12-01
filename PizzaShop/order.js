function onLoadCartNumbers() {
  let productNumbers = localStorage.getItem('cartNumbers');
  
  if (productNumbers) {
    document.querySelector('.cart span').textContent = productNumbers;
  }
}
onLoadCartNumbers()

function displayCart() {
  let cartItems = localStorage.getItem("productInCart");
  cartItems = JSON.parse(cartItems);
  
  let productContainer = document.querySelector(".products");
  let cartCost = localStorage.getItem('totalCost');
  if(cartItems && productContainer) {
    productContainer.innerHTML = '';
    Object.values(cartItems).map(item => {
      productContainer.innerHTML += `
      <div class="grid-products" id="${item.id}">
        <span><img src="${item.imagePath}"></span>
        <span>${item.name}</span>
        <span>${item.price},00</span>
        <span>${item.quantity}</span>
        <span>${item.quantity * item.price},00</span>
        <span><button type="button" class="jsRemove">X</button></span>
      </div>
      `
    });
    productContainer.innerHTML += `
    <div class="totalBasket">
      <h3>Total Amount: ${cartCost},00 RSD</h3>
      <button class="post-order" type="submit" id="PostBtn">Submit Order</button>
      <button class="clear-order" id="ClearBtn">Clear Basket</button>
    </div>
    `;
  }
}

displayCart();

//rem
//document.querySelectorAll('.jsRemove').addEventListener('submit', postOrder);

var btnsRemove = document.querySelectorAll('.jsRemove');

btnsRemove.forEach(el=>el.addEventListener('click', function(e){
  removeItem(e.target.parentNode.parentNode)
}))

function removeItem(poslednjiElement) {
  console.log(poslednjiElement)
  var orderList = JSON.parse(localStorage.getItem('productInCart'));

  var orderKeys = Object.keys(orderList)

  for(var keyId in orderKeys){
    var key = orderKeys[keyId];
    if(orderList[key].id == poslednjiElement.id)
      {
        delete orderList[key]
      }
  }

  localStorage.removeItem('productInCart');
  orderListJson = JSON.stringify(orderList); //Restoring object into items again
  localStorage.setItem("productInCart", orderListJson);

  location.reload()
  //displayCart();
}

//rem

document.getElementById("ClearBtn").addEventListener("click", clearOrder);

function clearOrder(){
  localStorage.removeItem('cartNumbers');
  localStorage.removeItem('productInCart');
  localStorage.removeItem('totalCost');
  document.querySelector('.cart span').textContent = 0;
  let productContainer = document.querySelector(".products");
  productContainer.innerHTML = '';
  let message = "No orders selected. Plese visit Product page!";
  let success = document.createElement("h2");
  success.textContent = message;
  let doc = document.querySelector(".products");
  doc.appendChild(success);
}

document.getElementById("log-out").addEventListener("click", logOut);

function logOut() {
  localStorage.clear();
  window.location.href="login.html";
}




function postOrder(e) {

  e.preventDefault();

  var order = JSON.parse(localStorage.getItem('productInCart'));
  
  arr = [];
  var ordArr = Object.values(order) // [{id:3,quantity:4}] => [{productId: 3, quantity: 4}]
  ordArr.forEach(function (ordItem) {
    var newItem = {productId: ordItem.id, quantity: ordItem.quantity}
    arr.push(newItem);
  });

  const data = {
    orderItems: arr
  }

  const baseUrl = 'https://localhost:44342/api';
  let req = new Request(baseUrl + '/order',
    ({
      method: 'POST',
      headers: { 'Content-Type': 'application/json', },
      body: JSON.stringify(data)
    }));
  fetch(req)
    .then(res => {
      console.log(res);
      postResponse(res);
    })
    .catch(err => {
      console.log(err);
    });
}
//let btn = document.querySelector('#PostBtn');
//btn.addEventListener('click', postOrder);
document.getElementById('form').addEventListener('submit', postOrder);


function postResponse(response) {
  if (response.status == 200) {
    localStorage.removeItem('cartNumbers');
    localStorage.removeItem('productInCart');
    localStorage.removeItem('totalCost');
    document.querySelector('.cart span').textContent = 0;
    let prContainer = document.querySelector(".products");
    prContainer.innerHTML = '';
    let message = "Vasa porudzbina je uspesno poslata";
    let success = document.createElement("h2");
    success.textContent = message;
    let doc = document.querySelector(".product-container");
    doc.appendChild(success);
    let productContainer = document.querySelector(".error");
    productContainer.innerHTML = '';
    productContainer.innerHTML += `<i class="fa fa-thumbs-up"></i>`;
  } else {
      let message = "Greska prilikom slanja porudzbine. Pokusajte ponovo.";
      let error = document.createElement("h3");
      error.textContent = message;
      let doc = document.querySelector(".product-container");
      doc.appendChild(error);
      let productContainer = document.querySelector(".error");
      productContainer.innerHTML = '';
      productContainer.innerHTML += `<i class="fa fa-thumbs-down"></i>`;
  }
}

function onLoadUserName() {
  let userName = localStorage.getItem('userName');
  
  if (userName) {
    document.querySelector('.fa-user').textContent = " User " + userName;
  }
}
onLoadUserName()