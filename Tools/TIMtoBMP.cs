using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
namespace Tools
{
    public class TIMtoBMP
    {
        // Convierte los datos porporcionados en un HEADER TIM
        public byte[] CreateTIMHeader(byte[] timRaw, Color[] palette, int height, int width)
        {
            // Determinar el tipo de imagen (4 bits para 16 colores, 8 bits para 256 colores)
            int imageType = (palette.Length <= 16) ? 1 : 2; // 1 = 4 bits, 2 = 8 bits

            // Calcular el tamaño de la imagen en bytes
            int imageSize = timRaw.Length;

            // Calcular el tamaño del encabezado
            int headerSize = 32; // Tamaño fijo del encabezado TIM en bytes

            // Crear el array de bytes para el encabezado TIM
            byte[] header = new byte[headerSize];

            // Escribir los datos en el encabezado TIM
            // Magic Number
            Array.Copy(new byte[] { 0x10, 0x00, 0x00, 0x00 }, 0, header, 0, 4);

            // Image Type (1 = 4 bits, 2 = 8 bits)
            header[4] = (byte)imageType;

            // Flags
            header[5] = 0;

            // Clut X
            header[6] = 0;

            // Clut Y
            header[7] = 0;

            // Clut W
            header[8] = (byte)palette.Length;

            // Clut H
            header[9] = 0;

            // Image X
            Array.Copy(BitConverter.GetBytes((ushort)0), 0, header, 10, 2);

            // Image Y
            Array.Copy(BitConverter.GetBytes((ushort)0), 0, header, 12, 2);

            // Image W
            Array.Copy(BitConverter.GetBytes((ushort)width), 0, header, 14, 2);

            // Image H
            Array.Copy(BitConverter.GetBytes((ushort)height), 0, header, 16, 2);

            // Image Size
            Array.Copy(BitConverter.GetBytes((uint)imageSize), 0, header, 20, 4);

            // Padding
            Array.Copy(new byte[] { 0, 0, 0, 0 }, 0, header, 24, 4);

            // Clut
            for (int i = 0; i < palette.Length; i++)
            {
                Color color = palette[i];
                int r = (color.R >> 3) & 0x1F;
                int g = (color.G >> 3) & 0x1F;
                int b = (color.B >> 3) & 0x1F;
                ushort colorData = (ushort)((b << 10) | (g << 5) | r);
                Array.Copy(BitConverter.GetBytes(colorData), 0, header, 32 + i * 2, 2);
            }

            return header;
        }
        // Convierte un array de colores a un array de bytes
        public byte[] ConvertColorArrayToBytes(Color[] colors)
        {
            int colorSize = 3; // Tamaño de cada color en bytes (RGB)

            // Calcular el tamaño total del array de bytes
            int totalSize = colors.Length * colorSize;

            // Crear el array de bytes
            byte[] bytes = new byte[totalSize];

            // Iterar sobre cada color y convertirlo a bytes
            for (int i = 0; i < colors.Length; i++)
            {
                bytes[i * colorSize + 0] = colors[i].R;
                bytes[i * colorSize + 1] = colors[i].G;
                bytes[i * colorSize + 2] = colors[i].B;
            }

            return bytes;
        }

        // Convierte un array de colores a un array de bytes de paleta TIM
        public byte[] ConvertColorsToTIMPalette(Color[] colors)
        {
            // Calcular el tamaño de la paleta en bytes
            int paletteSize = colors.Length * 2;

            // Crear un array de bytes para la paleta TIM
            byte[] paletteData = new byte[paletteSize];

            // Convertir cada color a su representación en la paleta TIM
            for (int i = 0; i < colors.Length; i++)
            {
                Color color = colors[i];

                // Convertir RGB de 8 bits a 5 bits
                int r = (color.R >> 3) & 0x1F;
                int g = (color.G >> 3) & 0x1F;
                int b = (color.B >> 3) & 0x1F;

                // Combinar los componentes RGB en un solo ushort (16 bits)
                ushort colorData = (ushort)((b << 10) | (g << 5) | r);

                // Guardar el color en el array de bytes
                BitConverter.GetBytes(colorData).CopyTo(paletteData, i * 2);
            }

            return paletteData;
        }

        // Convierte un array de bytes de paleta TIM a un array de colores
        public Color[] ConvertTIMBytesToColors(byte[] timPaletteData)
        {
            // Calcular el número de colores en la paleta TIM
            int numColors = timPaletteData.Length / 2;

            // Crear un array de Color para almacenar los colores
            Color[] colors = new Color[numColors];

            // Convertir cada color de la paleta TIM a Color
            for (int i = 0; i < numColors; i++)
            {
                // Extraer los componentes R, G, B del ushort de la paleta TIM
                ushort colorData = BitConverter.ToUInt16(timPaletteData, i * 2);

                // Convertir de 16 bits (TIM) a 24 bits (Color)
                int r = (colorData & 0x1F) << 3;   // 5 bits de rojo
                int g = (colorData >> 5 & 0x1F) << 3; // 5 bits de verde
                int b = (colorData >> 10 & 0x1F) << 3; // 5 bits de azul

                // Crear el color y agregarlo al array de colors
                colors[i] = Color.FromArgb(r, g, b);
            }

            return colors;
        }


    }
}
