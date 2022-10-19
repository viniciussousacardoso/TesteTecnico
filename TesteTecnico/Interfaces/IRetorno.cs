using System.Collections.Generic;

namespace TesteTecnico.Interfaces
{
    public interface IRetorno
    {
        string RetornoListaInserida(List<ITrade> trades);
        string RetornoRisco(List<ITrade> trades);
    }
}
