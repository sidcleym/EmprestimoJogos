using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoJogos.Domain.Helpers
{
    public class JogoHelper
    {

        public static string GeraDescricao()
        {
            IList<string> nomes = new List<string>(){
                "Conter striker ",                   
                "Assalts",                
                "Double Dragon",                  
                "Street Figther",                
                "The King of Fitgher"
             };

            var ponteiro = Convert.ToInt16(Randomize(1, nomes.Count));
            return nomes.Skip(ponteiro).FirstOrDefault();
        }

        

        public static string Randomize(int ini, int final, Random pRnd = null)
        {
            Random rnd = (pRnd == null) ? new Random() : pRnd;
            return rnd.Next(ini, final).ToString();
        }

    }
}
