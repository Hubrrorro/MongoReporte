function ExecuteAjax(_url, _type, funcExe, _sync) {
    var url_ =  _url;
    var isAsync = true;
    if (_sync) isAsync = false;

    $.ajax({
        cache: false,
        type: _type,
        url: url_,
        async: isAsync,
        success: function (data) {
                funcExe(data);
        },
        error: function (jqXHR, status, err) {
            console.log(jqXHR);
            console.log(status);
            console.log(err);
            return;
        }
    });
}
function ExecuteAjaxData(_url, _type, funcExe, _sync, _data) {
    var url_ = _url;
    var isAsync = true;
    if (_sync) isAsync = false;

    $.ajax({
        cache: false,
        type: _type,
        url: url_,
        data: _data,
        async: isAsync,
        success: function (data) {
            funcExe(data);
        },
        error: function (jqXHR, status, err) {
            console.log(jqXHR);
            console.log(status);
            console.log(err);
            return;
        }
    });
}