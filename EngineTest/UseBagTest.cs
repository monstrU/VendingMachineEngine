using NUnit.Framework;
using VendingMachineEngine.Model;
using VendingMachineEngine.Model.ObjectExtentions;

namespace EngineTest
{
    [TestFixture]
    public class UseBagTest
    {
        [Test]
        public static void ShowCoinsInUserBugTest()
        {
            const int oneRurCount = 10;
            const int twoRurCount = 30;
            const int fiveRurCount = 20;
            const int tenRurCount = 15;

            var userBug = new BugModel();
            userBug.InitUserBug();
            var oneRurs= userBug.ShowOneRublesCount();
            Assert.AreEqual(oneRurs, oneRurCount);

            var twoRurs = userBug.ShowTwoRublesCount();
            Assert.AreEqual(twoRurs, twoRurCount);

            var fiveRurs = userBug.ShowFiveRublesCount();
            Assert.AreEqual(fiveRurs, fiveRurCount);

            var tenRurs = userBug.ShowTenRublesCount();
            Assert.AreEqual(tenRurs, tenRurCount);

        }

        
    }
}
