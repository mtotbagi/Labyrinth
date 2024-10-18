using Labyrinth.Model;
using Labyrinth.Persistence;
using Moq;

namespace LabyrinthTest
{
    [TestClass]
    public class LabyrinthModelTest
    {
        private LabyrinthGame model = null!;
        private LabyrinthData mockedData = null!;
        private Mock<IDataManager> mock = null!;

        [TestInitialize]
        public void Initialize()
        {
            int[,] mockValues = new int[4, 4]
            {
                { 0, 1, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }
            };
            mockedData = new LabyrinthData(mockValues);

            mock = new Mock<IDataManager>();
            mock.Setup(x => x.Load(It.IsAny<int>()))
                .Returns(() => mockedData);

            model = new LabyrinthGame(mock.Object);
        }

        [TestMethod]
        public void NewGameTest()
        {
            Assert.AreEqual(true, model.GamePaused);

            model.Load(1);

            Assert.AreEqual(0, model.GameTime);
            Assert.AreEqual(false, model.GamePaused);
            Assert.AreEqual(false, model.Victory);
            Assert.AreEqual(4, model.Data.Size);
            Assert.AreEqual(0, model.Data.XPos);
            Assert.AreEqual(0, model.Data.YPos);
        }

        [TestMethod]
        public void MoveTest()
        {
            model.Load(1);

            model.Move(Direction.Right);
            Assert.AreEqual(0, model.Data.YPos);
            model.Move(Direction.Left);
            Assert.AreEqual(0, model.Data.YPos);
            model.Move(Direction.Down);
            Assert.AreEqual(0, model.Data.XPos);
            model.Move(Direction.Up);
            Assert.AreEqual(1, model.Data.XPos);
        }

        [TestMethod]
        public void VictoryTest()
        {
            model.Load(1);
            Assert.AreEqual(false, model.Victory);
            model.Move(Direction.Up);
            model.Move(Direction.Up);
            model.Move(Direction.Up);
            model.Move(Direction.Right);
            model.Move(Direction.Right);
            model.Move(Direction.Right);
            Assert.AreEqual(true, model.Victory);
        }

        [TestMethod]
        public void VisibilityTest()
        {
            model.Load(1);
            Assert.AreEqual(true, model.Data.Visible[0,0]);
            Assert.AreEqual(true, model.Data.Visible[0,1]);
            Assert.AreEqual(false, model.Data.Visible[0,2]);
            Assert.AreEqual(false, model.Data.Visible[0,3]);
            Assert.AreEqual(true, model.Data.Visible[1,0]);
            Assert.AreEqual(true, model.Data.Visible[1,1]);
            Assert.AreEqual(false, model.Data.Visible[1,2]);
            Assert.AreEqual(false, model.Data.Visible[1,3]);
        }
    }
}