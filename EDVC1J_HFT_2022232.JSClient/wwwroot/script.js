
let chefs = [];
let restaurants = [];
let Receipts = [];
let connection = null;

let chefidtoupdate = -1;
let restaurantidtoupdate = -1;
let receipttoupdate = -1;

getdata();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:49326/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("ChefCreated", (user, message) => {
        getdata();
    });

    connection.on("ChefDeleted", (user, message) => {
        getdata();
    });

    connection.on("ChefUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();


}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
        getdata();
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
    
};

async function getdata() {
    await fetch('http://localhost:49326/restaurant')
        .then(x => x.json())
        .then(y => {
            restaurants = y;
            console.log(restaurants);
            //window.onload();
            displayrestaurant();
        });

    await fetch('http://localhost:49326/chef')
        .then(x => x.json())
        .then(y => {
            chefs = y;
            console.log(chefs);
            //window.onload();
            displaychef();
        });

    await fetch('http://localhost:49326/receipt')
        .then(x => x.json())
        .then(y => {
            receipts = y;
            console.log(receipts);
            //window.onload();
            displayreceipts();
        });


}

function displaychef() {
    document.getElementById('chefresultarea').innerHTML = "";
    chefs.forEach(t => {
        document.getElementById('chefresultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
            + t.name + "</td><td>" +
                `<button type="button" onclick="removechef(${t.id})">Delete</button>`
            +
             `<button type="button" onclick="showchefpdate(${t.id})">Update</button>`
            +
            "</td></tr>";
    });
}

function displayrestaurant() {
    document.getElementById('restaurantresultarea').innerHTML = "";
    restaurants.forEach(t => {
        document.getElementById('restaurantresultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
            + t.name + "</td><td>" +
            `<button type="button" onclick="removrestaurant(${t.id})">Delete</button>`
            +
            `<button type="button" onclick="showrestaurantupdate(${t.id})">Update</button>`
            +
            "</td></tr>";
    });
}

function displayreceipts() {
    document.getElementById('receipttresultarea').innerHTML = "";
    receipts.forEach(t => {
        document.getElementById('receipttresultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
            + t.name + "</td><td>" +
            `<button type="button" onclick="removereceipt(${t.id})">Delete</button>`
            +
            `<button type="button" onclick="showreceiptupdate(${t.id})">Update</button>`
            +
            "</td></tr>";
    });
}

function showchefpdate(id)
{
    document.getElementById('chefnametoupdate').value = chefs.find(t => t['id'] == id)['name'];
    document.getElementById('updatechefformdiv').style.display = 'flex';
    chefidtoupdate = id;

}

function cehfupdate() {
    document.getElementById('updatechefformdiv').style.display = 'none';
    let name = document.getElementById('chefnametoupdate').value;
    fetch('http://localhost:49326/chef', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Name: name, ID: chefidtoupdate })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function showrestaurantupdate(id) {
    document.getElementById('restaurantnametoupdate').value = restaurants.find(t => t['id'] == id)['name'];
    document.getElementById('updaterestaurantformdiv').style.display = 'flex';
    restaurantidtoupdate = id;

}

function showreceiptupdate(id) {
    document.getElementById('receiptnametoupdate').value = receipts.find(t => t['id'] == id)['name'];
    document.getElementById('updatereceiptformdiv').style.display = 'flex';
    receiptidtoupdate = id;

}



function restaurantupdate() {
    document.getElementById('updaterestaurantformdiv').style.display = 'none';
    let name = document.getElementById('restaurantnametoupdate').value;
    fetch('http://localhost:49326/restaurant', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Name: name, ID: restaurantidtoupdate })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function receiptupdate() {
    document.getElementById('updatereceiptformdiv').style.display = 'none';
    let name = document.getElementById('receiptnametoupdate').value;
    fetch('http://localhost:49326/receipt', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Name: name, ID: receiptidtoupdate })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function removechef(id) {
    fetch('http://localhost:49326/chef/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function removereceipt(id) {
    fetch('http://localhost:49326/receipt/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function removrestaurant(id) {
    fetch('http://localhost:49326/restaurant/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function chefcreate() {
    let name = document.getElementById('chefname').value;
    fetch('http://localhost:49326/chef', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Name: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function restaurantcreate() {
    let name = document.getElementById('restaurantname').value;
    fetch('http://localhost:49326/restaurant', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Name: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function receiptcreate() {
    let name = document.getElementById('receiptname').value;
    fetch('http://localhost:49326/receipt', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Name: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}