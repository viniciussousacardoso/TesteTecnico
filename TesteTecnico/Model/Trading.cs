using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TesteTecnico.Interfaces;

namespace TesteTecnico.Model
{
    [ExcludeFromCodeCoverage]
    public class Trading
    {
        public List<ITrade> Trades { get; set; } = new List<ITrade>();
    }
}
