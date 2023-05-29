
'use strict';

$(function () {
	document.getElementById("project-id").value = makeid(7);

	var date = new Date();
	var day = date.getDate();
	var month = date.getMonth() + 1;
	var year = date.getFullYear();

	if (month < 10) month = "0" + month;
	if (day < 10) day = "0" + day;

	var today = year + "-" + month + "-" + day + "T00:00";
	$("#project-start-date").attr("value", today);
	$("#project-end-date").attr("value", today);
});

// Select2
$('.select2').select2({
    minimumResultsForSearch: Infinity,
    width: '100%'
})

// Select2 by showing the search
$('.select2-show-search').select2({
    minimumResultsForSearch: '',
    width: '100%'
})

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

// text editor
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


//display other files section
//function showAndHideOtherDetails() {

//    const otherDetails = document.querySelector('.other-details');
//    const addFilesContainer = document.querySelector('.other-details-main');
//    var upArrow = document.querySelector('.up-arrow');
//    var downArrow = document.querySelector('.down-arrow');

//    otherDetails.addEventListener('click', showAddFilesContainer);

//    upArrow.classList.add('d-none');

//    function showAddFilesContainer() {
//        if (addFilesContainer.classList.contains('d-none')) {
//            addFilesContainer.classList.remove('d-none');
//            upArrow.classList.remove('d-none');
//            downArrow.classList.add('d-none');

//        }
//        else {
//            addFilesContainer.classList.add('d-none');
//            upArrow.classList.add('d-none');
//            downArrow.classList.remove('d-none');
//        }
//    }
//}
//showAndHideOtherDetails();





function PostProject() {
	var ProjectId = document.getElementById("project-id").value;
	var ProjectName = document.getElementById("project-name").value;
	var ProjectOwner = document.getElementById("project-owner").value;
	var DepartmentId = document.getElementById("department").value;
	var StartDate = document.getElementById("project-start-date").value;
	var EndDate = document.getElementById("project-end-date").value;
	var Summary = document.getElementById("summernote").value;


	var values = $("#employee-id").map(function (idx, ele) {
		return $(ele).val();
	}).get();

	var dataObject = JSON.stringify({
		'ProjectId': ProjectId,
		'ProjectName': ProjectName,
		'ProjectOwner': ProjectOwner,
		'DepartmentId': DepartmentId,
		'StartDate': StartDate,
		'EndDate': EndDate,
		'Summary': Summary,
		'EmployeeId': values
	});


	$.ajax({
		url: "/ProjectsList/Create",
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