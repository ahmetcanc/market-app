
let buy = document.getElementById("product-buy");

$(document).ready(function () {
	var productItem = [{
			productName: product-name,
			price: product-price,
			photo: product-quantity
		},
		{
			productName: "EXP Portable Hard Drive",
			price: "800.00",
			photo: "external-hard-drive.jpg"
		},
		{
			productName: "Luxury Ultra thin Wrist Watch",
			price: "500.00",
			photo: "laptop.jpg"
		},
		{
			productName: "XP 1155 Intel Core Laptop",
			price: "1000.00",
			photo: "watch.jpg"
		}];
	showProductGallery(productItem);
	showCartTable();
});

function addToCart() {
	var productParent = $(event.target).closest('div');

	var price = productParent.find('[name="product-price"]').val();
	var productName = productParent.find('[name="product-name"]').val();
	var quantity = parseInt(productParent.find('[data-name="product-quantity"]').val());

	var cartArray = new Array();
	// If javascript shopping cart session is not empty
	if (sessionStorage.getItem('shopping-cart')) {
		cartArray = JSON.parse(sessionStorage.getItem('shopping-cart'));
	}

	// check if the product already exists in the cart
	var productIndex = -1;
	for (var i = 0; i < cartArray.length; i++) {
		var cartItem = JSON.parse(cartArray[i]);
		if (cartItem.productName === productName) {
			productIndex = i;
			break;
		}
	}

	if (productIndex === -1) {
		// if the product does not exist in the cart, add it as a new item
		var cartItem = {
			productName: productName,
			price: price,
			quantity: quantity
		};
		cartArray.push(JSON.stringify(cartItem));
	} else {
		// if the product exists in the cart, increase its quantity
		var cartItem = JSON.parse(cartArray[productIndex]);
		cartItem.quantity += quantity;
		cartArray[productIndex] = JSON.stringify(cartItem);
	}

	var cartJSON = JSON.stringify(cartArray);
	sessionStorage.setItem('shopping-cart', cartJSON);
	console.log("Ürün adı: " + productName);
	console.log("Fiyat: " + price);
	console.log("Miktar: " + quantity);
	showCartTable();
}



function removeCartItem(index) {
	if (sessionStorage.getItem('shopping-cart')) {
		var shoppingCart = JSON.parse(sessionStorage.getItem('shopping-cart'));
		sessionStorage.removeItem(shoppingCart[index]);
		showCartTable();
	}
}

function showCartTable() {
	var cartRowHTML = "";
	var itemCount = 0;
	var grandTotal = 0;

	var productName = 0;
	var price = 0;
	var quantity = 0;
	var subTotal = 0;

	if (sessionStorage.getItem('shopping-cart')) {
		var shoppingCart = JSON.parse(sessionStorage.getItem('shopping-cart'));
		itemCount = shoppingCart.length;

		//Iterate javascript shopping cart array
		shoppingCart.forEach(function(item) {
			var cartItem = JSON.parse(item);
			productName = cartItem.productName;
			price = parseFloat(cartItem.price);
			quantity = parseInt(cartItem.quantity);
			subTotal = price * quantity

			cartRowHTML += "<tr>" +
				"<td>" + productName + "</td>" +
				"<td class='text-right'>$" + price.toFixed(2) + "</td>" +
				"<td class='text-right'>" + quantity + "</td>" +
				"<td class='text-right'>$" + subTotal.toFixed(2) + "</td>" +
				"</tr>";

			grandTotal += subTotal;
		});
	}

	$('#cartTableBody').html(cartRowHTML);
	$('#itemCount').text(itemCount);
	$('#totalAmount').text("$" + grandTotal.toFixed(2));
}

function showProductGallery(product) {
	//Iterate javascript shopping cart array
	var productHTML = "";
	product.forEach(function (item) {
		productHTML += '<div class="product-item">' +
			'<img src="product-images/' + item.photo + '">' +
			'<div class="productname">' + item.productName + '</div>' +
			'<div class="price">$<span>' + item.price + '</span></div>' +
			'<div class="cart-action">' +
			'<input type="text" class="product-quantity" name="quantity" value="1" size="2" />' +
			'<input type="submit" value="Add to Cart" class="add-to-cart" onClick="addToCart(this)" />' +
			'</div>' +
			'</div>';
		"<tr>";

	});
	$('#product-item-container').html(productHTML);
}



function clearCart() {
	// Sepetteki öğeleri içeren bir dizi oluşturun veya alın
	var cartItems = JSON.parse(sessionStorage.getItem('shopping-cart'));

	// Eğer sepet boş ise, herhangi bir işlem yapmayın
	if (!cartItems || cartItems.length == 0) {
		return;
	}

	// Sepet dizi değişkenini boş bir dizi olarak ayarlayın
	cartItems = [];

	// Sepet tablosundaki satırları temizleyin veya silin
	var cartTableBody = document.getElementById('cartTableBody');
	cartTableBody.innerHTML = '';

	// Toplam ürün sayısını ve toplam tutarı sıfırlayın veya güncelleyin
	document.getElementById('itemCount').innerHTML = '0';
	document.getElementById('totalAmount').innerHTML = '0.00';

	// Sepeti güncellemek için değişiklikleri kaydedin
	sessionStorage.setItem('shopping-cart', JSON.stringify(cartItems));
}

function buyFunction(element) {
	var shoppingCartItems = JSON.parse(sessionStorage.getItem('shopping-cart'));

	if (shoppingCartItems) {
		var productNames = [];
		var quantities = [];

		shoppingCartItems.forEach(function (item) {
			var cartItem = JSON.parse(item);
			productNames.push(cartItem.productName);
			quantities.push(cartItem.quantity);
		});

		var totalPrice = 0;
		shoppingCartItems.forEach(function (item) {
			var cartItem = JSON.parse(item);
			totalPrice += cartItem.price * cartItem.quantity;
		});

		
		var dataToSend = {
			productNames: productNames,
			quantities: quantities,
			totalPrice: totalPrice.toFixed(2)
		};

		// AJAX isteği gönderin
		$.ajax({
			url: '/Deneme/Index',
			type: 'POST',
			data: JSON.stringify(dataToSend),
			contentType: 'application/json; charset=utf-8',
			dataType: 'json',
			success: function (response) {
				console.log(response);
			},
			error: function (xhr, status, error) {
				console.error(error);
			}
		});
		
		console.log(JSON.stringify(dataToSend))

	}
	
}