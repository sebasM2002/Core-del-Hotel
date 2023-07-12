function UpdateRecord() {
    var id = $("#idInput").val(); // Assuming you have an input field with id "idInput"
    var newName = $("#nameInput").val();
    $.ajax({
        type: "PUT",
        url: "//localhost:44334/api/PaisModels/" + id,
        data: JSON.stringify({
            id_Pais: id,
            name: newName
        }),
        contentType: "application/json",
        success: function (response) {
            console.log("Record updated successfully");
            // Perform any necessary actions after successful update
        },
        error: function (err) {
            console.log("Error updating record:", err);
        }
    });
}

function Load() {
    $.ajax({
        type: "GET",
        url: "//localhost:44334/api/PaisModels",
        dataType: "json",
        success: function (result) {
            console.log(result)
            // Clear the table body
            $('#table tbody').empty();

            // Iterate over the received data and append rows to the table
            $.each(result, function (index, item) {
                var row = '<tr>' +
                    '<td>' + item.id_Pais + '</td>' +
                    '<td>' + item.name + '</td>' +
                    '<td><a href="/PaisModels/Edit/' + item.id_Pais + '" >Edit</a></td>' +
                    '<td><a  href="/PaisModels/Delete/' + item.id_Pais + '">Delete</a></td>' +
                    '<td><a href="/PaisModels/Details/' + item.id_Pais + '">Details</a></td>' +
                    '</tr>';
                $('#table tbody').append(row);
            });
        },
        error: function (err) {
            console.log(err);
        }
    });
}

function LoadIndex() {
    var id = $("#idInput").val();
    $.ajax({
        type: "GET",
        url: "//localhost:44334/api/PaisModels/" + id,
        dataType: "json",
        success: function (result) {
            console.log(result)
            var row = '<tr>' +
                '<td>' + result.id_Pais + '</td>' +
                '<td>' + result.name + '</td>' +
                '</tr>';
            $('#details tbody').append(row);
        },
        error: function (err) {
            console.log(err);
        }
    });
}

function DeleteRecord() {
    var id = $("#idInput").val(); // Assuming you have an input field with id "idInput"

    $.ajax({
        type: "DELETE",
        url: "//localhost:44334/api/PaisModels/" + id,
        contentType: "application/json",
        data: JSON.stringify({
            id_Pais: id,
        }),
        success: function (response) {
            console.log("Record deleted successfully");
            // Perform any necessary actions after successful deletion
        },
        error: function (err) {
            console.log("Error deleting record:", err);
        }
    });
}


function CreateRecord() {
    var newName = $("#nameInput").val();
    $.ajax({
        type: "POST",
        url: "//localhost:44334/api/PaisModels",
        data: JSON.stringify({
            name: newName
            
        }),
        contentType: "application/json",
        success: function (response) {
            console.log("Record created successfully");
            // Perform any necessary actions after successful creation
        },
        error: function (err) {
            console.log("Error creating record:", err);
        }
    });
}