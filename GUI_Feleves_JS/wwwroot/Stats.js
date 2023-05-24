getdata();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:5417/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();
    connection.on("StatisticsUpdated", (user, message) => {
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

async function getdata() {
    document.getElementById('resultarea').innerHTML = "";
    await fetch('http://localhost:5417/Stat/StarPlayers')
        .then(x => x.json())
        .then(y => {
            let data = y.map(function (item) {
                return `Star: ${item['name']} `;
            });
            display("StarPlayers", true);
            display(data);
        });
    await fetch('http://localhost:5417/Stat/PositionStats')
        .then(x => x.json())
        .then(y => {
            let data = y.map(function (item) {
                return ` ${item['position']}: Salary ${item['avgSalary']} min ${item['minSalary']} max ${item['maxSalary']}`;
            });
            console.log(y);
            display("PositionStats", true);
            display(data);

            console.log(data);
        });
    await fetch('http://localhost:5417/Stat/ListPlayersCoachedBy?name=Steve%20Kerr')
        .then(x => x.json())
        .then(y => {
            let data = y.map(function (item) {
                return ` ${item['name']}`;
            });
            console.log(y);
            display("Coached By Steve Kerr", true);
            display(data);

            console.log(data);
        });

    await fetch('http://localhost:5417/Stat/PlayerListByPos?team=Golden%20State%20Warriors&Pos=PG')
        .then(x => x.json())
        .then(y => {
            let data = y.map(function (item) {
                return ` ${item['name']}`;
            });
            console.log(y);
            display("Every PG in GSW", true);
            display(data);

            console.log(data);
        });




    await fetch('http://localhost:5417/Stat/HighestSalary?team=Dallas%20Maverics')
        .then(x => x.json())
        .then(y => {
           
            display("Every PG in GSW", true);

            document.getElementById('resultarea').innerHTML += "<tr><td>" + y.name + "</td></tr>";
           
        });


}

function display(datas, head = false) {
    if (head) return document.getElementById('resultarea').innerHTML +=
        "<tr><th>" + datas + "</th></tr>";
    datas.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t + "</td></tr>";
    });
}