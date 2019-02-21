$(document).ready(function($) {

    // Выпадающее меню на мобильных устройствах
    $('.menu-toggle').on('click', function(event) {
        event.preventDefault();
        $(this).parent().find('ul').toggleClass('opened');
    });


    // Попапы
    var popup = getURLParameter('showpopup');

    switch (popup) {
        case 'ok':
            $('#popup-success').fadeIn(200);
            break;
        case 'fail':
            $('#popup-fail').fadeIn(200);
            break;
        case 'sent':
            $('#popup-sent').fadeIn(200);
            break;
    }

    $('.popup-overlay, .popup-close').on('click', function(event) {
        event.preventDefault();
        $(this).closest('.popup').fadeOut(200);
    });

    // Слайдер
    $('.bxslider').bxSlider({
        minSlides: 1,
        maxSlides: 3,
        moveSlides: 1,
        slideWidth: 360,
        slideMargin: 20,
        pager: false,
        adaptiveHeight: true
    });

    // Form Validator

    $('#phone, #MainContent_mobilenumber').on('keydown keyup', function(e) {
        $(this).val($(this).val().replace(/[^0-9]/g, ''));
        //this.value=this.value.replace(/[^\d]/,'');
    });

    try {
        $('.footer').find('form').validate({
            errorClass: "error",
            validClass: "valid",
            highlight: function(element, errorClass, validClass) {
                $(element).addClass(errorClass).removeClass(validClass);
            },
            unhighlight: function(element, errorClass, validClass) {
                $(element).removeClass(errorClass).addClass(validClass);
            },
            rules: {
                ctl00$phone: {
                    required: true,
                    minlength: 11
                }
            },
            messages: {
                ctl00$phone: {
                    required: "",
                    minlength: ""
                }
            }
        });
    } catch (e) {}
    try {
        $('#reg_form').validate({
            errorClass: "error",
            validClass: "valid",
            highlight: function(element, errorClass, validClass) {
                $(element).addClass(errorClass).removeClass(validClass);
            },
            unhighlight: function(element, errorClass, validClass) {
                $(element).removeClass(errorClass).addClass(validClass);
            },
            rules: {
                ctl00$MainContent$teamname: {
                    required: true,
                    minlength: 3
                },
                ctl00$MainContent$mobilenumber: {
                    required: true,
                    minlength: 11
                }
            },
            messages: {
                ctl00$MainContent$teamname: {
                    required: "",
                    minlength: ""
                },
                ctl00$MainContent$mobilenumber: {
                    required: "",
                    minlength: ""
                }
            }
        });
    } catch (e) {}

    // Видео попап
    $('.video-wrap').on('click', 'a', function(event) {
        event.preventDefault();
        height = $(window).height() * 0.8; // высота окна, сейчас 80% от высоты окна браузера
        width = $(window).width() * 0.8; // высота окна, сейчас 80% от ширины окна браузера
        $.fancybox({
            'type': 'iframe',
            'href': this.href.replace(new RegExp('watch\\?v=', 'i'), 'embed/') + '?rel=0&autoplay=1&showinfo=0', // autoplay=1 отвечает за проигрывание видео при открытии, 0 - нет автопроигрывания
            'overlayShow': true,
            'centerOnScroll': true,
            'speedIn': 100,
            'speedOut': 50,
            'width': width,
            'height': height,
            'padding': 0,
            'overlayOpacity': 0.9, // прозрачность подложки, 1 - фон не прозрачен
            'overlayColor': '#000' // цвет подолжки
        });
    });

    $('.fancybox').fancybox({
        'padding': 0
    });

    function getURLParameter(title) {
        return decodeURI((RegExp(title + '=' + '(.+?)(&|$)').exec(location.search) || [, null])[1]);
    }

});
