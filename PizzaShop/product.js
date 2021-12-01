const baseUrl = 'https://localhost:44342/api';
function getProducts() {
  let token = localStorage.getItem('token')
  let headers = {
    'Authorization': 'Bearer ' + token
  };
  
  let req = new Request(baseUrl + '/product', ({ method: 'GET', headers}));

  fetch(req)
    .then(res => {
      console.log('res', res)
      if (res.ok) {
        return res.json();
      } else {
        throw 'Doslo je do greske';
      }
    })
    .then(arr => {
      renderList(arr);
      console.log('resolved second promise', arr);
    })
    .catch(err => {
      console.log(err);
    })
}
getProducts();

function renderList(arr) {
  const list = document.querySelector('.list');
  arr.forEach(element => {
    const cont = document.createElement('div');
    cont.className = 'card';

    const name = document.createElement('h1');
    name.textContent = element.name;

    const price = document.createElement('p');
    price.className = 'price';
    price.textContent = element.price + ",00" + " " + "RSD";

    const photo = document.createElement('img');
    photo.setAttribute('src', element.imagePath);

    const size = document.createElement('p');
    size.textContent = element.size;

    // const orderItems = document.createElement('p');
    // orderItems.textContent = element.orderItems;

    // const is_active = document.createElement('p');
    // is_active.textContent = element.is_active;
    // is_active.className = 'active';

    // const is_deleted = document.createElement('p');
    // is_deleted.textContent = element.is_deleted;
    // is_deleted.className = 'deleted';

    // const discounted = document.createElement('p');
    // discounted.textContent = element.discounted;
    // discounted.className = 'discounted';

    const addBtn = document.createElement('button');
    addBtn.textContent = 'Add';
    addBtn.className = 'add';
    addBtn.addEventListener('click', function () {
      cartNumbers(element);
      totalCost(element);
    })


    cont.appendChild(photo);
    cont.appendChild(name);
    cont.appendChild(price);
    cont.appendChild(size);
    // cont.appendChild(orderItems);
    // cont.appendChild(is_active);
    // cont.appendChild(is_deleted);
    // cont.appendChild(discounted);
    cont.appendChild(addBtn);
    list.appendChild(cont);
  });
}


function onLoadCartNumbers() {
  let productNumbers = localStorage.getItem('cartNumbers');

  if (productNumbers) {
    document.querySelector('.cart span').textContent = productNumbers;
  }
}
function cartNumbers(product) {
  let productNumbers = localStorage.getItem('cartNumbers');

  productNumbers = parseInt(productNumbers);

  if (productNumbers) {
    localStorage.setItem('cartNumbers', productNumbers + 1);
    document.querySelector('.cart span').textContent = productNumbers + 1;
  } else {
    localStorage.setItem('cartNumbers', 1);
    document.querySelector('.cart span').textContent = 1;
  }

  setItems(product);
}

function setItems(product) {
  
  let cartItems = localStorage.getItem("productInCart");
  cartItems = JSON.parse(cartItems);
  product.quantity = 0;
  if (cartItems != null) {
    if (cartItems[product.name] == undefined) {
      cartItems = {
        ...cartItems,
        [product.name]: product
      }
    }
    
    cartItems[product.name].quantity += 1;
  } else {
    product.quantity = 1;
    cartItems = {
      [product.name]: product
    }
  }
  localStorage.setItem("productInCart", JSON.stringify(cartItems));
}

// function displayCart() {
//   let cartItems = localStorage.getItem("productInCart");
//   cartItems = JSON.parse(cartItems);
//   inCart = 1;
//   let productContainer = document.querySelector(".products");
//   let cartCost = localStorage.getItem('totalCost');
//   if(cartItems && productContainer) {
//     productContainer.innerHTML = '';
//     Object.values(cartItems).map(item => {
//       productContainer.innerHTML += `
//       <div class="grid-products">
//         <span>${item.name}</span>
//         <span>${item.price},00</span>
//         <span class="quantity"><h2><  </h2>${item.inCart}<h2>  ></h2></span>
//         <span>${item.inCart * item.price},00</span>
//       </div>
//       `
//     });
//     productContainer.innerHTML += `
//     <div class="totalBasket">
//       <h3>Total Amount: ${cartCost},00 RSD</h3>
//       <button class="post-order" type="submit" id="PostBtn">Submit Order</button>
//     </div>
//     `;
//   }
//  }
// displayCart();

function totalCost(product) {
  console.log("product price is ", product.price);
  let cartCost = localStorage.getItem('totalCost');

  if (cartCost != null) {
    cartCost = parseInt(cartCost);
    localStorage.setItem("totalCost", cartCost + product.price);
  } else {
    localStorage.setItem("totalCost", product.price)
  }
}

onLoadCartNumbers();

function onLoadUserName() {
  let userName = localStorage.getItem('userName');
  
  if (userName) {
    document.querySelector('.fa-user').textContent = " User " + userName;
  }
}
onLoadUserName()

document.getElementById("log-out").addEventListener("click", logOut);

function logOut() {
  localStorage.clear();
  window.location.href="login.html";
}

// function getOrders() {
//   let req = new Request(baseUrl + '/order', ({ method: 'GET' }));

//   fetch(req)
//     .then(res => {
//       console.log('res', res)
//       if (res.ok) {
//         return res.json();
//       } else {
//         throw 'Doslo je do greske';
//       }
//     })
//     .then(arr => {
//       //renderList(arr);
//       console.log('resolved second promise', arr);
//     })
//     .catch(err => {
//       console.log(err);
//     })
// }
// getOrders();


// function postOrder(e) {

//   e.preventDefault();

//   const data = {
//     // productId: JSON.parse(localStorage.getItem('productInCart', 'id')),
//     // quantity: JSON.parse(localStorage.getItem('productInCart', 'inCart')),
//     totalAmount: JSON.parse(localStorage.getItem('totalCost'))
//   }

//   let req = new Request(baseUrl + '/order',
//     ({
//       method: 'POST',
//       headers: { 'Content-Type': 'application/json', },
//       body: JSON.stringify(data)
//     }));
//   fetch(req)
//     .then(res => {
//       console.log(res);
//     })
//     .catch(err => {
//       console.log(err);
//     });
// }
// //let btn = document.querySelector('#PostBtn');
// //btn.addEventListener('click', postOrder);
// document.getElementById('form').addEventListener('submit', postOrder);

