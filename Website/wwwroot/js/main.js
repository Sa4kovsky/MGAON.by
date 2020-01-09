$('.anchor').on('click', function (e) {

    e.preventDefault();

    var target = $(this).attr('href'),
        offset = $(target).offset().top;

   /// $(document).scrollTop(offset);
    $("html, body").stop().animate({
        scrollTop: offset
    }, 1200);

});