using AppConsultaCEP.Servico.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace AppConsultaCEP.Servico
{
    public class ViaCEPServico
    {

        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json";

        public static Endereco BuscarEnderecoViaCEP (string cep)
        {
            string _enderecoURL = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();

            string conteudo = wc.DownloadString(_enderecoURL);

            Endereco endereco = JsonConvert.DeserializeObject<Endereco>(conteudo);

            if (endereco.cep == null) return null;

            return endereco;
        }
    }
}
