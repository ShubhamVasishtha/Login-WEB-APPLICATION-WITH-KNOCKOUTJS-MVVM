var Log = (function () {

    var _uname = ko.observable("");
    var _pass = ko.observable("");
    
    var _click = function () {

        $.ajax({
            url: "/Login_Controller.ashx?method=login",
            type: "get",
            async: false,
            cache: false,
            dataType: "json",
            data: {username: _uname() ,password:_pass()},
            success: function (result) {
                alert(result);              
            },
            error: function (result) {
                alert(result);
                return ([]);
            }
        });
    }

    return {
        username: _uname,
        password: _pass,
        submit: _click
    };
});
ko.applyBindings(Log);


