using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_cameras
{
    class HttpAuthData
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string address { get; set; }

        public HttpAuthData(string login, string pass, string addr)
        {
            if ((login == null) || (pass == null) || (addr == null))
                throw new Exception("Ошибка сбора данных аутентификации");

            userName = login;
            password = pass;
            address = addr;
        }

        public byte[] GetAuthToken()
        {
            if ((userName == null) || (password == null))
                throw new Exception("Ошибка создания токена аутентификации");

            return Encoding.ASCII.GetBytes($"{userName}:{password}");
        }
    }
}
