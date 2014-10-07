using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    //Task 4- inherit class Engine and create ShootPlayerRacket method
    public class EngineForShootingRocket : Engine
    {
        public EngineForShootingRocket(IRenderer renderer, IUserInterface userInterface)
            : base(renderer, userInterface)
        {
        }

        public void ShootPlayerRacket()
        {
            //Task 13
            if (this.playerRacket is ShoothingRacket)
            {
                (this.playerRacket as ShoothingRacket).Shoot();
            }
            //
        }
    }
}
