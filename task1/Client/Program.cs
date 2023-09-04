using System.Collections;
using System.Linq;
using System.Windows.Forms.VisualStyles;
using Client;

namespace WindowsFormsApplication1
{
    static class Program // код класса Program
    {
        /// <summary>
        /// Главная точка входа для системы.
        /// </summary> 
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static string ThreeMax(double x, double y, double z) // Метод для вычисления Z
        {
            return $"Max: {new[] { x, y, z }.Max()}";
        }

        public static string TwoSigns(double x, double y)
        {
            return x * y >= 0 ? $"Mult: {x * y}" : $"A^2: {x * x}, B^2: {y * y}";
        }

        public static string AbsMax(double x, double y, double z)
        {
            return $"Abs Max: {new[] { x, y, z }.Select(Math.Abs).Max()}";
        }

        public static string TwoDots(double x1, double y1, double x2, double y2, double r)
        {
            return x1 * x1 + y1 * y1 <= r * r & x2 * x2 + y2 * y2 <= r * r ? "Yes" : "No";
        }

        public static string AnotherBrickInTheWall(double x, double y, double z, double a, double b)
        {
            return ((a >= x) & (b >= y)) |
                   ((a >= y) & (b >= x)) |
                   ((a >= x) & (b >= z)) |
                   ((a >= z) & (b >= x)) |
                   ((a >= z) & (b >= y)) |
                   ((a >= y) & (b >= z))
                ? "Yes"
                : "No";
        }
    }
}