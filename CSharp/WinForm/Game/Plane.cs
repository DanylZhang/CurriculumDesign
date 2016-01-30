using Game.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Plane:GameObject
    {
        public bool IsHit
        {
            get;
            set;
        }
        public int HitTimes
        {
            get;
            set;
        }
        public override void Move()
        {
            if (this.X > this.FieldArea.Width)
            {
                this.X = 0;
                Random rand=new Random();
                this.Y = rand.Next(0, this.FieldArea.Height - this.Size - 50);
            }
            this.X = this.X + this.Speed;
        }
        public override void Draw(Graphics g)
        {
            g.DrawImage(Resources.plane, this.X, this.Y, this.Size, this.Size);
        }
    }
}