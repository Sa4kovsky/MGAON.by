$('.anchor').on('click', function (e) {

    e.preventDefault();

    var target = $(this).attr('name'),
        offset = $(target).offset().top;

   /// $(document).scrollTop(offset);
    $("html, body").stop().animate({
        scrollTop: offset
    }, 1200);

});

// Создание масок.
$(function () {
    $("#tel").mask("8(099) 99-99-999");
});


var x = 0;
var profile = document.getElementById('profile');
var div = document.createElement('div');

//Метод рисования новых форм для физ.лиц.
function addInputNaturalPerson() {
    if (x < 1) {
        delInput();
        div.id = 'input' + ++x;
        div.innerHTML = '<div class="form-group"><input type="text" class="form-control" name="designation" id="designation" placeholder="Наименование и (или) адрес организации либо должность лица*" required /></div> <div class="form-group"><input type="text" class="form-control" name="fullName" id="fullName" placeholder="ФИО*" required /></div> <div class="form-group"><input type="text" class="form-control" name="address" id="address" placeholder="Адрес места жительства (места пребывания)*" /></div> <div class="form-group"><input type="email" class="form-control" name="email" id="email" placeholder="Электронная почта*" /></div>  <div class="form-group"><input type="text" class="form-control" name="tel" id="tel" placeholder="Контактный телефон" /></div> <div class="form-group"><textarea class="form-control" name="message" id="message" placeholder="Обращение*" maxlength="2000"></textarea></div>  <div class="text-center" style="padding:20px"><button type="button" formnovalidate value="SendEmail" id="buttonSendEmail">Отправить сообщение</button></div>';
        profile.appendChild(div);
        $("#tel").mask("8(099) 99-99-999");
        //ajax сробатывает при отправе сообщения, чтобы частично обновлять представление
        $(document).ready(function () {
            $('#buttonSendEmail').click(function () {

                $('#exampleModalCenter').modal('show')

            });
        });
    }
}

//Метод рисования новых форм для юр.лиц.
function addInputLegalPerson() {
    if (x < 1) {
        delInput();
        div.id = 'input' + ++x;
        div.innerHTML = '<div class="form-group"><input type="text" class="form-control" name="designation" id="designation" placeholder="Наименование и (или) адрес организации либо должность лица*" required /></div> <div class="form-group"><input type="text" class="form-control" name="nameLegal" id="nameLegal" placeholder="Полное наименование юридического лица*" required /></div> <div class="form-group"><input type="text" class="form-control" name="fullName" id="fullName" placeholder="ФИО либо инициалы руководителя или лица, уполномоченного в установленном порядке подписывать обращения*" required /></div> <div class="form-group"><input type="text" class="form-control" name="address" id="address" placeholder="Местонахождение юридического лица*" /></div> <div class="form-group"><input type="email" class="form-control" name="email" id="email" placeholder="Электронная почта*" /></div>  <div class="form-group"><input type="text" class="form-control" name="tel" id="tel" placeholder="Контактный телефон" /></div> <div class="form-group"><textarea class="form-control" name="message" id="message" placeholder="Обращение*" maxlength="2000"></textarea></div>  <div class="text-center" style="padding:20px"><button type="button" formnovalidate value="SendEmail" id="buttonSendEmail">Отправить сообщение</button></div>';
        profile.appendChild(div);
        $("#tel").mask("8(099) 99-99-999");
        //ajax сробатывает при отправе сообщения, чтобы частично обновлять представление
        $(document).ready(function () {
            $('#buttonSendEmail').click(function () {

                $('#exampleModalCenter').modal('show')

            });
        });
    }
}

//Метод удаления
function delInput() {
    var div = document.getElementById('input' + x);
    div.remove();
    --x;
}

