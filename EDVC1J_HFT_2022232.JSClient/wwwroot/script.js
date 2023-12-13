﻿let chefs = [];
let connection = null;
getdata();
setupSignalR();

async function getdata() {
    await fetch('http://localhost:49326/chef')
        .then(x => x.json())
        .then(y => {
            chefs = y;
           
            display();
        });
}

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:53910/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("ActorCreated", (user, message) => {
        getdata();
    });

    connection.on("ActorDeleted", (user, message) => {
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
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};


function remove(id) {
    fetch('http://localhost:53910/chef' + id, {
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



function display()
{
    document.getElementById('resultarea').innerHTML = "";
    chefs.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.ID + "</td><td>"
            + t.Name + "</td><td>"
            + t.Age + "</td><td>"
        + t.RestaurantID + "</td></td>"
        +
        `<button type="button" onclick="remove(${t.ID})">Delete</button>`
        + "</td></tr>";
       
    });
}

function create()
{
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