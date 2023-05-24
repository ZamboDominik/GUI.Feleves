let Teams = [];
let connection = null;
let oldid = null;
getdata();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:5417/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("TeamCreated", (user, message) => {
        getdata();
    });
    connection.on("TeamUpdated", (user, message) => {
        getdata();
    });

    connection.on("TeamDeleted", (user, message) => {
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
    await fetch('http://localhost:5417/Team')
        .then(x => x.json())
        .then(y => {
            Teams = y;
            console.log(Teams);
            display();
        }).catch((error) => { console.error('Error:', error); });
;
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    Teams.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.name + "</td><td>"
            + t.luxuryTax + "</td><td>"+
           `<button type="button" onclick="showupdate(${t.id})">Update</button>` +
           `<button type="button" onclick="remove(${t.id})">Delete</button>`
            + "</td></tr>";
    }).catch((error) => { console.error('Error:', error); });
;
}


function create() {
    let TeamName = document.getElementById('TeamName').value;
    let Tax = document.getElementById('Tax').value;
    fetch('http://localhost:5417/Team', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: TeamName, luxuryTax: Tax })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}
function remove(id) {
    fetch('http://localhost:5417/Team/' + id, {
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
    let item = Teams.find(t => t['id'] == id);
    console.log(item);
    oldid = item.id;
    document.getElementById("updateformdiv").style.display = "block";
    document.getElementById("TeamNameupdate").value = item.name;
    //document.getElementById('SerieReleaseupdate').value = new Date(item.release).toISOString().split('T')[0];
    //document.getElementById('SerieRatingupdate').value = item.rating;
    document.getElementById('LuxTaxupdate').value = item.luxuryTax;
   // document.getElementById('SerieDirectorIdupdate').value = item.directorId;
    //document.getElementById('SerieCategoryIdupdate').value = item.categoryId;
    //document.getElementById("id").value = id;
}
async function update() {
    let item = Teams.find(t => t['id'] === oldid);
    let TeamName = document.getElementById('TeamNameupdate').value;  
    let Tax = document.getElementById('Taxupdate').value;
    await fetch('http://localhost:5417/Team', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { id: item.id, name: TeamName, luxuryTax: Tax })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
            document.getElementById("updateformdiv").style.display = "none";

        })
        .catch((error) => { console.error('Error:', error); });
}
