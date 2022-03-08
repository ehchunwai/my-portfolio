var Project = /** @class */ (function () {
    function Project() {
        this.triggerAnimate = function () {
            var elemList = document.getElementsByClassName("flip-card");
            Array.prototype.forEach.call(elemList, function (elem, index) {
                elem.style.animation = 'none';
                elem.offsetHeight; /* trigger reflow */
                elem.style.animation = null;
                if (!$(elem).is(":hover")) {
                    $(elem).css("animation", "shake 0.72s cubic-bezier(.36,.07,.19,.97) both");
                    $(elem).css("transform", " translate3d(0, 0, 0)");
                }
            });
            console.log("trigger");
        };
        var scope = this;
        /*setTimeout(() => {*/
        setTimeout(function () {
            scope.triggerAnimate();
            setInterval(function () {
                scope.triggerAnimate();
            }, 5000);
        }, 2000);
    }
    return Project;
}());
$(document).ready(function () {
    new Project();
});
//# sourceMappingURL=projects.js.map