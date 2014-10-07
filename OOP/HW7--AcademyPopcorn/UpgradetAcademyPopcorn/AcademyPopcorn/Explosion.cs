using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    // Task10: Implement an ExplodingBlock. It should destroy all blocks around it when it is destroyed. 
    public class Explosion : MovingObject
    {
        public Explosion(MatrixCoords topLeft, char[,] body, MatrixCoords speed)
            : base(topLeft, body, speed)
        {
            this.IsDestroyed = true;
        }
        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "block";
        }
        public override void Update()
        {
            this.IsDestroyed = true;
        }

    }
}
