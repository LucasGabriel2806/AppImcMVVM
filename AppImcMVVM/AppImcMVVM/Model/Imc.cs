using System;
using System.Collections.Generic;
using System.Text;

namespace AppImcMVVM.Model
{
    public class Imc
    {
        /**
         * o retorno é do tipo string
         * 
         * 37:37
         */
        public static string CalcularImc(double peso, double altura)
        {
            //Vou calcular o resultado
            double imc = peso / (altura * altura);

            string classificacao = "";


            if (imc < 17)
            {
                classificacao = "Muito abaixo do peso";

            }
            else if (imc >= 17 && imc < 18.49)
            {
                classificacao = "Abaixo do peso";
            }
            else if (imc >= 18.5 && imc < 24.99)
            {
                classificacao = "Peso normal";

            }
            else if (imc >= 25 && imc < 29.99)
            {
                classificacao = "Acima do peso";

            }
            else if (imc >= 30 && imc < 34.99)
            {
                classificacao = "ObesidadeI";

            }
            else if (imc >= 35 && imc < 39.99)
            {
                classificacao = "Obesidade II(severa)";

            }
            else if (imc >= 40)
            {
                classificacao = "Obesidade III(mórbida)";

            }

            return "Seu IMC é " + imc.ToString(("0.00")) + " está " + classificacao;
        }
    }
}
