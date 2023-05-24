let Coaches = [];
let connection = null;
let oldid = null;
getdata();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:5417/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("CoachCreated", (user, message) => {
        getdata();
    });
    connection.on("Coachpdated", (user, message) => {
        getdata();
    });

    connection.on("CoachDeleted", (user, message) => {
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
    await fetch('http://localhost:5417/Coach')
        .then(x => x.json())
        .then(y => {
            Coaches = y;
            console.log(Coaches);
            display();
        }).catch((error) => { console.error('Error:', error); });
    ;
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    Coaches.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.coachName + "</td><td>" +
            t.salary + "</td><td>" +
            t.teamID + "</td><td>" +
         
            `<button type="button" onclick="showupdate(${t.coachId})">Update</button>` +
            `<button type="button" onclick="remove(${t.coachId})">Delete</button>`
            + "</td></tr>";
       
    }).catch((error) => { console.error('Error:', error); });
    ;
}


function create() {
    let cName = document.getElementById('CoachName').value;
    let sal = document.getElementById('Salary').value;
    let tID = document.getElementById('teamID').value;
    // let pos = document.getElementById('Pos').value;
    fetch('http://localhost:5417/Coach', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { coachName: cName, salary: sal, teamID: tID })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}
function remove(id) {
    fetch('http://localhost:5417/Coach/' + id, {
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
    let item = Coaches.find(t => t['coachId'] == id);
    console.log(item);
    console.log(oldid);
    oldid = item.coachId;
    document.getElementById("updateformdiv").style.display = "block";
    document.getElementById("CoachNameupdate").value = item.coachName;
    
    document.getElementById("TeamIDupdate").value = item.teamID;
    document.getElementById('Salaryupdate').value = item.salary;

}
async function update() {
    let item = Coaches.find(t => t['coachId'] === oldid);
    let PlayerName = document.getElementById('CoachNameupdate').value;
    let sal = document.getElementById('Salaryupdate').value;
    let teamid = document.getElementById("TeamIDupdate").value;
    console.log(item);





    await fetch('http://localhost:5417/Coach', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { coachId: oldid, coachName: PlayerName, salary: sal, teamID: teamid })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
            document.getElementById("updateformdiv").style.display = "none";

        })
        .catch((error) => { console.error('Error:', error); });
}
