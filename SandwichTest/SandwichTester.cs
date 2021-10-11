using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SandwichTest {
    [TestClass]
    public class SandwichTester {
        [TestMethod]
        public void Fail() {
            Assert.Fail();
        }
    }
}
