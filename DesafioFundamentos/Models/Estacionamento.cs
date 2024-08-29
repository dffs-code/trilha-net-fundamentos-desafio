using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial;
        private decimal precoPorHora;
        private List<string> veiculos;

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
            this.veiculos = new List<string>();
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine(); // Lê a placa digitada pelo usuário

            if (!string.IsNullOrWhiteSpace(placa))
            {
                veiculos.Add(placa); // Adiciona a placa à lista de veículos
                Console.WriteLine($"Veículo {placa} adicionado com sucesso.");
            }
            else
            {
                Console.WriteLine("Placa inválida. Por favor, digite uma placa válida.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine(); // Lê a placa digitada pelo usuário

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas;
                bool horasValida = int.TryParse(Console.ReadLine(), out horas); // Lê e valida o número de horas

                if (horasValida && horas >= 0)
                {
                    decimal valorTotal = precoInicial + precoPorHora * horas;

                    veiculos.Remove(placa); // Remove a placa da lista de veículos
                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else
                {
                    Console.WriteLine("Quantidade de horas inválida. Por favor, digite um número válido de horas.");
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo); // Exibe cada veículo na lista
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
