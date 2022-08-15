$(document).ready(function () {
    $('body').off('click', '.addUserInRole').on('click', '.addUserInRole', addUserInRole);;
    function addUserInRole() {
        var model = new Object();       
        model.userName = $(this).data('user');
        model.roleName = $('#roleName').text();

        bootbox.confirm({
            message: "You want to assign user in this role",
            buttons: {
                confirm: {
                    label: 'Yes',
                    className: 'btn-success'
                },
                cancel: {
                    label: 'No',
                    className: 'btn-danger'
                }
            },
            callback: function (result) {
                console.log(model.roleName);
                if (result == true) {
                    $.ajax({
                        type: 'post',
                        url: '/Role/AddUserInRole',
                        dataType: 'json',
                        data: JSON.stringify(model),
                        contentType: "application/json; charset=utf-8",
                        success: function (response) {
                            var data = response.result;
                            if (data.statusCode == 200) {
                                bootbox.alert({
                                    message: "Add user in role success",
                                    callback: function () {
                                        window.location.reload()
                                    }
                                })
                            } else if (data.statusCode == 401) {
                                bootbox.alert({
                                    message: "You don't have permission to add",
                                    size: 'large'
                                })
                            } else {
                                bootbox.alert({
                                    message: "Error! Can not add!",
                                    size: 'large'
                                })
                            }
                            
                            
                        },
                        error: function (response) {
                            bootbox.alert("Error: " + response)
                        }
                    });
                }
            }
        });
    }


});