using CarrosGaleria;
using LibraryEntidades;
using System;

namespace GaleriaCarro
{
    public class Funcao
    {
        static bool armazenar = true;
        private static IGerenciar manager = new CarrosInFile();
        public static void Menu()
        { 
            Console.WriteLine("-------------------------BEM VINDO-------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                       ____________________\r\n                     //|           |        \\\r\n                   //  |           |          \\\r\n      ___________//____|___________|__________()\\__________________\r\n    /__________________|_=_________|_=___________|_________________{}\r\n    [           ______ |           | .           | ==  ______      { }\r\n  __[__        /##  ##\\|           |             |    /##  ##\\    _{# }_\r\n {_____)______|##    ##|___________|_____________|___|##    ##|__(______}\r\n             /  ##__##                              /  ##__##        \\\r\n----------------------------------------------------------------------------");
            Console.ResetColor();
            bool iniciararmazenamento = true;
            while (iniciararmazenamento)
            {
                Console.WriteLine("Aonde deseja salvar seu carro:\n [1] - EM ARQUIVO \n [2] - EM UMA LISTA");
                int opcaoarmazenar = int.Parse(Console.ReadLine());
                switch (opcaoarmazenar)
                {
                    case 1:
                        armazenar = true;
                        iniciararmazenamento = false;
                        break;
                    case 2:
                        armazenar = false;
                        iniciararmazenamento = false; break;
                    default:
                        Console.WriteLine("Não existe esta opção ...");
                        break;
                }
            }
            bool iniciar = true;
            MostrarTodos();
            while (iniciar)
            {
                Console.WriteLine("---------------------GALERIA DE CARROS---------------------");
                Console.WriteLine("[0] - Mostrar todos os carros");
                Console.WriteLine("[1] - Incluir carro");
                Console.WriteLine("[2] - Alterar carro");
                Console.WriteLine("[3] - Excluir carro");
                Console.WriteLine("[4] - Pesquisar carro");
                Console.WriteLine("[5] - Sair 'Galeria de carro'");
                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "0":
                        MostrarTodos();
                        break;
                    case "1":
                        IncluirCarro();
                        break;
                    case "2":
                        AlterarCarro();
                        break;
                    case "3":
                        ExcluirCarro();
                        break;
                    case "4":
                        PesquisarCarro();
                        break;
                    case "5":
                        iniciar = false;
                        break;
                    default:
                        Console.WriteLine("Opção invalida favor, digitar novamente: ");
                        break;
                }
            }
        }
        public static void IncluirCarro()
        {
            Carros carros = new Carros();
            Console.WriteLine("Digite o modelo do carro:");
            carros.ModeloCarro = Console.ReadLine().ToUpper();
            Console.WriteLine("Digite se este carro é Automatico:\n [S] Sim \n [N] Não");
            string lancamento = Console.ReadLine().ToUpper();
            carros.Lancamento = (lancamento == "S" || lancamento == "SIM") ? true : false;
            Console.WriteLine("Digite a quantidade de portas [0, 1, 2, 3, 4 ou 5]:");
            carros.Portas = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o ano de fabricação (YYYY):");
            int anoFabricacao = Convert.ToInt32(Console.ReadLine());
            carros.AnoDeFabricacao = new DateTime(anoFabricacao, 1, 1);
            carros.Exibir();
            Console.WriteLine("[1] - Confirmar \n [2] - Não Confirmar");
            int confirmar = Convert.ToInt32(Console.ReadLine());
            if (confirmar == 1)
            {
                Console.WriteLine("Cadastro COMPUTADO ...\n");
                if(armazenar)
                {
                    ArmazenarEmArquivo(carros);
                }else
                {
                    ArmazenarEmLista(carros);
                }

                Console.WriteLine("DADOS ADICIONADO COM SUCESSO!\n");
            }else
            {
                Console.WriteLine("Não armazenar os dados ... ");
            }   
        }
        private static void MostrarTodos()
        {
            if (manager.MostrarTodos().Count > 0)
            {
                Console.WriteLine("Essas são os carros cadastradas...");
                foreach (var item in manager.MostrarTodos())
                {
                    item.Exibir();
                }
            }
            else
            {
                Console.WriteLine("Ainda não existe carros cadastradas, favor cadastrar...");
            }
        }
        private static void AlterarCarro()
        {
            ExibirCarros();
            Console.WriteLine("Digite o modelo do Carro que deseja alterar");
            var modelocarro = Console.ReadLine();
            modelocarro = modelocarro.ToUpper();
            var carrospesquisar = manager.PesquisarCarro(modelocarro);
            Console.WriteLine("Editando...");
            foreach (var item in carrospesquisar)
            {
                bool a = true;
                
                    item.Exibir();
                while (a)
                {
                    Console.WriteLine("Deseja Atualizar este carro? \n[1]Sim\n[2]Não\n");
                    string opcao = Console.ReadLine();
                    if (opcao == "1")
                    {
                        manager.ExcluirCarro(item.ModeloCarro);
                        IncluirCarro();
                        a = false;
                    }
                    else if (opcao == "2")
                    {
                        OpcaoNaoexcluir();
                        a = false;
                    }
                    else
                    {
                        Console.WriteLine("Opção invalida...");
                    }
                } 
            }
        }
        private static void ExcluirCarro()
        {
            ExibirCarros();
            Console.WriteLine("Digite o modelo do Carro que deseja excluir");
            var modelocarro = Console.ReadLine();
            modelocarro = modelocarro.ToUpper();
            var carrospesquisar = manager.PesquisarCarro(modelocarro);
            Console.WriteLine("Avançando para excluir.......");
            foreach (var item in carrospesquisar)
            {
                bool b = true;
                item.Exibir();
                while (b)
                {
                    Console.WriteLine("Deseja excluir este carro? \n[1]Sim\n[2]Não\n");
                    string opcao = Console.ReadLine();
                    if (opcao == "1")
                    { b=    false; 
                        manager.ExcluirCarro(item.ModeloCarro);
                    }
                    else if (opcao == "2")
                    {
                        b = false;
                        OpcaoNaoexcluir();
                    }
                    else
                    {
                        Console.WriteLine("Opção invalida .. .");
                    }
                }
            }
        }
        private static void OpcaoNaoexcluir()
        {
            Console.WriteLine("Deseja sair ou busca outro carro?\n[1]Buscar novo Carro\n[Qualquer tecla]Menu");
            var ok = Convert.ToInt32(Console.ReadLine());
            if (ok == 1)
            {
                ExcluirCarro();
            }
        }
        private static void PesquisarCarro()
        {
            ExibirCarros();
            Console.WriteLine("Digite o Modelo do carro que deseja exibir detalhes:");
            var username = Console.ReadLine();
            username = username.ToUpper();
            var carros = manager.PesquisarCarro(username);
            Console.WriteLine("Imprimindo Resultado da Busca");
            if (carros.Count > 0)
            {
                foreach (var item in carros)
                {
                    item.Exibir();
                }
            }
            else
            {
                Console.WriteLine("Carro não encontrado");
            }
                
        }
        private static void ExibirCarros ()
        {
            List<Carros> todosOsCarros = manager.MostrarTodos();
            Console.WriteLine("Todos os carros cadastrados:");
            int i = 1;
            foreach (var carro in todosOsCarros)
            {
                Console.WriteLine($"Nome: {i} {carro.ModeloCarro}");
                i++;
            }
            if (todosOsCarros.Count < 0)
            {
                Console.WriteLine("Nenhum carro cadastrado.");
            }
        }
        private static void ArmazenarEmArquivo(Carros carros)
        {
            manager.CadastrarEmJson(carros);
            Console.WriteLine("Carro armazenado em arquivo.");
        }
        private static void ArmazenarEmLista(Carros carros)
        {
            manager.CadastrarCarro(carros);
            Console.WriteLine("Carro armazenado na lista.");
        }
    }
}
