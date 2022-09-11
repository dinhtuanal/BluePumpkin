$(document).ready(function () {

    $('body').on('click', '#add', Save);

    $('body').off('click', '#distribution').on('click', '#distribution', Load);
    function Load() {
        $('#prizes').find('option').remove().end()
        var event_id = $(this).data('eventid')
        console.log(event_id);
        $.ajax({
            type: 'get',
            url: '/Prize/GetByEventId/',
            dataType: 'json',
            data: { evtId: event_id },
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                var data = response.result;
                for (let i = 0; i < data.length; i++) {
                    $('#prizes').append($('<option>', {
                        value: data[i].prizeId,
                        text: data[i].prizeName
                    }));
                }
            },
            error: function (response) {
                var data = response.result;
                console.log(data);
            }
        });
    }
    function Save() {
        var model = new Object();
        model.status = $('#status').val();
        model.joinEventId = $('#distribution').data('id');
        model.prizeId = $('#prizes').val();
        model.ranking = $('#ranking').val();
        model.amount = $('#amount').val();
        model.createdBy = $('#createdBy').val();

        $.ajax({
            type: 'post',
            url: '/PrizeDistribution/Add',
            dataType: 'json',
            data: JSON.stringify(model),
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                var result = response.result;
                if (result.statusCode == 200) {
                    alert("Add success");
                    window.location.reload();
                }
            },
            error: function (result) {
                console.log(result.statusCode);
            }
        });

    }



})