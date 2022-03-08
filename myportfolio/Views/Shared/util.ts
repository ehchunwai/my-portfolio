class Util {
    static request(url, type: string, successCallback, failureCallback?, data?, completeCallback?) {
        try {

            if (!data)
                data = {};

            const options = {
                type: type, //get or post
                processData: true,
                data: data,
                url: url,
                beforeSend: function (xhr) {   //Include the bearer token in header
                    const token = localStorage.getItem('token');
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

        } catch (e) {
            console.error(e);
        }
    };

    private static handleUnauthorizedError() {
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
    }

    private static handleForbiddenError() {
        //iziToast.show({
        //    title: '',
        //    message: 'No permission to execute.',
        //    position: 'bottomCenter',
        //    color: 'red',
        //    icon: 'icofont-ban'
        //});
    }
}