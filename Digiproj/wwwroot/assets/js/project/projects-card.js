const stars = document.querySelectorAll('.star');

for(var i = 0; i < stars.length; i++){
    stars[i].addEventListener('click', activeStar);
}

function activeStar($e){
    'use strict'
    var currentStar = $e.target;

    if(currentStar.classList.contains('active')){
        currentStar.classList.remove('active')
    }
    else{
        currentStar.classList.add('active')
    }
}

const typeofProject = document.querySelector('#typeTitle');
const allBtn = document.querySelector('#all');


if(allBtn){
    allBtn.addEventListener('click', writeAll);
}
function writeAll(){
    'use strict'
    typeofProject.innerHTML = "All Projects";
}

function isNumeric(n) {
    return !isNaN(parseFloat(n)) && isFinite(n);
}

function SearchProject() {
    var ProjectName = document.getElementById("ProjectName").value;
    var DepartName = document.getElementById("DepartName").value;
    var Status = document.getElementById("Status").value;
    var OrderBy = document.getElementById("OrderBy").value;
    var Ascending = document.getElementById("Ascending").value;


    var dataObject = JSON.stringify({
        'ProjectName': ProjectName,
        'DepartmentName': DepartName,
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
                $('#card-project').empty();
                
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

                    var pid = "'" + item.projectId.toUpperCase() + "'";
                    var pname = "'" + item.projectName.toUpperCase() + "'";

                    let actionsDelete = '<a id="dlt" class="btn btn-sm btn-outline-secondary border me-2" data-bs-toggle="tooltip" data-bs-original-title="Delete" onclick="PopupModalProject(' + pid + ', ' + pname + ');">		<svg xmlns="http://www.w3.org/2000/svg" height="20" viewBox="0 0 24 24" width="16"><path d="M0 0h24v24H0V0z" fill="none" /><path d="M6 19c0 1.1.9 2 2 2h8c1.1 0 2-.9 2-2V7H6v12zM8 9h8v10H8V9zm7.5-5l-1-1h-5l-1 1H5v2h14V4h-3.5z" /></svg></a>';
                    let actions = "<a id='ed' class='dropdown-item' href='project/projects-edit?ProjectId=" + encodeURIComponent(item.aesProj) + "'><i class='fe fe-info me-2'> </i> Edit Metadata</a><a id='ed' class='dropdown-item' href='project/projects-edit-content?ProjectId=" + encodeURIComponent(item.aesProj) + "'><i class='fe fe-info me-2'> </i> Edit Content</a><a id='dt' class='dropdown-item' href='project/projects-detail?ProjectId=" + encodeURIComponent(item.aesProj) + "'><i class='fe fe-info me-2'> </i> Detail</a>";

                    let DataMember = item.assignTo[0];

                    var c = 0;
                    c = item.totalDone / item.totalTask * 100;

                    var html = "";
                    html += '<div class="col-sm-12 col-md-12 col-lg-12 col-xl-4">';
                    html += '<div class="card">';
                    html += '<div class="card-body"><div class="row"><div class="col-md-12"><div class="row">';
                    html += '<div class="col"><div class="d-sm-flex align-items-center">';
                    html += '<div class="avatar mb-2 p-2 lh-1 mb-sm-0 avatar-md rounded-circle bg-primary me-2"><svg xmlns="http://www.w3.org/2000/svg" class="w-icn text-white" enable-background="new 0 0 24 24" viewBox="0 0 24 24"><path d="M4.2069702,12l5.1464844-5.1464844c0.1871338-0.1937866,0.1871338-0.5009155,0-0.6947021C9.1616211,5.9602051,8.8450928,5.9547119,8.6464844,6.1465454l-5.5,5.5c-0.000061,0-0.0001221,0.000061-0.0001221,0.0001221c-0.1951904,0.1951904-0.1951294,0.5117188,0.0001221,0.7068481l5.5,5.5C8.7401123,17.9474487,8.8673706,18.0001831,9,18c0.1325684,0,0.2597046-0.0526733,0.3533936-0.1464233c0.1953125-0.1952515,0.1953125-0.5118408,0.0001221-0.7070923L4.2069702,12z M20.8534546,11.6465454l-5.5-5.5c-0.1937256-0.1871948-0.5009155-0.1871948-0.6947021,0c-0.1986084,0.1918335-0.2041016,0.5083618-0.0122681,0.7069702L19.7930298,12l-5.1465454,5.1464844c-0.09375,0.09375-0.1464233,0.2208862-0.1464233,0.3534546C14.5,17.776062,14.723877,17.999939,15,18c0.1326294,0.0001221,0.2598267-0.0525513,0.3534546-0.1464844l5.5-5.5c0.000061-0.000061,0.0001221-0.000061,0.0001831-0.0001221C21.0487671,12.1581421,21.0487061,11.8416748,20.8534546,11.6465454z"></path></svg></div>';
                    html += '<div class="ms-1"><h6 class="mb-1" id="title">' + item.projectName.toUpperCase() +"";
                    html += '<span class="mb-0 mt-1 badge rounded-pill '+ css +' fs-11 mx-2">' + status +'</span>';
                    html += '</h6>';
                    html += '<span class="text-muted border-end pe-2 fs-11 float-start mt-1">'+ item.totalTask+' Tasks</span>';
                    html += '<span class="text-teritary ps-1 fs-11">' + item.createdDate +"</span>'";
                    html += '</div></div></div>';

                    html += '<div class="col-auto"><div class="d-flex align-items-stretch">';
                    html += actionsDelete ;
                    html += "<a href='#' class='border br-5 px-2 py-1 text-muted d-flex align-items-center' data-bs-toggle='dropdown' aria-haspopup='true' aria-expanded='false'> <i class='fe fe-more-vertical'> </i></a>";
                    html += "<div class='dropdown-menu dropdown-menu-start'>";
                    html +=  actions ;
                    html += '</div>';
                    
                    html +='</div></div></div></div>';

                    html += '<div class="col-md-12 mt-4"><div class="row align-items-center">';
                    html += '<div class="col"><p class="m-0 mb-2">Members</p>';
                    html += '<div class="avatar-list avatar-list-stacked"><span><img src="/assets/images/users/bi-logo.jpg" title=' + DataMember.name + ' alt="profile-user" class="avatar bradius cover-image"></span>';
                    html += "<span class= 'avatar bradius bg-primary' > +" + item.memberTotal + "</span>";
                    html += '</div></div>';

                    html += '<div class="col-auto">';
                    html += '<p class="mb-0"><span class="text-muted d-block">Due Date</span>';
                    html += '<span class="text-danger">' + item.endDate + '</span></p>';
                    html += '</div>';
                    html += '</div></div>';

                    html += '<div class="col-md-12 mt-4"><div class="text-center d-f-ai-c-jc-c">';
                    html +='<div class="wp-100">';
                    html += '<div class="project-percentage small-bar small-lg">';

                    html += '<div class="percentage-title"><span>Progress</span>';
                    if (isNaN(c) || isNaN(c)) {
                        html += '<span class="progress-main font-weight-semibold text-13 mb-1">0%</span>';
                    } else {
                        html += '<span class="progress-main font-weight-semibold text-13 mb-1">' + c + '%</span>';
                    }
                   html += '</div> ';

                    html += '<div class="progress fileprogress mb-2 h-auto">';
                    if (isNaN(c) || isNaN(c)) {
                        html += '<div class="progress-bar" role="progressbar" style="width:0%">';
                    } else {
                        html += '<div class="progress-bar" role="progressbar" style="width:' + c.toFixed(2) + '%">';
                    }
                  
                    html += '</div>';
                    html += '</div></div>';
                    html += '</div></div></div> ';
                     
                   
                    

                    html += '</div></div></div></div>';

                    $('#card-project').append(html);
                });
                   
               
                return;
            }
            else {
                $('#card-project').empty();
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