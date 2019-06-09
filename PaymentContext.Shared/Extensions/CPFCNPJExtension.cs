namespace PaymentContext.Shared.Extensions
{
    public static class CPFCNPJExtension
    {
        public static bool IsValid(this string cpfCnpj)
        {
            return (IsCpf(cpfCnpj) || IsCnpj(cpfCnpj));
        }

        private static bool IsCpf(string cpf)
        {
            int[] firstMultiplier = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] secondMultiplier = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;

            for (int j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                    return false;

            string tempCpf = cpf.Substring(0, 9);
            int sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(tempCpf[i].ToString()) * firstMultiplier[i];

            int mod = sum % 11;
            if (mod < 2)
                mod = 0;
            else
                mod = 11 - mod;

            string digit = mod.ToString();
            tempCpf = tempCpf + digit;
            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += int.Parse(tempCpf[i].ToString()) * secondMultiplier[i];

            mod = sum % 11;
            if (mod < 2)
                mod = 0;
            else
                mod = 11 - mod;

            digit = digit + mod.ToString();

            return cpf.EndsWith(digit);
        }

        private static bool IsCnpj(string cnpj)
        {
            int[] firstMultiplier = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] secondMultiplier = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;

            string tempCnpj = cnpj.Substring(0, 12);
            int sum = 0;

            for (int i = 0; i < 12; i++)
                sum += int.Parse(tempCnpj[i].ToString()) * firstMultiplier[i];

            int mod = (sum % 11);
            if (mod < 2)
                mod = 0;
            else
                mod = 11 - mod;

            string digit = mod.ToString();
            tempCnpj = tempCnpj + digit;
            sum = 0;
            for (int i = 0; i < 13; i++)
                sum += int.Parse(tempCnpj[i].ToString()) * secondMultiplier[i];

            mod = (sum % 11);
            if (mod < 2)
                mod = 0;
            else
                mod = 11 - mod;

            digit = digit + mod.ToString();

            return cnpj.EndsWith(digit);
        }
    }
}
