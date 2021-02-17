using System;
using System.Collections;
using System.Collections.Generic;

/*
 * Matheus Lacerda Bezerra
 * Codigo: 201633695
 * 
 * Custo do codigo é a profundida da arvore vezes sua frequencia
 * Matematicamente: O(N)
 */

namespace ArvoreBinaria {

    class Node {
        public Node esquerda { get; set; }
        public Node direita { get; set; }
        public int valor { get; set; }

        public Node(int val, Node esq, Node dir) {
            valor = val;
            esquerda = esq;
            direita = dir;
        }
    }

    class ArvoreBinaria {
        public Node raiz { get; set; }

        public void Inserir(int valor) {
            Node antes = null, depois = this.raiz;

            while (depois != null) {
                antes = depois;
                if (valor < depois.valor) {
                    depois = depois.esquerda;
                } else if (valor > depois.valor) {
                    depois = depois.direita;
                }
            }

            Node node = new Node(valor, null, null);

            if (raiz == null)
                raiz = node;
            else {
                if (valor < antes.valor)
                    antes.esquerda = node;
                else
                    antes.direita = node;
            }
        }

        public Node Procurar(int value) {
            return this.Procurar(value, this.raiz);
        }

        public void Remover(int value) {
            this.raiz = Remover(this.raiz, value);
        }

        private Node Remover(Node pai, int chave) {
            if (pai == null) return pai;

            if (chave < pai.valor) pai.esquerda = Remover(pai.esquerda, chave);
            else if (chave > pai.valor)
                pai.direita = Remover(pai.direita, chave);
            else {
                if (pai.esquerda == null)
                    return pai.direita;
                else if (pai.direita == null)
                    return pai.esquerda;

                pai.valor = Min(pai.direita);

                pai.direita = Remover(pai.direita, pai.valor);
            }

            return pai;
        }

        private int Min(Node node) {
            int minValor = node.valor;

            while (node.esquerda != null) {
                minValor = node.esquerda.valor;
                node = node.esquerda;
            }

            return minValor;
        }

        private Node Procurar(int value, Node parent) {
            if (parent != null) {
                if (value == parent.valor) return parent;
                if (value < parent.valor)
                    return Procurar(value, parent.esquerda);
                else
                    return Procurar(value, parent.direita);
            }

            return null;
        }

        public int Profundidade() {
            return this.Profundidade(this.raiz);
        }

        private int Profundidade(Node parent) {
            return parent == null ? 0 : Math.Max(Profundidade(parent.esquerda), Profundidade(parent.direita)) + 1;
        }

        public void preOrdem(Node parent) {
            if (parent != null) {
                Console.Write(parent.valor + " ");
                preOrdem(parent.esquerda);
                preOrdem(parent.direita);
            }
        }

        public void Ordem(Node parent) {
            if (parent != null) {
                Ordem(parent.esquerda);
                Console.Write(parent.valor + " ");
                Ordem(parent.direita);
            }
        }

        public void PosOrdem(Node parent) {
            if (parent != null) {
                PosOrdem(parent.esquerda);
                PosOrdem(parent.direita);
                Console.Write(parent.valor + " ");
            }
        }

        public static void Main(String[] args) {
            ArvoreBinaria arvoreBinaria = new ArvoreBinaria();

            arvoreBinaria.Inserir(5);
            arvoreBinaria.Inserir(2);
            arvoreBinaria.Inserir(8);
            arvoreBinaria.Inserir(4);
            arvoreBinaria.Inserir(9);
            arvoreBinaria.Inserir(1);
            arvoreBinaria.Inserir(6);
            arvoreBinaria.Inserir(3);
            arvoreBinaria.Inserir(7);
            arvoreBinaria.Inserir(0);
            arvoreBinaria.Inserir(3);

            Node node = arvoreBinaria.Procurar(5);
            int depth = arvoreBinaria.Profundidade();

            Console.WriteLine("PreOrdem: ");
            arvoreBinaria.preOrdem(arvoreBinaria.raiz);
            Console.WriteLine();

            Console.WriteLine("Ordem: ");
            arvoreBinaria.Ordem(arvoreBinaria.raiz);
            Console.WriteLine();

            Console.WriteLine("PosOrdem: ");
            arvoreBinaria.PosOrdem(arvoreBinaria.raiz);
            Console.WriteLine();

            Console.Read();
        }
    }
}