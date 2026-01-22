using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using BmpHelper;
using WEUtils;
namespace GraphicsTools
{
    public partial class Form1 : Form
    {
        byte[] colorData = new byte[4];
        byte[] colorPalette;
        Color[] col;
        System.Drawing.Image img;
        Label label = null;
        int controlIndex;
        private int colorIndex;
        private int cantidadColores;
        bool esExterno = false;
        PictureBox myImagen = null;
        public int ColorIndex { get => colorIndex; set => colorIndex = value; }
        public int CantidadColores { get => cantidadColores; set => cantidadColores = value; }

        // Image img = null;
        public Form1()
        {
            InitializeComponent();
        }

        public Form1(string bmpPath, ref PictureBox pbImagen)
        {
            myImagen = pbImagen;
            InitializeComponent();
            CargaInicial(bmpPath);
            esExterno = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Control control in groupBox1.Controls)
            {
                control.Click += new EventHandler(GetClick);
                control.MouseUp += new MouseEventHandler(MainLabel_MouseUp);
            }
        }

        private void AddLabels()
        {

            Label[] labels = null;
            labels = new Label[cantidadColores];
            int labelIndex = 0;
            int labelLeftPos = 1;
            int labeltop = 1;

            for (int i = 0; i < labels.Length; i++)
            {
                labels[i] = new Label();
                labels[i].AutoSize = false;
                labels[i].Width = 13;
                labels[i].Height = 13;
                labels[i].Text = string.Empty;
                labels[i].Name = "label" + (labelIndex + 1).ToString();
                labels[i].Top = labeltop * labels[i].Height;
                labels[i].Left = labels[i].Width * labelLeftPos;
                //labels[i].LocationChanged(labeltop, labelLeftPos);
                labels[i].BorderStyle = BorderStyle.FixedSingle;
                labels[i].Click += new EventHandler(GetClick);
                labelIndex++;
                labelLeftPos++;
                if (labelLeftPos == 33)
                {
                    labelLeftPos = 1;
                    labeltop++;
                }
                groupBox1.Controls.Add(labels[i]);
            }
        }

        private void ShowBmpColors(Color[] colors)
        {
            string controlName = "label";
            controlIndex = colors.Length;
            lblCantidadColores.Text = Convert.ToString(controlIndex);
            ScrollEventArgs e = null;
            foreach (Control control in groupBox1.Controls)
            {
                if (control is Label)
                {
                    string l = control.Name.Substring(controlName.Length, control.Name.Length - controlName.Length);
                    if (Convert.ToInt32(l) <= colors.Length)
                    {
                        control.Visible = true;
                        control.BackColor = colors[Convert.ToInt32(l) - 1];
                        //controlIndex--;
                    }
                }
            }

        }

        private void cmd_Abrir(object sender, EventArgs e)
        {
            string tempPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\temp.bmp";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos BMP 4bpp - 8bpp (*.bmp)|*.bmp";
            //ClsBmpUtils clsBmpUtils = new ClsBmpUtils();      
            groupBox1.Controls.Clear();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //ClsGraphics clsGraphics = new ClsGraphics();
                if (ClsBmpUtils.GetBPP(ofd.FileName))
                {
                    Color[] colores = null;
                    colores = ClsBmpUtils.LoadColors(ofd.FileName);
                    cantidadColores = colores.Length;
                    //File.Copy(ofd.FileName, tempPath, true );
                    img = Image.FromFile(ofd.FileName);
                    //Image newIMG = img;
                    pbImage.Image = img;
                    lblFile.Text = ofd.FileName;
                    AddLabels();
                    foreach (Control control in groupBox1.Controls)
                    {
                        control.Click += new EventHandler(GetClick);
                        control.MouseUp += new MouseEventHandler(MainLabel_MouseUp);
                    }
                    ShowBmpColors(colores);
                    pbImage.Refresh();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un archivo BMP de 4bits o de 8bits");
                }

            }
            ofd.Dispose();
            groupBox4.Enabled = true;
            if (cantidadColores == 16)
            {
                txtOffset.Enabled = true;
                btnInsertarISO.Enabled = true;
                lblOffset.Enabled = true;
            }
            else
            {
                txtOffset.Enabled = false;
                btnInsertarISO.Enabled = false;
                lblOffset.Enabled = false;
            }
        }

        private void GetClick(object sender, EventArgs e)
        {

            if (sender is Label && sender != null)
            {
                colorData = null;

                label = (Label)sender;

                labelRGB.BackColor = label.BackColor;

                colorIndex = Convert.ToInt32(label.Name.Substring(5, label.Name.Length - 5));

                colorData = new byte[4];

                colorData[3] = 0xFF;

                colorData[2] = (label.BackColor.R);
                colorData[1] = (label.BackColor.G);
                colorData[0] = (label.BackColor.B);

                //hsR.Value = colorData[2];
                //hsG.Value = colorData[1];
                //hsB.Value = colorData[0];

                txtRHex.Text = Convert.ToString(colorData[2]);
                txtGHex.Text = Convert.ToString(colorData[1]);
                txtBHex.Text = Convert.ToString(colorData[0]);

                LabelR.BackColor = Color.FromArgb(colorData[3], colorData[2], 0, 0);
                LabelG.BackColor = Color.FromArgb(colorData[3], 0, colorData[1], 0);
                LabelB.BackColor = Color.FromArgb(colorData[3], 0, 0, colorData[0]);

                if (!groupBox3.Enabled)
                {
                    groupBox3.Enabled = true;
                }
                txtHTML.Text = colorData[2].ToString("X2") + colorData[1].ToString("X2") + colorData[0].ToString("X2");



                pbImage.Refresh();
                txtRHex.Focus();
                SendKeys.Send("{Enter}");

            }

        }

        private Color[] GetArrayOfColor()
        {
            Color[] colorData = new Color[Convert.ToInt32(lblCantidadColores.Text)];

            //int counter = colorData.Length;
            int n = 1;
            foreach (Control control in groupBox1.Controls)
            {
                if ((control is Label) && (control.Name == "label" + Convert.ToString(n)))
                {
                    colorData[n - 1] = control.BackColor;
                    n++;
                }
            }
            return colorData;
        }

        private void UpdatePictureBoxPalette()
        {

            // Convertir el array de colores en un ColorPalette

            col = GetArrayOfColor();
            Bitmap bmp;
            if (col.Length == 16)
            {
                bmp = new Bitmap(1, 1, PixelFormat.Format4bppIndexed);
            }
            else
            {
                bmp = new Bitmap(1, 1, PixelFormat.Format8bppIndexed);
            }

            ColorPalette colorPalette = bmp.Palette;

            for (int i = 0; i < col.Length; i++)
            {
                colorPalette.Entries[i] = col[i];
            }

            // Establecer la paleta actualizada en el PictureBox
            pbImage.Image.Palette = colorPalette;

            // Actualizar el PictureBox para reflejar los cambios
            pbImage.Refresh();

        }

        private void btnSalvarBMP_Click(object sender, EventArgs e)
        {
            BitmapConverter bmp = new BitmapConverter();
            Bitmap tempBMP;
            bool result = false;
            int bpp = lblCantidadColores.Text == "16" ? 4 : 8;
            string fileBINPath = string.Empty;
            string fileBIN = string.Empty;
            string fileRAW = Path.GetTempFileName();
            try
            {
                if (!esExterno)
                {
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        //BMPtoTIMConverter bMPtoTIMConverter = new BMPtoTIMConverter();
                        saveFileDialog.Filter = "Archivos BMP 4bpp - 8bpp (*.BMP)|*.BMP";
                        string file = string.Empty;
                        string tempPath = Path.GetTempFileName();
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            fileBINPath = Path.GetPathRoot(saveFileDialog.FileName);
                            fileBIN = fileBINPath + Path.GetFileNameWithoutExtension(saveFileDialog.FileName) + ".bin";


                                pbImage.Image.Save(saveFileDialog.FileName, ImageFormat.Bmp);
                                //tempBMP = bmp.ConvertTo4Bit((Bitmap)pbImage.Image);
                                //tempBMP.Save(saveFileDialog.FileName, ImageFormat.Bmp);
                                Simsala_BIN.CallCompressBMPImage(saveFileDialog.FileName, fileRAW, fileBIN);

                            saveFileDialog.Dispose();
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }

                    }
                }
                else
                {
                    myImagen = pbImage;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            if (result)
            {
                MessageBox.Show("Se guardaron los archivos (bmp y bin).");
            }
            else
            {
                MessageBox.Show("Error al guardar el archivo.");
            }
        }

        //private void btnSalvarTIM_Click(object sender, EventArgs e)
        //{
        //    bool result = false;
        //    try
        //    {
        //        SaveFileDialog saveFileDialog = new SaveFileDialog();
        //        BMPtoTIMConverter bMPtoTIMConverter = new BMPtoTIMConverter();
        //        string tmpPath = Path.GetTempPath() + "tmp.bmp";
        //        saveFileDialog.Filter = "Archivos TIM 4bpp - 8bpp (*.TIM)|*.TIM";
        //        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        //        {
        //            Bitmap bitmap = null;
        //            bitmap = (Bitmap)pictureBox1.Image;
        //            bitmap.Save(tmpPath);
        //            bMPtoTIMConverter.ConvertToTim(tmpPath, saveFileDialog.FileName);
        //            //bMPtoTIMConverter.ConvertToTim(bitmap,saveFileDialog.FileName);
        //            result = true;
        //            saveFileDialog.Dispose();
        //        }
        //        else
        //        {
        //            result = false;
        //        }

        //        // saveFileDialog = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }

        //    if (result)
        //    {
        //        MessageBox.Show("Se guardó el archivo.");
        //    }
        //    else
        //    {
        //        MessageBox.Show("Error al guardar el archivo.");
        //    }
        //}

        //private void btnSalvarBIN_Click(object sender, EventArgs e)
        //{
        //    bool result = false;
        //    ClsWECompressCARP clsWECompressCARP = new ClsWECompressCARP();
        //    SaveFileDialog saveFileDialog = new SaveFileDialog();
        //    BMPtoTIMConverter bMPtoTIMConverter = new BMPtoTIMConverter();
        //    try
        //    {
        //        string tmpPath = Path.GetTempPath() + "tmpBin.bmp";
        //        saveFileDialog.Filter = "Archivos BIN Compresión Konami (*.BIN)|*.BIN";
        //        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        //        {
        //            Bitmap bitmap = null;
        //            bitmap = (Bitmap)pictureBox1.Image;
        //            bitmap.Save(tmpPath);
        //            bMPtoTIMConverter.ConvertToTim(tmpPath, saveFileDialog.FileName);
        //            //bMPtoTIMConverter.ConvertToTim(bitmap,saveFileDialog.FileName);
        //            result = clsWECompressCARP.SaveFile(tmpPath, saveFileDialog.FileName);
        //            saveFileDialog.Dispose();
        //        }
        //        else
        //        {
        //            result = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }

        //    if (result)
        //    {
        //        MessageBox.Show("Se guardó el archivo.");
        //    }
        //    else
        //    {
        //        MessageBox.Show("Error al guardar el archivo.");
        //    }
        //}

        private void txtRHex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar)) e.Handled = true;
        }

        private void txtGHex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar)) e.Handled = true;
        }

        private void txtBHex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar)) e.Handled = true;
        }

        private void txtHTML_KeyDown(object sender, KeyEventArgs e)
        {

            if ((e.KeyCode == Keys.Enter) && (txtHTML.Text.Length == 6))
            {
                int r = Convert.ToInt32(txtHTML.Text.Substring(0, 2), 16);
                int g = Convert.ToInt32(txtHTML.Text.Substring(2, 2), 16);
                int b = Convert.ToInt32(txtHTML.Text.Substring(4, 2), 16);
                colorData[0] = (byte)b; // B
                colorData[1] = (byte)g; // G
                colorData[2] = (byte)r; // R
                colorData[3] = 0xFF;
                hsR.Value = r;
                hsG.Value = g;
                hsB.Value = b;
                txtRHex.Text = Convert.ToString(b);
                txtGHex.Text = Convert.ToString(g);
                txtRHex.Text = Convert.ToString(r);
            }
        }

        private void hsR_ValueChanged(object sender, EventArgs e)
        {
            // A

            txtRHex.Text = Convert.ToString(hsR.Value);
            txtGHex.Text = Convert.ToString(hsG.Value);
            txtBHex.Text = Convert.ToString(hsB.Value);

            labelRGB.BackColor = Color.FromArgb(colorData[3], hsR.Value, hsG.Value, hsB.Value);

            LabelR.BackColor = Color.FromArgb(labelRGB.BackColor.R, 0, 0);
            LabelG.BackColor = Color.FromArgb(0, labelRGB.BackColor.G, 0);
            LabelB.BackColor = Color.FromArgb(0, 0, labelRGB.BackColor.B);

            txtHTML.Text = hsR.Value.ToString("X2") + hsG.Value.ToString("X2") + hsB.Value.ToString("X2");

            if (label != null)
            {
                label.BackColor = Color.FromArgb(colorData[3], hsR.Value, hsG.Value, hsB.Value);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un color para cambiar.");
            }

            colorData[0] = (byte)hsB.Value; // B
            colorData[1] = (byte)hsG.Value; // G
            colorData[2] = (byte)hsR.Value; // R
            colorData[3] = 0xFF;

            UpdatePictureBoxPalette();
        }

        private void hsG_ValueChanged(object sender, EventArgs e)
        {
            colorData[0] = (byte)hsB.Value; // B
            colorData[1] = (byte)hsG.Value; // G
            colorData[2] = (byte)hsR.Value; // R
            colorData[3] = 0xFF;            // A
            txtRHex.Text = Convert.ToString(colorData[2]);
            txtGHex.Text = Convert.ToString(colorData[1]);
            txtBHex.Text = Convert.ToString(colorData[0]);

            labelRGB.BackColor = Color.FromArgb(colorData[3], colorData[2], colorData[1], colorData[0]);
            LabelR.BackColor = Color.FromArgb(labelRGB.BackColor.R, 0, 0);
            LabelG.BackColor = Color.FromArgb(0, labelRGB.BackColor.G, 0);
            LabelB.BackColor = Color.FromArgb(0, 0, labelRGB.BackColor.B);

            if (label != null)
            {
                label.BackColor = Color.FromArgb(colorData[3], colorData[2], colorData[1], colorData[0]);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un color para cambiar.");
            }
            txtHTML.Text = hsR.Value.ToString("X2") + hsG.Value.ToString("X2") + hsB.Value.ToString("X2");
            UpdatePictureBoxPalette();
        }

        private void hsB_ValueChanged(object sender, EventArgs e)
        {
            colorData[0] = (byte)hsB.Value; // B
            colorData[1] = (byte)hsG.Value; // G
            colorData[2] = (byte)hsR.Value; // R
            colorData[3] = 0xFF;            // A

            txtRHex.Text = Convert.ToString(colorData[2]);
            txtGHex.Text = Convert.ToString(colorData[1]);
            txtBHex.Text = Convert.ToString(colorData[0]);


            labelRGB.BackColor = Color.FromArgb(colorData[3], colorData[2], colorData[1], colorData[0]);
            LabelR.BackColor = Color.FromArgb(labelRGB.BackColor.R, 0, 0);
            LabelG.BackColor = Color.FromArgb(0, labelRGB.BackColor.G, 0);
            LabelB.BackColor = Color.FromArgb(0, 0, labelRGB.BackColor.B);

            if (label != null)
            {
                label.BackColor = Color.FromArgb(colorData[3], colorData[2], colorData[1], colorData[0]);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un color para cambiar.");
            }

            txtHTML.Text = hsR.Value.ToString("X2") + hsG.Value.ToString("X2") + hsB.Value.ToString("X2");

            UpdatePictureBoxPalette();
        }

        private void txtRHex_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && (Convert.ToInt32(txtRHex.Text) <= 255))
            {
                byte r = Convert.ToByte(txtRHex.Text);
                byte g = Convert.ToByte(txtGHex.Text);
                byte b = Convert.ToByte(txtBHex.Text);
                colorData[0] = (byte)b; // B
                colorData[1] = (byte)g; // G
                colorData[2] = (byte)r; // R
                colorData[3] = 0xFF;
                hsR.Value = r;
                hsG.Value = g;
                hsB.Value = b;
                txtHTML.Text = r.ToString("X2") + g.ToString("X2") + b.ToString("X2");
            }
        }

        private void txtGHex_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && (Convert.ToInt32(txtRHex.Text) <= 255))
            {
                byte r = Convert.ToByte(txtRHex.Text);
                byte g = Convert.ToByte(txtGHex.Text);
                byte b = Convert.ToByte(txtBHex.Text);
                colorData[0] = (byte)b; // B
                colorData[1] = (byte)g; // G
                colorData[2] = (byte)r; // R
                colorData[3] = 0xFF;
                hsR.Value = r;
                hsG.Value = g;
                hsB.Value = b;
                txtHTML.Text = r.ToString("X2") + g.ToString("X2") + b.ToString("X2");
            }
        }

        private void txtBHex_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && (Convert.ToInt32(txtRHex.Text) <= 255))
            {
                byte r = Convert.ToByte(txtRHex.Text);
                byte g = Convert.ToByte(txtGHex.Text);
                byte b = Convert.ToByte(txtBHex.Text);
                colorData[0] = (byte)b; // B
                colorData[1] = (byte)g; // G
                colorData[2] = (byte)r; // R
                colorData[3] = 0xFF;
                hsR.Value = r;
                hsG.Value = g;
                hsB.Value = b;
                txtHTML.Text = r.ToString("X2") + g.ToString("X2") + b.ToString("X2");
            }
        }

        private void LabelR_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void MainLabel_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void txtRHex_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtRHex.Text) > 255)
            {
                txtRHex.Text = "255";
            }
        }

        private void txtGHex_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtGHex.Text) > 255)
            {
                txtGHex.Text = "255";
            }
        }

        private void txtBHex_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtBHex.Text) > 255)
            {
                txtBHex.Text = "255";
            }
        }

        private bool IsHexCharacter(char c)
        {
            return (c >= '0' && c <= '9') || (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F');
        }

        private void txtHTML_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si es un carácter hexadecimal válido
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !IsHexCharacter(e.KeyChar))
            {
                e.Handled = true; // Cancelar la pulsación de tecla
            }
        }

        private void txtHTML_Validated(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar)) e.Handled = true;
        }

        private void btnInsertarISO_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            int contador;
            ofd.Title = "Archivos BIN";
            ofd.Filter = "Archivos BIN (*.bin)|*.bin";
            byte[] timPalette = new byte[32];
            if (!string.IsNullOrEmpty(txtOffset.Text))
            {
                // Guardamos TIM
                //BMPtoTIMConverter bMPtoTIMConverter = new BMPtoTIMConverter();
                string tmpBmpPath = Path.GetTempPath() + "tmp.bmp";

                //if (File.Exists(Path.GetTempPath() + Convert.ToString(contador) + ".tim")) contador++;

                string tmpTimPath = Path.GetTempPath() + Convert.ToString(contador = new Random().Next(0, 100000000)) + ".tim";
                Bitmap bitmap = null;
                bitmap = (Bitmap)pbImage.Image;
                bitmap.Save(tmpBmpPath);
                // bMPtoTIMConverter.ConvertToTim(tmpBmpPath, tmpTimPath);
                //bMPtoTIMConverter = null;

                using (FileStream tim = new FileStream(tmpTimPath, FileMode.Open, FileAccess.Read))
                {
                    tim.Position = 20;
                    tim.Read(timPalette, 0, timPalette.Length);
                }

                if (ofd.ShowDialog() == DialogResult.OK)
                {

                    using (FileStream file = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Write))
                    {
                        int.TryParse(txtOffset.Text, out int offset);
                        file.Seek(offset, SeekOrigin.Begin);
                        file.Write(timPalette, 0, timPalette.Length);
                    }
                }
            }
            else
            {
                MessageBox.Show("Ingrese un offset.");
                txtOffset.Focus();
            }

        }

        private void CargaInicial(string bmpPath)
        {
            string tempPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\temp.bmp";
            groupBox1.Controls.Clear();

            //ClsGraphics clsGraphics = new ClsGraphics();
            if (ClsBmpUtils.GetBPP(bmpPath))
            {
                Color[] colores = null;
                colores = ClsBmpUtils.LoadColors(bmpPath);
                cantidadColores = colores.Length;
                //File.Copy(ofd.FileName, tempPath, true );
                img = Image.FromFile(bmpPath);
                //Image newIMG = img;
                pbImage.Image = img;
                lblFile.Text = bmpPath;
                AddLabels();
                foreach (Control control in groupBox1.Controls)
                {
                    control.Click += new EventHandler(GetClick);
                    control.MouseUp += new MouseEventHandler(MainLabel_MouseUp);
                }
                ShowBmpColors(colores);
                pbImage.Refresh();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un archivo BMP de 4bits o de 8bits");
            }

            groupBox4.Enabled = true;
            if (cantidadColores == 16)
            {
                txtOffset.Enabled = true;
                btnInsertarISO.Enabled = true;
                lblOffset.Enabled = true;
            }
            else
            {
                txtOffset.Enabled = false;
                btnInsertarISO.Enabled = false;
                lblOffset.Enabled = false;
            }
        }

        private void btnSalvarBIN_Click(object sender, EventArgs e)
        {

        }
    }
}