using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Utils
{
    public class RelatorioUtils
    {
        public DateTime AvancarParaSexta(DateTime data){
            
            if (data.DayOfWeek.ToString() != "Friday")
            {
                DateTime novaDt = new DateTime();
        
                switch (data.DayOfWeek.ToString())
                {
                    case "Monday":
                        novaDt = data.AddDays(4);
                        break;
        
                    case "Tuesday":
                        novaDt = data.AddDays(3);
                        break;
        
                    case "Wednesday":
                        novaDt = data.AddDays(2);
                        break;
        
                    case "Thursday":
                        novaDt = data.AddDays(1);
                        break;
        
                    default:
                        break;
        
                }
        
                return novaDt;
            }
            else
                return data;
        }
        public List<DateTime> duasSemanasAtras(DateTime data){
            
            List<DateTime> dts = new List<DateTime>();
        
            if (data.DayOfWeek.ToString() == "Sunday")
            {
                for (int retrocederDias = 1; retrocederDias <= 14; retrocederDias++)
                {
                    DateTime novaDt = data.AddDays(-retrocederDias);
                    string diaSemana = novaDt.DayOfWeek.ToString();
        
                    if (diaSemana != "Saturday" && diaSemana != "Sunday")
                        dts.Add(novaDt); 
                    else
                        continue;
                }
            }
            else if (data.DayOfWeek.ToString() == "Saturday")
            {
                for (int retrocederDias = 1; retrocederDias <= 13; retrocederDias++)
                {
                    DateTime novaDt = data.AddDays(-retrocederDias);
                    string diaSemana = novaDt.DayOfWeek.ToString();
        
                    if (diaSemana != "Saturday" && diaSemana != "Sunday")
                        dts.Add(novaDt);
                    else
                        continue;
                }
            }
            else if (data.DayOfWeek.ToString() == "Friday")
            {
                for (int retrocederDias = 0; retrocederDias < 12; retrocederDias++)
                {
                    DateTime novaDt = data.AddDays(-retrocederDias);
                    string diaSemana = novaDt.DayOfWeek.ToString();
        
                    if (diaSemana != "Saturday" && diaSemana != "Sunday")
                        dts.Add(novaDt);
                    else
                        continue;
                }
            }
            return dts;
        }
    }
}