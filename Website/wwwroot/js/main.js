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
function maskTel() {
    $("#tel").mask("8(099) 99-99-999");
};


//Проверки на валидность
var _validName, _validMessage, _validDesignation, _validAddress, _validEmail, _validNameLegal;
function ValidName() {
    var regular = /^([А-яёіў ][а-яёіў ]+[\-\'\s]?){3,}?$/;
    var fullName = document.getElementById('fullName').value;
    _validName = regular.test(fullName);
    if (_validName) {
        document.getElementById('fullName').style.borderColor = '#ced4da';
        document.getElementById('resultName').innerHTML = '';
        document.getElementById('resultSendEmail').innerHTML = '';
    }
    else {
        output = 'Укажите полное имя (кириллицей)';
        document.getElementById('fullName').style.borderColor = '#dc3545';
        document.getElementById('resultName').innerHTML = output;
        $('#exampleModalCenter').modal('show')
    }
    return _validName;
}

function ValidMessage() {
    var regular = /^[А-яёіў][А-яёіў0-9,. -!?""'']*$/;
    var message = document.getElementById('message').value;
    _validMessage = regular.test(message);
    if (_validMessage) {
        document.getElementById('message').style.borderColor = '#ced4da';
        document.getElementById('resultMessage').innerHTML = '';
        document.getElementById('resultSendEmail').innerHTML = '';
    }
    else {
        output = 'Обращение (кириллицей)';
        document.getElementById('message').style.borderColor = '#dc3545';
        document.getElementById('resultMessage').innerHTML = output;
        $('#exampleModalCenter').modal('show')
    }

    return _validMessage;
} 

function ValidDesignation() {
    var regular = /^[А-яёіў][А-яёіў0-9,. -!?""'']*$/;
    var designation = document.getElementById('designation').value;
    _validDesignation = regular.test(designation);
    if (_validDesignation) {
        document.getElementById('designation').style.borderColor = '#ced4da';
        document.getElementById('resultDesignation').innerHTML = '';
        document.getElementById('resultSendEmail').innerHTML = '';
    }
    else {
        output = 'Наименование и (или) адрес организации либо должность лица обязательное поле (кириллицей)';
        document.getElementById('designation').style.borderColor = '#dc3545';
        document.getElementById('resultDesignation').innerHTML = output;
        $('#exampleModalCenter').modal('show')
    }
    return _validDesignation;
} 

function ValidAddress() {
    var regular = /^[А-яёіў][А-яёіў0-9,. -!?""'']*$/;
    var address = document.getElementById('address').value;
    _validAddress = regular.test(address);
    if (_validAddress) {
        document.getElementById('address').style.borderColor = '#ced4da';
        document.getElementById('resultAddress').innerHTML = '';
        document.getElementById('resultSendEmail').innerHTML = '';
    }
    else {
        output = 'Адрес обязательное поле (кириллицей)';
        document.getElementById('address').style.borderColor = '#dc3545';
        document.getElementById('resultAddress').innerHTML = output;
        $('#exampleModalCenter').modal('show')
    }
    return _validAddress;
} 

function ValidEmail() {
    var regular = /.+@.+\..+/i;
    var email = document.getElementById('email').value;
    _validEmail = regular.test(email);
    if (_validEmail) {
        document.getElementById('email').style.borderColor = '#ced4da';
        document.getElementById('resultEmail').innerHTML = '';
        document.getElementById('resultSendEmail').innerHTML = '';
    }
    else {
        output = 'Введите корректный емайл';
        document.getElementById('email').style.borderColor = '#dc3545';
        document.getElementById('resultEmail').innerHTML = output;
        $('#exampleModalCenter').modal('show')
    }
    return _validEmail;
} 

function ValidNameLegal() {
    var regular = /^[А-яёіў][А-яёіў0-9,. -!?""'']*$/;
    var nameLegal = document.getElementById('nameLegal').value;
    _validNameLegal = regular.test(nameLegal);
    if (_validNameLegal) {
        document.getElementById('nameLegal').style.borderColor = '#ced4da';
        document.getElementById('resultNameLegal').innerHTML = '';
        document.getElementById('resultSendEmail').innerHTML = '';
    }
    else {
        output = 'Введите наименование юридического лица (кириллицей)';
        document.getElementById('nameLegal').style.borderColor = '#dc3545';
        document.getElementById('resultNameLegal').innerHTML = output;
        $('#exampleModalCenter').modal('show')
    }
    return _validNameLegal;
} 

var x = 0;
var profile = document.getElementById('profile');
var div = document.createElement('div');

function Add() {
    div.id = 'input' + ++x;
    div.innerHTML = '<input type="file" name="upload" id="uploadFile" /><br /> <button type="button" formnovalidate value="SendEmail" id="buttonSendEmailas">Отправить сообщение</button>';
    profile.appendChild(div);
    $(document).ready(function () {
        $('#buttonSendEmailas').click(function () {
            var formData = new FormData();
            formData.append('File', $('#uploadFile')[0].files[0]); // myFile is the input type="file" control
            $.ajax({
                url: '/service/uploadFile',
                type: 'POST',
                data: formData,
                processData: false,
                contentType: false
            });
        });
    });
}

//Метод рисования новых форм для физ.лиц.
function addInputNaturalPerson() {
    if (x < 1) {
        delInput();
        div.id = 'input' + ++x;
        div.innerHTML = '<div class="form-group"><input type="text" class="form-control" name="designation" id="designation" placeholder="Наименование и (или) адрес организации либо должность лица*" required /></div> <div class="form-group"><input type="text" class="form-control" name="fullName" id="fullName" placeholder="ФИО*" required /></div> <div class="form-group"><input type="text" class="form-control" name="address" id="address" placeholder="Адрес места жительства (места пребывания)*" /></div> <div class="form-group"><input type="email" class="form-control" name="email" id="email" placeholder="Электронная почта*" /></div>  <div class="form-group"><input type="text" class="form-control" name="tel" id="tel" placeholder="Контактный телефон" /></div> <div class="form-group"><textarea class="form-control" name="message" id="message" placeholder="Обращение*" maxlength="2000"></textarea></div> <div class="form-group"><input type="file" name="upload" id="uploadFile" /></div> <div class="text-center" style="padding:20px"><button type="button" formnovalidate value="SendEmail" id="buttonSendEmail">Отправить сообщение</button></div>';
        profile.appendChild(div);
        maskTel();
        //ajax сробатывает при отправе сообщения, чтобы частично обновлять представление
        $(document).ready(function () {
            $('#buttonSendEmail').click(function () {
                ValidName();
                ValidMessage();
                ValidDesignation();
                ValidAddress();
                ValidEmail();
                if (_validName == true && _validMessage == true && _validDesignation == true && _validAddress == true && _validEmail == true) {
                    var formData = new FormData();
                    formData.append('File', $('#uploadFile')[0].files[0]); // myFile is the input type="file" control
                    formData.append('Name', $('#fullName').val());
                    formData.append('Address', $('#address').val());
                    formData.append('Email', $('#email').val());
                    formData.append('Phone', $('#tel').val());
                    formData.append('Message', $('#message').val());
                    formData.append('Designation', $('#designation').val());
                    $.ajax({
                        url: '/service/sendEmail',
                        type: 'POST',
                        data: formData,
                        processData: false,
                        contentType: false,
                        success: function (result) {
                            $('#resultSendEmail').html(result);
                        }
                    });
                    $('#exampleModalCenter').modal('show')
                }
            });
        });
    }
}

//Метод рисования новых форм для юр.лиц.
function addInputLegalPerson() {
    if (x < 1) {
        delInput();
        div.id = 'input' + ++x;
        div.innerHTML = '<div class="form-group"><input type="text" class="form-control" name="designation" id="designation" placeholder="Наименование и (или) адрес организации либо должность лица*" required /></div> <div class="form-group"><input type="text" class="form-control" name="nameLegal" id="nameLegal" placeholder="Полное наименование юридического лица*" required /></div> <div class="form-group"><input type="text" class="form-control" name="fullName" id="fullName" placeholder="ФИО либо инициалы руководителя или лица, уполномоченного в установленном порядке подписывать обращения*" required /></div> <div class="form-group"><input type="text" class="form-control" name="address" id="address" placeholder="Местонахождение юридического лица*" /></div> <div class="form-group"><input type="email" class="form-control" name="email" id="email" placeholder="Электронная почта*" /></div>  <div class="form-group"><input type="text" class="form-control" name="tel" id="tel" placeholder="Контактный телефон" /></div> <div class="form-group"><textarea class="form-control" name="message" id="message" placeholder="Обращение*" maxlength="2000"></textarea></div> <div class="form-group"><input type="file" name="upload" id="uploadFile" /></div> <div class="text-center" style="padding:20px"><button type="button" formnovalidate value="SendEmail" id="buttonSendEmail">Отправить сообщение</button></div>';
        profile.appendChild(div);
        maskTel();
        //ajax сробатывает при отправе сообщения, чтобы частично обновлять представление
        $(document).ready(function () {
            $('#buttonSendEmail').click(function () {
                ValidName();
                ValidNameLegal();
                ValidMessage();
                ValidDesignation();
                ValidAddress();
                ValidEmail();
                if (_validName == true && _validMessage == true && _validDesignation == true && _validAddress == true && _validEmail == true && _validNameLegal == true) {
                    var formData = new FormData();
                    formData.append('File', $('#uploadFile')[0].files[0]); // myFile is the input type="file" control
                    formData.append('Name', $('#fullName').val());
                    formData.append('Address', $('#address').val());
                    formData.append('Email', $('#email').val());
                    formData.append('Phone', $('#tel').val());
                    formData.append('Message', $('#message').val());
                    formData.append('Designation', $('#designation').val());
                    formData.append('NameLegal', $('#nameLegal').val());
                    $.ajax({
                        url: '/service/sendEmail',
                        type: 'POST',
                        data: formData,
                        processData: false,
                        contentType: false,
                        success: function (result) {
                            $('#resultSendEmail').html(result);
                        }
                    });
                    $('#exampleModalCenter').modal('show')
                }
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

