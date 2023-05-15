function capitalizeFirstLetter(string) {
    return string.charAt(0).toUpperCase() + string.slice(1);
}

$(document).ready(function () {
    $('#project-table').DataTable({
        searching: false,
        orderable: false,
        bSort: false,
    });
});

function SearchProject() {
    var ProjectName = document.getElementById("ProjectName").value;
    var Status = document.getElementById("Status").value;
    var OrderBy = document.getElementById("OrderBy").value;
    var Ascending = document.getElementById("Ascending").value;

    var dtTable = $('#project-table').DataTable({
        searching: false,
        orderable: false,
        bSort: false,
        bDestroy: true
    });

    var dataObject = JSON.stringify({
        'ProjectName': ProjectName,
        'Status': Status,
        'Column': OrderBy,
        'Y': Boolean(Ascending)
    });

    $.ajax({
        type: "POST",
        url: "/ProjectsList/SearchProject",
        contentType: "application/json; charset=utf-8",
        data: dataObject,
        success: function (data) {
            if (data.length > 0) {
                dtTable.clear().draw();
                $.each(data, function (i, item) {

                    var IsStatus = "" + item.status + "";

                    var css;
                    var status;
                    if (IsStatus == 1) {
                        css = 'text-default bg-warning-transparent';
                        status = 'Not Started';
                    }
                    if (IsStatus == 2) {
                        css = 'text-info bg-info-transparent';
                        status = 'Work Inprogress';
                    }
                    if (IsStatus == 3) {
                        css = 'bg-primary-transparent text-primary';
                        status = 'Done';
                    }
                    if (IsStatus == 4) {
                        css = 'text-default bg-warning-transparent';
                        status = 'Block';
                    }
                    const cdate = new Date(Date.parse(item.createdDate));
                    let sdate = ("00" + (cdate.getMonth() + 1)).slice(-2) + "/" +
                        ("00" + cdate.getDate()).slice(-2) + "/" +
                        cdate.getFullYear() + " " +
                        ("00" + cdate.getHours()).slice(-2) + ":" +
                        ("00" + cdate.getMinutes()).slice(-2) + ":" +
                        ("00" + cdate.getSeconds()).slice(-2);

                    const edate = new Date(Date.parse(item.endDate));
                    let ddate = ("00" + (cdate.getMonth() + 1)).slice(-2) + "/" +
                        ("00" + cdate.getDate()).slice(-2) + "/" +
                        cdate.getFullYear() + " " +
                        ("00" + cdate.getHours()).slice(-2) + ":" +
                        ("00" + cdate.getMinutes()).slice(-2) + ":" +
                        ("00" + cdate.getSeconds()).slice(-2);

                    const rows = $("<tr>" +
                        "<td class='text-muted fs-15 fw-semibold text-center'>" + item.projectId.toUpperCase() + "</td>" +
                        "<td class='text-muted fs-15 fw-semibold text-center'>" + item.projectName.toUpperCase() + "</td>" +
                        "<td class='text-muted fs-15 fw-semibold text-center'><span class='mb-0 mt-1 badge rounded-pill " + css + "'>" + status + "</span></td>" +
                        "<div class='avatar-list avatar-list-stacked'><td class='text-muted fs-15 fw-semibold text-center'><span class='avatar bradius bg-primary'>+" + item.memberTotal + "</span> Members</td></div>" +
                        "<td class='text-muted fs-15 fw-semibold text-center'>" + capitalizeFirstLetter(item.createdBy) + "</td>" +
                        "<td class='text-muted fs-15 fw-semibold text-center'>" + sdate + "</td>" +
                        "<td class='text-muted fs-15 fw-semibold text-center'>" + ddate + "</td>" +
                        "<td>" +
                        "<div class='d-flex align-items-stretch'>" +
                        "<a class='btn btn-sm btn-outline-secondary border me-2' data-bs-toggle='tooltip' data-bs-original-title='Delete'>" +
                        "<svg xmlns='http://www.w3.org/2000/svg' height='20' viewBox='0 0 24 24' width='16'> <path d='M0 0h24v24H0V0z' fill='none' /> <path d='M6 19c0 1.1.9 2 2 2h8c1.1 0 2-.9 2-2V7H6v12zM8 9h8v10H8V9zm7.5-5l-1-1h-5l-1 1H5v2h14V4h-3.5z' /> </svg></a>" +
                        "<a href='#' class='border br-5 px-2 py-1 text-muted d-flex align-items-center' data-bs-toggle='dropdown' aria-haspopup='true' aria-expanded='false'> <i class='fe fe-more-vertical'> </i></a>" +
                        "<div class='dropdown-menu dropdown-menu-start'>" +
                        "<a class='dropdown-item' href='projects-edit'> <i class='fe fe-edit-2 me-2'> </i> Edit</a>" +
                        "<a class='dropdown-item' href='projects-detail'> <i class='fe fe-info me-2'> </i> Detail</a>" +
                        "</div></div>" +
                        "</td>" +
                        "</tr>"
                    );
                    dtTable.row.add(rows[0]).draw();


                });
                return;
            } else {
                dtTable.clear().draw();
                Swal.fire({
                    text: "Project data not found.",
                    icon: "warning",
                    buttonsStyling: false,
                    confirmButtonText: "Oke",
                    customClass: {
                        confirmButton: "btn btn-warning"
                    }
                }).then(function (result) {
                    if (result.isConfirmed) {
                        return;
                    }
                });
                return;
            }
        },
        error: function (err) {
            Swal.fire({
                text: "	Error API",
                icon: "error",
                buttonsStyling: false,
                confirmButtonText: "Oke",
                customClass: {
                    confirmButton: "btn btn-danger"
                }
            }).then(function (result) {
                if (result.isConfirmed) {
                    return;
                }
            });
            return;
        }
    });
}

function parseBool(value) {
    return (typeof value === "undefined") ?
        false :
        value.replace(/^\s+|\s+$/g, "").toLowerCase() === "true";
}