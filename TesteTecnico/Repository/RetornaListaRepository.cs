using System;
using System.Collections.Generic;
using TesteTecnico.Enums;
using TesteTecnico.Interfaces;

namespace TesteTecnico.Repository
{
    public class RetornaListaRepository : IRetorno
    {
        public readonly double valorRiscoPadrao = 1000000;

        public string RetornoListaInserida(List<ITrade> trades)
        {
            string retorno = string.Empty;

            foreach (var i in trades)
            {
                retorno += $"{i.Value}  {i.NextPaymentDate:dd/MM/yyyy}  {i.ClientSector} \n";
            }

            return retorno;
        }

        public string RetornoRisco(List<ITrade> trades)
        {
            string retorno = string.Empty;

            foreach (var i in trades)
            {
                if (i.NextPaymentDate >= DateTime.Now.AddDays(-30))
                {
                    if (i.Value <= valorRiscoPadrao)
                        retorno = $"{retorno} LOWRISK \n";

                    if (i.Value > valorRiscoPadrao && i.ClientSector == Enum.GetName(typeof(TipoClienteEnum), TipoClienteEnum.Privado))
                        retorno = $"{retorno} HIGHRISK \n";

                    if (i.Value > valorRiscoPadrao && i.ClientSector == Enum.GetName(typeof(TipoClienteEnum), TipoClienteEnum.Publico))
                        retorno = $"{retorno} MEDIUMRISK \n";
                }
                else
                    retorno = $"{retorno} EXPIRED \n";
            }

            return retorno;
        }
    }
}
