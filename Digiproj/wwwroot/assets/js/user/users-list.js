﻿$(document).ready(function () {
    $('#project-table').DataTable({
        searching: false,
        orderable: false,
        bSort: false,
        processing: true,
        lengthMenu: [5, 10, 20],
    });
});

function SearchUser() {
    var EmployeeId = document.getElementById("EmployeeId").value;
    var Fname = document.getElementById("Fullname").value;
    var Uname = document.getElementById("Username").value;
    var Role = document.getElementById("Role").value;
    var OrderBy = document.getElementById("OrderBy").value;
    var Ascending = document.getElementById("Ascending").value;

    var dtTable = $('#project-table').DataTable({
        searching: false,
        orderable: false,
        bSort: false,
        processing: true,
        lengthMenu: [5, 10, 20],
        bDestroy: true
    });

    var dataObject = JSON.stringify({
        'EmployeeId': EmployeeId,
        'Name': Fname,
        'UserName': Uname,
        'RoleIds': [0],
        'Column': OrderBy,
        'Y': Boolean(Ascending),
        'IsActive': true,
    });

    $.ajax({
        type: "POST",
        url: "/User/SearchUser",
        contentType: "application/json; charset=utf-8",
        data: dataObject,
        success: function (data) {
            if (data.length > 0) {
                dtTable.clear().draw();
                $.each(data, function (i, item) {
                    i += 1;
                    console.log(data);
                    var IsStatus = item.isActive;
                    var css;
                    if (IsStatus == true) {
                        css = '<span style= "display: inline-block ;width: 0.8rem ;height: 0.8rem ;border-radius: 50% ;background: #222222 ;margin-right: 0.5rem ;background-color:#25be64"</span>'
                    } else {
                        css = '<span style= "display: inline-block;width: 0.8rem;height: 0.8rem;border-radius: 50%;background: #222222;margin-right: 0.5rem;background-color:red"</span>'
                    }
                    
                    
                    

                    var pid = "'" + item.employeeId.toUpperCase() + "'";
                    var pname = "'" + item.name.toUpperCase() + "'";

                    const cdate = new Date(Date.parse(item.createdDate));
                    let actionsDelete = '<a id="dlt" class="btn btn-sm btn-outline-secondary border me-2" data-bs-toggle="tooltip" data-bs-original-title="Delete" onclick="PopupModalProject(' + pid + ', ' + pname + ');">';
                    let actions = "<a id='ed' class='dropdown-item' href='project/projects-edit?ProjectId=" + encodeURIComponent(item.aesProj) + "'><i class='fe fe-info me-2'> </i> Edit</a><a id='dt' class='dropdown-item' href='project/projects-detail?ProjectId=" + encodeURIComponent(item.aesProj) + "'><i class='fe fe-info me-2'> </i> Detail</a>";

                    let rolenames = "";
                    item.roles.forEach((DataMember) => { rolenames = DataMember.roleName });
                    //console.log(tes)
                   
                    let rows = $("<tr>" +
                        "<td class='text-muted fs-15 fw-semibold text-center'>" + i++ + "</td>" +
                        "<td class='text-muted fs-15 fw-semibold text-center'>" + item.employeeId.toUpperCase() + "</td>" +
                        "<td class='text-muted fs-15 fw-semibold text-center'>" + item.userName + "</td>" +
                        "<td class='text-muted fs-15 fw-semibold text-center'>" + item.name.toUpperCase() + "</td>" +
                        "<td class='text-muted fs-15 fw-semibold text-center'>" + item.email + "</td>" +
                        "<td class='text-muted fs-15 fw-semibold text-center'>" + rolenames + "</td>" +
                        "<td class='text-muted fs-15 fw-semibold text-center'>" + css + "</td>" +
                        "<td>" +
                        "<div class='d-flex align-items-stretch'>" +
                        " " + actionsDelete + " " +
                        "<svg xmlns='http://www.w3.org/2000/svg' height='20' viewBox='0 0 24 24' width='16'> <path d='M0 0h24v24H0V0z' fill='none' /> <path d='M6 19c0 1.1.9 2 2 2h8c1.1 0 2-.9 2-2V7H6v12zM8 9h8v10H8V9zm7.5-5l-1-1h-5l-1 1H5v2h14V4h-3.5z' /> </svg></a>" +
                        "<a href='#' class='border br-5 px-2 py-1 text-muted d-flex align-items-center' data-bs-toggle='dropdown' aria-haspopup='true' aria-expanded='false'> <i class='fe fe-more-vertical'> </i></a>" +
                        "<div class='dropdown-menu dropdown-menu-start'>" +
                        " " + actions + " " +
                        "</div></div>" +
                        "</td>" + "</tr>"
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