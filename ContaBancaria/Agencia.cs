using System;

namespace ContaBancaria
{
    public class Agencia
    {
        public string numero { get; set; }

        public Agencia()
        {
            var rand = new Random();
            
            this.numero = (rand.Next(0, 100)).ToString("00");
        }
        public Agencia(string numero)
        {            
            this.numero = numero;
        }
        
        public string exibir(){
            return 
                string.Format(
                    "//Agência//\nNúmero:{0}\n",
                    this.numero
                );
        }
    }
}