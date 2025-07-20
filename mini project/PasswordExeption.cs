using System;

namespace mini_progect
{
    internal class PasswordExeption : ApplicationException
    {
        private string _msg;
        public PasswordExeption()
        {
            _msg = "Password Needs to be At Least 8 letters";
        }

        public override string Message { get { return _msg; } }



    }


} 



