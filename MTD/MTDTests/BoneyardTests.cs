using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MTDClasses;
using NUnit.Framework;

namespace MTDTests
{
    [TestFixture]
    public class BoneyardTests
    {
        [Test]
        public void TestConstructor()
        {
            // declared and initialized new BoneYard with max number of 6 dots
            BoneYard b6 = new BoneYard(6);

            // dominos remaining in b6 should be equal to 28
            Assert.AreEqual(28, b6.DominosRemaining);

            // created new domino with both sides 0, should be equal to index 0
            Assert.AreEqual(new Domino(0, 0), b6[0]);
            // created new domino with both sides 6, should be equal to index 27
            Assert.AreEqual(new Domino(6, 6), b6[27]);
            // created new domino with both sides 1, should be equal to index 7
            Assert.AreEqual(new Domino(1, 1), b6[7]);
        }

        [Test]
        public void TestShuffle()
        {
            BoneYard b6 = new BoneYard(6);
            BoneYard control = new BoneYard(6);

            Assert.AreEqual(b6[0], control[0]);
            Assert.AreEqual(b6[27], control[27]);
            b6.Shuffle();
            Assert.AreNotEqual(b6[0], control[0]);
            Assert.AreNotEqual(b6[27], control[27]);
        }

        [Test]
        public void TestIsEmpty()
        {
            BoneYard b6 = new BoneYard(6);

            Assert.IsFalse(b6.IsEmpty());
           
            for (int i = 0; i < 28; i++)
            {
                b6.Draw();
            }

            Assert.IsTrue(b6.IsEmpty());
        }

        [Test]
        public void TestDominosRemaining()
        {
            BoneYard b6 = new BoneYard(6);
            BoneYard b1 = new BoneYard(1);

            Assert.AreEqual(b6.DominosRemaining, 28);
            Assert.AreEqual(b1.DominosRemaining, 3);
        }


        [Test]
        public void TestDraw()
        {
            BoneYard b6 = new BoneYard(6);

            Domino top = b6[0];
            Assert.AreEqual(b6.DominosRemaining, 28);
            Domino drawn1 = b6.Draw();
            Assert.AreEqual(drawn1.ToString(), top.ToString());
            Assert.AreNotEqual(b6.DominosRemaining, 28);
            
        }

        [Test]
        public void TestToString()
        {
            BoneYard b6 = new BoneYard(6);

            Domino top = b6.Draw();
            Assert.AreEqual(top.ToString(), "Side 1: 0  Side 2: 0");
        }
    }
}
