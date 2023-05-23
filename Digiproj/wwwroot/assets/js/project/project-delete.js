function PopupModalProject(ProjectId, ProjectName) {
    document.getElementById("InfoProjectId").value = ProjectId;
    document.getElementById("InfoProjectName").innerHTML = ProjectName.toUpperCase();
    $('#modal_delete_project').appendTo("body").modal('show');
}

function CancelProject() {
    $("#modal_delete_project").modal('hide');
    SearchProject();
}

function DeleteProject() {
    var ProjectId = document.getElementById("InfoProjectId").value;
    var dataObject = JSON.stringify({
        'ProjectId': ProjectId
    });

    $.ajax({
        type: "POST",
        url: "/ProjectsList/Delete",
        contentType: "application/json; charset=utf-8",
        data: dataObject,
        success: function (res) {
            if (res.success == true) {
                $("#modal_delete_project").modal('hide');
                SearchProject();
                Swal.fire({
                    icon: 'success',
                    type: 'success',
                    title: "Success!",
                    confirmButtonText: 'OK',
                    text: "" + res.message + "",
                    showCloseButton: false
                })
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