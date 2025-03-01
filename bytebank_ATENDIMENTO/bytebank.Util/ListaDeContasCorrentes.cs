using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bytebank.Modelos.Conta;

namespace bytebank_ATENDIMENTO.bytebank.Util
{
    //O OBEJTIVO AQUI É ENCAPSULAR O COMPORTAMENTO DO ARRAY DE OBJETOS
    public class ListaDeContasCorrentes
    {
        private ContaCorrente[] _itens = null;
        private int _proximaPosicao = 0;

        //vai começar com o tamanho inicial de 5.
        public ListaDeContasCorrentes(int tamanhoInicial = 5)
        {
            _itens = new ContaCorrente[tamanhoInicial];
        }

        public void Adicionar(ContaCorrente item)
        {
            Console.WriteLine($"Adicionando item na posição {_proximaPosicao}");
            VerificarCapacidade(_proximaPosicao + 1);
            _itens[_proximaPosicao] = item;
            _proximaPosicao++;
        }

        private void VerificarCapacidade(int tamanhoNecessario)
        {
            if (_itens.Length >= tamanhoNecessario)
            {
                return;
            }
            Console.WriteLine("Aumentando a capacidade da lista");
            ContaCorrente[] novoArray = new ContaCorrente[tamanhoNecessario];

            for (int i = 0; i < _itens.Length; i++)
            {
                //adiciona-se nos indices do novoarray, os indices do array antigo
                novoArray[i] = _itens[i];
            }

            _itens = novoArray;
        
        }

        //METODO DE REMOVER
        public void Remover (ContaCorrente conta)
        {
            int indiceItem = -1;
            for (int i = 0; i < _proximaPosicao; i++)
            {
                ContaCorrente contaAtual = _itens[i];
                if (contaAtual == conta)
                {
                    indiceItem = i;
                    break;
                }
            }

            for(int i = indiceItem;  i < _proximaPosicao; ++i)
            {
                _itens[i] = _itens[i + 1];
            }
            _proximaPosicao--;
            _itens[_proximaPosicao] = null;
        }

        public void ExibeLista()
        {
            for (int i = 0; i < _itens.Length; i++)
            {
                if (_itens[i] != null)
                {
                    var conta = _itens[i];
                    Console.WriteLine($"Indice[{i}] = " + $"Conta:{conta.Conta} - " + $"Nº da Agência: {conta.Numero_agencia}");
                }
            }
        }
        public ContaCorrente RetornarContaComMaiorSaldo()
        {
            //conta é uma variável do tipo conta corrente que armazenará a conta com maior saldo
            //inicializamos com null pois ainda não sabemos qual conta possui o maior saldo, ou seja, isso indica que até o momento nenhuma conta foi encontrada.
            ContaCorrente conta = null; 

            double maiorValor = 0;
            for (int i = 0; i< _itens.Length; i++)
            {
                //se o indice não for nulo? ou seja, se tiver algo lá?
                //o deepseek falou que é exatamente isso.
                //Isso é importante para evitar erros de referência nula ao tentar acessar propriedades de um objeto nulo.
                if (_itens[i] != null)
                {

                    //verifica se o saldo da conta atual é maior que o valor armazenado na variavel maiorValor.
                    if (maiorValor < _itens[i].Saldo)
                    {
                        //se for, o saldo desta conta fica armazenado na variavel maiorvalor. Além disso, armazena a conta atual na variável conta.
                        maiorValor = _itens[i].Saldo;
                        conta = _itens[i];
                    }
                }
            }

            return conta;
        }

        public ContaCorrente RecuperarContaNoIndice(int indice)
        {
            if(indice < 0 || indice >= _proximaPosicao)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }

            return _itens[indice];
        }

        public int Tamanho
        {
            get
            {
                return _proximaPosicao;
            }
        }

        public ContaCorrente this[int indice]
        {
            get
            {
                return RecuperarContaNoIndice(indice);
            }
        }
    }
}
