$(function () {
    'use strict';

    $('#datatable2').DataTable({
        lengthMenu: [[5, 10, 15, 50, -1], [5, 10, 15, 50, "All"]],
        responsive: true,
        language: {
            searchPlaceholder: 'Search...',
            sSearch: '',
            lengthMenu: "Show _MENU_ item/page",
        }
    });

});
