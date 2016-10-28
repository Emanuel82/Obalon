(function ($) {

    var authorizeUri = 'http://localhost:64316/';
    var tokenUri = 'http://localhost:64316/token';

    window.login = {};

    window.login.popup = function showFieldsChecklist(idButton, idPopup)
    {
        var dropdown = $('.dropdown-content');
        dropdown.hide();

        if (idButton === '' || idPopup === '') return;

        dropdown = $('#' + idPopup);
        var el = $('#' + idButton);

        var pos = el.position();
        var left = el.outerWidth() + el.offset().left - 350;

        if (dropdown.is(":visible")) {
            dropdown.hide();
        }
        else {
            dropdown.css('left', left + 'px');
            dropdown.css('top', pos.top + 'px');
            dropdown.show();
        }

        this.filterColumnName = "";
        this.filterGroupColumnName = "";

        $('.columnName').parent().parent().show();
        $('.groupColumnName').parent().parent().show();
    }

    $('#Login').click(function () {
        var name        = $("#name").val();
        var password = $("#password").val();

        var sendInfo = {
            grant_type: "password",
            username:  name,
            password: password
        };
        $.ajax({
            url: tokenUri,
            type: 'POST',
            dataType: 'json',
            success: function (data) {
                debugger;
                var result = data;
                $.cookie("ticket", data.access_token);
            },
            data: sendInfo
        });

        //$.ajax(tokenUri, {
        //    beforeSend: function (xhr) {
        //        xhr.setRequestHeader('Authorization', 'Bearer ' + $('#AccessToken').val());
        //    },
        //    dataType: 'text',
        //    cache: false,
        //    success: function (data) {
        //        console.log(data);
        //        $('#output').text(data);
        //    }
        //});

    });


})(jQuery);