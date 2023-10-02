var token = localStorage.getItem('token');
var type = localStorage.getItem('type')
document.getElementById('filterState').addEventListener('change', FilterStateChange);


let table = new DataTable('#projects', {
    paging: true, 
    lengthMenu: [1, 5, 10, 20], 
    pageLength: 5,
    ajax: {

        url: `https://localhost:7147/api/projects?page=1&units=100`,
        dataSrc: "data",
        headers: { "Authorization": "Bearer " + token }
    },
    columns: [
        { data: 'codProject', title: 'CodProyecto' },
        { data: 'name', title: 'Nombre' },
        { data: 'address', title: 'Direccion' },
        { data: 'state', title: 'Estado' },
        {
            data: function (data) {
                var buttons =	
                    `<td><a href='javascript:UpdateProject(${JSON.stringify(data)})'><i class="fa-solid fa-pen-to-square m-3 updateProject"></i></a></td>` +
                    `<td><a href='javascript:DeleteProject(${JSON.stringify(data)})'><i class="fa-solid fa-trash deleteProject"></i></a></td>`;
                return buttons;
            }
        }
    ]
});

function GetAll(){

    var existingTable = $('#projects').DataTable();

    if ($.fn.DataTable.isDataTable('#projects')) {
        existingTable.destroy();
    }

    let table = new DataTable('#projects', {
        paging: true,
        lengthMenu: [1, 5, 10, 20],
        pageLength: 5,
        ajax: {

            url: `https://localhost:7147/api/projects?page=1&units=100`,
            dataSrc: "data",
            headers: { "Authorization": "Bearer " + token }
        },
        columns: [
            { data: 'codProject', title: 'CodProyecto' },
            { data: 'name', title: 'Nombre' },
            { data: 'address', title: 'Direccion' },
            { data: 'state', title: 'Estado' },
            {
                data: function (data) {
                    var buttons =
                        `<td><a href='javascript:UpdateProject(${JSON.stringify(data)})'><i class="fa-solid fa-pen-to-square m-3 updateProject"></i></a></td>` +
                        `<td><a href='javascript:DeleteProject(${JSON.stringify(data)})'><i class="fa-solid fa-trash deleteProject"></i></a></td>`;
                    return buttons;
                }
            }
        ]
    });



}
function FilterByState(state) {

    var existingTable = $('#projects').DataTable();

    if ($.fn.DataTable.isDataTable('#projects')) {
        existingTable.destroy();
    }

    let table = new DataTable('#projects', {
        paging: true,
        lengthMenu: [1, 5, 10, 20],
        pageLength: 5,
        ajax: {
            url: `https://localhost:7147/api/projects/state/${state}`,
            dataSrc: "data",
            headers: { "Authorization": "Bearer " + token },
        },
        columns: [
            { data: 'codProject', title: 'CodProyecto' },
            { data: 'name', title: 'Nombre' },
            { data: 'address', title: 'Direccion' },
            { data: 'state', title: 'Estado' },
            {
                data: function (data) {
                    var buttons =
                        `<td><a href='javascript:UpdateProject(${JSON.stringify(data)})'><i class="fa-solid fa-pen-to-square m-3 updateProject"></i></a></td>` +
                        `<td><a href='javascript:DeleteProject(${JSON.stringify(data)})'><i class="fa-solid fa-trash deleteProject"></i></a></td>`;
                    return buttons;
                }
            }
        ]
    });
}

function FilterStateChange() {
    const filterValue = parseInt(document.getElementById('filterState').value);

    FilterByState(filterValue);
}



function DeleteProject(data) {
    if (type === "Consultor") {
        alert("No tiene los derechos suficientes para realizar esta acción!")
    }
    else if (window.confirm("Estas seguro que deseas eliminar el proyecto?"))
    {
       $.ajax({
            type: "GET",
            url: "DeleteProject",
            data: data,
            'dataType': "html",
           success: function (result) {
               location.reload()
            },
       })
    } else {
        alert("No se ha eliminado el projecto!")
    }

}
function UpdateProject(data) {
    if (type === "Consultor") {
        alert("No tiene los derechos suficientes para realizar esta acción!")
    }
    else {
        $.ajax({
            type: "GET",
            url: "ProjectAddPartial",
            data: data,
            dataType: "html",
            success: function (result) {
                $("#ProjectAddPartial").html(result);
                $('#projectoModal').modal('show');
            }
        });
}
    
}


function AddProject() {
    if (type === "Consultor") {
        alert("No tiene los derechos suficientes para realizar esta acción!")
    }
    else {
        $.ajax({
            type: "GET",
            url: "ProjectAddPartial",
            'dataType': "html",
            success: function (result) {
                $("#ProjectAddPartial").html(result);
                $('#projectoModal').modal('show');
            }
        })
    }
}