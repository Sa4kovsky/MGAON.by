$('.anchor').on('click', function (e) {

    e.preventDefault();

    var target = $(this).attr('name'),
        offset = $(target).offset().top;

   /// $(document).scrollTop(offset);
    $("html, body").stop().animate({
        scrollTop: offset
    }, 1200);

});

// �������� �����.
$(function () {
    $("#tel").mask("8(099) 99-99-999");
});


var x = 0;
var profile = document.getElementById('profile');
var div = document.createElement('div');

//����� ��������� ����� ���� ��� ���.���.
function addInputNaturalPerson() {
    if (x < 1) {
        delInput();
        div.id = 'input' + ++x;
        div.innerHTML = '<div class="form-group"><input type="text" class="form-control" name="designation" id="designation" placeholder="������������ � (���) ����� ����������� ���� ��������� ����*" required /></div> <div class="form-group"><input type="text" class="form-control" name="fullName" id="fullName" placeholder="���*" required /></div> <div class="form-group"><input type="text" class="form-control" name="address" id="address" placeholder="����� ����� ���������� (����� ����������)*" /></div> <div class="form-group"><input type="email" class="form-control" name="email" id="email" placeholder="����������� �����*" /></div>  <div class="form-group"><input type="text" class="form-control" name="tel" id="tel" placeholder="���������� �������" /></div> <div class="form-group"><textarea class="form-control" name="message" id="message" placeholder="���������*" maxlength="2000"></textarea></div>  <div class="text-center" style="padding:20px"><button type="button" formnovalidate value="SendEmail" id="buttonSendEmail">��������� ���������</button></div>';
        profile.appendChild(div);
        $("#tel").mask("8(099) 99-99-999");
        //ajax ����������� ��� ������� ���������, ����� �������� ��������� �������������
        $(document).ready(function () {
            $('#buttonSendEmail').click(function () {

                $('#exampleModalCenter').modal('show')

            });
        });
    }
}

//����� ��������� ����� ���� ��� ��.���.
function addInputLegalPerson() {
    if (x < 1) {
        delInput();
        div.id = 'input' + ++x;
        div.innerHTML = '<div class="form-group"><input type="text" class="form-control" name="designation" id="designation" placeholder="������������ � (���) ����� ����������� ���� ��������� ����*" required /></div> <div class="form-group"><input type="text" class="form-control" name="nameLegal" id="nameLegal" placeholder="������ ������������ ������������ ����*" required /></div> <div class="form-group"><input type="text" class="form-control" name="fullName" id="fullName" placeholder="��� ���� �������� ������������ ��� ����, ��������������� � ������������� ������� ����������� ���������*" required /></div> <div class="form-group"><input type="text" class="form-control" name="address" id="address" placeholder="��������������� ������������ ����*" /></div> <div class="form-group"><input type="email" class="form-control" name="email" id="email" placeholder="����������� �����*" /></div>  <div class="form-group"><input type="text" class="form-control" name="tel" id="tel" placeholder="���������� �������" /></div> <div class="form-group"><textarea class="form-control" name="message" id="message" placeholder="���������*" maxlength="2000"></textarea></div>  <div class="text-center" style="padding:20px"><button type="button" formnovalidate value="SendEmail" id="buttonSendEmail">��������� ���������</button></div>';
        profile.appendChild(div);
        $("#tel").mask("8(099) 99-99-999");
        //ajax ����������� ��� ������� ���������, ����� �������� ��������� �������������
        $(document).ready(function () {
            $('#buttonSendEmail').click(function () {

                $('#exampleModalCenter').modal('show')

            });
        });
    }
}

//����� ��������
function delInput() {
    var div = document.getElementById('input' + x);
    div.remove();
    --x;
}

