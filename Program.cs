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
                        AtualizarSerie();
                    break;
                    case '4':
                        ExcluirSerie();
                    break;
                    case '5':
                        VisualizaSerie();
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

        private static void VisualizaSerie()
        {
             Console.WriteLine("Digite o ID do filme que deseja visualizar: ");
            int id = int.Parse(Console.ReadLine());
            Serie s = repositorio.RetornaPorId(id);
            Console.WriteLine(s.ToString());
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o ID do filme que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());
            repositorio.Exclui(id);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o ID do filme que deseja atualizar: ");
            int id = int.Parse(Console.ReadLine());
            QuestionarioSerie(out sbyte opcao, out string titulo, out string descricao, out int ano);
            repositorio.Atualiza(id, new Serie(id, (Genero)opcao, titulo, descricao, ano));
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série:");
            Console.WriteLine("");
            QuestionarioSerie(out sbyte opcao, out string titulo, out string descricao, out int ano);
            repositorio.Insere(new Serie(repositorio.ProximoId(), (Genero)opcao, titulo, descricao, ano));
        }

        private static void QuestionarioSerie(out sbyte opcao, out string titulo, out string descricao, out int ano)
        {
            foreach (var item in Enum.GetValues(typeof(Genero)))
                Console.WriteLine($"{item.GetHashCode()} - {item.ToString()}");
            Console.WriteLine("Digite o código do Gênero: ");
            opcao = sbyte.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Título: ");
            titulo = Console.ReadLine();
            Console.WriteLine("Digite a Descrição: ");
            descricao = Console.ReadLine();
            Console.WriteLine("Digite o Ano de Lançamento: ");
            ano = int.Parse(Console.ReadLine());
        }

        private static void ListarSeries()
        {
            List<Serie> lista = repositorio.Lista();
            if (lista.Count == 0) {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            foreach (Serie item in lista)
                Console.WriteLine("#ID {0} - {1} {2}", item.retornaId(), item.retornaTitulo(), item.retornaExcluido() ? "*Excluído*" : "");
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
