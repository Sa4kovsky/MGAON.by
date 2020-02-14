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
    $("#tel").mask("+375 (99) 99-99-999");
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

//Метод рисования новых форм для физ.лиц (RU).
function addInputNaturalPerson() {
    if (x < 1) {
        delInput();
        div.id = 'input' + ++x;
        div.innerHTML = '<div class="form-group"><input type="text" class="form-control" name="designation" id="designation" placeholder="Наименование и (или) адрес организации либо должность лица*" required /></div> <div class="form-group"><input type="text" class="form-control" name="fullName" id="fullName" placeholder="ФИО*" required /></div> <div class="form-group"><input type="text" class="form-control" name="address" id="address" placeholder="Адрес места жительства (места пребывания)*" /></div> <div class="form-group"><input type="email" class="form-control" name="email" id="email" placeholder="Электронная почта*" /></div>  <div class="form-group"><input type="text" class="form-control" name="tel" id="tel" placeholder="Контактный телефон" /></div> <div class="form-group"><textarea class="form-control" name="message" id="message" placeholder="Обращение*" maxlength="2000"></textarea></div> <div><p>Допустимыми форматами прикрепляемых документов и (или) сведений в электронном виде являются <em>Portable Document Format/A</em> (<em>PDF/A</em>), <em>Office Open XML</em> (<em>DOCX</em>), двойной формат с разметкой (<em>DOC</em>), Rich Text Format (<em>RTF</em>), текстовый файл (<em>TXT</em>), <em>Open Document Format</em> (<em>ODT</em>), формат архивации и сжатия данных (<em>ZIP, RAR</em>), <em>Portable Network Graphics</em> (<em>PNG</em>), <em>Tagged Image File Format</em> (<em>TIFF</em>), <em>Joint Photograph Experts Group</em> (<em>JPEG</em>), <em>Joint Photograph Group</em> (<em>JPG</em>).</p></div> <div class="form-group"><input type="file" name="upload" id="uploadFile" /></div> <div class="text-center" style="padding:20px"><button type="button" formnovalidate value="SendEmail" id="buttonSendEmail">Отправить обращение</button></div>';
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

//Метод рисования новых форм для юр.лиц (RU).
function addInputLegalPerson() {
    if (x < 1) {
        delInput();
        div.id = 'input' + ++x;
        div.innerHTML = '<div class="form-group"><input type="text" class="form-control" name="designation" id="designation" placeholder="Наименование и (или) адрес организации либо должность лица*" required /></div> <div class="form-group"><input type="text" class="form-control" name="nameLegal" id="nameLegal" placeholder="Полное наименование юридического лица*" required /></div> <div class="form-group"><input type="text" class="form-control" name="fullName" id="fullName" placeholder="ФИО либо инициалы руководителя или лица, уполномоченного в установленном порядке подписывать обращения*" required /></div> <div class="form-group"><input type="text" class="form-control" name="address" id="address" placeholder="Местонахождение юридического лица*" /></div> <div class="form-group"><input type="email" class="form-control" name="email" id="email" placeholder="Электронная почта*" /></div>  <div class="form-group"><input type="text" class="form-control" name="tel" id="tel" placeholder="Контактный телефон" /></div> <div class="form-group"><textarea class="form-control" name="message" id="message" placeholder="Обращение*" maxlength="2000"></textarea></div> <div><p>Допустимыми форматами прикрепляемых документов и (или) сведений в электронном виде являются <em>Portable Document Format/A</em> (<em>PDF/A</em>), <em>Office Open XML</em> (<em>DOCX</em>), двойной формат с разметкой (<em>DOC</em>), Rich Text Format (<em>RTF</em>), текстовый файл (<em>TXT</em>), <em>Open Document Format</em> (<em>ODT</em>), формат архивации и сжатия данных (<em>ZIP, RAR</em>), <em>Portable Network Graphics</em> (<em>PNG</em>), <em>Tagged Image File Format</em> (<em>TIFF</em>), <em>Joint Photograph Experts Group</em> (<em>JPEG</em>), <em>Joint Photograph Group</em> (<em>JPG</em>).</p></div> <div class="form-group"><input type="file" name="upload" id="uploadFile" /></div> <div class="text-center" style="padding:20px"><button type="button" formnovalidate value="SendEmail" id="buttonSendEmail">Отправить обращение</button></div>';
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

//Метод рисования новых форм для физ.лиц (BE).
function addInputNaturalPersonBE() {
    if (x < 1) {
        delInput();
        div.id = 'input' + ++x;
        div.innerHTML = '<div class="form-group"><input type="text" class="form-control" name="designation" id="designation" placeholder="Назву і (або) адрас арганізацыі альбо пасаду асобы*" required /></div> <div class="form-group"><input type="text" class="form-control" name="fullName" id="fullName" placeholder="Прозвішча, імя*" required /></div> <div class="form-group"><input type="text" class="form-control" name="address" id="address" placeholder="Адрас месца жыхарства (месца знаходжання)*" /></div> <div class="form-group"><input type="email" class="form-control" name="email" id="email" placeholder="Электронная пошта*" /></div>  <div class="form-group"><input type="text" class="form-control" name="tel" id="tel" placeholder="Кантактны тэлефон" /></div> <div class="form-group"><textarea class="form-control" name="message" id="message" placeholder="Зварот*" maxlength="2000"></textarea></div> <div><p>Дапушчальнымі фарматамі дакументаў і (або) звестак, якія прымацоўваюцца ў электронным відзе, з\'яўляюцца <em>Portable Document Format/A</em> (<em>PDF/A</em>), <em>Office Open XML</em> (<em>DOCX</em>), двайны фармат з разметкай (<em>DOC</em>), Rich Text Format (<em>RTF</em>), тэкставы файл (<em>TXT</em>), <em>Open Document Format</em> (<em>ODT</em>), фармат архівацыі і скарачэння даных (<em>ZIP, RAR</em>), <em>Portable Network Graphics</em> (<em>PNG</em>), <em>Tagged Image File Format</em> (<em>TIFF</em>), <em>Joint Photograph Experts Group</em> (<em>JPEG</em>), <em>Joint Photograph Group</em> (<em>JPG</em>).</p></div> <div class="form-group"><input type="file" name="upload" id="uploadFile" /></div> <div class="text-center" style="padding:20px"><button type="button" formnovalidate value="SendEmail" id="buttonSendEmail">Адправіць зварот</button></div>';
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

//Метод рисования новых форм для юр.лиц (BE).
function addInputLegalPersonBE() {
    if (x < 1) {
        delInput();
        div.id = 'input' + ++x;
        div.innerHTML = '<div class="form-group"><input type="text" class="form-control" name="designation" id="designation" placeholder="Назву і (або) адрас арганізацыі альбо пасаду асобы*" required /></div> <div class="form-group"><input type="text" class="form-control" name="nameLegal" id="nameLegal" placeholder="Поўнае найменне юрыдычнай асобы*" required /></div> <div class="form-group"><input type="text" class="form-control" name="fullName" id="fullName" placeholder="Прозвішча, імя або ініцыялы кіраўніка або асобы, упаўнаважанай ва ўстаноўленым парадку падпісваць звароты*" required /></div> <div class="form-group"><input type="text" class="form-control" name="address" id="address" placeholder="Месцазнаходжанне юрыдычнай асобы*" /></div> <div class="form-group"><input type="email" class="form-control" name="email" id="email" placeholder="Электронная пошта*" /></div>  <div class="form-group"><input type="text" class="form-control" name="tel" id="tel" placeholder="Кантактны тэлефон" /></div> <div class="form-group"><textarea class="form-control" name="message" id="message" placeholder="Зварот*" maxlength="2000"></textarea></div> <div><p>Дапушчальнымі фарматамі дакументаў і (або) звестак, якія прымацоўваюцца ў электронным відзе, з\'яўляюцца <em>Portable Document Format/A</em> (<em>PDF/A</em>), <em>Office Open XML</em> (<em>DOCX</em>), двайны фармат з разметкай (<em>DOC</em>), Rich Text Format (<em>RTF</em>), тэкставы файл (<em>TXT</em>), <em>Open Document Format</em> (<em>ODT</em>), фармат архівацыі і скарачэння даных (<em>ZIP, RAR</em>), <em>Portable Network Graphics</em> (<em>PNG</em>), <em>Tagged Image File Format</em> (<em>TIFF</em>), <em>Joint Photograph Experts Group</em> (<em>JPEG</em>), <em>Joint Photograph Group</em> (<em>JPG</em>).</p></div> <div class="form-group"><input type="file" name="upload" id="uploadFile" /></div> <div class="text-center" style="padding:20px"><button type="button" formnovalidate value="SendEmail" id="buttonSendEmail">Адправіць зварот</button></div>';
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

