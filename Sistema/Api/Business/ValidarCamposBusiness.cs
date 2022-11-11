using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Business
{
    public class ValidarCamposBusiness
    {

        public bool ValidarEmail(string Email)
        {
            bool ValidEmail = false;
            int indexArr = Email.IndexOf("@");
            
            if (indexArr > 0)
            {
                int indexDot = Email.IndexOf(".", indexArr);
                if (indexDot - 1 > indexArr)
                {
                    if (indexDot + 1 < Email.Length)
                    {
                        string indexDot2 = Email.Substring(indexDot + 1, 1);
                        if (indexDot2 != ".")
                        {
                            ValidEmail = true;
                        }
                    }
                }
            }
            return ValidEmail;
        }     

        public void ValidarSenha(string senha){

            if(senha.Length < 8)
                throw new ArgumentException("Senha muito curta");

            if(senha.Length > 30)
                throw new ArgumentException("Senha muito longa");

            if(!senha.Contains("&") && !senha.Contains("$") && !senha.Contains("@") && !senha.Contains("#")
            && !senha.Contains("%") && !senha.Contains("!"))
                throw new ArgumentException("Utilize pelo menos um caracter especial [@-!-#-$-%-&]");

            if(!senha.Contains("0") && !senha.Contains("1") && !senha.Contains("2") && !senha.Contains("3") &&
            !senha.Contains("4") && !senha.Contains("5") && !senha.Contains("6") && !senha.Contains("7") &&
            !senha.Contains("8") && !senha.Contains("9"))
                throw new ArgumentException("Utilize pelo menos um número na senha");

        }              
    }
}