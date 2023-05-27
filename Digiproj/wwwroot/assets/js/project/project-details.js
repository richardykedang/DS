'use strict';

(function () {

    //Data Tables
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

    //$('#log-table').DataTable({
    //    language: {
    //        searchPlaceholder: 'Search...',
    //        sSearch: '',
    //    },
    //    pageLength: 10,
    //});

    $('#projectfiles-table').DataTable({
        language: {
            searchPlaceholder: 'Search...',
            sSearch: '',
        },
        pageLength: 10,
    });

})
    ();




