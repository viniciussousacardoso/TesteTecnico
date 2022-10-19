using System;
using System.Diagnostics.CodeAnalysis;
using TesteTecnico.Interfaces;

namespace TesteTecnico.Model
{
    [ExcludeFromCodeCoverage]
    public class Trade : ITrade
    {
        public double Value { get; set; }

        public string ClientSector { get; set; }

        public DateTime NextPaymentDate { get; set; }
    }
}
