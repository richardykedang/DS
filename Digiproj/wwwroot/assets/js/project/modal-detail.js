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