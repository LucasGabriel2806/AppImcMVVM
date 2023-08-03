using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppImcMVVM.ViewModel
{
    /**
     * INotifyPropertyChanged é uma propriedade do Xamarin.
     * Pro C#, eu to implementando aqui, uma propriedade que 
     * vai conter um método que vai de fato fazer com que 
     * funcione a notificação da View.
     */
    public class FormularioIMCViewModel : INotifyPropertyChanged
    {
        //Campos
        private double peso, altura;
        private string resultado;
        //Evento que vai tratar da mudança das propriedades
        public event PropertyChangedEventHandler PropertyChanged;

        /**
         * Propriedades que vão definir as regras de acesso
         * nesses campos.
         * Propriedades que fazem o vinculo la com a view.
         */

        public double Peso
        {
            /**
             * set é quando quero colocar valores na minha 
             * propriedade, get é quando quero ler esses valores.
             * Então, como eu declarei get e set, e eu vinculei por
             * binding, eu consigo colocar e pegar valores.
             * 
             * Dentro do get eu defino como vai ser o acesso aos campos.
             * No get Eu to pegando o valor que vai ser digitado na interface
             * No método set eu pego o valor que foi digitado e jogo na propriedade peso.
             */
            get { return peso;}
            set { peso = value; }
        }
        public double Altura
        {
            get { return altura; }
            set { altura = value; }
        }
        
        public string Resultado
        {
            /**
             * Declarei como string e não double, porque, eu quero mostrar
             * uma mensagem completa, ex: Sui Imc é...
             * 
             * Declarei minha propriedade(resultado), ela é acessivel por get,
             * então sempre que eu abrir meu app, ele ta lendo aquela propriedade, 
             * isso é possivel por que o get ta implementado aqui,então minha propriedade
             * também permite leitura.
             */
            get { return resultado; } 
            set { 
                resultado = value;
                /**
                 * To chamando a PropertyChanged e passar qual foi a propriedade
                 * que alterou, que foi a resultado, e eu tenho que passar como string.
                 * A INotifyPropertyChanged ela pede pra implementar alguns métodos, e 
                 * isso já ta pronto por tras em toda a Api do DotNet.
                 * Então quando eu tava passando aqui, eu tava passando a PropertyChanged,
                 * eu tava passando a propriedade que eu queria que fosse notificado que 
                 * teve a alteração, eu só esqueci que isso é vazio, não tem nada implementado aqui:
                 * PropertyChanged("Resultado");
                 * 
                 * O que eu preciso fazer é chamar a PropertyChanged, ai eu falo, é essa classe
                 * (atual) e a propriedade que mudou tem que receber o nome da minha propriedade.
                 * 
                 */

                PropertyChanged(this, new PropertyChangedEventArgs("Resultado"));


            }
        }

        /**
         * Pra fazermos a programação do boão, existe uma classe
         * e uma interface(Icommand) que eu vou declarar:
         */
        public ICommand CalcularIMCCommand
        {
            /**
             * Eu declaro uma propriedade(CalcularIMCCommand), e ela vai conter
             * um método que vai interpretar o meu evento.Ela vai conter o
             * tratamento do meu calculo de iMC. Do outro
             * jeito era mais fácil, mas desse jeito, vamos separar
             * totalmente td que é programação(lógica) do que é interface.
             */
            
            get
            {
                /**
                 * Já vou declarar uma funcionalidade do get, sempre que alguém
                 * chamar o que tiver dentro dessa minha propriedade, ela vai com
                 * o get retornar um novo comando, e esse comando vai executar uma 
                 * ação, então pra simplificar, eu vou colocar em forma de função 
                 * lámbida. Funções lambida em C#, em sumo significa que todas as 
                 * vezes que eu chamar essa CalcularIMCCommand, eu vou executar uma 
                 * ação, que vai ser calcular o resultado.
                 */
                return new Command(() =>
                {
                    
                    Resultado = Model.Imc.CalcularImc(peso, altura); ;
                    /**
                     * O conceito de Binding significa que, eu to gerando um valor aqui,
                     * eu to calculando, eu consegui pegar os valores da Interface e ler 
                     * eles, ai eu calculei aqui embaixo e eu quero mostrar esse resultado 
                     * na interface. Só o Resultado = ...(lá embaixo)não vai resolver meu 
                     * problema. Nós até vinculamos o botão no Command, só que o C# não
                     * sabe muito bem como avisar a View que alguma coisa mudou e que tá 
                     * na hora. Temos que de fato, pela natureza do padrão de projeto, 
                     * Sempre avisar a view que alguma coisa no model mudou, temos um
                     * recurso da propria linguagem pra fazer isso(será mostrado).
                     * Aqui abaixo estava o código que está na Model
                     */


                    /**
                     * Aqui quando eu calculei toda classificação e chamei Resultado =,
                     * o método set é chamado:
                     * resultado = value;
                     * PropertyChanged(this, new PropertyChangedEventArgs("Resultado");
                     * Ai atraves dessa ultima linha de código, eu peço pro xamarin
                     * avisar minha view que houve uma mudança de valor nessa propriedade.
                     */


                    /**
                     * Console.WriteLine vai mostrar o resultado na Saída. Nosso
                     * Desafio é mostrar isso na View.
                     */
                    //Console.WriteLine("Res = " + Resultado);
                    /**
                     * resultado.TextColor = Color.Red;
                     * resultado.HorizontalTextAlignment = TextAlignment.Center;
                     */

                });
            }

        }

        
    }
}
