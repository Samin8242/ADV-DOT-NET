
namespace LINQ
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] marks = new int[] { 45, 65, 12, 56, 78, 89, 88, 86, 85 };
            var apuls = (from item in marks
                         where item >= 80
                         select item).ToArray();
        }
    }
}