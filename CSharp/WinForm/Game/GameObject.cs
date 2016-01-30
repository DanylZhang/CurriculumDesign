using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    abstract class GameObject
    {
        public int X
        {
            get;
            set;
        }
        public int Y
        {
            get;
            set;
        }
        public int Size
        {
            get;
            set;
        }
        public int Speed
        {
            get;
            set;
        }
        public Rectangle FieldArea
        {
            get;
            set;
        }
        public abstract void Move();
        public abstract void Draw(Graphics g);
    }
}