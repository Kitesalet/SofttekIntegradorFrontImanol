var token = localStorage.getItem('token');
var type = localStorage.getItem('type')

console.log(type)

let table = new DataTable('#usuarios', {
    paging: true, 
    lengthMenu: [1, 5, 10, 20], 
    pageLength: 5,
    ajax: {

        url: `https://localhost:7147/api/users?page=1&units=1000`,
        dataSrc: "data",
        headers: { "Authorization": "Bearer " + token }
    },
    columns: [
        { data: 'codUser', title: 'CodUsuario' },
        { data: 'name', title: 'Nombre' },
        { data: 'dni', title: 'Dni' },
        { data: 'type', title: 'Tipo' },
        {
            data: function (data) {
                var buttons =	
                    `<td><a href='javascript:UpdateUser(${JSON.stringify(data)})'><i class="fa-solid fa-pen-to-square m-3 updateUser"></i></a></td>` +
                    `<td><a href='javascript:DeleteUser(${JSON.stringify(data)})'><i class="fa-solid fa-trash deleteUser"></i></a></td>`;
                return buttons;
            }
        }
    ]
});

function DeleteUser(data) {
    if (type === "Consultor") {
        alert("No tiene los derechos suficientes para realizar esta acción!")
    }
    else if (window.confirm("Estas seguro que deseas eliminar al usuario?"))
    {
       $.ajax({
            type: "GET",
            url: "DeleteUser",
            data: data,
            'dataType': "html",
           success: function (result) {
               alert('Por favor, recargue la pagina...')
            },
       })
    } else {
        alert("No se ha eliminado al usuario!")
    }

}
function UpdateUser(data) {
    if (type === "Consultor") {
        alert("No tiene los derechos suficientes para realizar esta acción!")
    }
    else {
        $.ajax({
            type: "GET",
            url: "UsersAddPartial",
            data: data,
            dataType: "html",
            success: function (result) {
                $("#UsersAddPartial").html(result);
                $('#usuarioModal').modal('show');
            }
        });
}
    
}


function AddUser() {
    if (type === "Consultor") {
        alert("No tiene los derechos suficientes para realizar esta acción!")
    }
    else {
        $.ajax({
            type: "GET",
            url: "UsersAddPartial",
            'dataType': "html",
            success: function (result) {
                $("#UsersAddPartial").html(result);
                $('#usuarioModal').modal('show');
            }
        })
    }
}