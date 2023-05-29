function formatDateID(sdate) {
    const cdate = new Date(Date.parse(sdate));
    sdate = ("00" + (cdate.getMonth() + 1)).slice(-2) + "/" +
        ("00" + cdate.getDate()).slice(-2) + "/" +
        cdate.getFullYear() + " " +
        ("00" + cdate.getHours()).slice(-2) + "." +
        ("00" + cdate.getMinutes()).slice(-2) + "." +
        ("00" + cdate.getSeconds()).slice(-2);

    return sdate;
}

function capitalizeFirstLetter(string) {
    return string.charAt(0).toUpperCase() + string.slice(1);
}

function parseBool(value) {
    return (typeof value === "undefined") ?
        false :
        value.replace(/^\s+|\s+$/g, "").toLowerCase() === "true";
}

//random id
function makeid(length) {
    let result = '';
    const characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    const charactersLength = characters.length;
    let counter = 0;
    while (counter < length) {
        result += characters.charAt(Math.floor(Math.random() * charactersLength));
        counter += 1;
    }
    return result;
}
