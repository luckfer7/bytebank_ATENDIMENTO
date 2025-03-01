using System.Collections;
using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Exceptions;
using bytebank_ATENDIMENTO.bytebank.Util;

//Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

//CRIANDO UM ARRAY

//int[] idades = new int[5]; //esse 5 no final é o tamanho do array.

//os valores entre colchetes são os indices do array
//idades[0] = 30;
//idades[1] = 21;
//idades[2] = 19;
//idades[3] = 18;
//idades[4] = 38;


#region exemplos de arraus no C#
void TestaArray()
{
    int[] idades = new int[5];
    idades[0] = 30;
    idades[1] = 21;
    idades[2] = 19;
    idades[3] = 18;
    idades[4] = 38;

    //primeiro imprimiremos o tamanho do array
    Console.WriteLine($"Tamanho do array {idades.Length}");

    //agora, criaremos um método que percorre esse array e calcula a media de idades.

    int acumulador = 0;
    for ( int i = 0; i < idades.Length; i++ )
    {
        int idade = idades[i];
        Console.WriteLine($"Índice [{i}] = {idade}");
        acumulador += idade;
    }

    int media = acumulador / idades.Length; //media
    Console.WriteLine($"Média de idades = {media}");
}

//TestaArray();

//CRIANDO ARRAYS DE STRINGS

void TestaBuscarPalavra()
{
    string[] arrayDePalavras = new string[5];

    for (int i = 0; i < arrayDePalavras.Length; i++)
    {
        Console.Write($"Digite {i + 1} palavra: ");
        arrayDePalavras[i] = Console.ReadLine(); //vai receber a palavra e colocar no  indice?
    }

    Console.Write("Digite a palavra a ser buscada: ");
    string busca = Console.ReadLine();

    //agora, cria-se uma estrutura que percorre o array para examinar se a palavra foi encontrada
    foreach (string  palavra in arrayDePalavras)
    {
        if (palavra.Equals(busca)) //ou: palavra == busca
        {
            Console.WriteLine($"Palavra encontrada: {busca}");
            break;
        }
        else
        {
            Console.WriteLine($"Palavra não encontrada.");
        }
    }

}
//TestaBuscarPalavra();

//DEFININDO ARRAYS PELA CLASSE ARRAY
Array amostra = Array.CreateInstance(typeof(double), 5);
amostra.SetValue(5.9, 0);
amostra.SetValue(1.8, 1);
amostra.SetValue(7.1, 2);
amostra.SetValue(10, 3);
amostra.SetValue(6.9, 4);

//aqui vamos calcular a mediana, ou seja, pegar o valor que está no meio.
void TestaMediana(Array array)
{
    if((array == null) || (array.Length == 0))
    {
        Console.WriteLine("Array para calculo da mediana está vazio ou nulo");
    }

    double[] numeroOrdenados = (double[])array.Clone();

    //agora, ordena o array.
    Array.Sort(numeroOrdenados);

    //Calculando a mediana
    int tamanho = numeroOrdenados.Length;
    int meio = tamanho / 2;
    double mediana = (tamanho % 2 != 0) ? numeroOrdenados[meio] : (numeroOrdenados[meio] + numeroOrdenados[meio - 1]) / 2;
    Console.WriteLine($"Com base na amostra a mediana = {mediana}");
}

//TestaMediana(amostra);

//ARRAY DE OBJETOS

void TestaArrayDeContasCorrentes()
{
    ContaCorrente[] listaDeContas = new ContaCorrente[]
    {
        new ContaCorrente(874, "5679787-A"),
        new ContaCorrente(874, "4456668-B"),
        new ContaCorrente(874, "7781438-C")
    };

    for (int i = 0; i < listaDeContas.Length; i++)
    {
        ContaCorrente contaAtual = listaDeContas[i];
        //a variável contaAtual está armazenando cada conta corrente, que são 3, vinda da lista de contas através do indice.
        Console.WriteLine($"Indice{i} - Conta:{contaAtual.Conta}");
    }
}

//TestaArrayDeContasCorrentes();

void TestarArrayDeContasCorrentesDaClasse()
{
    //primeiro, se instancia a classe
    ListaDeContasCorrentes listaDeContas = new ListaDeContasCorrentes();

    //segundo, chama o método de adicionr
    listaDeContas.Adicionar(new ContaCorrente(874, "5679787-A"));
    listaDeContas.Adicionar(new ContaCorrente(874, "4456668-B"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
    var contaDoAndre = new ContaCorrente(963, "123456-X");
    listaDeContas.Adicionar(contaDoAndre);
    //listaDeContas.ExibeLista();
    //Console.WriteLine("===============");
    //listaDeContas.Remover(contaDoAndre);
    //listaDeContas.ExibeLista();

    for (int i = 0; i < listaDeContas.Tamanho; i++)
    {
        ContaCorrente conta = listaDeContas.RecuperarContaNoIndice(i);
        Console.WriteLine($"Indice [{i}] = {conta.Conta} / {conta.Numero_agencia}");
    }
}

//TestarArrayDeContasCorrentesDaClasse();
#endregion

//AGORA FAREMOS UM SISTEMA INTERNO QUE PERMITA AO USUÁRIO CADASTRAR, LISTAR CLIENTES E FAZER OUTRAS FUNCIONALIDADES. É UM MENU INTERATIVO.
ArrayList listaDeContas = new ArrayList();
AtendimentoCliente();
void AtendimentoCliente()
{
    try
    {
        char opcao = '0';
        while (opcao != '6')
        {
            Console.WriteLine("===============================");
            Console.WriteLine("===       Atendimento       ===");
            Console.WriteLine("===1 - Cadastrar Conta      ===");
            Console.WriteLine("===2 - Listar Contas        ===");
            Console.WriteLine("===3 - Remover Conta        ===");
            Console.WriteLine("===4 - Ordenar Contas       ===");
            Console.WriteLine("===5 - Pesquisar Conta      ===");
            Console.WriteLine("===6 - Sair do Sistema      ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n\n");
            Console.Write("Digite a opção desejada: ");

            try
            {
                opcao = Console.ReadLine()[0];
            }
            catch (Exception excecao)
            {

                throw new ByteBankException(excecao.Message);
            }
            
            switch (opcao)
            {
                case '1':
                    CadastrarConta();
                    break;
                default:
                    Console.WriteLine("Opcao não implementada.");
                    break;
            }
        }
    }
    catch (ByteBankException excecao)
    {

        Console.WriteLine($"{excecao.Message}");
    }
            
}


    void CadastrarConta()
    {
        //Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("===   CADASTRO DE CONTAS    ===");
        Console.WriteLine("===============================");
        Console.WriteLine("\n");
        Console.WriteLine("=== Informe dados da conta ===");
        Console.Write("Número da conta: ");
        string numeroConta = Console.ReadLine();

        Console.Write("Número da Agência: ");
        int numeroAgencia = int.Parse(Console.ReadLine());

        ContaCorrente conta = new ContaCorrente(numeroAgencia, numeroConta);

        Console.Write("Informe o saldo inicial: ");
        conta.Saldo = double.Parse(Console.ReadLine());

        Console.Write("Infome nome do Titular: ");
        conta.Titular.Nome = Console.ReadLine();

        Console.Write("Infome CPF do Titular: ");
        conta.Titular.Cpf = Console.ReadLine();

        Console.Write("Infome Profissão do Titular: ");
        conta.Titular.Profissao = Console.ReadLine();

        _listaDeContas.Add(conta);
        Console.WriteLine("... Conta cadastrada com sucesso! ...");
        Console.ReadKey();
    }
