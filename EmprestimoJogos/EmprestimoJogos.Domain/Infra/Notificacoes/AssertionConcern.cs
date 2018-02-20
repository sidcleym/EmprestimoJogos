using System;
using System.Collections.Generic;
using System.Linq;

namespace EmprestimoJogos.Domain.Infra.Notificacoes
{
    public static class AssertionConcern
    {
        public static string mensagemErro = null;
       


        public static bool IsSatisfiedBy(params DominioNotificacoes[] validations)
        {
            var notificationsNotNull = validations.Where(validation => validation != null);
            NotifyAll(notificationsNotNull);

            var erros = "Erros:";
            foreach (var item in notificationsNotNull)
            {
                erros += item.Solucao + "\r\n";
            }

            mensagemErro = erros;

            return notificationsNotNull.Count().Equals(0);
        }

        private static void NotifyAll(IEnumerable<DominioNotificacoes> notifications)
        {
            notifications.ToList().ForEach(validation =>
            {
                DominioEvento.Raise<DominioNotificacoes>(validation);
            });
        }

        public static DominioNotificacoes AssertLength(string stringValue, int minimum, int maximum, string message, string pTitulo = null)
        {
            int length = (stringValue !=null) ? stringValue.Trim().Length : 0;
            var titulo = (pTitulo == null) ? "Preenchimento Incorreto" : pTitulo;

            return (length < minimum || length > maximum) ?
                new DominioNotificacoes(new Erros(0, "", titulo, "", message)) : null;
        }

        public static DominioNotificacoes AssertMatches(string pattern, string stringValue, string message, string pTitulo = null)
        {
            var titulo = (pTitulo == null) ? "Preenchimento Incorreto" : pTitulo;

            return (!(pattern == stringValue)) ?
                new DominioNotificacoes(new Erros(0, "", titulo, "", message)) : null;
        }

        public static DominioNotificacoes AssertNotEmpty(string stringValue, string message, string pTitulo = null)
        {
            var titulo = (pTitulo == null) ? "Preenchimento Incorreto" : pTitulo;
            return (string.IsNullOrEmpty(stringValue)) ?
                new DominioNotificacoes(new Erros(0, "", titulo, "", message)) : null;
        }

        public static DominioNotificacoes AssertNotNull(object object1, string message, string pTitulo = null)
        {
            var titulo = (pTitulo == null) ? "Preenchimento Incorreto" : pTitulo;
            return (object1 == null) ?
                new DominioNotificacoes(new Erros(0, "", titulo, "", message)) : null;
        }

        public static DominioNotificacoes AssertTrue(bool boolValue, string message, string pTitulo = null)
        {
            var titulo = (pTitulo == null) ? "Preenchimento Incorreto" : pTitulo;
            return (!boolValue) ?
                new DominioNotificacoes(new Erros(0, "", titulo, "", message)) : null;
        }

        public static DominioNotificacoes AssertFalse(bool boolValue, string message, string pTitulo = null)
        {
            var titulo = (pTitulo == null) ? "Preenchimento Incorreto" : pTitulo;
            return (boolValue) ?
                new DominioNotificacoes(new Erros(0, "", titulo, "", message)) : null;
        }

        public static DominioNotificacoes AssertAreEquals(string value, string match, string message, string pTitulo = null)
        {
            var titulo = (pTitulo == null) ? "Preenchimento Incorreto" : pTitulo;
            return (!(value == match)) ?
                new DominioNotificacoes(new Erros(0, "", titulo, "", message)) : null;
        }

        public static DominioNotificacoes AssertIsGreaterThan(int value1, int value2, string message, string pTitulo = null)
        {
            var titulo = (pTitulo == null) ? "Preenchimento Incorreto" : pTitulo;
            return (!(value1 > value2)) ?
                new DominioNotificacoes(new Erros(0, "", titulo, "", message)) : null;
        }

        public static DominioNotificacoes AssertIsGreaterThan(decimal value1, decimal value2, string message, string pTitulo = null)
        {
            var titulo = (pTitulo == null) ? "Preenchimento Incorreto" : pTitulo;
            return (!(value1 > value2)) ?
                new DominioNotificacoes(new Erros(0, "", titulo, "", message)) : null;
        }
        public static DominioNotificacoes AssertIsBetween(int pattern, int min, int max, string message, string pTitulo = null)
        {
            var titulo = (pTitulo == null) ? "Preenchimento Incorreto" : pTitulo;
            return (!(pattern >= min && pattern <=max)) ?
                new DominioNotificacoes(new Erros(0, "", titulo, "", message)) : null;
        }

        public static DominioNotificacoes AssertIsTrue(bool cond, string message, string pTitulo = null)
        {
            var titulo = (pTitulo == null) ? "Preenchimento Incorreto" : pTitulo;
            return (!(cond)) ?
                new DominioNotificacoes(new Erros(0, "", titulo, "", message)) : null;
        }

        public static DominioNotificacoes AssertIsGreaterOrEqualThan(int value1, int value2, string message, string pTitulo = null)
        {
            var titulo = (pTitulo == null) ? "Preenchimento Incorreto" : pTitulo;
            return (!(value1 >= value2)) ?
                new DominioNotificacoes(new Erros(0, "", titulo, "", message)) : null;
        }

        public static DominioNotificacoes AssertIsNullorWhiteSpace(object object1, string message, string pTitulo = null)
        {
            var titulo = (pTitulo == null) ? "Preenchimento Incorreto" : pTitulo;
            if (object1 == null)
                return new DominioNotificacoes(new Erros(0, "", titulo, "", message));

            if (String.IsNullOrWhiteSpace(Convert.ToString(object1)))
                return new DominioNotificacoes(new Erros(0, "", titulo, "", message));

            return null;
        }


        public static DominioNotificacoes AssertContains(string stringValue, string message, params string[] opcoes)
        {            
            return (!opcoes.Contains(stringValue)) ? new DominioNotificacoes(new Erros(0, "", "Preenchimento Incorreto", "", message)) : null;
        }
    }
}
