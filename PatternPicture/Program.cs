using System.Drawing;

class Program
{
    static void Main()
    {
        int rows = 200;
        int cols = 200;
        if (rows != cols) {
            throw new Exception("Rows and columns must be equal to create a square matrix for the spiral pattern.");
        }
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

        int cx = (rows / 2)-1;
        int cy = (cols / 2)-1;
        // Starting point in the center of the matrix
        matrix[cx, cy] = 1;
        int direction = 1;
        int steps = 1;

        for (int i = 0; i < rows - 1; i++)
        {
            //coloumns
            for (int a = 0; a < steps; a++)
            {
                cy = (cy + (direction * 1)) % cols;
                matrix[cx, cy] = 1;
            }
            //rows
            for (int a = 0; a < steps; a++)
            {
                cx = (cx + (direction * 1)) % rows;
                matrix[cx, cy] = 1;
            }
            steps++;
            direction = direction * -1;
        }
        for (int a = 0; a < steps-1; a++)
        {
            cy = (cy + (direction * 1)) % cols;
            matrix[cx, cy] = 1;
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