using Newtonsoft.Json;

namespace EmprestimoJogos.Domain.Infra.Notificacoes
{
    public class DominioNotificacoes : IDominioEvento
    {
        [JsonProperty(PropertyName = "tipo")]
        public int Tipo { get; protected set; }

        [JsonProperty(PropertyName = "codigo")]
        public string Codigo { get; protected set; }

        [JsonProperty(PropertyName = "titulo")]
        public string Titulo { get; protected set; }

        [JsonProperty(PropertyName = "motivo")]
        public string Motivo { get; protected set; }

        [JsonProperty(PropertyName = "solucao")]
        public string Solucao { get; protected set; }
       

        public DominioNotificacoes(Erros erro)
        {
            this.Tipo    = erro.Tipo;
            this.Codigo  = erro.Codigo;
            this.Titulo  = erro.Titulo;
            this.Motivo  = erro.Motivo;
            this.Solucao = erro.Solucao;                  
        }
    }
}
