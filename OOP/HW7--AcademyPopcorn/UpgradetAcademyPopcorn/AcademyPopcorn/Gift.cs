using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    /*Task11: Implement a Gift class. It should be a moving object, which always falls down. 
    The gift shouldn't collide with any ball, but should collide (and be destroyed) with the racket.*/
    public class Gift: MovingObject
    {
        public Gift(MatrixCoords topLeft)
            : base(topLeft, new char[,]{ { 'G' } } , new MatrixCoords(1, 0))
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }
        //  Adding for Task13
        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> produceObjects = new List<GameObject>();
            if (this.IsDestroyed)
            {
                produceObjects.Add(new ShoothingRacket(new MatrixCoords(this.topLeft.Row + 1, this.topLeft.Col), 6));
            }
            return produceObjects;
        }
    }
}
