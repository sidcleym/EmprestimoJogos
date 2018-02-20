using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System;
using EmprestimoJogos.Domain.Service;
using EmprestimoJogos.Domain.Infra;
using EmprestimoJogos.Domain.Models;
using EmprestimoJogos.Domain.EscopoValidacao;
using EmprestimoJogos.Domain.Helpers;

namespace EmprestimoJogos.Tests
{
    [TestClass]
    public class AmigoTeste
    {
        private string  dataCorrente             = Convert.ToString(DateTime.Now);
        private bool    excluirTodosTestes       = true;
        private AmigoService  _service;                
              
        private void InicializaConexao()
        {
            TConexao.Open();
            _service          = new AmigoService(TConexao.unitofWork, TConexao.context);
        }       
        private Amigo MontaEntidade()
        {
            Amigo entidade  = new Amigo();
            entidade.Email  = "testeAmigo@gmail.com";
            entidade.Nome   = AmigoHelper.primeiroNome()+" "+ AmigoHelper.sobreNome1();
            entidade.Observacao = "TESTE UNIT. " + DateTime.Now;
            return entidade;
        }

        private Amigo SalvaEntidade(bool dispose)
        {
            InicializaConexao();

            var entidade = MontaEntidade();
            var amigoSalvo = _service.Salva(entidade);

            if (dispose) TConexao.Dispose();

            return amigoSalvo;
        }

        [TestMethod]
        [TestCategory("Amigo")]
        public void Deve_Salvar_Amigo()
        {
            InicializaConexao();

            var entidade    = MontaEntidade();            
            var tituloSalvo = _service.Salva(entidade);

            TConexao.Dispose();
            Assert.AreNotEqual(null, tituloSalvo, AmigoEscopo._notificacoes);
        }
              

        [TestMethod]
        [TestCategory("Amigo")]
        public void Deve_Atualizar_Amigo()
        {         
            InicializaConexao();       

            var entidade = (_service.Get() as IQueryable<Amigo>).Where(x=> x.Observacao.Contains("TEST")).FirstOrDefault();

            if (entidade == null)
                entidade = SalvaEntidade(false);


            entidade.Nome     = "TEST UNITARIO "+DateTime.Now;

            var entidadeAtualizada = _service.Atualiza(entidade.Id, entidade);

            TConexao.Dispose();
            Assert.AreNotEqual(null, entidadeAtualizada, AmigoEscopo._notificacoes);
        }
        
        
        [TestMethod]
        [TestCategory("Amigo")]
        public void Deve_Buscar_ID()
        {         
            InicializaConexao();

            var entidade = (_service.Get() as IQueryable<Amigo>).FirstOrDefault();

            if (entidade == null)            
                entidade = SalvaEntidade(false);
            
            var result = _service.Get(entidade.Id);
            
            TConexao.Dispose();
            Assert.AreNotEqual(null, result, AmigoEscopo._notificacoes);
        }

        [TestMethod]
        [TestCategory("Amigo")]
        public void Deve_Buscar()
        {         
            InicializaConexao();
 
            var titulos = (_service.Get() as IQueryable<Amigo>).ToList();

            TConexao.Dispose();
            Assert.AreNotEqual(null, titulos, AmigoEscopo._notificacoes);
        }


        [TestMethod]
        [TestCategory("Amigo")]
        public void Deve_Excluir()
        {         
            InicializaConexao();
                                   
            var entidade = SalvaEntidade(false);

            var tituloExcluido = _service.Delete(entidade.Id);

            TConexao.Dispose();
            Assert.AreNotEqual(null, tituloExcluido, AmigoEscopo._notificacoes);
        }

                         
    }
}