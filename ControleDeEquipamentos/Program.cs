using System.Runtime.Intrinsics.X86;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ControleDeEquipamentos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcaomenu = 0, NI = -1, loopnoswitch = 0;
            Equipamento[] vetorEquipamento = new Equipamento[43];

            string nomeequipamento = "", fabricante = "", SN = "", data = "";
            decimal preco = 0;

            while (opcaomenu != 5)
            {
                opcaomenu = Interface.Menu();
                while (true)
                {
                    switch (opcaomenu)
                    {
                        case 1:
                            while(true)
                            {
                                NI = ++NI;

                                Interface.AvisoRegra();

                                nomeequipamento = Funcao.NomeMinimo("\nDigite o nome do produto que você deseja cadastrar: ");
                                Console.Write($"\nDigite o fabricante do produto {nomeequipamento}: ");
                                fabricante = Console.ReadLine();
                                Console.Write($"\nDigite o Serial Number do produto {nomeequipamento}: ");
                                SN = Console.ReadLine();
                                preco = Funcao.LerDecimal($"\nDigite o preço do produto {nomeequipamento}: R$");
                                data = Funcao.Data(nomeequipamento);

                                vetorEquipamento[NI] = new Equipamento(nomeequipamento, SN, data, fabricante, preco);

                                Console.Write("\n\nCadastro efetuado com sucesso! Precione qualquer tecla para continuar.");
                                Console.ReadKey();

                                Interface.Cabecalho();
                                while(true)
                                {
                                    opcaomenu = Funcao.LerInt("\n\nO que deseja fazer?\n\n1. Voltar ao menu\n2. Cadastrar outro produto\nSua opção: ");
                                    if (opcaomenu < 1 || opcaomenu > 2)
                                    {
                                        Interface.Erro();
                                        continue;
                                    }
                                    break;
                                }
                               
                                if (opcaomenu == 2)
                                {
                                    opcaomenu = 1;
                                    continue;
                                }
                                break;
                            }
                        break;

                        case 2:
                            opcaomenu = Funcao.VerificacaoEquipamento(NI);
                            if (opcaomenu == 1)
                            {
                                break;
                            }
                            else if (opcaomenu == 2)
                            {
                                opcaomenu = 1;
                                continue;
                            }
                            Interface.Cabecalho();
                            Console.Write("Listagem dos equipagentos registrados.\n\n");
                            int auxlista = 1;
                            for (int i = 0; i <= NI; i++)
                            {
                                Console.Write($"Nº{auxlista} |  Nome: {vetorEquipamento[i].NomeEquipamento}   Fabricante: {vetorEquipamento[i].Fabricante}   Serial Number: {vetorEquipamento[i].SN}\nPreço: R${vetorEquipamento[i].Preco}   Data de Fabricação: {vetorEquipamento[i].Data}");
                                Console.Write("\n------------------------------------------------------------------------------------------\n");
                                auxlista++;
                            }
                            Console.Write("\n\nPrecione qualquer tecla para continuar.");
                            Console.ReadKey();
                            if (loopnoswitch == 1)
                            {
                                opcaomenu = 3;
                                continue;
                            }
                            if (loopnoswitch == 2)
                            {
                                opcaomenu = 4;
                                continue;
                            }
                            if (loopnoswitch == 3)
                            {
                                loopnoswitch = 0;
                            }
                        break;

                        case 3:
                            opcaomenu = Funcao.VerificacaoEquipamento(NI);
                            if (opcaomenu == 1)
                            {
                                break;
                            }
                            else if (opcaomenu == 2)
                            {
                                opcaomenu = 1;
                                continue;
                            }
                            if(loopnoswitch == 0)
                            {
                                loopnoswitch++;
                                opcaomenu = 2;
                                continue;
                            }
                            loopnoswitch = 0;
                            int aux = 0;
                            while (true)
                            {
                                aux = Funcao.LerInt("\n\nPor favor escolha o número do Equipamento, que está listado a esquerda na lista, para editar o campo.\nSua escolha: ");
                                --aux;
                                if (aux > NI || aux < 0)
                                {
                                    Interface.Erro();
                                    continue;
                                }
                                break;
                            }

                            bool op6 = false;
                            int submenudelete = 0;
                            while (true)
                            {
                                submenudelete = Funcao.LerInt("\nQual campo você deseja alterar?\n\n1. Nome\n2. Fabricante\n3. Serial Numer\n4. Preço\n5. Data de Fabricação\n6. Todos os campos\nSua Opção: ");
                                Interface.Cabecalho();
                                if (submenudelete != 1 && submenudelete != 2 && submenudelete != 3 && submenudelete != 4 && submenudelete != 5 && submenudelete != 6)
                                {
                                    Interface.Erro();
                                    continue;
                                }
                                break;
                            }
                            
                            while (true)
                            {
                                switch (submenudelete)
                                {
                                    case 1:
                                        nomeequipamento = Funcao.NomeMinimo($"\nO nome estava cadastrado como {nomeequipamento}. Digite o novo nome do produto que você deseja cadastrar: ");
                                        if (op6 == true)
                                        {
                                            submenudelete = 2;
                                            continue;
                                        }
                                        Console.Write("\n\nAlteração efetuada com sucesso! Precione qualquer tecla para continuar.");
                                        Console.ReadKey();
                                        break;

                                    case 2:
                                        Console.Write($"\nDigite o novo fabricante do equipamento {nomeequipamento}: ");
                                        fabricante = Console.ReadLine();
                                        if (op6 == true)
                                        {
                                            submenudelete = 3;
                                            continue;
                                        }
                                        Console.Write("\n\nAlteração efetuada com sucesso! Precione qualquer tecla para continuar.");
                                        Console.ReadKey();
                                        break;

                                    case 3:
                                        Console.Write($"\nDigite o novo Serial Number do produto {nomeequipamento}: ");
                                        SN = Console.ReadLine();
                                        if (op6 == true)
                                        {
                                            submenudelete = 4;
                                            continue;
                                        }
                                        Console.Write("\n\nAlteração efetuada com sucesso! Precione qualquer tecla para continuar.");
                                        Console.ReadKey();
                                        break;

                                    case 4:
                                        preco = Funcao.LerDecimal($"\nDigite o novo preço do produto {nomeequipamento}: R$");
                                        if (op6 == true)
                                        {
                                            submenudelete = 5;
                                            continue;
                                        }
                                        Console.Write("\n\nAlteração efetuada com sucesso! Precione qualquer tecla para continuar.");
                                        Console.ReadKey();
                                        break;

                                    case 5:
                                        data = Funcao.Data(nomeequipamento);
                                        Console.Write("\n\nAlteração efetuada com sucesso! Precione qualquer tecla para continuar.");
                                        Console.ReadKey();
                                        break;

                                    case 6:
                                        op6 = true;
                                        if (op6 == true)
                                        {
                                            submenudelete = 1;
                                            continue;
                                        }
                                    break;
                                }
                                vetorEquipamento[aux] = new Equipamento(nomeequipamento, SN, data, fabricante, preco);
                                break;
                            }
                        break;

                        case 4:
                            opcaomenu = Funcao.VerificacaoEquipamento(NI);
                            if (opcaomenu == 1)
                            {
                                break;
                            }
                            else if (opcaomenu == 2)
                            {
                                opcaomenu = 1;
                                continue;
                            }
                            if (loopnoswitch == 0)
                            {
                                loopnoswitch = 2;
                                opcaomenu = 2;
                                continue;
                            }
                            loopnoswitch = 0;

                            while(true)
                            {
                                aux = Funcao.LerInt("\n\nPor favor escolha o número do Equipamento, que está listado a esquerda na lista, para apaga-lo.\nSua escolha: ");
                                --aux;
                                if (aux > NI || aux < 0)
                                {
                                    Interface.Erro();
                                    continue;
                                }
                            break;
                            }

                            for(int i = aux; i < NI; i++)
                            {
                                aux++;
                                vetorEquipamento[i].NomeEquipamento = vetorEquipamento[aux].NomeEquipamento;
                                vetorEquipamento[i].Fabricante = vetorEquipamento[aux].Fabricante;
                                vetorEquipamento[i].SN = vetorEquipamento[aux].SN;
                                vetorEquipamento[i].Data = vetorEquipamento[aux].Data;
                                vetorEquipamento[i].Preco = vetorEquipamento[aux].Preco;
                            }
                            NI = NI - 1;
                            Console.Write("\n\nAlteração efetuada com sucesso! Precione qualquer tecla para apresentar a nova lista.");
                            Console.ReadKey();
                            if (loopnoswitch == 0)
                            {
                                loopnoswitch = 3;
                                opcaomenu = 2;
                                continue;
                            }
                        break;

                        case 5:
                            opcaomenu = 5;
                            break;
                    }
                    break;
                }
            }
        }
    }

    public class Funcao
    {
        public static int LerInt(string texto)
        {
            while (true)
            {
                Console.Write(texto);
                var digitouNumero = int.TryParse(Console.ReadLine(), out var numero);

                if (digitouNumero)
                {
                    return numero;
                }
                Interface.Erro();
            }
        }
        public static decimal LerDecimal(string texto)
        {
            while (true)
            {
                Console.Write(texto);
                var digitouNumero = decimal.TryParse(Console.ReadLine(), out var numero);

                if (digitouNumero)
                {
                    return numero;
                }
                Interface.Erro();
            }
        }
        public static string NomeMinimo(string texto)
        {
            while (true)
            {
                Console.Write(texto);
                string nome = Console.ReadLine();
                int tamanhodastring = nome.Length;
                if(tamanhodastring < 6)
                {
                    Interface.Erro();
                    continue;
                }
                return nome;
            }
        }
        public static string Data(string nomeequipamento)
        {
            string data = "", mesaux = "", diaaux = "";
            while (true)
            {
                int dia = LerInt($"\nDigite o dia de fabricação do produto {nomeequipamento}: ");
                if (dia < 0 || dia > 31)
                {
                    Interface.Erro();
                    continue;
                }
                int mes = LerInt($"\nDigite o mês, em numero, de fabricação do produto {nomeequipamento}: ");
                if (mes < 0 || mes > 12)
                {
                    Interface.Erro();
                    continue;
                }
                int ano = LerInt($"\nDigite o ano de fabricação do produto {nomeequipamento}: ");
                if (ano > 2024)
                {
                    Interface.Erro();
                    continue;
                }

                mesaux = $"{mes}";
                diaaux = $"{dia}";

                if (mes < 10)
                {
                    mesaux = $"0{mes}";
                }
                if (dia < 10)
                {
                    diaaux = $"0{dia}";
                }
                data = $"{diaaux}/{mesaux}/{ano}";
                return data;
            }
        }
        public static int VerificacaoEquipamento(int NI)
        {
            int opcaomenu = 0;
            if (NI == -1)
            {
                Interface.Cabecalho();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Nenhum produto cadastrado ainda.");
                Console.ForegroundColor = ConsoleColor.Magenta;
                opcaomenu = Funcao.LerInt("\n\nO que deseja fazer?\n\n1. Voltar ao menu\n2. Cadastrar um produto\nSua opção: ");
            }
            return opcaomenu;
        }
    }
    public class Interface
    {
        public static void Erro()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Clear();
            Console.WriteLine("\n\n\n######################################################################################");
            Console.WriteLine("###                                                                                ###");
            Console.WriteLine("###                                     ATENÇÃO                                    ###");
            Console.WriteLine("###                                                                                ###");
            Console.WriteLine("###              Comando inválido. Por favor digite um comando válido.             ###");
            Console.WriteLine("###                                                                                ###");
            Console.WriteLine("###                     Precione qualquer tecla para continuar.                    ###");
            Console.WriteLine("###                                                                                ###");
            Console.WriteLine("######################################################################################");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.ReadKey();
            Cabecalho();
        }
        public static void Cabecalho()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Clear();
            Console.WriteLine("######################################################################################");
            Console.WriteLine("###                                                                                ###");
            Console.WriteLine("###                          Academia do programador 2024                          ###");
            Console.WriteLine("###                                                                                ###");
            Console.WriteLine("###                            Controle de Equipamentos                            ###");
            Console.WriteLine("###                                                                                ###");
            Console.WriteLine("######################################################################################\n\n");
        }
        public static void AvisoRegra()
        {
            Cabecalho();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\n\n######################################################################################");
            Console.WriteLine("###                                                                                ###");
            Console.WriteLine("###                                     ATENÇÃO                                    ###");
            Console.WriteLine("###                                                                                ###");
            Console.WriteLine("###     Devido a normas internas da impresa, é necessário cadastrar um produto     ###");
            Console.WriteLine("###                            com pelo menos 6 digitos.                           ###");
            Console.WriteLine("###                                                                                ###");
            Console.WriteLine("###                     Precione qualquer tecla para continuar.                    ###");
            Console.WriteLine("###                                                                                ###");
            Console.WriteLine("######################################################################################");
            Console.ReadKey();
            Cabecalho();
        }
        public static int Menu()
        {
            while (true)
            {
                Cabecalho();
                int opcaomenu = Funcao.LerInt("1. Registrar equipamentos\n2. Listar equipamentos\n3. Editar equipamento\n4. Excluir equipamento\n5. Sair\nSua Opção: ");
                if (opcaomenu != 1 && opcaomenu != 2 && opcaomenu != 3 && opcaomenu != 4 && opcaomenu != 5)
                {
                    Erro();
                    continue;
                }
                return opcaomenu;
            }
        }
        
    }
    public class Equipamento
    {
        public string NomeEquipamento = "", SN = "", Data = "", Fabricante = "";
        public decimal Preco = 0;

        public Equipamento(string nomeequipamento, string SN, string data, string fabricante, decimal preco)
        {
            NomeEquipamento = nomeequipamento;
            this.SN = SN;
            Data = data;
            Fabricante = fabricante;
            Preco = preco;
        }

    }
}