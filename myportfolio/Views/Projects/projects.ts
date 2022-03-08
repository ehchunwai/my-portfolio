class Project {

    constructor() {
        const scope = this;
        /*setTimeout(() => {*/

        setTimeout(() => {
            scope.triggerAnimate();

            setInterval(() => {
                scope.triggerAnimate();
            }, 5000);
        }, 2000);

 


    }

    triggerAnimate = () => {
        let elemList = document.getElementsByClassName("flip-card") as HTMLCollection;

        Array.prototype.forEach.call(elemList, function (elem: HTMLElement, index) {
            elem.style.animation = 'none';
            elem.offsetHeight; /* trigger reflow */
            elem.style.animation = null;

            if (!$(elem).is(":hover")) {
                $(elem).css("animation", "shake 0.72s cubic-bezier(.36,.07,.19,.97) both");
                $(elem).css("transform", " translate3d(0, 0, 0)");
            }
        });
        console.log("trigger");
    }

}

$(document).ready(function () {
    new Project();
});