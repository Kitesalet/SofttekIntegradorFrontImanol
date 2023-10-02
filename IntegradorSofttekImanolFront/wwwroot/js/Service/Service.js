var token = localStorage.getItem('token');
var type = localStorage.getItem('type')


let table = new DataTable('#services', {
    paging: true, 
    lengthMenu: [1, 5, 10, 20], 
    pageLength: 5,
    ajax: {

        url: `https://localhost:7147/api/services?page=1&units=100`,
        dataSrc: "data",
        headers: { "Authorization": "Bearer " + token }
    },
    columns: [
        { data: 'codService', title: 'CodServicio' },
        { data: 'descr', title: 'Descripcion' },
        { data: 'hourValue', title: 'ValorHora' },
        { data: 'state', title: 'Estado' },
        {
            data: function (data) {
                var buttons =	
                    `<td><a href='javascript:UpdateService(${JSON.stringify(data)})'><i class="fa-solid fa-pen-to-square m-3 updateService"></i></a></td>` +
                    `<td><a href='javascript:DeleteService(${JSON.stringify(data)})'><i class="fa-solid fa-trash deleteService"></i></a></td>`;
                return buttons;
            }
        }
    ]
});

function GetAll() {

    var existingTable = $('#services').DataTable();

    if ($.fn.DataTable.isDataTable('#services')) {
        existingTable.destroy();
    }

    let table = new DataTable('#services', {
        paging: true,
        lengthMenu: [1, 5, 10, 20],
        pageLength: 5,
        ajax: {

            url: `https://localhost:7147/api/services?page=1&units=100`,
            dataSrc: "data",
            headers: { "Authorization": "Bearer " + token }
        },
        columns: [
            { data: 'codService', title: 'CodServicio' },
            { data: 'descr', title: 'Descripcion' },
            { data: 'hourValue', title: 'ValorHora' },
            { data: 'state', title: 'Estado' },
            {
                data: function (data) {
                    var buttons =
                        `<td><a href='javascript:UpdateService(${JSON.stringify(data)})'><i class="fa-solid fa-pen-to-square m-3 updateService"></i></a></td>` +
                        `<td><a href='javascript:DeleteService(${JSON.stringify(data)})'><i class="fa-solid fa-trash deleteService"></i></a></td>`;
                    return buttons;
                }
            }
        ]
    });


}
function FilterState() {

    var existingTable = $('#services').DataTable();

    if ($.fn.DataTable.isDataTable('#services')) {
        existingTable.destroy();
    }

    let table = new DataTable('#services', {
        paging: true,
        lengthMenu: [1, 5, 10, 20],
        pageLength: 5,
        ajax: {
            url: 'https://localhost:7147/api/services/active',
            headers: { "Authorization": "Bearer " + token },
            dataSrc: ''
        },
        columns: [
            { data: 'codService', title: 'Service Code' },
            { data: 'descr', title: 'Description' },
            { data: 'state', title: 'State' },
            { data: 'hourValue', title: 'Hour Value' },
            {
                data: function (data) {
                    var buttons =
                        `<td><a href='javascript:UpdateService(${JSON.stringify(data)})'><i class="fa-solid fa-pen-to-square m-3 updateService"></i></a></td>` +
                        `<td><a href='javascript:DeleteService(${JSON.stringify(data)})'><i class="fa-solid fa-trash deleteService"></i></a></td>`;
                    return buttons;
                }
            }
        ]
    });
}

function DeleteService(data) {
    if (type === "Consultor") {
        alert("No tiene los derechos suficientes para realizar esta acción!")
    }
    else if (window.confirm("Estas seguro que deseas eliminar al servicio?"))
    {
       $.ajax({
            type: "GET",
            url: "DeleteService",
            data: data,
            'dataType': "html",
           success: function (result) {
               location.reload()
            },
       })
    } else {
        alert("No se ha eliminado el servicio!")
    }

}
function UpdateService(data) {
    if (type === "Consultor") {
        alert("No tiene los derechos suficientes para realizar esta acción!")
    }
    else {
        $.ajax({
            type: "GET",
            url: "ServiceAddPartial",
            data: data,
            dataType: "html",
            success: function (result) {
                $("#ServiceAddPartial").html(result);
                $('#servicioModal').modal('show');
            }
        });
}
    
}


function AddService() {
    if (type === "Consultor") {
        alert("No tiene los derechos suficientes para realizar esta acción!")
    }
    else {
        $.ajax({
            type: "GET",
            url: "ServiceAddPartial",
            'dataType': "html",
            success: function (result) {
                $("#ServiceAddPartial").html(result);
                $('#servicioModal').modal('show');
            }
        })
    }
}