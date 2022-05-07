using System;

namespace ETT
{
    class Program
    {
        public enum RoomType
        {
            SMALL,
            MEDIUM,
            LARGE 
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Tipi: ");
            var tipi = Console.ReadLine();
            //fromString(tipi);
        }
        //public static RoomType fromString(string param)
        //{
        //    string[] values = Enum.GetNames(typeof(RoomType));
        //    foreach (string s in values)
        //    {
        //        if (s == param)
        //        {
        //            Console.WriteLine(s);
        //        }
        //    }
        //    return 0;
        //}
    }
}
