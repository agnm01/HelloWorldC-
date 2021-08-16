//Js code
$(document).ready(function () {
    // see https://api.jquery.com/click/

    $('#nameField').on('keyup', function () {
        var empty = false;

        $('#nameField').each(function () {
            empty = $(this).val().length == 0;
        });

        if (empty)
            $('#createMember').attr('disabled', 'disabled');
        else
            $('#createMember').attr('disabled', false);
    });

    $("#createMember").click(function () {
        var newcomerName = $("#nameField").val();
        $.ajax({
            method: "POST",
            url: "/Home/AddTeamMember",
            data: {
                "name": newcomerName
            },
            success: function (result) {
                $("#list").append(`
                <li class="member" data-member-id=${result.id}>
                    <span class="name">${result.name}</span>
                    <span class="delete fa fa-remove"></span>
                    <span class="pencil fa fa-pencil"></span>
                </li>`
                );
                $("#nameField").val("");
                $('#createMember').prop('disabled', true);
            },
            error: function (err) {
                console.log(err);
            }
        })
    });

    $("#clearNameField").click(function () {
        $("#nameField").val("");
        $('#createMember').prop('disabled', true);
    });

    $('#editClassmate  #submit').click(function () {
        console.log("clicked");
    });

    $("#list").on("click", ".pencil", function () {
        var targetMemberTag = $(this).closest('li');
        var id = targetMemberTag.attr('data-member-id');
        var currentName = targetMemberTag.find(".name").text();

        $('#editClassmate').attr("data-member-id", id);
        $('#classmateName').val(currentName);
        $('#editClassmate').modal('show');
    });

    $("#editClassmate").on("click", "#submit", function () {
        var name = $("#classmateName").val();
        var id = $('#editClassmate').attr('data-member-id');

        $.ajax({
            method: "PUT",
            url: "/Home/UpdateTeamMember",
            data: {
                "id": id,
                "name": name
            },
            success: function (result) {
                console.log('Succsesful renamed: ${id}')
                location.reload();
            }
        })
    });

    $("#editClassmate").on("click", "#cancel", function () {
        console.log('cancel changes');
    });

    $("#list").on("click", ".delete", function () {
        const targetMemberTag = $(this).closest('li');
        var id = targetMemberTag.attr('data-member-id');

        $.ajax({
            method: "DELETE",
            url: `/Home/DeleteTeamMember?id=${id}`,
            success: function (result) {
                targetMemberTag.remove();
            },
            error: function (err) {
                console.log(err);
            }
        })
    });
});
