using Labyrinth.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth.Persistence
{
    public interface IDataManager
    {
        public LabyrinthData Load(int mapId);
    }

    public class DataManager : IDataManager
    {
        public DataManager() { }

        public LabyrinthData Load(int mapId)
        {
            try
            {
                string[] lines = File.ReadLines(mapId + ".txt").ToArray();
                int size = int.Parse(lines[0]);
                int[,] values = new int[size, size];
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        values[size-1-i,j] = int.Parse(lines[i+1][j].ToString());
                    }
                }

                return new LabyrinthData(values);
            }
            catch
            {
                throw new LabyrinthDataException();
            }
        }
    }
}
