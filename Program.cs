using System;
using Series.Classes;

namespace Series 
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main (string [] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario ();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                    ListarSerie();
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
                    VizualizarSerie();
                    break;
                    case "C":
                    Console.Clear();
                    break;
                    default:
                    throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario ();
            }
        Console.WriteLine("Obrigado por utilizar nossos serviços.");
        Console.ReadLine();
            
        }
        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            repositorio.Excluir(indiceSerie);
        }

        private static void VizualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o titulo da serie: ");
            string entradaTitulo = Console.ReadLine();
            Console.WriteLine("Digite o ano do inicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite descrição da série: ");
            string entradaDescricao = Console.ReadLine();
            Serie atualizaSerie = new Serie(Id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }
        private static void ListarSerie()
        {
            Console.WriteLine("Listar séries");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }
            foreach (var serie in lista)
            {
                var Excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1}  {2}", serie.retornaId(), serie.retornaTitulo(), serie.retornaExcluido(), (Excluido ? "*Excluido*" : ""));
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine ("Inserir nova série");

            foreach (int  i in Enum.GetValues(typeof(Genero)))
            {
               Console.WriteLine("{0}+{1}", i, Enum.GetName(typeof(Genero), i)); 
            }
            Console.WriteLine("Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o titulo da serie: ");
            string entradaTitulo = Console.ReadLine();
            Console.WriteLine("Digite o ano do inicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(Id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Insere(novaSerie);

;        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Series a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada: ");


            Console.WriteLine("1- Listar séries ");
            Console.WriteLine("2- Inserir nova serie");
            Console.WriteLine("3- Atualizar Série");
            Console.WriteLine("4- Excluir Série ");
            Console.WriteLine("5- Vizualizar serie");
            Console.WriteLine("C- Limpar Tela ");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
