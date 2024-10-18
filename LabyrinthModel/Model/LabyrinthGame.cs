using Labyrinth.Persistence;
using System;
using System.Reflection.Metadata.Ecma335;

namespace Labyrinth.Model
{
    public enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }
	public class LabyrinthGame
	{
        private readonly IDataManager manager;

        private LabyrinthData data = null!;

        private int gameTime;

        private bool gamePaused;

        public bool Victory { get { return data.Victory; } }
        public LabyrinthData Data { get { return data; } }
        public int GameTime { get { return gameTime; } }
        public bool GamePaused { get { return gamePaused; } set { gamePaused = value; } }

        public event EventHandler? GameOver;

        public event EventHandler? MovePerformed;

        public event EventHandler? TimePassed;

        public LabyrinthGame(IDataManager instance)
		{
            manager = instance;
            gamePaused = true;
        }

        public void Load(int mapId)
        {
            data = manager.Load(mapId);
            gameTime = 0;
            gamePaused = false;
        }

        public void AdvanceTime()
        {
            if (Victory) return;
            gameTime++;
            TimePassed?.Invoke(this, EventArgs.Empty);
        }

        public void Move(Direction direction)
        {
            if(gamePaused || Victory) return;
            bool moved = false;
            switch (direction)
            {
                case Direction.Down:
                    if (data.XPos == 0) break;
                    if (data.Value[data.XPos - 1, data.YPos] == 1) break;
                    moved = true;
                    data.XPos--;
                    break;
                case Direction.Up:
                    if (data.XPos == data.Size - 1) break;
                    if (data.Value[data.XPos + 1, data.YPos] == 1) break;
                    moved = true;
                    data.XPos++;
                    break;
                case Direction.Right:
                    if (data.YPos == data.Size - 1) break;
                    if (data.Value[data.XPos, data.YPos + 1] == 1) break;
                    moved = true;
                    data.YPos++;
                    break;
                case Direction.Left:
                    if (data.YPos == 0) break;
                    if (data.Value[data.XPos, data.YPos - 1] == 1) break;
                    moved = true;
                    data.YPos--;
                    break;
                default: break;
            }

            if(moved)
            {
                data.UpdateVisibility();
                MovePerformed?.Invoke(this, EventArgs.Empty);
                if (Victory) GameOver?.Invoke(this, EventArgs.Empty);
            }
        }
        
	}

}
