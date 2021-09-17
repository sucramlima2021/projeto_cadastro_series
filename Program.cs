using System;

namespace cadastro_series
{
    class Program
    {
        static SerieRepositorio repo = new SerieRepositorio();
        static void Main(string[] args)
        {
           Console.WriteLine("Bem vindo ao Sistema de Cadastramento de Séries.");
           string sai = "";
           while (sai != "x")
           {
                Console.WriteLine("Escolha a opção desejada");
                Console.WriteLine("1 - Cadastrar Série");
                Console.WriteLine("2 - Alterar Série");
                Console.WriteLine("3 - Excluir Série");
                Console.WriteLine("4 - Visualizar Série");
                Console.WriteLine("5 - Listar Séries");
                Console.WriteLine("6 - Limpar a tela");
                Console.WriteLine("X - Sair do sistema");
                string opcao = Console.ReadLine().ToLower();
                switch (opcao)
                {
                    case "1":
                        cadastrar();
                        break;
                    case "2":
                        alterar();
                        break;
                    case "3":
                        excluir();
                        break;
                    case "4":
                        visualizar();
                        break;
                    case "5":
                        listar();
                        break;
                    case "6":
                        Console.Clear();
                        break;
                    case "x":
                        sai = "x";
                        break;

                    default:
                        Console.WriteLine("Opção Inválida!");
                        Console.WriteLine("");
                        break;

                }

           }
        }
        public static void cadastrar()
        {
            
            int gen = 0;
            int a = 0;
               Console.WriteLine("Cadastrar nova Série");
               
               Console.WriteLine("Digite o Gênero da Série:");
               Console.WriteLine("");
               foreach ( int i in Enum.GetValues(typeof(Genero)))
               {
                   Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
               }
               try
               {
                    gen = int.Parse(Console.ReadLine());
               }
               catch (System.Exception)
               {
                   
                   Console.WriteLine("Opção Inválida!");
                   Console.WriteLine("Tente novamente.");
                   Console.WriteLine("");
                   cadastrar();
               }
               bool verifica = Enum.IsDefined(typeof(Genero), gen);
               if (verifica)
               {
                    Console.WriteLine("");
                    Console.WriteLine("Digite o Título da Série.");
                    string tit = Console.ReadLine();

                    Console.WriteLine("");
                    Console.WriteLine("Digite a Descrição da Série.");
                    string descr = Console.ReadLine();

                    Console.WriteLine("");
                    Console.WriteLine("Digite o Ano que a Série estreou.");
                   try
                   {
                        a = int.Parse(Console.ReadLine());    
                   }
                   catch (System.Exception)
                   {
                        Console.WriteLine("Opção Inválida!");
                        Console.WriteLine("Tente novamente.");
                        Console.WriteLine("");
                        cadastrar();
                   }
                    

                    Serie nova = new Serie(id:repo.ProximoId(), genero: (Genero)gen, titulo: tit, descricao: descr, ano: a);
                    repo.Insere(nova);
                    Console.WriteLine("");
            }

                else
                {
                    Console.WriteLine("Gênero inexistente");
                    Console.WriteLine("Tente novamente.");
                    Console.WriteLine("");
                    cadastrar();
                }
        }

        public static void alterar()
        {
            int pegaId = 0;
            bool ok = true;
            int gen = 0;
            int a = 0;
            Console.WriteLine("Digite o ID da Série.");
            try
            {
                pegaId = int.Parse(Console.ReadLine());
            }
            catch (System.Exception)
            {
                Console.WriteLine("Opção Inválida!");
                Console.WriteLine("Tente novamente.");
                Console.WriteLine("");
                alterar();
            }
            var lista = repo.Lista();
            foreach (var i in lista)
            {
                if (i.id == pegaId)
                {
                    ok = true;
                    break;
                }
                else
                {
                   ok = false;
                }
            }
            if (!ok)
            {
                Console.WriteLine("Este ID não existe");
                Console.WriteLine("Tente novamente.");
                Console.WriteLine("");
                alterar();
            }
            else
            {
                Console.WriteLine("Digite o Gênero da Série:");
               Console.WriteLine("");
               foreach ( int i in Enum.GetValues(typeof(Genero)))
               {
                   Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
               }
               try
               {
                    gen = int.Parse(Console.ReadLine());
               }
               catch (System.Exception)
               {
                   
                   Console.WriteLine("Opção Inválida!");
                   Console.WriteLine("Tente novamente.");
                   Console.WriteLine("");
                   alterar();
               }
               bool verifica = Enum.IsDefined(typeof(Genero), gen);
               if (verifica)
               {
                    Console.WriteLine("");
                    Console.WriteLine("Digite o Título da Série.");
                    string tit = Console.ReadLine();

                    Console.WriteLine("");
                    Console.WriteLine("Digite a Descrição da Série.");
                    string descr = Console.ReadLine();

                    Console.WriteLine("");
                    Console.WriteLine("Digite o Ano que a Série estreou.");
                   try
                   {
                        a = int.Parse(Console.ReadLine());    
                   }
                   catch (System.Exception)
                   {
                        Console.WriteLine("Opção Inválida!");
                        Console.WriteLine("Tente novamente.");
                        Console.WriteLine("");
                        alterar();
                   }
                    

                    Serie atual = new Serie(id:pegaId, genero: (Genero)gen, titulo: tit, descricao: descr, ano: a);
                    repo.Atualiza(pegaId, atual);
                    Console.WriteLine("");
                }

                else
                {
                    Console.WriteLine("Gênero inexistente");
                    Console.WriteLine("Tente novamente.");
                    Console.WriteLine("");
                    alterar();
                }
            }
        }

        public static void excluir()
        {
            int pegaId = 0;
            bool ok = false;
            Console.WriteLine("Digite o ID da Série para excluir.");
            try
            {
                pegaId = int.Parse(Console.ReadLine());
            }
            catch (System.Exception)
            {
                Console.WriteLine("Opção Inválida!");
                Console.WriteLine("Tente novamente.");
                Console.WriteLine("");
                excluir();
            }
            var lista = repo.Lista();
            foreach (var i in lista)
            {
                if (i.id == pegaId)
                {
                    ok = true;
                    break;
                }
                else
                {
                   ok = false;
                }
            }
            if (ok)
            {
               repo.Exclui(pegaId);
            }
            else
            {
                Console.WriteLine("ID Não encontrado");
                Console.WriteLine("Tente novamente.");
                Console.WriteLine("");
                excluir();
            }
        }

        public static void visualizar()
        {
            int pegaId = 0;
            bool ok = false;
            Console.WriteLine("Digite o ID da Série para exibir.");
            try
            {
                pegaId = int.Parse(Console.ReadLine());
            }
            catch (System.Exception)
            {
                Console.WriteLine("Opção Inválida!");
                Console.WriteLine("Tente novamente.");
                Console.WriteLine("");
                excluir();
            }
            var lista = repo.Lista();
            foreach (var i in lista)
            {
                if (i.id == pegaId)
                {
                    ok = true;
                    break;
                }
                else
                {
                   ok = false;
                }
            }
            if (ok)
            {
               Console.WriteLine(repo.RetornaPorId(pegaId));
            }
            else
            {
                Console.WriteLine("ID Não encontrado");
                Console.WriteLine("Tente novamente.");
                Console.WriteLine("");
                excluir();
            }
        }

        public static void listar()
        {
            Console.WriteLine("Listar Séries");
            var lista = repo.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Série cadastrada!");
                Console.WriteLine("");
                return;
            }
            Console.WriteLine(lista);
            foreach (var i in lista)
            {
                Console.WriteLine("#ID {0}: {1}", i.RetornaId(), i.RetornaTitulo());
            }
            

            Console.WriteLine("");

        }
        
    }
}
