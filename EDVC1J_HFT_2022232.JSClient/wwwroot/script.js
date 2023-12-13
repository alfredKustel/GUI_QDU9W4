
let chefs = [];
let connection = null;

let chefidtoupdate = -1

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
    await fetch('http://localhost:49326/chef')
        .then(x => x.json())
        .then(y => {
            chefs = y;
            //console.log(chefs);
            //window.onload();
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    chefs.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
            + t.name + "</td><td>" +
                `<button type="button" onclick="removechef(${t.id})">Delete</button>`
            +
             `<button type="button" onclick="showupdate(${t.id})">Update</button>`
            +
            "</td></tr>";
    });
}

function showupdate(id)
{
    document.getElementById('chefnametoupdate').value = chefs.find(t => t['id'] == id)['name'];
    document.getElementById('updateformdiv').style.display = 'flex';
    chefidtoupdate = id;

}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let name = document.getElementById('chefnametoupdate').value;
    fetch('http://localhost:49326/chef', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Name: name , ID : chefidtoupdate})
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

function create() {
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