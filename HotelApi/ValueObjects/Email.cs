using System;
using System.Text.RegularExpressions;

namespace HotelApi.ValueObjects
{
    public struct Email
    {
        private readonly string _value;

        private Email(string value)
        {
            _value = value;
        }

        public static implicit operator Email(string input) => Parse(input);

        public override string ToString() => _value;

        public static Email Parse(string value)
        {
            if (TryParse(value, out var resultado))
            {
                return resultado;
            }
            
            throw new ArgumentException("E-mail inválido");
        }

        public static bool TryParse(string value, out Email email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(value);
            if (!match.Success)
            {
                email = new Email();
                return false;
            }
            
            email = new Email(value);
            return true;
        }
    }
}