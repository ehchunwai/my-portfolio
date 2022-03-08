var Main = /** @class */ (function () {
    //private urlHome = '/home/index';
    //private urlAboutUs = '/aboutus/index';
    function Main() {
        this.setLink = function () {
            var url = localStorage.getItem('url');
            if (url) {
                Util.request(url, 'get', function (response) {
                    localStorage.setItem('url', url);
                    var list = document.querySelectorAll(".nav-link");
                    list.forEach(function (element) {
                        $(element).removeClass("active");
                    });
                    list.forEach(function (element) {
                        if (element.getAttribute("data-url") == url) {
                            element.classList.add("active");
                            return;
                        }
                    });
                    $(".layout-right-main").html(response);
                }, function () {
                    console.log("error");
                });
            }
        };
        $(document).on('click', '.nav-link', function (e) {
            var list = document.querySelectorAll(".nav-link");
            list.forEach(function (element) {
                $(element).removeClass("active");
            });
            $(e.target).addClass("active");
            var url = $(e.target).data("url");
            Util.request(url, 'get', function (response) {
                localStorage.setItem('url', url);
                $(".layout-right-main").html(response);
            }, function () {
                console.log("error");
            });
            //$(".layout-right-main iframe").attr('src', url);
        });
        $(document).on('click', '.toggle-theme', function (e) {
            var theme = e.currentTarget.dataset.theme;
            e.currentTarget.style.display = "none";
            var tmpBody = document.querySelector("body");
            if (theme == 'light') {
                tmpBody.classList.remove("theme-dark");
                var tmp = void 0;
                tmp = document.querySelector('.toggle-theme[data-theme="dark"]');
                tmp.style.display = "block";
            }
            else {
                tmpBody.classList.remove("theme-light");
                var tmp = void 0;
                tmp = document.querySelector('.toggle-theme[data-theme="light"]');
                tmp.style.display = "block";
            }
            tmpBody.classList.add("theme-".concat(theme));
        });
        this.setLink();
    }
    return Main;
}());
$(document).ready(function () {
    new Main();
});
//# sourceMappingURL=main.js.map