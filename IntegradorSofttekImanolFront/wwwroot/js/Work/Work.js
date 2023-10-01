var token = localStorage.getItem('token');
var type = localStorage.getItem('type')

let table = new DataTable('#works', {
    paging: true,
    lengthMenu: [1, 5, 10, 20],
    pageLength: 5,
    ajax: {
        url: `https://localhost:7147/api/works?page=1&units=100`,
        dataSrc: "data",
        headers: { "Authorization": "Bearer " + token }
    },
    columns: [
        { data: 'codWork', title: 'CodTrabajo' },
        { data: 'date', title: 'Fecha' },
        { data: 'project.codProject', title: 'CodProyecto' },
        { data: 'service.codService', title: 'CodServicio' },
        { data: 'hourQty', title: 'Cantidad de Horas' },
        { data: 'hourValue', title: 'Valor x Hora' },
        { data: 'cost', title: 'Costo' },
        {
            data: function (data) {
                var buttons =
                    `<td><a href='javascript:UpdateWork(${JSON.stringify(data)})'><i class="fa-solid fa-pen-to-square m-3 updateWork"></i></a></td>` +
                    `<td><a href='javascript:DeleteWork(${JSON.stringify(data)})'><i class="fa-solid fa-trash deleteWork"></i></a></td>`;
                return buttons;
            }
        }
    ]
});

function DeleteWork(data) {
    if (type === "Consultor") {
        alert("No tiene los derechos suficientes para realizar esta acción!")
    }
    else if (window.confirm("Estas seguro que deseas eliminar el trabajo?"))
    {
       $.ajax({
            type: "GET",
            url: "DeleteWork",
            data: data,
            'dataType': "html",
           success: function (result) {
               location.reload()
            },
       })
    } else {
        alert("No se ha eliminado el trabajo!")
    }

}
function UpdateWork(data) {
    if (type === "Consultor") {
        alert("No tiene los derechos suficientes para realizar esta acción!")
    }
    else {
        $.ajax({
            type: "POST",
            url: "WorkAddPartial",
            data: data,
            dataType: "html",
            success: function (result) {
                $("#WorkAddPartial").html(result);
                $('#trabajoModal').modal('show');
            }
        });
}
    
}


function AddWork() {
    if (type === "Consultor") {
        alert("No tiene los derechos suficientes para realizar esta acción!")
    }
    else {
        $.ajax({
            type: "GET",
            url: "WorkAddPartial",
            'dataType': "html",
            success: function (result) {
                $("#WorkAddPartial").html(result);
                $('#trabajoModal').modal('show');
            }
        })
    }
}