$("#project_create_date").datetimepicker({
    format: 'd-m-Y H:i:s'
});
$("#project_end_date").datetimepicker({
    format: 'd-m-Y H:i:s'
});


$(function (e) {
	$('#summernote').summernote({
		height: "300px",
		callbacks: {
			onImageUpload: function (image) {
				uploadImage(image[0]);
			},
			onMediaDelete: function (target) {
				deleteImage(target[0].src);
			}
		}
	});
});

function SubmitProject() {
	var ProjectId = document.getElementById("project-id").value;
	var ProjectName = document.getElementById("project-name").value;
	var ProjectOwner = document.getElementById("project-owner").value;
	var DepartmentId = document.getElementById("department").value;
	var Status = document.getElementById("status").value;
	var StartDate = document.getElementById("project_create_date").value;
	var EndDate = document.getElementById("project_end_date").value;
	var Summary = document.getElementById("summernote").value;
	var Active = document.getElementById("active").value;


	var dataObject = JSON.stringify({
		'ProjectId': ProjectId,
		'ProjectName': ProjectName,
		'ProjectOwner': ProjectOwner,
		'DepartmentId': DepartmentId,
		'Status': Status,
		'StartDate': StartDate,
		'EndDate': EndDate,
		'Summary': Summary,
		'IsActive': Boolean(Active)
	});


	$.ajax({
		url: "/ProjectsList/Update",
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
					showCloseButton: false
				})
					.then(function (result) {
						if (result.value) {
							window.location.href = "/project";
						}
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
	return;
}