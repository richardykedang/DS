'use strict';

(function () {

    $('#members-table').DataTable({
        language: {
            searchPlaceholder: 'Search...',
            sSearch: '',
        },
        lengthMenu: [5, 10, 20],
    });

    $('#tasks-table').DataTable({
        language: {
            searchPlaceholder: 'Search...',
            sSearch: '',
        },
        lengthMenu: [5, 10, 20],
    });

    $('#projectfiles-table').DataTable({
        language: {
            searchPlaceholder: 'Search...',
            sSearch: '',
        },
        pageLength: 10,
    });

})
    ();



