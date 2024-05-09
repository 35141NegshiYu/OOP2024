using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BallApp {
    internal class SoccerBall : Obj {
        public static int count { get; set; }
        public SoccerBall(double xp, double yp)
            : base(xp, yp, @"Picture\soccer_ball.png") {

            Random r = new Random();

            MoveX = r.Next(-25, 25); //移動量設定
            MoveY = r.Next(-25, 25);

            count++;
        }

        public override bool Move() {


            if (PosX > 750 || PosX < 0) {
                MoveX = -MoveX;
            }

            if (PosY > 500 || PosY < 0) {
                MoveY = -MoveY;
            }
            PosX += MoveX;
            PosY += MoveY;
            return true;

        }
        public override bool Move(Keys direction) {
            return true;
        }
    }
}

