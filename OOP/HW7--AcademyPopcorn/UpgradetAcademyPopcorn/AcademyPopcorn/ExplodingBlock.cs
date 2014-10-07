using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    // Task10: Implement an ExplodingBlock. It should destroy all blocks around it when it is destroyed. 
    public class ExplodingBlock : Block
    {
        public ExplodingBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
        }
        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }
        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> produceObjects = new List<GameObject>();
            if (this.IsDestroyed)
            {
                produceObjects.Add(new Explosion(this.topLeft, new char[,] { { '+' } }, new MatrixCoords(- 1, 0)));
                produceObjects.Add(new Explosion(this.topLeft, new char[,] { { '+' } }, new MatrixCoords(1, 0)));
                produceObjects.Add(new Explosion(this.topLeft, new char[,] { { '+' } }, new MatrixCoords(0, 1)));
                produceObjects.Add(new Explosion(this.topLeft, new char[,] { { '+' } }, new MatrixCoords(0, - 1)));
            }
            return produceObjects;
        }
    }
}
