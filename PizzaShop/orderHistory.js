const baseUrl = 'https://localhost:44342/api';
function getMyOrders() {
  let token = localStorage.getItem('token')
  let headers = {
    'Authorization': 'Bearer ' + token
  };
  
  let req = new Request(baseUrl + '/Order/myOrders', ({ method: 'GET', 'Content-Type': 'application/json', headers}));

  fetch(req)
    .then(res => {
        // console.log('res', res)
        if (res.ok) {
          
          return res.json();
        } else {
          throw 'Doslo je do greske';
        }
      })
      .then(arr => {
        renderList(arr);
        console.log(arr);
        //console.log('resolved second promise', arr);
      })
    .catch(err => {
      console.log(err);
    })
}
getMyOrders();

function renderList(arr) {
    const list = document.querySelector('.wrapper');
    arr.forEach(element => {
      const cont = document.createElement('div');
      cont.className = 'order-wrapper';
  
      const name = document.createElement('h2');
      name.textContent = "Order Number: " + element.number;

      const date = document.createElement('p');
      date.textContent = "Date: " + element.date;

      // const quantity = document.createElement('p');
      // quantity.textContent = element.quant;
  
      const totalAmount = document.createElement('p');
      totalAmount.className = 'total';
      totalAmount.textContent = "Total Amount: " + element.totalAmount + ",00" + " " + "RSD";
        
      let ordItems = document.createElement("div");
      ordItems.className = 'ord-items';
      let textItems = document.createElement("h3");
      textItems.textContent = "Order List: ";
      // var ordArr = Object.values(element.orderItems) 
      // ordArr.forEach(el => {
      //   var quant = {quantity: el.quantity}
      //   console.log(quant)
      // })

    
      cont.appendChild(name);
      cont.appendChild(date);
      //cont.appendChild(productItem);
      cont.appendChild(totalAmount);
      cont.appendChild(ordItems);
      ordItems.appendChild(textItems);
      list.appendChild(cont);

      //const productItem = document.createElement('div');

      element.orderItems.forEach((p) =>{
        let productItem = document.createElement("div");
        productItem.className = "product-item";

        let prodName = document.createElement("h4");
        prodName.textContent = p.product.productName;
        let prodPrice = document.createElement("p");
        prodPrice.textContent = "price: " + p.product.unitPrice;
        let prodSize = document.createElement("p");
        prodSize.textContent = "size: " + p.product.size;
        
        productItem.appendChild(prodName);
        productItem.appendChild(prodPrice);
        productItem.appendChild(prodSize);
        ordItems.appendChild(productItem);
      })
    });
    }





    document.getElementById("log-out").addEventListener("click", logOut);

    function logOut() {
    localStorage.clear();
    window.location.href="login.html";
    }