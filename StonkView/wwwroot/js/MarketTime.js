function updateClock() {
    var now = new Date(),
        time = now.getHours() + ':' + now.getMinutes() + ':' + now.getSeconds();
    date = [now.getDate(), , now.getMonth(), now.getFullYear()].join(' ');

    document.getElementById('time').innerHTML = [date, time].join(' / ');

    setTimeout(updateClock, 1000);
}

function checkMarket() {
    const start = 15 * 60 + 30;
    const end = 22 * 60 + 0;
    const date = new Date();
    const now = date.getHours() * 60 + date.getMinutes();
    if (start <= now && now <= end)
        document.getElementById('market').innerHTML = "<span style='color: green; font-size:18px'>Market: Open</span>";
    else {
        document.getElementById('market').innerHTML = "<span style='color: red; font-size:16px'>Market: Closed</span>";

    }
}
checkMarket();
updateClock();
