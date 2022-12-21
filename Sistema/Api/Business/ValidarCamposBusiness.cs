using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable
namespace Api.Business
{
    public class ValidarCamposBusiness
    {
        Database.TestDriveDatabase db = new Database.TestDriveDatabase();

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
    
        public void ValidarData(DateTime data){

            int dia = data.Day;
            int mes = data.Month;
            int ano = data.Year;
            int hora = data.Hour;
            int minuto = data.Minute;
 
            if(data == DateTime.Now || data.Day == DateTime.Now.Day && data.Month == DateTime.Now.Month)
                throw new ArgumentException("Não é possivel marcar um agendamento para hoje");

            if(ano < DateTime.Now.Year)
                throw new ArgumentException("Insira um ano de agendamento válido");

            if(mes < DateTime.Now.Month)
                throw new ArgumentException("Insira um mês de agendamento válido");

            if(dia <= DateTime.Now.Day && mes <= DateTime.Now.Month)
                throw new ArgumentException("Insira um dia de agendamento válido");

            if(hora == 0 && minuto == 0)
                throw new ArgumentException("Insira uma hora de agendamento válida");

            if(hora < 8 || hora > 21)
                throw new ArgumentException("Os horários disponiveis estão entre 8 e 21 horas");

            if(minuto != 0 && minuto != 30)
                throw new ArgumentException("Os intervalos entre os agendamentos são de no mínimo 30 minutos");

            List<Models.TbTestDrive> tests = db.listartestdrives();
            Models.TbTestDrive agen = tests.FirstOrDefault(x => x.DtTestDrive.Day == dia && x.DtTestDrive.Month == mes && x.DtTestDrive.Hour == hora && x.DtTestDrive.Minute == minuto);

            if(agen != null)
                throw new ArgumentException("Este horário já foi reservado, tente outro");

        }
    
    }
}