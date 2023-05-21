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