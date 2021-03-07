using System;

namespace Series
{
    class Program
    {

        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {

            string opcao = ObterOpcaoUsuario();

            while (opcao != "X")
            {
                switch(opcao)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcao = ObterOpcaoUsuario();
            }

        }

        private static void ListarSeries()
        {
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                System.Console.WriteLine("Nenhuma série cadastrada");
                return;
            }
            foreach (var serie in lista)
            {
                System.Console.WriteLine(
                    "{0}: {1} - {2}", 
                    serie.RetornarId(), 
                    serie.RetornarTitulo(),
                    serie.RetornarExcluido() ? "Indisponível" : "Disponível"
                );
            }

        }

        private static void InserirSerie()
        {
            Serie novaSerie = PromptSerie(repositorio.ProximoId());
            repositorio.Insere(novaSerie);
        }

        private static void AtualizarSerie() 
        {
            System.Console.WriteLine("Insira o id da série");
            int id = int.Parse(Console.ReadLine());
            Serie serie = PromptSerie(id);
            repositorio.Atualiza(id, serie);
        }

        private static void ExcluirSerie()
        {
            System.Console.WriteLine("Digite o id da série:");
            int id = int.Parse(Console.ReadLine());
            repositorio.Exclui(id);
        }

        private static void VisualizarSerie()
        {
            System.Console.WriteLine("Digite o id da série:");
            int id = int.Parse(Console.ReadLine());
            var serie = repositorio.RetornaPorId(id);
            System.Console.WriteLine(serie);
        }

        private static Serie PromptSerie(int id) 
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0}: {1}", i, Enum.GetName(typeof(Genero), i));
            }
            System.Console.WriteLine("Digite o id do gênero");
            int genero = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o título da série");
            string titulo = Console.ReadLine();

            System.Console.WriteLine("Digite o ano da série");
            int ano = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite a descrição da série");
            string descricao = Console.ReadLine();

            return new Serie(
                id: id,
                genero: (Genero) genero,
                titulo: titulo,
                ano: ano,
                descricao: descricao
            );
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("1. Listar séries");
            Console.WriteLine("2. Inserir nova série");
            Console.WriteLine("3. Atualizar série");
            Console.WriteLine("4. Excluir série");
            Console.WriteLine("5. Visualizar série");
            Console.WriteLine("C. Limpar tela");
            Console.WriteLine("X. Sair");
            Console.WriteLine();
            return Console.ReadLine().ToUpper();
        }

    }
}
