Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

//CRIANDO UM ARRAY

//int[] idades = new int[5]; //esse 5 no final é o tamanho do array.

//os valores entre colchetes são os indices do array
//idades[0] = 30;
//idades[1] = 21;
//idades[2] = 19;
//idades[3] = 18;
//idades[4] = 38;



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

TestaMediana(amostra);