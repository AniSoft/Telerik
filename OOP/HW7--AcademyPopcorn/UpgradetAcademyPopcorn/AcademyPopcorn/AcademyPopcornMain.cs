using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock;
                if (i == 7)
                {
                    currBlock = new ExplodingBlock(new MatrixCoords(startRow, i));
                }
                else if (i == endCol - 3)
                {
                    currBlock = new GiftBlock(new MatrixCoords(startRow, i));
                }
                else
                {
                    currBlock = new Block(new MatrixCoords(startRow, i));
                }

                engine.AddObject(currBlock);
            }

            Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1));
            engine.AddObject(theBall);
            // Task7: Test MeteoriteBall
            //Ball theMeteoriteBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1));
            //engine.AddObject(theMeteoriteBall);

            #region
            // Task9 Test UnstoppableBall
            /*Ball theUnstopableBall = new UnstoppableBall(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1));
            engine.AddObject(theUnstopableBall);

            for (int i = 2; i < WorldCols/2; i+=4)
            {
                engine.AddObject(new UnpassableBlock(new MatrixCoords(4, i)));
            }*/
            #endregion

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);
            engine.AddObject(theRacket);
            //Task3
            Racket newtheRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength+1);
            engine.AddObject(newtheRacket);

        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            //Engine gameEngine = new Engine(renderer, keyboard);
            EngineForShootingRocket gameEngine = new EngineForShootingRocket(renderer, keyboard);

            #region
            // task1 - add undestructable blocks
            for (int i = 2; i < WorldRows; i++)
			{
		        gameEngine.AddObject(new IndestructibleBlock(new MatrixCoords(i, 0)));
                gameEngine.AddObject(new IndestructibleBlock(new MatrixCoords(i, WorldCols - 1)));
            }
            for (int i = 0; i < WorldCols; i++)
            {
                gameEngine.AddObject(new IndestructibleBlock(new MatrixCoords(2, i)));
            }
            #endregion

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };
            //Task13
            keyboard.OnActionPressed += (sender, eventInfo) =>
            {
                gameEngine.ShootPlayerRacket();
            };
            //

            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}
