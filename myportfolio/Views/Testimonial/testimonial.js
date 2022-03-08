var Testimonial = /** @class */ (function () {
    function Testimonial() {
        $('.owl-carousel').owlCarousel({
            center: true,
            items: 2,
            loop: true,
            margin: 10,
            autoplay: true,
            autoplayTimeout: 5000,
            animateOut: 'fadeOut'
        });
    }
    return Testimonial;
}());
//$(document).ready(function () {
//    new Testimonial();
//});
//# sourceMappingURL=testimonial.js.map