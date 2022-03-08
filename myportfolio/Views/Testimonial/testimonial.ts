class Testimonial {
    constructor() {
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
}


//$(document).ready(function () {
//    new Testimonial();
//});