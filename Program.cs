using System;
using System.Collections.Generic;

namespace SistemaMetasFabrica
{
    class Program
    {
        static void Main(string[] args)
        {
            // Nossas coleções para guardar os dados na memória (Conceito que você acabou de aprender!)
            List<string> setores = new List<string>();
            List<int> metasPeccas = new List<int>();
            List<int> producaoAtual = new List<int>();

            bool rodando = true;

            while (rodando)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("   SISTEMA DE METAS - LINHA DE PRODUÇÃO ");
                Console.WriteLine("========================================");
                Console.WriteLine("1 - Cadastrar Nova Meta de Setor");
                Console.WriteLine("2 - Registrar Produção Atual");
                Console.WriteLine("3 - Ver Painel Geral (Dashboard)");
                Console.WriteLine("4 - Sair do Sistema");
                Console.WriteLine("========================================");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Clear();
                        Console.Write("Digite o nome do Setor: ");
                        string setor = Console.ReadLine();
                        Console.Write($"Digite a meta de peças para o {setor}: ");
                        int meta = int.Parse(Console.ReadLine());

                        // Salvando os dados nas listas
                        setores.Add(setor);
                        metasPeccas.Add(meta);
                        producaoAtual.Add(0); // Começa com zero peças produzidas

                        Console.WriteLine("\nMeta cadastrada com sucesso!");
                        Console.ReadKey();
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("--- REGISTRAR PRODUÇÃO ---");
                        if (setores.Count == 0)
                        {
                            Console.WriteLine("Nenhum setor cadastrado ainda.");
                            Console.ReadKey();
                            break;
                        }

                        // Listando os setores na tela
                        for (int i = 0; i < setores.Count; i++)
                        {
                            Console.WriteLine($"{i} - {setores[i]}");
                        }
                        Console.Write("Escolha o número do setor: ");
                        int indiceSetor = int.Parse(Console.ReadLine());

                        // PRONTO! Esse IF checa se a gaveta existe antes de mexer nela
                        if (indiceSetor >= 0 && indiceSetor < setores.Count)
                        {
                            Console.Write("Digite a quantidade de peças produzidas agora: ");
                            int quantidade = int.Parse(Console.ReadLine());

                            // Só mexe na memória se o número for seguro
                            producaoAtual[indiceSetor] += quantidade;
                            Console.WriteLine("\nProdução atualizada com sucesso!");
                        }
                        else
                        {
                            // Se digitar um número errado (tipo 1 ou 5), cai aqui e não trava!
                            Console.WriteLine("\n❌ Erro: Esse número de setor não existe!");
                        }

                        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("==================================================");
                        Console.WriteLine("           PAINEL GERAL DE PRODUÇÃO               ");
                        Console.WriteLine("==================================================");

                        if (setores.Count == 0)
                        {
                            Console.WriteLine("Nenhuma meta ativa no momento.");
                        }

                        for (int i = 0; i < setores.Count; i++)
                        {
                            int metaDoSetor = metasPeccas[i];
                            int produzido = producaoAtual[i];

                            // Calculando a porcentagem de conclusão da meta
                            double porcentagem = ((double)produzido / metaDoSetor) * 180;
                            // Correção rápida na lógica da porcentagem (regra de 3 simples):
                            double porcentagemReal = ((double)produzido / metaDoSetor) * 100;

                            Console.WriteLine($"Setor: {setores[i]}");
                            Console.WriteLine($"Meta: {metaDoSetor} pçs | Produzido: {produzido} pçs");
                            Console.WriteLine($"Progresso: {porcentagemReal:F1}% concluído");

                            if (produzido >= metaDoSetor)
                            {
                                Console.WriteLine("🏆 META ATINGIDA! PARABÉNS À EQUIPE!");
                            }
                            Console.WriteLine("--------------------------------------------------");
                        }

                        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                        Console.ReadKey();
                        break;

                    case "4":
                        rodando = false;
                        Console.WriteLine("Saindo do sistema... Até o próximo turno!");
                        break;

                    default:
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
