using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

namespace Chess
{
    public class ChessForm : System.Windows.Forms.Form
    {
        #region Variáveis globais
        private PictureBox[,] pb;
        Label label1;
        Label label2;
        Label label3;
        Label label4;
        Label label5;
        Label label6;
        Label label7;
        Label label8;
        Label labela;
        Label labelb;
        Label labelc;
        Label labeld;
        Label labele;
        Label labelf;
        Label labelg;
        Label labelh;
        Button btn;
        private int[] posicoes = new int[8];
        private Board brd;
        private Image img1;
        private Image img2;
        private static DateTime tempo;
        private static Queue<int[]>[] passos;
        private static Item[] estados;
        int indice_solucao = -1;
        private static int p = 10;
        #endregion

        //Construtor do programa
        public ChessForm()
        {
            Inicializa_Tabuleiro();
            Inicializa_Jogo();
        }

        [STAThread]
        static void Main()
        {
            Application.Run(new ChessForm());
        }        

        //Constroi o tabuleiro
        public void Inicializa_Tabuleiro()
        {
            pb = new PictureBox[8, 8];
            brd = new Board();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    pb[i, j] = new PictureBox();
                    if (brd.getFundoImagem(i, j) == 2)
                    {
                        this.pb[i, j].BackColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        this.pb[i, j].BackColor = System.Drawing.Color.Silver;
                    }
                    this.pb[i, j].Location = new System.Drawing.Point(30 + i * 60, 10 + j * 60);
                    this.pb[i, j].Name = "pb1";
                    this.pb[i, j].Size = new System.Drawing.Size(60, 60);
                    this.pb[i, j].TabIndex = i;
                    this.pb[i, j].TabStop = false;
                    this.Controls.AddRange(new System.Windows.Forms.Control[] { this.pb[i, j] });
                }
            }

            label1 = new Label();
            this.label1.Location = new System.Drawing.Point(10, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 20);
            this.label1.TabIndex = 65;
            this.label1.TabStop = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
            label1.Text = "1";
            this.Controls.AddRange(new Control[] { this.label1 });

            label2 = new Label();
            this.label2.Location = new System.Drawing.Point(10, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 20);
            this.label2.TabIndex = 65;
            this.label2.TabStop = false;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
            label2.Text = "2";
            this.Controls.AddRange(new Control[] { this.label2 });

            label3 = new Label();
            this.label3.Location = new System.Drawing.Point(10, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 20);
            this.label3.TabIndex = 65;
            this.label3.TabStop = false;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
            label3.Text = "3";
            this.Controls.AddRange(new Control[] { this.label3 });

            label4 = new Label();
            this.label4.Location = new System.Drawing.Point(10, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 20);
            this.label4.TabIndex = 65;
            this.label4.TabStop = false;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
            label4.Text = "4";
            this.Controls.AddRange(new Control[] { this.label4 });

            label5 = new Label();
            this.label5.Location = new System.Drawing.Point(10, 270);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 20);
            this.label5.TabIndex = 65;
            this.label5.TabStop = false;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
            label5.Text = "5";
            this.Controls.AddRange(new Control[] { this.label5 });

            label6 = new Label();
            this.label6.Location = new System.Drawing.Point(10, 330);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 20);
            this.label6.TabIndex = 65;
            this.label6.TabStop = false;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
            label6.Text = "6";
            this.Controls.AddRange(new Control[] { this.label6 });

            label7 = new Label();
            this.label7.Location = new System.Drawing.Point(10, 390);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 20);
            this.label7.TabIndex = 65;
            this.label7.TabStop = false;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
            label7.Text = "7";
            this.Controls.AddRange(new Control[] { this.label7 });

            label8 = new Label();
            this.label8.Location = new System.Drawing.Point(10, 450);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 20);
            this.label8.TabIndex = 65;
            this.label8.TabStop = false;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
            label8.Text = "8";
            this.Controls.AddRange(new Control[] { this.label8 });

            labelh = new Label();
            this.labelh.Location = new System.Drawing.Point(50, 490);
            this.labelh.Name = "labelh";
            this.labelh.Size = new System.Drawing.Size(20, 20);
            this.labelh.TabIndex = 65;
            this.labelh.TabStop = false;
            this.labelh.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
            labelh.Text = "h";
            this.Controls.AddRange(new Control[] { this.labelh });

            labelg = new Label();
            this.labelg.Location = new System.Drawing.Point(110, 490);
            this.labelg.Name = "labelg";
            this.labelg.Size = new System.Drawing.Size(20, 30);
            this.labelg.TabIndex = 65;
            this.labelg.TabStop = false;
            this.labelg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
            labelg.Text = "g";
            this.Controls.AddRange(new Control[] { this.labelg });

            labelf = new Label();
            this.labelf.Location = new System.Drawing.Point(175, 490);
            this.labelf.Name = "labelf";
            this.labelf.Size = new System.Drawing.Size(20, 20);
            this.labelf.TabIndex = 65;
            this.labelf.TabStop = false;
            this.labelf.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
            labelf.Text = "f";
            this.Controls.AddRange(new Control[] { this.labelf });

            labele = new Label();
            this.labele.Location = new System.Drawing.Point(230, 490);
            this.labele.Name = "labele";
            this.labele.Size = new System.Drawing.Size(20, 20);
            this.labele.TabIndex = 65;
            this.labele.TabStop = false;
            this.labele.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
            labele.Text = "e";
            this.Controls.AddRange(new Control[] { this.labele });

            labeld = new Label();
            this.labeld.Location = new System.Drawing.Point(290, 490);
            this.labeld.Name = "labeld";
            this.labeld.Size = new System.Drawing.Size(20, 20);
            this.labeld.TabIndex = 65;
            this.labeld.TabStop = false;
            this.labeld.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
            labeld.Text = "d";
            this.Controls.AddRange(new Control[] { this.labeld });

            labelc = new Label();
            this.labelc.Location = new System.Drawing.Point(350, 490);
            this.labelc.Name = "labelc";
            this.labelc.Size = new System.Drawing.Size(20, 20);
            this.labelc.TabIndex = 65;
            this.labelc.TabStop = false;
            this.labelc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
            labelc.Text = "c";
            this.Controls.AddRange(new Control[] { this.labelc });

            labelb = new Label();
            this.labelb.Location = new System.Drawing.Point(410, 490);
            this.labelb.Name = "labelb";
            this.labelb.Size = new System.Drawing.Size(20, 20);
            this.labelb.TabIndex = 65;
            this.labelb.TabStop = false;
            this.labelb.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
            labelb.Text = "b";
            this.Controls.AddRange(new Control[] { this.labelb });

            labela = new Label();
            this.labela.Location = new System.Drawing.Point(470, 490);
            this.labela.Name = "labela";
            this.labela.Size = new System.Drawing.Size(20, 20);
            this.labela.TabIndex = 65;
            this.labela.TabStop = false;
            this.labela.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
            labela.Text = "a";
            this.Controls.AddRange(new Control[] { this.labela });

            btn = new Button();
            this.btn.Location = new System.Drawing.Point(160, 520);
            this.btn.Name = "buscar";
            this.btn.Click += new EventHandler(this.Resolver);
            this.btn.Size = new System.Drawing.Size(200, 30);
            this.btn.TabIndex = 65;
            this.btn.TabStop = false;
            this.btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
            this.btn.Text = "Resolver";
            this.Controls.AddRange(new Control[] { this.btn });

            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(550, 550);
            this.Name = "8-Rainhas";
            this.Text = "8-Rainhas";

            img1 = Image.FromFile("pic/rainha_b.jpg");
            img2 = Image.FromFile("pic/rainha_c.jpg");
        }

        //Inicializa os estados iniciais
        public void Inicializa_Jogo()
        {
            passos = Inicializa_Passos();
            estados = new Item[p];
            estados = Gerar_Estados(estados);
            estados = Calculos(estados);
            estados = Ordena(estados);
        }

        //Metodo chamado pelo botão "Resolver"
        private void Resolver(Object sender, EventArgs e)
        {
            Button tb = (Button)sender;
            int cont = 0;
            int[] inicial = new int[8];
            if (tb.Text == "Resolver")
            {
                tempo = DateTime.Now;
                Boolean solucao = false;
                do
                {
                    for (int i = 0; i < p; i++)
                    {
                        if (estados[i].h == 56)
                        {
                            solucao = true;
                            inicial = estados[i].estado;
                            indice_solucao = i;
                        }
                    }
                    if (!solucao)
                    {
                        Processar();
                    }
                    cont++;
                } while (!solucao && (DateTime.Now - tempo).TotalSeconds < 40);

                if ((DateTime.Now - tempo).TotalSeconds < 20)
                {
                    if (MessageBox.Show("Solução não encontrada em " + (DateTime.Now - tempo).TotalSeconds + " segundos.", "8-rainhas", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        Application.Exit();
                    }
                }
                else if (solucao && cont == 1)
                {
                    if (MessageBox.Show("Um dos estado iniciais é a solução. Confira no tabuleiro.", "8-rainhas", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        Configura_Estado(inicial);
                    }
                }
                else if (solucao)
                {
                    MessageBox.Show("Solução encontrada em " + (DateTime.Now - tempo).TotalSeconds + " segundos.");
                    tb.Text = "Próximo";
                }
            }
            else
            {
                int[] item = passos[indice_solucao].Dequeue();

                Configura_Estado(item);
                if (passos[indice_solucao].Count == 0)
                {
                    tb.Visible = false;
                }
            }
        }

        //Usado para definir as cores do tabuleiro
        public Image getFundoImagem(int i, int j)
        {
            if ((i + j) % 2 == 0)
            {
                return img1;
            }
            else
            {
                return img2;
            }
        }

        //Limpa tabuleiro
        private void Clear()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    pb[i, j].Image = null;
                }
            }
        }

        //Controle do tabuleiro paara exibir as imagens das peças
        private void Configura_Estado(int[] item)
        {
            Clear();
            for (int i = 0; i < 8; i++)
            {
                pb[i, item[i]].Image = getFundoImagem(item[i], i);
            }
        }

        //Soma todos os h's
        public int Total_Porcentagem(Item[] itens)
        {
            int total_porcentagem = 0;
            for (int i = 0; i < p; i++)//Soma todos h
            {
                total_porcentagem += itens[i].h;
            }
            return total_porcentagem;
        }

        //Calcula a porcentagem
        public Item[] Porcentagem(Item[] itens, int total)
        {
            for (int i = 0; i < p; i++)//Soma todos h
            {
                itens[i].porcentagem = (((double)itens[i].h / (double)total) * 100.00);
            }
            return itens;
        }

        //Inicializa a variável de controle para a exibição dos passos
        public Queue<int[]>[] Inicializa_Passos()
        {
            Queue<int[]>[] passos = new Queue<int[]>[p];
            for (int i = 0; i < p; i++)
            {
                passos[i] = new Queue<int[]>();
            }
            return passos;
        }

        //Após um conjunto de 4 estados ser verificado, cria outros 4
        public void Processar()
        {
            estados = CrossOver(estados);
            estados = Mutacao(estados);
            estados = Calculos(estados);
            estados = Ordena(estados);
        }

        //Metodo que faz o Cross-over
        public Item[] CrossOver(Item[] itens)
        {
            Item[] novos = Novos_Estados();
            Random rnd = new Random();
            int ponto1 = rnd.Next(1, 7);
            int ponto2 = rnd.Next(1, 7);
            //Primeiro estado
            Array.Copy(estados[0].estado, 0, novos[0].estado, 0, ponto1);
            Array.Copy(estados[1].estado, ponto1+1, novos[0].estado, ponto1+1, 7-ponto1);
            //Segundo estado
            Array.Copy(estados[1].estado, 0, novos[1].estado, 0, ponto1);
            Array.Copy(estados[0].estado, ponto1+1, novos[1].estado, ponto1+1, 7-ponto1);
            //Teceiro estado
            Array.Copy(estados[2].estado, 0, novos[2].estado, 0, ponto2);
            Array.Copy(estados[3].estado, ponto2+1, novos[2].estado, ponto2, 7-ponto2);
            //Quarto estado
            Array.Copy(estados[3].estado, 0, novos[3].estado, 0, ponto2);
            Array.Copy(estados[2].estado, ponto2+1, novos[3].estado, ponto2+1, 7-ponto2);

            return novos;
        }

        //Aplica a mutacao em posicoes aleatorias
        public Item[] Mutacao(Item[] itens)
        {
            Random rnd = new Random();
            for (int i = 0; i < p; i++)
            {
                int n_1 = rnd.Next(0, 8);
                int n_2 = rnd.Next(0, 8);
                itens[i].estado[n_1] = n_2;
            }
            return itens;
        }

        //Em relação a porcentagem
        public Item[] Ordena(Item[] itens)
        {
            int i, j;
            Item atual;
            for (i = 1; i < itens.Length; i++)
            {
                atual = itens[i];
                j = i;
                while ((j > 0) && (itens[j - 1].porcentagem > atual.porcentagem))
                {
                    itens[j] = itens[j - 1];
                    j = j - 1;
                }
                itens[j] = atual;
            }
            return itens;
        }

        //Gerador de novos estados vazios
        public Item[] Novos_Estados()
        {
            Item[] novo = new Item[p];
            for (int i = 0; i < p; i++)
            {
                novo[i] = new Item();
            }
            return novo;
        }

        //Gerador de novos estados
        public Item[] Gerar_Estados(Item[] itens)
        {
            Random rnd = new Random();
            for (int i = 0; i < p; i++)
            {
                itens[i] = new Item() ;
                for (int j = 0; j < 8; j++)
                {
                    itens[i].estado[j] = rnd.Next(0, 8);
                }
                itens[i].h = Heuristica(itens[i].estado);
            }
            return itens;
        }

        //Soma todos o h's e calcula a porcentagem
        private Item[] Calculos(Item[] itens)
        {
            for (int i = 0; i < p; i++)
            {
                 itens[i].h = Heuristica(itens[i].estado);
            }

            int total = Total_Porcentagem(itens);
            itens = Porcentagem(estados, total);
            return itens;
        }

        //Dado um estado verifica o valor da heurística
        private int Heuristica(int[] item)
        {
            int valor_heuristica = 0;
            for (int i = 0; i < 8; i++)//Seleciona cada peça
            {
                int peca = item[i];
                int diagonal_1 = i + peca;
                int diagonal_2 = peca - i;
                for (int j = 0; j < 8; j++)//Percorre o tabuleiro
                {
                    if (i != j)//Checagem de restrição para não pegar peça igual
                    {
                        int verificar = item[j];
                        int verificar_diagonal_1 = j + verificar;
                        int verificar_diagonal_2 = verificar - j;
                        valor_heuristica += (peca == verificar) ? 1 : 0;
                        valor_heuristica += (diagonal_1 == verificar_diagonal_1) ? 1 : 0;
                        valor_heuristica += (diagonal_2 == verificar_diagonal_2) ? 1 : 0;
                    }
                }
            }
            int h = valor_heuristica / 2;
            h = 56 - h;
            return h;
        }
    }

}