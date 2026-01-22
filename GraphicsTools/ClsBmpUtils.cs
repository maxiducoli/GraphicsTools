using System.Drawing;
using System.IO;

namespace GraphicsTools
{
    public  class ClsBmpUtils
    {
        public static System.Drawing.Color[] LoadColors(string bmpPath)
        {
            byte[] data = GetRGBFromBMP(bmpPath);
            byte[] dataTemp = new byte[4];
            System.Drawing.Color[] color = new Color[data.Length / 4];
            int colorIndex = 0;
            for (int i = 0; i < data.Length; i += 4)
            {
                dataTemp[0] = data[i];
                dataTemp[1] = data[i + 1];
                dataTemp[2] = data[i + 2];
                dataTemp[3] = 0xFF;
                color[colorIndex] = Color.FromArgb(dataTemp[3], dataTemp[2], dataTemp[1], dataTemp[0]);
                colorIndex++;
            }
            return color;
        }

        public static bool GetBPP(string bmpPath)
        {
            bool result = false;
            const int bppPisition = 28;
            byte[] tempdata = new byte[1];

            FileStream file = new FileStream(bmpPath, FileMode.Open, FileAccess.Read);
            file.Position = bppPisition;
            file.Read(tempdata, 0, 1);
            if (tempdata[0] == 4)
            {
                result = true;
            }
            if (tempdata[0] == 8)
            {
                result = true;
            }
            file.Close();
            return result;
        }

        private static byte[] GetRGBFromBMP(string bmpPath)
        {
            byte[] result = null;
            const int bppPosition = 28;
            const int palettePosition = 54;
            byte[] tempdata = new byte[1];
            FileStream file = new FileStream(bmpPath, FileMode.Open, FileAccess.Read);
            file.Position = bppPosition;
            file.Read(tempdata, 0, 1);
            if (tempdata[0] == 4)
            {
                result = new byte[64];
            }
            if (tempdata[0] == 8)
            {
                result = new byte[1024];
            }
            file.Position = palettePosition;
            file.Read(result, 0, result.Length);
            file.Close();
            return result;
        }
    }
}