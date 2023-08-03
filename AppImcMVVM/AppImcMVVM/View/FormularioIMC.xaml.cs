using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppImcMVVM.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormularioIMC : ContentPage
    {
        public FormularioIMC()
        {
            InitializeComponent();

            /**
             * O 1ºPasso pra utilizarmos o padrão MVVM É fazer a 
             * "Amarração" da minha view, com a minha viewmodel, 
             * amarrando via BindingContext.
             * Agora as duas classes já vão poder conversar via BindingContext.
             * Como Definimos que a classe ViewModel vai ser o BindingContext 
             * da minha View, precisamos fazer o mapeamento dos campos, dos
             * entrys la dentro do viewModel. Se eu criei uma entry é
             * porque eu quero recuperar esses dados, então eu preciso 
             * criar um jeito de pegar esses dados por Binding.
             */
            this.BindingContext = new ViewModel.FormularioIMCViewModel();

        }
    }
}