using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoJogos.Domain.Helpers
{
    public class AmigoHelper
    {

        public static string primeiroNome()
        {
            IList<string> nomes = new List<string>(){
                "Davi",           "Arthur",           "Pedro",
                "Gabriel",        "Bernardo",         "Lucas",
                "Maria",          "Kátia",             "Rafaela",
                "Matheus",        "Rafael",            "Heitor",
                "Enzo",           "Guilherme",         "Nicolas",
                "Gabriela",       "Manuela",           "Sabrina",
                "Lorenzo",        "Gustavo",           "Felipe",
                "Samuel",         "João",              "Daniel",
                "Vitor",          "Leonardo",          "Henrique",
                "Theo",           "Murilo",            "Eduardo",
                "Pedro",          "Pietro",            "Cauã",
                "Isaac",          "Caio",              "Vinicius",
                "Juliana",        "Joane",             "Luciana",
                "Benjamin",       "João",              "Lucca",
                "João",           "Bryan",             "Joaquim",
                "João Vitor",     "Thiago",            "Antônio",
                "Milena",         "Eliene",            "Cleonice",
                "Davi Lucas",
             };

            var ponteiro = Convert.ToInt16(Randomize(1, nomes.Count));
            return nomes.Skip(ponteiro).FirstOrDefault();
        }


        public static string sobreNome1()
        {
            IList<string> sobreNome = new List<string>(){
                 "Fernandes",   "Santana",    "Carvalho",
                 "Martins",     "Santos",     "Boaventura",
                 "Oliveira",    "Moraes",     "Leão",
                 "Garcia",      "Alves",      "Costa",
                 "Oliveira",    "Martinez",   "Novaes",
                 "Oliveira",    "Araújo",     "Maia",
                 "Vasconcelos", "Gonçalves",  "Guimarães",
                 "Menezes",     "Sampaio",    "Cavalcante",
                 "Lacerda",     "Mello",      "Moraes",
                 "Muniz",       "Figueira",   "Paes",
                 "Lima",        "Marques",    "Duarte",
                 "Vasconcelos", "Vieira",     "Souza",
                 "Soares",      "Silva",      "Duarte",
                 "Morais",      "Gomes",      "Paiva",
                 "Junqueira",   "Queiroz",    "Barreto",
                 "Menezzes",    "Campos",     "Pilar"
             };

            var ponteiro = Convert.ToInt16(Randomize(1, sobreNome.Count));
            return sobreNome.Skip(ponteiro).FirstOrDefault();
        }


        public static string sobreNome2()
        {
            IList<string> sobreNome = new List<string>(){
                "Soares",      "Silva",      "Duarte",
                 "Morais",      "Gomes",      "Paiva",
                 "Fernandes",   "Santana",    "Carvalho",
                 "Martins",     "Santos",     "Boaventura",
                 "Oliveira",    "Moraes",     "Leão",
                 "Muniz",       "Figueira",   "Paes",
                 "Garcia",      "Alves",      "Costa",
                 "Oliveira",    "Martinez",   "Novaes",
                 "Oliveira",    "Araújo",     "Maia",
                 "Vasconcelos", "Gonçalves",  "Guimarães",
                 "Menezes",     "Sampaio",    "Cavalcante",
                 "Lacerda",     "Mello",      "Moraes",
                 "Lima",        "Marques",    "Duarte",
                 "Vasconcelos", "Vieira",     "Souza",
                 "Junqueira",   "Queiroz",    "Barreto",
                 "Menezzes",    "Campos",     "Pilar"
             };

            var ponteiro = Convert.ToInt16(Randomize(1, sobreNome.Count));
            return sobreNome.Skip(ponteiro).FirstOrDefault();
        }

        public static string Randomize(int ini, int final, Random pRnd = null)
        {
            Random rnd = (pRnd == null) ? new Random() : pRnd;
            return rnd.Next(ini, final).ToString();
        }

    }
}
