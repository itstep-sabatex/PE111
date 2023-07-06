// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function rowClick(id) {
    let el = document.getElementById(id);
    let selectedRow = document.getElementsByClassName("selectedRow");
    for (let i = 0; i < selectedRow.length; i++) {
        selectedRow[i].classList.remove("selectedRow");
    }
    el.classList.add("selectedRow");
}

function getSelectedRow() {
    let selectedRow = document.getElementsByClassName("selectedRow");
    if (selectedRow.length == 0)
        return null;
    else
        return selectedRow[0].id;
}

function deleteItem(tbId) {
    let id = getSelectedRow();
    if (id == null)
        return;
    else {
        let id1 = id.substring(2);
        $.ajax({
            url: '/api/studentGroups/' + id1,
            type: 'DELETE',
            success: () => {
                let a = 1;
                RefreshStudentTable(tbId); 
            }, error: () => {
                let b = 1;
            }
        });
    }
}
function RefreshStudentTable(tbId) {
    let xhr = new XMLHttpRequest();
    xhr.open('GET', '/api/StudentGroups');
    xhr.responseType = 'json';
    xhr.onload = function () {
        let status = xhr.status;
        if (status == 200) {
            let data = xhr.response;
            let tb = document.getElementById(tbId);
            tb.innerHTML = null;
            for (let i = 0; i < data.length; i++) {
                let tr = document.createElement("tr");
                let id = "id" + data[i].id;
                tr.id = id;
                tr.onclick = () => rowClick(id);
                tb.appendChild(tr);
                let tdName = document.createElement("td");
                tr.appendChild(tdName);
                tdName.innerHTML = data[i].name;
                tr.appendChild(document.createElement("td"));
            }
            
        } else {

        }
      
    }
    xhr.send();
}