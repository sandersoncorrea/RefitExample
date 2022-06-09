using System;
using System.Threading.Tasks;
using Refit;

namespace RefirExample
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var cepClient = RestService.For<ICepApiService>("http://viacep.com.br");
                Console.WriteLine("Informe seu CEP:");

                string cepInformado = Console.ReadLine().ToString();
                Console.WriteLine("Consultando informações...");

                var address = await cepClient.GetAddressAsync(cepInformado);

                Console.WriteLine($"CEP: {address.cep}\nLogradouro: {address.logradouro}\nComplemento: {address.complemento}\nBairro: {address.bairro}\n");
                Console.WriteLine($"Localidade: {address.localidade}\nUF: {address.uf}\nIBGE: {address.ibge}\nGIA: {address.gia}\n");
                Console.WriteLine($"DDD: {address.ddd}\nSIAFI: {address.siafi}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
