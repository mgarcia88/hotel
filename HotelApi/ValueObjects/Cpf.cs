using System;

namespace HotelApi.ValueObjects
{
    public struct Cpf
    {
        private readonly string _value;

        private Cpf(string value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return _value;
        }

        public static implicit operator Cpf(string input) => Parse(input);

        public static Cpf Parse(string value)
        {
            if (TryParse(value, out var Result))
            {
                return Result;
            }

            throw new ArgumentException("CPF inválido");
        }

        public static bool TryParse(string value, out Cpf cpf)
        {
            int[] multiplicador1 = new int[9] {10, 9, 8, 7, 6, 5, 4, 3, 2};
            int[] multiplicador2 = new int[10] {11, 10, 9, 8, 7, 6, 5, 4, 3, 2};
            string tempCpf;
            string digito;
            int soma;
            int resto;
            value = value.Trim();
            value = value.Replace(".", "").Replace("-", "");

            if (value.Length != 11)
            {
                cpf = new Cpf();
                return false;
            }

            tempCpf = value.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            cpf = new Cpf(value);
            return value.EndsWith(digito);
        }
    }
}