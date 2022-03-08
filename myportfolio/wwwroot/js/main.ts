class Main {

    //private urlHome = '/home/index';
    //private urlAboutUs = '/aboutus/index';

    constructor() {
        $(document).on('click', '.nav-link', (e) => {

            let list = document.querySelectorAll(".nav-link");
            list.forEach(function (element) {
                $(element).removeClass("active");
            });
            $(e.target).addClass("active");


            let url = $(e.target).data("url");
            Util.request(url, 'get', (response) => {

                localStorage.setItem('url', url);

                $(".layout-right-main").html(response);
            }, function () {
                console.log("error");
            });
            //$(".layout-right-main iframe").attr('src', url);
        });

        $(document).on('click', '.toggle-theme', (e) => {

            let theme = e.currentTarget.dataset.theme;

            e.currentTarget.style.display = "none";

            let tmpBody = document.querySelector("body");
            if (theme == 'light') {
                tmpBody.classList.remove("theme-dark");

                let tmp: HTMLElement;
                tmp = document.querySelector('.toggle-theme[data-theme="dark"]');
                tmp.style.display = "block";
            }
            else {
                tmpBody.classList.remove("theme-light");
                let tmp: HTMLElement;
                tmp = document.querySelector('.toggle-theme[data-theme="light"]');
                tmp.style.display = "block";
            }
            tmpBody.classList.add(`theme-${theme}`);
        });

        this.setLink();
    }

    setLink = () => {
        const url = localStorage.getItem('url');
        if (url) {
            Util.request(url, 'get', (response) => {
                localStorage.setItem('url', url);

                let list = document.querySelectorAll(".nav-link");
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
    }
}


$(document).ready(function () {
    new Main();
});