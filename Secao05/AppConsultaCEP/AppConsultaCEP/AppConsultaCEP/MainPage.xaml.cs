using AppConsultaCEP.Servico;
using AppConsultaCEP.Servico.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppConsultaCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            _botao.Clicked += BuscarCEP;

        }

        private void BuscarCEP(object sender, EventArgs e)
        {

            string cep = _CEP.Text.Trim();

            if (isValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);
                    if ( end != null)
                    {
                        _resultado.Text = string.Format("Endereço: {0},{1} {2} {3}", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "Endereço não encontrado para o CEP: " + cep, "OK");
                    }

                }
                catch (Exception ex)
                {
                    DisplayAlert("ERRO", "Erro interno, tente novamente mais tarde. " , "OK");
                }
                
            }
        }

        private bool isValidCEP(string cep)
        {
            if (cep.Length != 8)
            {
                DisplayAlert("ERRO", "O CEP deve ter 8 Caracteres", "OK");
                return false;

            }
            int _n = 0;
            if (!int.TryParse(cep, out _n))
            {
                DisplayAlert("ERRO", "O CEP deve conter apenas números", "OK");
                return false;
            }

            return true;
        }
    }
}
