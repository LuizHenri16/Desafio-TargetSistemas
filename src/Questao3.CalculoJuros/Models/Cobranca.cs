public class Cobranca
{
        public decimal ValorOriginal { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal TaxaJurosDiaria { get; set; } = 0.025m; // 2,5% ao dia de juros, como pede o enunciado do documento.

        public int DiasAtraso
        {
            get;
            private set;
        }

        public decimal ValorJuros => CalcularJuros();
        public decimal ValorTotal => ValorOriginal + ValorJuros;

        public Cobranca(decimal valorOriginal, DateTime dataVencimento)
        {
            ValorOriginal = valorOriginal;
            DataVencimento = dataVencimento.Date;
            
            DateTime hoje = DateTime.Today;
            DiasAtraso = hoje > DataVencimento ? (hoje - DataVencimento).Days : 0;
        }

        private decimal CalcularJuros()
        {
            if (DiasAtraso <= 0)
                return 0.00m;

            // Calcula o valor dos juros com base no valor original, na taxa de juros diária e no número de dias em atraso.
            return decimal.Round(ValorOriginal * TaxaJurosDiaria * DiasAtraso,2, MidpointRounding.AwayFromZero);
        }
    }