$(function () {
    var animals = $('#animals');
    var houses = $('#houses');

    animals.on('click', function () {
        $.ajax({
            type: 'GET',
            url: '/api/AnimalsTest',
            success: function (msg) {
                var html = '<ul>';
                $.each(msg, function (i, el) {
                    html += '<li>' + el.Id + ': ' + el.Name + ' (' + el.Type + ')</li>';
                });
                html += '</ul>';
                $('.list-container').empty().append(html);
            },
            error: function (msg) {
                console.log('Server error', msg);
            }
        });
    });
    houses.on('click', function () {
        $.ajax({
            type: 'GET',
            url: '/api/HousesTest',
            success: function (msg) {
                var html = '<ul>';
                $.each(msg, function (i, el) {
                    html += '<li>' + el.Id + ': ' + el.Name + '</li>';
                });
                html += '</ul>';
                $('.list-container').empty().append(html);
            },
            error: function (msg) {
                console.log('Server error', msg);
            }
        });
    });
});