
function selectClient(client) {
    if (!client.id) { return client.text; }
    var $client = $(
        '<span><img src="../assets/images/users/bi-logo.jpg" class="rounded-circle avatar-sm" /> '
        + client.text + '</span>'
    );
    return $client;
};

$(".select2-client-search").select2({
    templateResult: selectClient,
    templateSelection: selectClient,
    escapeMarkup: function (m) { return m; }
});

function LoadMember() {
    $('#modal_add_member').appendTo("body").modal('hide');
    document.getElementById('employee-id').value = '';
    setInterval(function () { location.reload(true); }, 2000);
}

function PopupAddMember(ProjectId) {
    document.getElementById("InfoProjectId").value = ProjectId;    
    $('#modal_add_member').appendTo("body").modal('show');
}

function AddMember() {
    var ProjectId = document.getElementById("InfoProjectId").value;
    var values = $("#employee-id").map(function (idx, ele) {
        return $(ele).val();
    }).get();

    var dataObject = JSON.stringify({
        'ProjectId': ProjectId,
        'EmployeeId': values
    });

    $.ajax({
        url: "/ProjectsList/CreateMember",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: dataObject,
        success: function (res) {
            if (res.success == true) {
                Swal.fire({
                icon: 'success',
                    title: "Success!",
                    text: "" + res.message + "",
                    type: "success",
                    timer: 2000,
                    showCloseButton: false,
                    showConfirmButton: false
                });
                LoadMember();
            }
            else {
                Swal.fire(
                    'Ups error!',
                    "" + res.message + "",
                    'error'
                )
            }
        },
        error: function (err) {
            Swal.fire(
                'Ups error API!',
                "" + res.message + "",
                'error'
            )
        }
    });
}
//-------------------------------
function PopupAddTask(ProjectId) {
    document.getElementById("project-id").value = ProjectId; 
    $('#modal_add_task').appendTo("body").modal('show');

    $.ajax({
        type: "GET",
        url: "/ProjectsList/GetProjectByEmployee",
        contentType: "application/json; charset=utf-8",
        data: { ProjectId: ProjectId },
        success: function (data) {
            if (data.length > 0) {
                $.each(data, function (i, item) {
                    var id = item.employeeId;
                    var name = item.name;

                    $('#select-employee').append($('<option>', {
                        value: id,
                        text: name
                    }));
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

function CloseTask() {
    document.getElementById("select-employee").innerHTML = "";
    document.getElementById("task-name").value = "";
    document.getElementById("project-id").innerHTML = "";
    $('#modal_add_task').appendTo("body").modal('hide');

}

function AddTask() {
    var ProjectId = document.getElementById("project-id").value;
    var TaskName = document.getElementById("task-name").value;
    var Owner = document.getElementById("select-employee").value;
    var Priority = document.getElementById("select-priority").value;
    var StartDate = document.getElementById("task_create_date").value;
    var EndDate = document.getElementById("task_end_date").value;

    var dataObject = JSON.stringify({
        'ProjectId': ProjectId,
        'TaskName': TaskName,
        'TaskOwner': Owner,
        'Priority': Priority,
        'StartDate': StartDate,
        'EndDate': EndDate
    });


    $.ajax({
        url: "/ProjectsList/CreateTask",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: dataObject,
        success: function (res) {
            if (res.success == true) {
                Swal.fire({
                    icon: 'success',
                    type: 'success',
                    title: "Success!",
                    confirmButtonText: 'OK',
                    text: "" + res.message + "",
                    showCloseButton: false,
                    timer: 2000,
                    showConfirmButton: false
                });
                setInterval(function () { location.reload(true); }, 2000); 
            }
            else {
                Swal.fire(
                    'Ups error!',
                    "" + res.message + "",
                    'error'
                )
            }
        },
        error: function (err) {
            Swal.fire(
                'Ups error API!',
                "" + res.message + "",
                'error'
            )
        }
    });
    return;
}
//--------------------------------

function PopupModalDeleteTask(TaskId) {
    document.getElementById("InfoTaskId").value = TaskId;
    $('#modal_delete_task').appendTo("body").modal('show');
}
function CancelTask() {
    $("#modal_delete_task").modal('hide');
}

function DeleteTask() {
    var TaskId = document.getElementById("InfoTaskId").value;
    var dataObject = JSON.stringify({
        'Id': TaskId
    });

    $.ajax({
        type: "POST",
        url: "/ProjectsList/DeleteTask",
        contentType: "application/json; charset=utf-8",
        data: dataObject,
        success: function (res) {
            if (res.success == true) {
                $("#modal_delete_task").modal('hide');
                Swal.fire({
                    icon: 'success',
                    type: 'success',
                    title: "Success!",
                    confirmButtonText: 'OK',
                    text: "" + res.message + "",
                    showCloseButton: false,
                    timer: 2000,
                    showConfirmButton: false
                });
                setInterval(function () { location.reload(true); }, 2000); 
            }
            else {
                Swal.fire(
                    'Ups error!',
                    "" + res.message + "",
                    'error'
                )
            }
        },
        error: function (err) {
            Swal.fire(
                'Ups error API!',
                "" + res.message + "",
                'error'
            )
        }
    });
}
//--------------------------------


$("#ed-task_create_date").datetimepicker({
    format: 'd-m-Y H:i:s'
});
$("#ed-task_end_date").datetimepicker({
    format: 'd-m-Y H:i:s'
});

function PopupModalEditTask(TaskId, ProjectId, TaskName, EmployeeId, Status, Priority, StartDate, EndDate) {
    document.getElementById("task-id").value = TaskId;
    document.getElementById("ed-project-id").value = ProjectId;
    document.getElementById("ed-task-name").value = TaskName;
    document.getElementById("ed-select-employee").value = EmployeeId;
    document.getElementById("ed-status").value = Status;
    document.getElementById("ed-select-priority").value = Priority;
    document.getElementById("ed-task_create_date").value = StartDate;
    document.getElementById("ed-task_end_date").value = EndDate;

    //AJAX
    $.ajax({
        type: "GET",
        url: "/ProjectsList/GetProjectByEmployee",
        contentType: "application/json; charset=utf-8",
        data: { ProjectId: ProjectId },
        success: function (data) {
            if (data.length > 0) {
                $.each(data, function (i, item) {
                    var id = item.employeeId;
                    var name = item.name;

                    if (id == EmployeeId) {
                        $('#ed-select-employee').append($('<option>', {
                            value: id,
                            text: name,
                            selected: true
                        }));
                    } else {
                        $('#ed-select-employee').append($('<option>', {
                            value: id,
                            text: name
                        }));
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
    //END AJA

    $('#modal_edit_task').appendTo("body").modal('show');
}

function CloseEditTask() {
    document.getElementById("task-id").value = "";
    document.getElementById("ed-project-id").value = "";
    document.getElementById("ed-task-name").value = "";
    document.getElementById("ed-task_create_date").value = "";
    document.getElementById("ed-task_end_date").value = "";
    document.getElementById("ed-select-employee").innerHTML = "";
    $('#modal_edit_task').appendTo("body").modal('hide');
}

function UpdateTask() {
    var TaskId = document.getElementById("task-id").value;
    var TaskName = document.getElementById("ed-task-name").value;
    var EmployeeId = document.getElementById("ed-select-employee").value;
    var Status = document.getElementById("ed-status").value;
    var Priority = document.getElementById("ed-select-priority").value;
    var StartDate = document.getElementById("ed-task_create_date").value;
    var EndDate = document.getElementById("ed-task_end_date").value;
   
    var dataObject = JSON.stringify({
        'Id': TaskId,
        'TaskName': TaskName,
        'TaskOwner': EmployeeId,
        'Priority': Priority,
        'Status': Status,
        'StartDate': StartDate,
        'EndDate': EndDate
    });

    $.ajax({
        url: "/ProjectsList/UpdateTask",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: dataObject,
        success: function (res) {
            if (res.success == true) {
                Swal.fire({
                    icon: 'success',
                    title: "Success!",
                    text: "" + res.message + "",
                    type: "success",
                    timer: 2000,
                    showCloseButton: false,
                    showConfirmButton: false
                });

                document.getElementById("task-id").value = "";
                document.getElementById("ed-project-id").value = "";
                document.getElementById("ed-task-name").value = "";
                document.getElementById("ed-task_create_date").value = "";
                document.getElementById("ed-task_end_date").value = "";
                setInterval(function () { location.reload(true); }, 2000); 
            }
            else {
                Swal.fire(
                    'Ups error!',
                    "" + res.message + "",
                    'error'
                )
            }
        },
        error: function (err) {
            Swal.fire(
                'Ups error API!',
                "" + res.message + "",
                'error'
            )
        }
    });
}
//-------------------------------
function PopupTaskProject(EmployeeId, ProjectId) {
    $('#modal_member_task').appendTo("body").modal('show');

    //initiate table modal-task-table
    var dtTable = $('#modal_member_task_table').DataTable({
        searching: true,
        orderable: true,
        bSort: true,
        processing: true,
        responsive: true,
        lengthMenu: [5, 10, 20],
        bDestroy: true,
        initComplete: function () {
            $('.dataTables_filter input[type="search"]').css({ 'width': '200px'});
        }
    });

    $.ajax({
        type: "GET",
        url: "/ProjectsList/GetTaskByEmployee",
        contentType: "application/json; charset=utf-8",
        data: { EmployeeId: EmployeeId, ProjectId: ProjectId },
        success: function (data) {
            if (data.length > 0) {
                dtTable.clear().draw();
                $.each(data, function (i, item) {
                    i += 1;
                    var TaskName = "" + item.taskName + "";
                    var ProjectName = "" + item.projectName + "";
                    const cdate = new Date(Date.parse(item.endDate));

                    var IsStatus = "" + item.status + "";
                    var css;
                    var status;
                    if (IsStatus == 1) {
                        css_s = 'text-default bg-warning-transparent';
                        status = 'Not Started';
                    }
                    if (IsStatus == 2) {
                        css_s = 'text-info bg-info-transparent';
                        status = 'Work Inprogress';
                    }
                    if (IsStatus == 3) {
                        css_s = 'bg-primary-transparent text-primary';
                        status = 'Done';
                    }
                    if (IsStatus == 4) {
                        css_s = 'text-default bg-warning-transparent';
                        status = 'Block';
                    }

                    var IsPriority = "" + item.priority + "";
                    var css_p;
                    var priority;
                    if (IsPriority == "Low") {
                        css_p = 'text-info bg-info-transparent';
                        priority = 'Low';
                    }
                    if (IsPriority == "Medium") {
                        css_p = 'text-warning bg-warning-transparent';
                        priority = 'Medium';
                    }
                    if (IsPriority == "High") {
                        css_p = 'bg-danger-transparent text-danger';
                        priority = 'High';
                    }

                    let rows = $("<tr>" +
                        "<td class='text-muted fs-15 fw-semibold text-center'>" + i++ + "</td>" +
                        "<td class='text-muted fs-15 fw-semibold text-center'>" + capitalizeFirstLetter(TaskName) + "</td>" +
                        "<td class='text-muted fs-15 fw-semibold text-center'>" + ProjectName.toUpperCase() + "</td>" +
                        "<td class='text-muted fs-15 fw-semibold text-center'>" + formatDateID(cdate) + "</td>" +
                        "<td class='text-muted fs-15 fw-semibold text-center'>" + capitalizeFirstLetter(item.fullname) + "</td>" +
                        "<td class='text-muted fs-15 fw-semibold text-center'><span class='mb-0 mt-1 badge rounded-pill " + css_s + "'>" + status + "</span></td>" +
                        "<td class='text-muted fs-15 fw-semibold text-center'><span class='mb-0 mt-1 badge rounded-pill " + css_p + "'>" + priority + "</span></td>" +
                        "</tr>"
                    );
                    dtTable.row.add(rows[0]).draw();
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