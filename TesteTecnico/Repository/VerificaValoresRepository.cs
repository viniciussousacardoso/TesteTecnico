using TesteTecnico.Enums;
using TesteTecnico.Interfaces;

namespace TesteTecnico.Repository
{
    public class VerificaValoresRepository : IVerificaValores
    {
        public bool VerifyAndValidateClientSector(int tipoClienteEnum)
        {
            if (TipoClienteEnum.Privado == (TipoClienteEnum)tipoClienteEnum || TipoClienteEnum.Publico == (TipoClienteEnum)tipoClienteEnum)
                return true;
            return false;
        }
    }
}
