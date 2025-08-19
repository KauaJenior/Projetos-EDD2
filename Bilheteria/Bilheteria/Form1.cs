using System.Drawing.Text;

namespace Bilheteria
{
    public partial class Bilheteria : Form
    {
        private Label TelaLabel;
        private Label legendaLabel;
        private CheckBox[] Poltronas;
        private HashSet<int> AssentoComprado = new HashSet<int>(); // assentos já comprados
        private HashSet<int> AssentosSelecionados = new HashSet<int>();

        private Button btnMapaOcupacao;
        private Button btnReservar;
        private Button btnFinalizar;
        private Button btnComprar;
        private Button btn_ocupacaonovo;
        private Button btn_faturamentoNovo;

        public Bilheteria()
        {
            InitializeComponent();
            InitializePoltronas();
            AtualizarPoltronas(false, AssentoComprado);
            CriarLegenda();
        }

        // Cria as poltronas só uma vez
        private void InitializePoltronas()
        {
            if (Poltronas != null) return;

            Poltronas = new CheckBox[600];
            int totalFileiras = 15, totalPorFileira = 40;
            int espacamentoHorizontal = 25, espacamentoVertical = 25;
            int margemEsquerda = 50, margemTopo = 80;

            for (int i = 0; i < totalFileiras; i++)
            {
                for (int j = 0; j < totalPorFileira; j++)
                {
                    int index = i * totalPorFileira + j;

                    var cb = new CheckBox
                    {
                        Parent = this,
                        Appearance = Appearance.Button,
                        Text = "",
                        Width = 20,
                        Height = 20,
                        Top = margemTopo + (i * espacamentoVertical),
                        Left = margemEsquerda + (j * espacamentoHorizontal),
                        Tag = new { Fileira = i + 1, Poltrona = j + 1, Id = index }
                    };

                    // clique na poltrona → seleciona/deseleciona
                    cb.CheckedChanged += Poltrona_CheckedChanged;

                    Poltronas[index] = cb;
                    this.Controls.Add(cb);
                }
            }

            if (TelaLabel == null)
            {
                TelaLabel = new Label
                {
                    Text = "TELA",
                    Font = new Font("Arial", 16, FontStyle.Bold),
                    AutoSize = true,
                    Top = 20,
                    Left = (this.ClientSize.Width - 50) / 2 // ajuste simples
                };
                this.Controls.Add(TelaLabel);
            }
        }

        // Marca e desmarca poltronas
        private void Poltrona_CheckedChanged(object sender, EventArgs e)
        {
            var cb = sender as CheckBox;
            int id = ((dynamic)cb.Tag).Id;

            if (cb.Checked)
                AssentosSelecionados.Add(id);
            else
                AssentosSelecionados.Remove(id);

            AtualizarPoltronas(true, AssentoComprado);

            // habilita botão de compra apenas se tiver seleção
            btnComprar.Enabled = AssentosSelecionados.Count > 0;
        }

        private void InitializeBotao()
        {
            if (btnComprar == null)
            {
                btnComprar = new Button
                {
                    Text = "Finalizar Compra",
                    Width = 135,
                    Height = 35,
                    Top = 482,
                    Left = 50,
                    Enabled = false
                };

                btnComprar.Click += (sender, e) =>
                {
                    reservarPoltronas(sender, e);
                    btnComprar.Enabled = false;
                    btn_faturamento.Enabled = true;
                    btn_ocupacao.Enabled = true;
                };

                this.Controls.Add(btnComprar);
            }
        }

        private void CriarLegenda()
        {
            CheckBox livre = new CheckBox
            {
                Text = "Livre",
                Enabled = false,
                BackColor = Color.LightGreen,
                ForeColor = Color.Black,
                AutoSize = true,
                Appearance = Appearance.Button
            };

            CheckBox reservado = new CheckBox
            {
                Text = "Reservado",
                Enabled = false,
                BackColor = Color.Red,
                ForeColor = Color.LightGray,
                AutoSize = true,
                Appearance = Appearance.Button
            };

            FlowLayoutPanel painelLegenda = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                AutoSize = true
            };

            painelLegenda.Controls.Add(livre);
            painelLegenda.Controls.Add(reservado);

            this.Controls.Add(painelLegenda);
        }

        // Atualiza estados (sem recriar)
        private void AtualizarPoltronas(bool permitirReserva, HashSet<int> comprados)
        {
            if (Poltronas == null) return;

            for (int index = 0; index < Poltronas.Length; index++)
            {
                var p = Poltronas[index];

                if (comprados.Contains(index))
                {
                    p.BackColor = Color.Red;     // comprado
                    p.Enabled = false;
                    p.Checked = true;
                }
                else
                {
                    bool selecionada = AssentosSelecionados.Contains(index);
                    p.BackColor = selecionada ? Color.Khaki : Color.LightGreen;
                    p.Enabled = permitirReserva;
                    p.Checked = selecionada;
                }
            }
        }

        private void reservarPoltronas(object sender, EventArgs e)
        {
            if (AssentosSelecionados.Count == 0)
            {
                MessageBox.Show("Nenhuma poltrona foi selecionada neste pedido.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // preços por faixa
            double PrecoVip = 50.0, PrecoOuro = 30.0, PrecoPrata = 15.0;
            int vip = 0, ouro = 0, prata = 0;

            List<string> assentosEscolhidos = new List<string>();

            // calcula o pedido atual
            foreach (int idx in AssentosSelecionados)
            {
                var dados = (dynamic)Poltronas[idx].Tag;
                int fileira = dados.Fileira;
                int numero = dados.Poltrona;

                assentosEscolhidos.Add($"{fileira}-{numero}");

                if (fileira >= 1 && fileira <= 4) vip++;
                else if (fileira >= 5 && fileira <= 10) ouro++;
                else if (fileira >= 11 && fileira <= 15) prata++;
            }

            double totalPedido = vip * PrecoVip + ouro * PrecoOuro + prata * PrecoPrata;

            // mostra resumo do pedido
            MessageBox.Show($"Pedido concluído!\n\n" +
                            $"VIP: {vip} (R$ {vip * PrecoVip:F2})\n" +
                            $"Ouro: {ouro} (R$ {ouro * PrecoOuro:F2})\n" +
                            $"Prata: {prata} (R$ {prata * PrecoPrata:F2})\n\n" +
                            $"Assentos selecionados: {string.Join(", ", assentosEscolhidos)}\n\n" +
                            $"Total do pedido: R$ {totalPedido:F2}",
                            "Resumo do Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // confirma compra: move os selecionados para “comprados”
            foreach (int idx in AssentosSelecionados)
            {
                AssentoComprado.Add(idx);
                var cb = Poltronas[idx];
                cb.BackColor = Color.Red;
                cb.Enabled = false;
                cb.Checked = true;
            }

            AssentosSelecionados.Clear();

            // volta para visualização
            AtualizarPoltronas(false, AssentoComprado);
        }

        private void btn_ocupacao_Click(object sender, EventArgs e)
        {
            AtualizarPoltronas(false, AssentoComprado);
        }

        private void btn_Poltrona_Click(object sender, EventArgs e)
        {
            AtualizarPoltronas(true, AssentoComprado);
            InitializeBotao();
            AssentosSelecionados.Clear();
            btnComprar.Enabled = false;
            btn_ocupacao.Enabled = false;
        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private double CalcularFaturamento()
        {
            int vip = 0, ouro = 0, prata = 0;
            double PrecoVip = 50.0, PrecoOuro = 30.0, PrecoPrata = 15.0;

            foreach (int index in AssentoComprado)
            {
                int fileira = ((dynamic)Poltronas[index].Tag).Fileira;

                if (fileira >= 1 && fileira <= 4) vip++;
                else if (fileira >= 5 && fileira <= 10) ouro++;
                else if (fileira >= 11 && fileira <= 15) prata++;
            }

            return vip * PrecoVip + ouro * PrecoOuro + prata * PrecoPrata;
        }

        private void btn_faturamento_Click(object sender, EventArgs e)
        {
            int qtdeOcupados = AssentoComprado.Count;
            double valorBilheteria = CalcularFaturamento();

            MessageBox.Show(
                $"Qtde de lugares ocupados: {qtdeOcupados}\n" +
                $"Valor da bilheteria: R$ {valorBilheteria:F2}",
                "Faturamento",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            AtualizarPoltronas(false, AssentoComprado);
        }
    }
}
