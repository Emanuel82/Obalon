(function ($) {

    var authorizeUri    = 'http://localhost:64316/';
    var tokenUri        = 'http://localhost:64316/token';

    //var apiUri = '@(Paths.ResourceServerBaseAddress + Paths.MePath)';
    //var returnUri = '@Paths.ImplicitGrantCallBackPath';
    //debugger;
    

    $('#Authorize').click(function () {
        var nonce = 'my-nonce';

        debugger;

        var uri = addQueryString(authorizeUri, {
            'client_id': '7890ab',
            'redirect_uri': returnUri,
            'state': nonce,
            'scope': 'bio notes',
            'response_type': 'token',
        });

        window.oauth = {};
        window.oauth.signin = function (data) {
            if (data.state !== nonce) {
                return;
            }

            $('#AccessToken').val(data.access_token);
        }

        debugger;

        window.open(uri, 'Authorize', 'width=640,height=480');
    });

    $('#CallApi').click(function () {
        $.ajax(apiUri, {
            beforeSend: function (xhr) {
                xhr.setRequestHeader('Authorization', 'Bearer ' + $('#AccessToken').val());
            },
            dataType: 'text',
            cache: false,
            success: function (data) {
                console.log(data);
                $('#output').text(data);
            }
        });
    });

    function addQueryString(uri, parameters) {
        var delimiter = (uri.indexOf('?') == -1) ? '?' : '&';
        for (var parameterName in parameters) {
            var parameterValue = parameters[parameterName];
            uri += delimiter + encodeURIComponent(parameterName) + '=' + encodeURIComponent(parameterValue);
            delimiter = '&';
        }
        return uri;
    }
})(jQuery);