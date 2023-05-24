let Players = [];
let connection = null;
let oldid = null;
getdata();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:5417/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("PlayerCreated", (user, message) => {
        getdata();
    });
    connection.on("Playerpdated", (user, message) => {
        getdata();
    });

    connection.on("PlayerDeleted", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
    getdata();
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

async function getdata() {
    await fetch('http://localhost:5417/Player')
        .then(x => x.json())
        .then(y => {
            Players = y;
            console.log(Players);
            display();
        }).catch((error) => { console.error('Error:', error); });
    ;
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    Players.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.name + "</td><td>"+
            t.salary + "</td><td>" +
            t.teamID + "</td><td>" +
             t.position + "</td><td>" +
            `<button type="button" onclick="showupdate(${t.playerId})">Update</button>` +
            `<button type="button" onclick="remove(${t.playerId})">Delete</button>`
            + "</td></tr>";
        console.log(t.position);
    }).catch((error) => { console.error('Error:', error); });
    ;
}


function create() {
    let PlayerName = document.getElementById('PlayerName').value;
    let sal = document.getElementById('Salary').value;
    let tID = document.getElementById('teamID').value;
    let pos = document.getElementById('Pos').value;
    fetch('http://localhost:5417/Player', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: PlayerName, salary: sal, position: pos, teamID: tID })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}
function remove(id) {
    fetch('http://localhost:5417/Player/' + id, {
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


function showupdate(id) {
    let item = Players.find(t => t['playerId'] == id);
    console.log(item);
    oldid = item.playerId;
    document.getElementById("updateformdiv").style.display = "block";
    document.getElementById("PlayerNameupdate").value = item.name;
    document.getElementById("Positionupdate").value = item.position; 
    document.getElementById("TeamIDupdate").value = item.teamID; 
    document.getElementById('Salaryupdate').value = item.salary;
  
}
async function update() {
    let item = Players.find(t => t['playerId'] === oldid);
    let PlayerName = document.getElementById('PlayerNameupdate').value;
    let sal = document.getElementById('Salaryupdate').value;
    let pos = document.getElementById("Positionupdate").value;
    let teamid = document.getElementById("TeamIDupdate").value;





    await fetch('http://localhost:5417/Player', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { playerId: item.playerId, name: PlayerName, salary: sal, position: pos, teamID: teamid })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
            document.getElementById("updateformdiv").style.display = "none";

        })
        .catch((error) => { console.error('Error:', error); });
}
