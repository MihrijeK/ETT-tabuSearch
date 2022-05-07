using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETT.model
{
    class Room
    {
        public enum RoomType
        {
            SMALL,
            MEDIUM,
            LARGE
        }
        public RoomType fromString(string param)
        {
            string[] values = Enum.GetNames(typeof(RoomType));
            foreach (string s in values)
            {
                if (s == param)
                {
                    Console.WriteLine(s);
                }
            }
            return 0;
        }
        private string room { get; set; }
        private RoomType type { get; set; }

        public Room() {
        }

        public Room(string room, RoomType type)
        {
            this.room = room;
            this.type = type;
        }
    }
}
