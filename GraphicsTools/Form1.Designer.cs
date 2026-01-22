namespace GraphicsTools
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new System.Windows.Forms.GroupBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            pbImage = new System.Windows.Forms.PictureBox();
            groupBox3 = new System.Windows.Forms.GroupBox();
            label1 = new System.Windows.Forms.Label();
            txtBHex = new System.Windows.Forms.TextBox();
            txtGHex = new System.Windows.Forms.TextBox();
            txtRHex = new System.Windows.Forms.TextBox();
            txtHTML = new System.Windows.Forms.TextBox();
            labelRGB = new System.Windows.Forms.Label();
            LabelB = new System.Windows.Forms.Label();
            LabelG = new System.Windows.Forms.Label();
            LabelR = new System.Windows.Forms.Label();
            hsB = new System.Windows.Forms.HScrollBar();
            hsG = new System.Windows.Forms.HScrollBar();
            hsR = new System.Windows.Forms.HScrollBar();
            lblFile = new System.Windows.Forms.Label();
            groupBox4 = new System.Windows.Forms.GroupBox();
            btnSalvarBIN = new System.Windows.Forms.Button();
            btnSalvarBMP = new System.Windows.Forms.Button();
            lblCantidadColores = new System.Windows.Forms.Label();
            label257 = new System.Windows.Forms.Label();
            btnSalvarTIM = new System.Windows.Forms.Button();
            cmdAbrir = new System.Windows.Forms.Button();
            btnInsertarISO = new System.Windows.Forms.Button();
            txtOffset = new System.Windows.Forms.TextBox();
            lblOffset = new System.Windows.Forms.Label();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbImage).BeginInit();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Location = new System.Drawing.Point(15, 367);
            groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Size = new System.Drawing.Size(630, 145);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Colores";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(pbImage);
            groupBox2.Location = new System.Drawing.Point(15, 14);
            groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox2.Size = new System.Drawing.Size(630, 346);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Imagen";
            // 
            // pbImage
            // 
            pbImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pbImage.Location = new System.Drawing.Point(13, 27);
            pbImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pbImage.Name = "pbImage";
            pbImage.Size = new System.Drawing.Size(597, 295);
            pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pbImage.TabIndex = 0;
            pbImage.TabStop = false;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(txtBHex);
            groupBox3.Controls.Add(txtGHex);
            groupBox3.Controls.Add(txtRHex);
            groupBox3.Controls.Add(txtHTML);
            groupBox3.Controls.Add(labelRGB);
            groupBox3.Controls.Add(LabelB);
            groupBox3.Controls.Add(LabelG);
            groupBox3.Controls.Add(LabelR);
            groupBox3.Controls.Add(hsB);
            groupBox3.Controls.Add(hsG);
            groupBox3.Controls.Add(hsR);
            groupBox3.Enabled = false;
            groupBox3.Location = new System.Drawing.Point(15, 519);
            groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox3.Size = new System.Drawing.Size(504, 135);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Cambiar color";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(390, 98);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(29, 15);
            label1.TabIndex = 11;
            label1.Text = "HEX";
            // 
            // txtBHex
            // 
            txtBHex.Location = new System.Drawing.Point(341, 93);
            txtBHex.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtBHex.MaxLength = 3;
            txtBHex.Name = "txtBHex";
            txtBHex.Size = new System.Drawing.Size(38, 23);
            txtBHex.TabIndex = 10;
            txtBHex.Text = "000";
            txtBHex.TextChanged += txtBHex_TextChanged;
            txtBHex.KeyDown += txtBHex_KeyDown;
            txtBHex.KeyPress += txtBHex_KeyPress;
            // 
            // txtGHex
            // 
            txtGHex.Location = new System.Drawing.Point(341, 58);
            txtGHex.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtGHex.MaxLength = 3;
            txtGHex.Name = "txtGHex";
            txtGHex.Size = new System.Drawing.Size(38, 23);
            txtGHex.TabIndex = 9;
            txtGHex.Text = "000";
            txtGHex.TextChanged += txtGHex_TextChanged;
            txtGHex.KeyDown += txtGHex_KeyDown;
            txtGHex.KeyPress += txtGHex_KeyPress;
            // 
            // txtRHex
            // 
            txtRHex.Location = new System.Drawing.Point(341, 27);
            txtRHex.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtRHex.MaxLength = 3;
            txtRHex.Name = "txtRHex";
            txtRHex.Size = new System.Drawing.Size(38, 23);
            txtRHex.TabIndex = 8;
            txtRHex.Text = "000";
            txtRHex.TextChanged += txtRHex_TextChanged;
            txtRHex.KeyDown += txtRHex_KeyDown;
            txtRHex.KeyPress += txtRHex_KeyPress;
            // 
            // txtHTML
            // 
            txtHTML.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtHTML.Location = new System.Drawing.Point(430, 93);
            txtHTML.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtHTML.MaxLength = 6;
            txtHTML.Name = "txtHTML";
            txtHTML.Size = new System.Drawing.Size(60, 23);
            txtHTML.TabIndex = 7;
            txtHTML.Text = "000000";
            txtHTML.KeyDown += txtHTML_KeyDown;
            txtHTML.KeyPress += txtHTML_KeyPress;
            txtHTML.Validated += txtHTML_Validated;
            // 
            // labelRGB
            // 
            labelRGB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            labelRGB.Location = new System.Drawing.Point(386, 25);
            labelRGB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelRGB.Name = "labelRGB";
            labelRGB.Size = new System.Drawing.Size(105, 56);
            labelRGB.TabIndex = 6;
            // 
            // LabelB
            // 
            LabelB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            LabelB.Location = new System.Drawing.Point(289, 92);
            LabelB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LabelB.Name = "LabelB";
            LabelB.Size = new System.Drawing.Size(44, 24);
            LabelB.TabIndex = 5;
            // 
            // LabelG
            // 
            LabelG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            LabelG.Location = new System.Drawing.Point(289, 58);
            LabelG.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LabelG.Name = "LabelG";
            LabelG.Size = new System.Drawing.Size(44, 24);
            LabelG.TabIndex = 4;
            // 
            // LabelR
            // 
            LabelR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            LabelR.Location = new System.Drawing.Point(289, 25);
            LabelR.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LabelR.Name = "LabelR";
            LabelR.Size = new System.Drawing.Size(44, 24);
            LabelR.TabIndex = 3;
            LabelR.MouseUp += LabelR_MouseUp;
            // 
            // hsB
            // 
            hsB.LargeChange = 1;
            hsB.Location = new System.Drawing.Point(13, 92);
            hsB.Maximum = 255;
            hsB.Name = "hsB";
            hsB.Size = new System.Drawing.Size(251, 21);
            hsB.TabIndex = 2;
            hsB.ValueChanged += hsB_ValueChanged;
            // 
            // hsG
            // 
            hsG.LargeChange = 1;
            hsG.Location = new System.Drawing.Point(13, 58);
            hsG.Maximum = 255;
            hsG.Name = "hsG";
            hsG.Size = new System.Drawing.Size(251, 21);
            hsG.TabIndex = 1;
            hsG.ValueChanged += hsG_ValueChanged;
            // 
            // hsR
            // 
            hsR.LargeChange = 1;
            hsR.Location = new System.Drawing.Point(13, 25);
            hsR.Maximum = 255;
            hsR.Name = "hsR";
            hsR.Size = new System.Drawing.Size(251, 21);
            hsR.TabIndex = 0;
            hsR.ValueChanged += hsR_ValueChanged;
            // 
            // lblFile
            // 
            lblFile.AutoSize = true;
            lblFile.Location = new System.Drawing.Point(14, 691);
            lblFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblFile.Name = "lblFile";
            lblFile.Size = new System.Drawing.Size(0, 15);
            lblFile.TabIndex = 1;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(btnSalvarBIN);
            groupBox4.Controls.Add(btnSalvarBMP);
            groupBox4.Controls.Add(lblCantidadColores);
            groupBox4.Controls.Add(label257);
            groupBox4.Controls.Add(btnSalvarTIM);
            groupBox4.Enabled = false;
            groupBox4.Location = new System.Drawing.Point(526, 519);
            groupBox4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox4.Size = new System.Drawing.Size(133, 194);
            groupBox4.TabIndex = 9;
            groupBox4.TabStop = false;
            groupBox4.Text = "Archivo";
            // 
            // btnSalvarBIN
            // 
            btnSalvarBIN.Location = new System.Drawing.Point(22, 123);
            btnSalvarBIN.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSalvarBIN.Name = "btnSalvarBIN";
            btnSalvarBIN.Size = new System.Drawing.Size(88, 27);
            btnSalvarBIN.TabIndex = 14;
            btnSalvarBIN.Text = "Comprimir";
            btnSalvarBIN.UseVisualStyleBackColor = true;
            btnSalvarBIN.Visible = false;
            btnSalvarBIN.Click += btnSalvarBIN_Click;
            // 
            // btnSalvarBMP
            // 
            btnSalvarBMP.Location = new System.Drawing.Point(22, 60);
            btnSalvarBMP.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSalvarBMP.Name = "btnSalvarBMP";
            btnSalvarBMP.Size = new System.Drawing.Size(88, 27);
            btnSalvarBMP.TabIndex = 13;
            btnSalvarBMP.Text = "Salvar BMP";
            btnSalvarBMP.UseVisualStyleBackColor = true;
            btnSalvarBMP.Click += btnSalvarBMP_Click;
            // 
            // lblCantidadColores
            // 
            lblCantidadColores.Location = new System.Drawing.Point(7, 42);
            lblCantidadColores.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblCantidadColores.Name = "lblCantidadColores";
            lblCantidadColores.Size = new System.Drawing.Size(119, 15);
            lblCantidadColores.TabIndex = 12;
            lblCantidadColores.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label257
            // 
            label257.Location = new System.Drawing.Point(7, 25);
            label257.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label257.Name = "label257";
            label257.Size = new System.Drawing.Size(112, 15);
            label257.TabIndex = 11;
            label257.Text = "Colores";
            label257.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSalvarTIM
            // 
            btnSalvarTIM.Location = new System.Drawing.Point(22, 93);
            btnSalvarTIM.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSalvarTIM.Name = "btnSalvarTIM";
            btnSalvarTIM.Size = new System.Drawing.Size(88, 27);
            btnSalvarTIM.TabIndex = 10;
            btnSalvarTIM.Text = "Salvar TIM";
            btnSalvarTIM.UseVisualStyleBackColor = true;
            btnSalvarTIM.Visible = false;
            // 
            // cmdAbrir
            // 
            cmdAbrir.Location = new System.Drawing.Point(15, 661);
            cmdAbrir.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cmdAbrir.Name = "cmdAbrir";
            cmdAbrir.Size = new System.Drawing.Size(104, 27);
            cmdAbrir.TabIndex = 10;
            cmdAbrir.Text = "Cargar Imagen";
            cmdAbrir.UseVisualStyleBackColor = true;
            cmdAbrir.Click += cmd_Abrir;
            // 
            // btnInsertarISO
            // 
            btnInsertarISO.Enabled = false;
            btnInsertarISO.Location = new System.Drawing.Point(245, 661);
            btnInsertarISO.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnInsertarISO.Name = "btnInsertarISO";
            btnInsertarISO.Size = new System.Drawing.Size(104, 27);
            btnInsertarISO.TabIndex = 11;
            btnInsertarISO.Text = "Guardar en ISO";
            btnInsertarISO.UseVisualStyleBackColor = true;
            btnInsertarISO.Click += btnInsertarISO_Click;
            // 
            // txtOffset
            // 
            txtOffset.Enabled = false;
            txtOffset.Location = new System.Drawing.Point(430, 663);
            txtOffset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtOffset.MaxLength = 10;
            txtOffset.Name = "txtOffset";
            txtOffset.Size = new System.Drawing.Size(75, 23);
            txtOffset.TabIndex = 12;
            txtOffset.KeyPress += textBox1_KeyPress;
            // 
            // lblOffset
            // 
            lblOffset.AutoSize = true;
            lblOffset.Enabled = false;
            lblOffset.Location = new System.Drawing.Point(383, 667);
            lblOffset.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblOffset.Name = "lblOffset";
            lblOffset.Size = new System.Drawing.Size(39, 15);
            lblOffset.TabIndex = 13;
            lblOffset.Text = "Offset";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(663, 727);
            Controls.Add(lblOffset);
            Controls.Add(txtOffset);
            Controls.Add(btnInsertarISO);
            Controls.Add(cmdAbrir);
            Controls.Add(groupBox4);
            Controls.Add(lblFile);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "WE Graphic editor -= By @maxiducoli (CARP) =-";
            Load += Form1_Load;
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbImage).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.HScrollBar hsB;
        private System.Windows.Forms.HScrollBar hsG;
        private System.Windows.Forms.HScrollBar hsR;
        private System.Windows.Forms.Label LabelB;
        private System.Windows.Forms.Label LabelG;
        private System.Windows.Forms.Label LabelR;
        private System.Windows.Forms.Label labelRGB;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnSalvarBIN;
        private System.Windows.Forms.Button btnSalvarBMP;
        private System.Windows.Forms.Label lblCantidadColores;
        private System.Windows.Forms.Label label257;
        private System.Windows.Forms.Button btnSalvarTIM;
        private System.Windows.Forms.Button cmdAbrir;
        private System.Windows.Forms.TextBox txtHTML;
        private System.Windows.Forms.TextBox txtBHex;
        private System.Windows.Forms.TextBox txtGHex;
        private System.Windows.Forms.TextBox txtRHex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInsertarISO;
        private System.Windows.Forms.TextBox txtOffset;
        private System.Windows.Forms.Label lblOffset;
    }
}

