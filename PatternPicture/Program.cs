using System.Drawing;

class Program
{
    static void Main()
    {
        int rows = 200;
        int cols = 200;
        int pixelSize = 10;

        int[,] matrix = GenerateSpiralMatrix(rows, cols);
        Bitmap image = ConvertMatrixToImage(matrix, pixelSize);

        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string imagePath = Path.Combine(desktopPath, "matrix_spiral.png");
        image.Save(imagePath, System.Drawing.Imaging.ImageFormat.Png);

        Console.WriteLine($"Image saved to {imagePath}");
    }

  
    static int[,] GenerateSpiralMatrix(int rows, int cols)
    {
        int[,] matrix = new int[rows, cols];
        Random rand = new Random();

        int cx = rows / 2;
        int cy = cols / 2;

        int x = cx;
        int y = cy;

        int dx = 0;
        int dy = -1;

        int maxI = Math.Max(rows, cols) * Math.Max(rows, cols);

        for (int i = 0; i < maxI; i++)
        {
            if (x >= 0 && x < rows && y >= 0 && y < cols)
            {
          
            }

            
            if (x == y || (x < cx && x == -y) || (x > cx && x == 1 - y))
            {
                int temp = dx;
                dx = -dy;
                dy = temp;
            }

            x += dx;
            y += dy;
        }

        return matrix;
    }

    static Bitmap ConvertMatrixToImage(int[,] matrix, int pixelSize)
    {
        int width = matrix.GetLength(1) * pixelSize;
        int height = matrix.GetLength(0) * pixelSize;
        Bitmap image = new Bitmap(width, height);

        using (Graphics g = Graphics.FromImage(image))
        {
            g.Clear(Color.White);
            for (int y = 0; y < matrix.GetLength(0); y++)
            {
                for (int x = 0; x < matrix.GetLength(1); x++)
                {
                    Color color = matrix[y, x] == 1 ? Color.Black : Color.White;
                    g.FillRectangle(new SolidBrush(color), x * pixelSize, y * pixelSize, pixelSize, pixelSize);
                }
            }
        }

        return image;
    }
}