$(function () {
    $('#login').on('submit', function () {
        var form = $(this);
        form.find('button').prop('disabled', true);
        $.ajax({
            type: 'POST',
            data: form.serialize(),
            url: form.attr('action'),
            success: function (msg) {
                if (msg) {
                    window.location.href = '/Animals/';
                } else {
                    alert('Error!');
                }
                form.find('button').prop('disabled', false);
            },
            error: function (msg) {
                console.log('Server error', msg);
                form.find('button').prop('disabled', false);
            }
        });
        return false;
    });
    $('#registration').on('submit', function () {
        var form = $(this);
        form.find('button').prop('disabled', true);
        $.ajax({
            type: 'POST',
            data: form.serialize(),
            url: form.attr('action'),
            success: function (msg) {
                if (msg) {
                    window.location.href = '/Account/Login';
                } else {
                    alert('Error!');
                }
                form.find('button').prop('disabled', false);
            },
            error: function (msg) {
                console.log('Server error', msg);
                form.find('button').prop('disabled', false);
            }
        });
        return false;
    });
    $('#sign-out').on('click', function () {
        $.ajax({
            type: 'POST',
            url: '/Api/SignOut',
            success: function (msg) {
                window.location.href = '/Animals/';
            },
            error: function (msg) {
                console.log('Server error', msg);
            }
        });
        return false;
    });
});