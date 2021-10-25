using System;
using DIO.Series.Interfaces;
using System.Collections.Generic;

namespace DIO.Series
{
    class Program
    {
        public static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            char opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario != 'X')
            {
                switch (opcaoUsuario)
                {
                    case '1':
                        ListarSeries();
                    break;
                    case '2':
                        InserirSerie();
                    break;
                    case '3':
                        //ListarSeries();
                    break;
                    case '4':
                        //ListarSeries();
                    break;
                    case '5':
                        //ListarSeries();
                    break;
                    case 'C':
                        Console.Clear();
                    break;
                    default:
                    throw new ArgumentException();
                }
                opcaoUsuario = ObterOpcaoUsuario();       
            }
            Console.WriteLine("Saindo...");
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série:");
            Console.WriteLine("");
            foreach (var item in Enum.GetValues(typeof(Genero)))
                Console.WriteLine($"{item.GetHashCode()} - {item.ToString()}");
            Console.WriteLine("Digite o código do Gênero: ");
            sbyte opcao = sbyte.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Título: ");
            string titulo = Console.ReadLine();
            Console.WriteLine("Digite a Descrição: ");
            string descricao = Console.ReadLine();
            Console.WriteLine("Digite o Ano de Lançamento: ");
            int ano = int.Parse(Console.ReadLine());
            repositorio.Insere(new Serie(repositorio.ProximoId(), (Genero)opcao, titulo, descricao, ano));
        }

        private static void ListarSeries()
        {
            List<Serie> lista = repositorio.Lista();
            if (lista.Count == 0) {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            foreach (Serie item in lista)
                Console.WriteLine("#ID {0} - {1}", item.retornaId(), item.retornaTitulo());
            Console.ReadLine();
        }

        private static char ObterOpcaoUsuario() {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();
            Console.WriteLine("1- Listar séries;");
            Console.WriteLine("2- Inserir nova série;");
            Console.WriteLine("3- Atualizar série;");
            Console.WriteLine("4- Excluir série;");
            Console.WriteLine("5- Visualizar série;");
            Console.WriteLine("C- Limpar tela;");
            Console.WriteLine("X- Sair");
            Console.WriteLine();
            string r = Console.ReadLine();
            if (char.TryParse(r.ToUpper(), out char result))
                return result;
            else
                return '0';
        }
    }
}
