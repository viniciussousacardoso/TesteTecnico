using System;
using System.Globalization;
using TesteTecnico.Enums;
using TesteTecnico.Interfaces;
using TesteTecnico.Model;
using TesteTecnico.Repository;
using Microsoft.Extensions.DependencyInjection;
using TesteTecnico.Extensions;

namespace TesteTecnico
{
    public class Program
    {
        private readonly IRetorno _retorno;

        public Program()
        {
            var trade = new Trading();
            var verificar = new VerificaValoresRepository();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddServices();

            var _serviceProvider = serviceCollection.BuildServiceProvider();

            _retorno = _serviceProvider.GetRequiredService<IRetorno>();

            bool continua = true;
            string ClientSector;
            double MoneyValue;
            DateTime NextPaymentDate;
           
            while (continua)
            {
                try
                {
                    try
                    {
                        Console.WriteLine("Entre com o valor do dinheiro:");
                        MoneyValue = Convert.ToDouble(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"=================================================================");
                        Console.WriteLine($"Ocorreu um erro ao inserir o valor do dinheiro: {ex}");
                        Console.WriteLine($"================================================================= \n");
                        throw (ex);
                    }

                    try
                    {
                        Console.WriteLine("Entre com a data(mm/dd/yyyy):");
                        NextPaymentDate = Convert.ToDateTime(Console.ReadLine(), CultureInfo.CreateSpecificCulture("en-US"));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"=================================================================");
                        Console.WriteLine($"Ocorreu um erro ao inserir o valor da data: {ex}");
                        Console.WriteLine($"================================================================= \n");
                        throw (ex);
                    }

                    try
                    {
                        Console.WriteLine("Entre com o tipo do cliente 0 Publico 1 Privado: ");
                        int Selector = Convert.ToInt32(Console.ReadLine());

                        ClientSector = Selector == 0 ? Enum.GetName(typeof(TipoClienteEnum), TipoClienteEnum.Publico) : Selector == 1 ? Enum.GetName(typeof(TipoClienteEnum), TipoClienteEnum.Privado) : string.Empty;

                        if (!verificar.VerifyAndValidateClientSector(Selector))
                            throw new Exception("Tipo de Cliente não existe");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"=================================================================");
                        Console.WriteLine($"Ocorreu um erro ao inserir o tipo do cliente: {ex}");
                        Console.WriteLine($"================================================================= \n");
                        throw (ex);
                    }

                    trade.Trades.Add(new Trade() { Value = MoneyValue, ClientSector = ClientSector, NextPaymentDate = NextPaymentDate });

                    Console.WriteLine("Deseja continuar inserindo os dados Y or N?");
                    continua = Console.ReadLine().ToUpper() == "Y";
                }
                catch (Exception)
                {
                    Console.WriteLine("Ocorreu um erro e esse dado não sera computado. \n");

                    Console.WriteLine("Deseja continuar inserindo os dados Y or N?");
                    continua = Console.ReadLine().ToUpper() == "Y";
                }
            }

            Console.WriteLine("=========================================================");
            Console.WriteLine("Dados inseridos: \n \n");


            Console.WriteLine(_retorno.RetornoListaInserida(trade.Trades));

            Console.WriteLine("=========================================================");
            Console.WriteLine("saida: \n \n");

            Console.WriteLine(_retorno.RetornoRisco(trade.Trades));


        }

        static void Main()
        {
            new Program();
            Console.ReadKey();
        }
    }
}
