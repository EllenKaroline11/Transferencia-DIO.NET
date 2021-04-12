using System;

namespace Dio.Bank 
{
    public class NewBaseType
    {
        public void Transferir(double valorTrasferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTrasferencia))
            {
                contaDestino.Depositar(valorTrasferencia);
            }
        }

        private bool Sacar(double valorTrasferencia)
        {
            throw new NotImplementedException();
        }
    }

    public class conta : NewBaseType
    {
        private TipoConta  TipoConta {set; get;}

         private double Saldo {set; get;}

          private double Credito {set; get;}

           public string Nome{set; get;}


            public conta(TipoConta  tipoConta, double saldo, double credito, string nome)
            {
                this.TipoConta = tipoConta;
                this.Saldo = saldo;
                this.Credito = credito;
                this.Nome = nome;
            }

            public bool Sacar (double valorSaque)
            {
                //validacao de saldo suficiente
                if(this.Saldo - valorSaque < (this.Credito * -1)){
                 Console.WriteLine("Saldo insuficiente!");
                    return false;
                }
                this.Saldo -= valorSaque;

                Console.WriteLine("Saldo atual da conta de {0} é {1}" , this.Nome , this.Saldo);

                return true;
            }

            public void Depositar (double ValorDeposito)
            {
                this.Saldo += ValorDeposito;
                Console.WriteLine("Saldo atual da conta de {0} é {1}" , this.Nome , this.Saldo);
            }

        public override string ToString()
        {
           string retorno = "";
           retorno += "TipoConta " + this.TipoConta + " |" ;
           retorno += "Nome " + this.Nome + " |";
           retorno += "Saldo" + this.Saldo + " |";
           retorno += "Credito " + this.Credito;
           return retorno;

        }
    }
}