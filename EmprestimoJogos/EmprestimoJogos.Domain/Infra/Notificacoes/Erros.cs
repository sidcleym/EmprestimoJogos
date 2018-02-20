using Newtonsoft.Json;

namespace EmprestimoJogos.Domain.Infra.Notificacoes
{
    public class Erros
    {

        public Erros()
        {

        }
        public Erros(int tipo=0, string codigo="", string titulo="", string motivo="", string solucao="")
        {
            this.Tipo      = tipo;
            this.Codigo    = codigo;
            this.Titulo    = titulo;
            this.Motivo    = motivo;
            this.Solucao   = solucao;
        }

     
        [JsonProperty(PropertyName = "tipo")]
        public int Tipo {  get; protected set; }

        [JsonProperty(PropertyName = "codigo")]
        public string Codigo { get; protected set; }

        [JsonProperty(PropertyName = "titulo")]
        public string Titulo { get; protected set; }

        [JsonProperty(PropertyName = "motivo")]
        public string Motivo { get; protected set; }

        [JsonProperty(PropertyName = "solucao")]
        public string Solucao { get; protected set; }

    }
}
