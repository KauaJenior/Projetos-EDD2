namespace Bilheteria
{
    partial class Bilheteria
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_faturamento = new Button();
            btn_finalizar = new Button();
            btn_ocupacao = new Button();
            btn_Reservar = new Button();
            SuspendLayout();
            // 
            // btn_faturamento
            // 
            btn_faturamento.Location = new Point(308, 482);
            btn_faturamento.Name = "btn_faturamento";
            btn_faturamento.Size = new Size(135, 35);
            btn_faturamento.TabIndex = 0;
            btn_faturamento.Text = "Faturamento";
            btn_faturamento.UseVisualStyleBackColor = true;
            btn_faturamento.Click += btn_faturamento_Click;
            // 
            // btn_finalizar
            // 
            btn_finalizar.Location = new Point(912, 482);
            btn_finalizar.Name = "btn_finalizar";
            btn_finalizar.Size = new Size(135, 35);
            btn_finalizar.TabIndex = 1;
            btn_finalizar.Text = "Finalizar";
            btn_finalizar.UseVisualStyleBackColor = true;
            btn_finalizar.Click += btn_finalizar_Click;
            // 
            // btn_ocupacao
            // 
            btn_ocupacao.Location = new Point(449, 482);
            btn_ocupacao.Name = "btn_ocupacao";
            btn_ocupacao.Size = new Size(135, 35);
            btn_ocupacao.TabIndex = 2;
            btn_ocupacao.Text = "Mapa Ocupação";
            btn_ocupacao.UseVisualStyleBackColor = true;
            btn_ocupacao.Click += btn_ocupacao_Click;
            // 
            // btn_Reservar
            // 
            btn_Reservar.Location = new Point(590, 482);
            btn_Reservar.Name = "btn_Reservar";
            btn_Reservar.Size = new Size(135, 35);
            btn_Reservar.TabIndex = 3;
            btn_Reservar.Text = "Reservar Poltrona";
            btn_Reservar.UseVisualStyleBackColor = true;
            btn_Reservar.Click += btn_Poltrona_Click;
            // 
            // Bilheteria
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1059, 571);
            Controls.Add(btn_Reservar);
            Controls.Add(btn_ocupacao);
            Controls.Add(btn_finalizar);
            Controls.Add(btn_faturamento);
            Name = "Bilheteria";
            Text = "Bilheteria";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_faturamento;
        private Button btn_finalizar;
        private Button btn_ocupacao;
        private Button btn_Reservar;
    }
}
