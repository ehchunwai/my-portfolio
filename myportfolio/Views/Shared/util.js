var Util = /** @class */ (function () {
    function Util() {
    }
    Util.request = function (url, type, successCallback, failureCallback, data, completeCallback) {
        try {
            if (!data)
                data = {};
            var options = {
                type: type,
                processData: true,
                data: data,
                url: url,
                beforeSend: function (xhr) {
                    var token = localStorage.getItem('token');
                    if (token) {
                        xhr.setRequestHeader("Authorization", 'Bearer ' + token);
                    }
                },
                statusCode: {
                    200: successCallback,
                    401: this.handleUnauthorizedError,
                    403: this.handleForbiddenError,
                },
                complete: function () {
                    if (completeCallback)
                        completeCallback();
                },
                error: function () {
                    if (failureCallback)
                        failureCallback();
                }
            };
            $.ajax(options);
        }
        catch (e) {
            console.error(e);
        }
    };
    ;
    Util.handleUnauthorizedError = function () {
        //iziToast.show({
        //    title: '',
        //    message: 'Session expired. Please login again.',
        //    position: 'bottomCenter',
        //    color: 'red',
        //    icon: 'icofont-ban',
        //    onClosed: () => {
        //        location.reload();  //force to reload in order to redirect to login page                    
        //    }
        //});
    };
    Util.handleForbiddenError = function () {
        //iziToast.show({
        //    title: '',
        //    message: 'No permission to execute.',
        //    position: 'bottomCenter',
        //    color: 'red',
        //    icon: 'icofont-ban'
        //});
    };
    return Util;
}());
//# sourceMappingURL=util.js.map