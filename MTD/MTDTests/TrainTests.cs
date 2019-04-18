using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MTDClasses;
using NUnit.Framework;

namespace MTDTests
{    [TestFixture]
    public class TrainTests
    {
        [Test]
        public void TestTrainConstructors()
        {
            // declare and initialize new Boneyard
            BoneYard b6 = new BoneYard(6);
            // declare and initialize new Hand
            Hand playaHand = new Hand(b6, 4);
            // declare and initialize new Mexican train
            MexicanTrain mexiTrain = new MexicanTrain(6);
            // declare and initialize new Player train
            PlayerTrain playaTrain = new PlayerTrain(playaHand, 6);
            // declare and initialize new Domino
            Domino d1 = new Domino(1,1);

            Assert.True(mexiTrain.IsEmpty);
            Assert.True(playaTrain.IsEmpty);

            mexiTrain.Add(d1);
            Assert.False(mexiTrain.IsEmpty);
        }
    }
}
