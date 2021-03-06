﻿using System;
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
            // declare and initialize new Dominos
            Domino d1 = new Domino(1,1);
            Domino d2 = new Domino(2, 2);

            // playaTrain ToString should result in empty string
            Assert.AreEqual(playaTrain.ToString(), "");

            // add d1 and d2 to mexiTrain
            mexiTrain.Add(d1);
            mexiTrain.Add(d2);
            // mexiTrain ToString should now result in list of stringified d1 and d2
            Assert.AreEqual(mexiTrain.ToString(), "Side 1: 1  Side 2: 1" + "/n" + "Side 1: 2  Side 2: 2" + "/n");
        }

        [Test]
        public void TestTrainCount()
        {
            // declare and initialize new Boneyard
            BoneYard b6 = new BoneYard(6);
            // declare and initialize new Hand
            Hand playaHand = new Hand(b6, 4);
            // declare and initialize new Mexican train
            MexicanTrain mexiTrain = new MexicanTrain(1);
            // declare and initialize new Player train
            PlayerTrain playaTrain = new PlayerTrain(playaHand, 6);
            // declare and initialize new Dominos
            Domino d1 = new Domino(1, 1);
            Domino d2 = new Domino(2, 2);
            Domino d3 = new Domino(3, 0);

            // count of mexiTrain should be equal to 0
            Assert.AreEqual(mexiTrain.Count, 0);
            // add d1 to mexiTrain
            mexiTrain.Add(d1);
            // count of mexiTrain should now be equal to 1
            Assert.AreEqual(mexiTrain.Count, 1);

            // add d2 and d3 to playaTrain
            playaTrain.Add(d2);
            playaTrain.Add(d3);
            // count of playaTrain should be equal to 2
            Assert.AreEqual(playaTrain.Count, 2);
        }

        [Test]
        public void TestTrainEngineValue()
        {
            // declare and initialize new Boneyard
            BoneYard b6 = new BoneYard(6);
            // declare and initialize new Hand
            Hand playaHand = new Hand(b6, 4);
            // declare and initialize new Mexican trains
            MexicanTrain mexiTrain = new MexicanTrain(6);
            MexicanTrain mexi2Train = new MexicanTrain(4);
            // declare and initialize new Player train
            PlayerTrain playaTrain = new PlayerTrain(playaHand, 6);


            // engine value of mexiTrain should be equal to 6
            Assert.AreEqual(mexiTrain.EngineValue, 6);

            // engine value of mexi2Train should be equal to 4
            Assert.AreEqual(mexi2Train.EngineValue, 4);
        }

        [Test]
        public void TestTrainIsEmpty()
        {
            // declare and initialize new Boneyard
            BoneYard b6 = new BoneYard(6);
            // declare and initialize new Hand
            Hand playaHand = new Hand(b6, 4);
            // declare and initialize new Mexican train
            MexicanTrain mexiTrain = new MexicanTrain(1);
            // declare and initialize new Player train
            PlayerTrain playaTrain = new PlayerTrain(playaHand, 2);
            // declare and initialize new Dominos
            Domino d1 = new Domino(1, 1);
            Domino d2 = new Domino(2, 2);

            // both trains should return true for IsEmpty
            Assert.True(mexiTrain.IsEmpty);
            Assert.True(playaTrain.IsEmpty);

            // add d1 to mexiTrain
            mexiTrain.Add(d1);
            // mexiTrain should now return false for IsEmpty
            Assert.False(mexiTrain.IsEmpty);

            // add d2 to playaTrain
            playaTrain.Add(d2);
            // playaTrain should now return false for IsEmpty
            Assert.False(playaTrain.IsEmpty);
        }
        [Test]
        public void TestLastDomino()
        {
            // declare and initialize new Boneyard
            BoneYard b6 = new BoneYard(6);
            // declare and initialize new Hand
            Hand playaHand = new Hand(b6, 4);
            // declare and initialize new Mexican train
            MexicanTrain mexiTrain = new MexicanTrain(3);
            // declare and initialize new Player train
            PlayerTrain playaTrain = new PlayerTrain(playaHand, 6);
            // declare and initialize new Dominos
            Domino d1 = new Domino(1, 1);
            Domino d2 = new Domino(2, 2);
            Domino d3 = new Domino(3, 0);

            // add d3 to mexiTrain
            mexiTrain.Add(d3);
            // last domino of mexiTrain should be equal to d3 stringified
            Assert.AreEqual(mexiTrain.LastDomino.ToString(), "Side 1: 3  Side 2: 0");

            playaTrain.Add(d2);
            playaTrain.Add(d1);
            // last domino of playaTrain should be equal to d1 stringified
            Assert.AreEqual(playaTrain.LastDomino.ToString(), "Side 1: 1  Side 2: 1");
        }

        [Test]
        public void TestPlayableValue()
        {
            // declare and initialize new Boneyard
            BoneYard b6 = new BoneYard(6);
            // declare and initialize new Hand
            Hand playaHand = new Hand(b6, 4);
            // declare and initialize new Mexican train
            MexicanTrain mexiTrain = new MexicanTrain(2);
            // declare and initialize new Player train
            PlayerTrain playaTrain = new PlayerTrain(playaHand, 3);
            // declare and initialize new Dominos
            Domino d1 = new Domino(1, 1);
            Domino d2 = new Domino(2, 2);
            Domino d3 = new Domino(3, 0);

            mexiTrain.Add(d2);
            // mexiTrain playable value should be equal to 2 (engineValue)
            Assert.AreEqual(mexiTrain.PlayableValue, 2);

            playaTrain.Add(d3);
            // playaTrain playable value should be equal to 0 (side 2 of d3)
            Assert.AreEqual(playaTrain.PlayableValue, 0);
        }

        // Add method is used in the above tests, so no individual test

        [Test]
        public void TestIndexer()
        {
            // declare and initialize new Boneyard
            BoneYard b6 = new BoneYard(6);
            // declare and initialize new Hand
            Hand playaHand = new Hand(b6, 4);
            // declare and initialize new Mexican train
            MexicanTrain mexiTrain = new MexicanTrain(6);
            // declare and initialize new Player train
            PlayerTrain playaTrain = new PlayerTrain(playaHand, 6);
            // declare and initialize new Dominos
            Domino d1 = new Domino(1, 1);
            Domino d2 = new Domino(2, 2);
            Domino d3 = new Domino(3, 0);

            mexiTrain.Add(d1);
            // index 0 of mexiTrain should be equal to stringified d1
            Assert.AreEqual(mexiTrain[0].ToString(), d1.ToString());

            playaTrain.Add(d3);
            playaTrain.Add(d2);
            // index 1 of playatrain should be equal to stringified d2
            Assert.AreEqual(playaTrain[1].ToString(), d2.ToString());
        }

        [Test]
        public void TestPlay()
        {
            // declare and initialize new Boneyard
            BoneYard b6 = new BoneYard(6);
            // declare and initialize new Hand
            Hand playaHand = new Hand(b6, 4);
            // declare and initialize new Mexican train
            MexicanTrain mexiTrain = new MexicanTrain(1);
            // declare and initialize new Player train
            PlayerTrain playaTrain = new PlayerTrain(playaHand, 3);
            // declare and initialize new Dominos
            Domino d1 = new Domino(1, 1);
            Domino d2 = new Domino(2, 2);
            Domino d3 = new Domino(3, 0);
            Domino d4 = new Domino(1, 3);
            Domino d5 = new Domino(3, 3);

            // add d1, d2, and d3 to playaHand
            playaHand.Add(d1);
            playaHand.Add(d2);
            playaHand.Add(d3);

            // add d5 to playaTrain
            playaTrain.Add(d5);
            // add d1 to mexiTrain
            mexiTrain.Add(d1);

            // playaHand play d3 on playaTrain
            playaTrain.Play(playaHand, d3);
            // playaHand play d4 on mexiTrain
            mexiTrain.Play(playaHand, d4);

            // domino at index 1 of playaTrain should be equal to stringified d3
            Assert.AreEqual(playaTrain[1].ToString(), d3.ToString());
            // domino at index 1 of mexiTrain should be equal to stringified d1
            Assert.AreEqual(mexiTrain[1].ToString(), d4.ToString());

        }

        // Player Train Members
        [Test]
        public void PlayerTrainOpenMethods()
        {
            // declare and initialize new Boneyard
            BoneYard b6 = new BoneYard(6);
            // declare and initialize new Hand
            Hand playaHand = new Hand(b6, 4);
            // declare and initialize new Player train
            PlayerTrain playaTrain = new PlayerTrain(playaHand, 1);
            // declare and initialize new Dominos
            Domino d1 = new Domino(1, 1);
            Domino d4 = new Domino(1, 3);

            // playaTrain should return false (default) for IsOpen
            Assert.False(playaTrain.IsOpen);

            playaTrain.Add(d1);
            playaTrain.Add(d4);

            // playaTrain still return false (default) for IsOpen
            Assert.False(playaTrain.IsOpen);

            // open playaTrain
            playaTrain.Open();

            // playaTrain should now return true for IsOpen
            Assert.True(playaTrain.IsOpen);
        }

        [Test]
        public void TestPlayerTrainClose()
        {
            // declare and initialize new Boneyard
            BoneYard b6 = new BoneYard(6);
            // declare and initialize new Hand
            Hand playaHand = new Hand(b6, 4);
            // declare and initialize new Player train
            PlayerTrain playaTrain = new PlayerTrain(playaHand, 1);
            // declare and initialize new Dominos
            Domino d1 = new Domino(1, 1);
            Domino d4 = new Domino(1, 3);

            // playaTrain should return false (default) for IsOpen
            Assert.False(playaTrain.IsOpen);

            playaTrain.Add(d1);
            playaTrain.Add(d4);

            // open playaTrain
            playaTrain.Open();

            // playaTrain should now return true for IsOpen
            Assert.True(playaTrain.IsOpen);

            // close playaTrain
            playaTrain.Close();

            // playaTrain should now return false for IsOpen
            Assert.False(playaTrain.IsOpen);
        }
        // overridden IsPlayable method
        [Test]
        public void TestPlayerTrainIsPlayableNoFlip()
        {
            // declare and initialize new Boneyard
            BoneYard b6 = new BoneYard(6);
            // declare and initialize new Hand
            Hand playaHand = new Hand(b6, 4);

            // declare and initialize new Player train
            PlayerTrain playaTrain = new PlayerTrain(playaHand, 3);

            // declare and initialize new Dominos
            Domino d1 = new Domino(1, 1);
            Domino d2 = new Domino(2, 2);
            Domino d3 = new Domino(3, 0);
            Domino d4 = new Domino(1, 3);
            Domino d5 = new Domino(3, 3);

            // add d1, d2, and d3 to playaHand
            playaHand.Add(d1);
            playaHand.Add(d2);
            playaHand.Add(d3);

            // add d5 to playaTrain
            playaTrain.Add(d5);

            // playaHand attempting to play d3 on playaTrain should return true
            Assert.True(playaTrain.IsPlayable(playaHand, d3, out bool mustFlip));
        }
        [Test]
        public void TestPlayerTrainIsPlayableBasic()
        {
            // declare and initialize new Boneyard
            BoneYard b6 = new BoneYard(6);
            // declare and initialize new Hands
            Hand playaHand = new Hand(b6, 4);
            Hand playa2Hand = new Hand(b6, 4);
            // declare and initialize new Player trains
            PlayerTrain playaTrain = new PlayerTrain(playaHand, 3);
            PlayerTrain playa2Train = new PlayerTrain(playa2Hand, 3);
            // declare and initialize new Dominos
            Domino d1 = new Domino(1, 1);
            Domino d2 = new Domino(2, 2);
            Domino d3 = new Domino(3, 0);
            Domino d4 = new Domino(1, 3);
            Domino d5 = new Domino(3, 3);
            Domino d6 = new Domino(5, 3);

            // add d1, d2, and d3 to playaHand
            playaHand.Add(d1);
            playaHand.Add(d2);
            playaHand.Add(d3);
            // add d6 to playa2Hand
            playa2Hand.Add(d6);

            // add d5 to playaTrain
            playaTrain.Add(d5);

            // playa2Hand attempting to play on playaTrain should return false
            Assert.False(playaTrain.IsPlayable(playa2Hand, d6, out bool mustFlip));

            // playaHand attempting to play d1 on playaTrain should return false
            Assert.False(playaTrain.IsPlayable(playaHand, d1, out mustFlip));

            // playaHand attempting to play d3 on playaTrain should return true
            Assert.True(playaTrain.IsPlayable(playaHand, d3, out mustFlip));
        }
        [Test]
        public void TestPlayerTrainIsPlayableFlip()
        {
            // declare and initialize new Boneyard
            BoneYard b6 = new BoneYard(6);
            // declare and initialize new Hand
            Hand playa2Hand = new Hand(b6, 4);
            // declare and initialize new Player train
            PlayerTrain playa2Train = new PlayerTrain(playa2Hand, 3);
            // declare and initialize new Dominos
            Domino d5 = new Domino(3, 3);
            Domino d6 = new Domino(5, 3);

            // add d6 to playa2Hand
            playa2Hand.Add(d6);

            // add d5 to playa2Train
            playa2Train.Add(d5);

            // playa2Hand attempting to play on playa2Train should return true
            Assert.True(playa2Train.IsPlayable(playa2Hand, d6, out bool mustFlip));

        }
        [Test]
        public void TestMexicanTrainIsPlayableNoFlip()
        {
            // declare and initialize new Boneyard
            BoneYard b6 = new BoneYard(6);
            // declare and initialize new Hands
            Hand playaHand = new Hand(b6, 4);
            Hand playa2Hand = new Hand(b6, 4);
            // declare and initialize new Mexican train
            MexicanTrain mexiTrain = new MexicanTrain(6);
            // declare and initialize new Dominos
            Domino d6 = new Domino(5, 3);
            Domino d7 = new Domino(3, 6);
            Domino d8 = new Domino(6, 6);
            Domino d9 = new Domino(6, 1);
            Domino d10 = new Domino(6, 3);

            // add d10 to playaHand
            playaHand.Add(d10);
            // add d9 to playa2Hand
            playa2Hand.Add(d9);

            // add d8 to mexiTrain
            mexiTrain.Add(d8);

            // playa2Hand attempting to play d9 should return true
            Assert.True(mexiTrain.IsPlayable(playa2Hand, d9, out bool mustFlip));

            // playaHand attempting to play d10 should return true
            Assert.True(mexiTrain.IsPlayable(playaHand, d10, out mustFlip));
        }

        [Test]
        public void TestMexicanTrainIsPlayableFlip()
        {
            // declare and initialize new Boneyard
            BoneYard b6 = new BoneYard(6);
            // declare and initialize new Hands
            Hand playaHand = new Hand(b6, 4);
            Hand playa2Hand = new Hand(b6, 4);
            // declare and initialize new Mexican train
            MexicanTrain mexiTrain = new MexicanTrain(6);
            // declare and initialize new Dominos
            Domino d6 = new Domino(5, 3);
            Domino d7 = new Domino(3, 6);
            Domino d8 = new Domino(6, 6);
            Domino d9 = new Domino(6, 1);

            // add d6 and d7 to playaHand
            playaHand.Add(d6);
            playaHand.Add(d7);
            // add d9 to playa2Hand
            playa2Hand.Add(d9);

            // add d8 to mexiTrain
            mexiTrain.Add(d8);

            // playaHand attempting to play d7 should return true
            Assert.True(mexiTrain.IsPlayable(playaHand, d7, out bool mustFlip));
        }

        [Test]
        public void TestMexicanTrainIsPlayableBasic()
        {
            // declare and initialize new Boneyard
            BoneYard b6 = new BoneYard(6);
            // declare and initialize new Hands
            Hand playaHand = new Hand(b6, 4);
            Hand playa2Hand = new Hand(b6, 4);
            // declare and initialize new Mexican train
            MexicanTrain mexiTrain = new MexicanTrain(6);
            // declare and initialize new Dominos
            Domino d6 = new Domino(5, 3);
            Domino d7 = new Domino(3, 6);
            Domino d8 = new Domino(6, 6);
            Domino d9 = new Domino(6, 1);
            Domino d10 = new Domino(6, 3);

            // add d9 to playa2Hand
            playa2Hand.Add(d9);

            // add d6 and d7 to playaHand
            playaHand.Add(d6);

            // add d8 to mexiTrain
            mexiTrain.Add(d8);

            // playa2Hand attempting to play d9 should return true
            Assert.True(mexiTrain.IsPlayable(playa2Hand, d9, out bool mustFlip));

            // playaHand attempting to play d6 should return false
            Assert.False(mexiTrain.IsPlayable(playaHand, d6, out mustFlip));
        }
    }
}
