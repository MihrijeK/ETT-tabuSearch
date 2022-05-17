using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ETT.model.Room;

namespace ETT.model
{
    public class RoomsRequested
    {
        private int number { get; set; }
        private RoomType type { get; set; }
        public RoomsRequested() { }
        public RoomsRequested(int number, RoomType type)
        {
            this.number = number;
            this.type = type;
        }
        public int getNumber() {
            return number;
        }
        public void setNumber(int number) {
            this.number = number;
        }
        public RoomType getType() {
            return type;
        }
        public void setType(RoomType type) {
            this.type = type;
        }
    }
}
