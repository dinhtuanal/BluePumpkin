$(document).ready(function () {
    $('body').off('click', '.addUserInRole').on('click', '.removeUserInRole', removeUserInRole);;
    function removeUserInRole() {
        var model = new Object();       
        model.userName = $(this).data('user');
        model.roleName = $('#roleName').text();

        bootbox.confirm({
            message: "You want to remove user in this role",
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
                        url: '/Role/RemoveUserInRole',
                        dataType: 'json',
                        data: JSON.stringify(model),
                        contentType: "application/json; charset=utf-8",
                        success: function (response) {
                            var data = response.result;
                            if (data.statusCode == 200) {
                                bootbox.alert({
                                    message: "Remove user in role success",
                                    callback: function () {
                                        window.location.reload()
                                    }
                                })
                            } else if (data.statusCode == 401) {
                                bootbox.alert({
                                    message: "You don't have permission to remove",
                                    size: 'large'
                                })
                            } else {
                                bootbox.alert({
                                    message: "Error! Can not remove!",
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