$(document).ready(function () {
    $('body').off('click', '#joinEvent').on('click', '#joinEvent', ShowJoinEvent);
    $('body').off('click', '#prize').on('click', '#prize', ShowPrize);
    function ShowJoinEvent() {
        var id = $(this).data('id');
        $.ajax({
            type: 'get',
            url: '/JoinEvent/getId',
            dataType: 'json',
            data: { id: id },
            success: function (response) {
                const data = response.result.result;
                $('#username').text(data.userName);
                $('#event').text(data.eventName);
                $('#description').text(data.description);
                switch (data.joinEventStatus) {
                    case 0:
                        $('#status').text("InActive");
                    case 1:
                        $('#status').text("Failed");
                    case 2:
                        $('#status').text("Peding");
                    case 3:
                        $('#status').text("Accepted");
                    case 4:
                        $('#status').text("Won");
                }
            },
            error: function (err) {
                console.log("Error: " + err)
            }
        })
    }
    function ShowPrize() {
        var id = $(this).data('id');
        $.ajax({
            type: 'get',
            url: '/prize/getId',
            dataType: 'json',
            data: { id: id },
            success: function (response) {
                var data = response.result;
                $('#prizeName').text(data.prizeName);
                $('#content').text(data.content);
                $('#amount').text(data.amount);
            },
            error: function (err) {
                console.log("Error: " + err)
            }
        })
    }
})