using Moq;
using System;
using System.Collections.Generic;
using TesteTecnico.Enums;
using TesteTecnico.Interfaces;
using TesteTecnico.Model;
using TesteTecnico.Repository;
using Xunit;
using FluentAssertions;

namespace Testes
{
    public class UnitTests
    {
        private readonly Trading listTradePublico = new Trading();
        private readonly Trading listTradePrivado = new Trading();

        public UnitTests()
        {
            listTradePublico.Trades.Add(new Trade() { Value = 1000001, ClientSector = Enum.GetName(typeof(TipoClienteEnum), TipoClienteEnum.Publico), NextPaymentDate = DateTime.Now });
            listTradePublico.Trades.Add(new Trade() { Value = 100000, ClientSector = Enum.GetName(typeof(TipoClienteEnum), TipoClienteEnum.Publico), NextPaymentDate = DateTime.Now });
            listTradePublico.Trades.Add(new Trade() { Value = 1000000, ClientSector = Enum.GetName(typeof(TipoClienteEnum), TipoClienteEnum.Publico), NextPaymentDate = DateTime.Now.AddDays(-31) });

            listTradePrivado.Trades.Add(new Trade() { Value = 1000001, ClientSector = Enum.GetName(typeof(TipoClienteEnum), TipoClienteEnum.Privado), NextPaymentDate = DateTime.Now });
            listTradePrivado.Trades.Add(new Trade() { Value = 100000, ClientSector = Enum.GetName(typeof(TipoClienteEnum), TipoClienteEnum.Privado), NextPaymentDate = DateTime.Now });
            listTradePrivado.Trades.Add(new Trade() { Value = 1000000, ClientSector = Enum.GetName(typeof(TipoClienteEnum), TipoClienteEnum.Privado), NextPaymentDate = DateTime.Now.AddDays(-31) });
        }

        [Fact]
        public void RetornoListaInseridaPublico()
        {
            var retorno = new RetornaListaRepository().RetornoListaInserida(listTradePublico.Trades);
            retorno.Should().Be(retorno);
        }

        [Fact]
        public void RetornoRiscoPublico()
        {
            var retorno = new RetornaListaRepository().RetornoRisco(listTradePublico.Trades);
            retorno.Should().Be(retorno);
        }

        [Fact]
        public void RetornoListaInseridaPrivado()
        {
            var retorno = new RetornaListaRepository().RetornoListaInserida(listTradePrivado.Trades);
            retorno.Should().Be(retorno);
        }

        [Fact]
        public void RetornoRiscoPrivado()
        {
            var retorno = new RetornaListaRepository().RetornoRisco(listTradePrivado.Trades);
            retorno.Should().Be(retorno);
        }

        [Fact]
        public void VerifyAndValidateClientSectorPrivado()
        {
            var retorno = new VerificaValoresRepository().VerifyAndValidateClientSector(Convert.ToInt32(TipoClienteEnum.Privado));
            retorno.Should().Be(true);
        }

        [Fact]
        public void VerifyAndValidateClientSectorPublico()
        {
            var retorno = new VerificaValoresRepository().VerifyAndValidateClientSector(Convert.ToInt32(TipoClienteEnum.Publico));
            retorno.Should().Be(true);
        }

        [Fact]
        public void VerifyAndValidateClientSectorInvalido()
        {
            var retorno = new VerificaValoresRepository().VerifyAndValidateClientSector(3);
            retorno.Should().Be(false);
        }
    }
}
