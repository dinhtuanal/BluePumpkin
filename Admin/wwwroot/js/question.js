$(document).ready(function () {
    $('body').off('click', '.deleteQuestion').on('click', '.deleteQuestion', Delete);
    function Delete() {
        var id = $(this).data('id');
        bootbox.confirm({
            message: "You want to remove question",
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
                if (result == true) {
                    $.ajax({
                        type: 'post',
                        url: '/Question/Delete',
                        dataType: 'json',
                        data: { id: id },
                        success: function (response) {
                            var data = response.result;
                            console.log(data)
                            if (data.statusCode == 200) {
                                bootbox.alert({
                                    message: "Remove question success",
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
})