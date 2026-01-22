using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class BytesToTIM
    {
        public void CreateTIM(string outputPath, int width, int height, byte[] rawImage, byte[] palette)
        {
            using (FileStream fs = new FileStream(outputPath, FileMode.Create))
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                // Escribir el encabezado TIM
                WriteTIMHeader(writer, width, height, palette.Length);

                // Escribir la paleta
                writer.Write(palette);

                // Escribir la imagen comprimida (rawImage)
                writer.Write(rawImage);
            }
        }

        private void WriteTIMHeader(BinaryWriter writer, int width, int height, int paletteSize)
        {
            // Magic number y otras constantes del encabezado TIM
            ushort magic = 0x10; // Por ejemplo, 0x10 para TIM de 4 bits
            ushort flags = 0x08; // Modo 4 bits

            writer.Write(magic);
            writer.Write(flags);
            writer.Write((ushort)0); // Clut x, y
            writer.Write((ushort)width);
            writer.Write((ushort)height);
            writer.Write((ushort)((paletteSize / 2) | ((paletteSize / 2) << 12))); // Clut colors
            writer.Write((ushort)0); // Image x, y
            writer.Write((ushort)0); // Image w, h
        }

        public byte[] Palette(string path, int offset, int length)
        {
            byte[] palette = null;
            if (length == 4)
            {
                palette = new byte[32];
            }
            else
            {
                palette = new byte[512];
            }
            try
            {
                using (FileStream fs = new FileStream(path,FileMode.Open,FileAccess.Read))
                {
                    fs.Position = offset;
                    fs.Read(palette, 0, palette.Length);
                }
            }
            catch (Exception ex)
            {

                throw new IOException(ex.Message);
            }

            return palette;
        }
    }
}
