using System.Net;
using System.Net.Mail;
using Website.Models.UsersSendEmail;

namespace Website.Assistant.SendEmail
{
    public class SendEmail
    {
        /// <summary>
        /// Метод предназначен для отправки сообщения на почту info@mgaon.by
        /// 1.Определяем отправителя
        /// 2.Определяем кому будем отрпавлять
        /// 3.Создаем объект сообщения
        /// 4.Если есть прикрепленные файлы, то их тоже добавляем к письму
        /// 5.Определяем порт и сервер с которого будем отправлять, заходим в акаунт почты и отправляем письмо
        /// </summary>
        /// <param name="person">Объект LegalPerson</param>
        /// <param name="messaga">Тема письма</param>
        public async void SendEmailAsync(Person person,  string messaga)
        { 
            // отправитель
            MailAddress _from = new MailAddress("info@mgaon.by", person.Name);
            // кому отправляем
            MailAddress _to = new MailAddress("info@mgaon.by");
            // создаем объект сообщения
            MailMessage _message = new MailMessage(_from, _to);
            // тема письма
            _message.Subject = messaga;
            // текст письма
            _message.Body = "<html><body> <br>" + "<br>" + messaga + @"
                          <br>Наименование и (или) адрес организации либо должность лица - " + person.Designation + @"
                          <br>Полное наименование юридического лица (обязательно) - " + person.NameLegal + @"
                          <br>ФИО  -  " + person.Name + @"
                          <br>Адрес места жительства (места пребывания) - " + person.Address + @"
                          <br>E-mail - " + person.Email + @"
                          <br>Контактный телефон - " + person.Phone + @"                                                                                              
                          <br>
                          <br>Сообщение - " + person.Message + @" </body></html>";
            // письмо представляет код html
            _message.IsBodyHtml = true;
           /* if (file != null)
            {
                _m.Attachments.Add(new Attachment("/app/wwwroot/share-pictures/" + file.Path));
            }
            */
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient _smtp = new SmtpClient("smtp.yandex.ru", 587);
            // логин и пароль
            _smtp.Credentials = new NetworkCredential("info@mgaon.by", "!23QweAsd");
            _smtp.EnableSsl = true;
            await _smtp.SendMailAsync(_message);
        }
    }
}
