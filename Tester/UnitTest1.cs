using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwentyFortyEight;
using System;

namespace Tester {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestGetStateString() {
            var inputString = "2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0";
            var state = BoardState.Load(inputString);
            var stateString = state.GetStateString();
            Assert.AreEqual(inputString.Trim(','), stateString.Trim(','));
        }

        [TestMethod]
        public void TestLeft() {
            var inputString = "0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0";
            var state = BoardState.Load(inputString);
            state.Left();
            var stateString = state.GetStateString();
            var targetOutput = "2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            Assert.AreEqual(targetOutput, stateString);

            inputString = "0,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0";
            state = BoardState.Load(inputString);
            state.Left();
            stateString = state.GetStateString();
            targetOutput = "4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            Assert.AreEqual(targetOutput, stateString);

            inputString = "2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0";
            state = BoardState.Load(inputString);
            state.Left();
            stateString = state.GetStateString();
            targetOutput = "4,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            Assert.AreEqual(targetOutput, stateString);

            inputString = "2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0";
            state = BoardState.Load(inputString);
            state.Left();
            stateString = state.GetStateString();
            targetOutput = "4,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            Assert.AreEqual(targetOutput, stateString);

            inputString = "2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,64";
            state = BoardState.Load(inputString);
            state.Left();
            stateString = state.GetStateString();
            targetOutput = "4,2,0,0,0,0,0,0,0,0,0,0,64,0,0,0";
            Assert.AreEqual(targetOutput, stateString);
        }

        [TestMethod]
        public void TestRight() {
            var inputString = "0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0";
            var state = BoardState.Load(inputString);
            state.Right();
            var stateString = state.GetStateString();
            var targetOutput = "0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0";
            Assert.AreEqual(targetOutput, stateString);

            inputString = "0,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0";
            state = BoardState.Load(inputString);
            state.Right();
            stateString = state.GetStateString();
            targetOutput = "0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0";
            Assert.AreEqual(targetOutput, stateString);

            inputString = "2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0";
            state = BoardState.Load(inputString);
            state.Right();
            stateString = state.GetStateString();
            targetOutput = "0,0,2,4,0,0,0,0,0,0,0,0,0,0,0,0";
            Assert.AreEqual(targetOutput, stateString);

            inputString = "2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0";
            state = BoardState.Load(inputString);
            state.Right();
            stateString = state.GetStateString();
            targetOutput = "0,0,4,4,0,0,0,0,0,0,0,0,0,0,0,0";
            Assert.AreEqual(targetOutput, stateString);

            inputString = "2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,64";
            state = BoardState.Load(inputString);
            state.Right();
            stateString = state.GetStateString();
            targetOutput = "0,0,2,4,0,0,0,0,0,0,0,0,0,0,0,64";
            Assert.AreEqual(targetOutput, stateString);

            inputString = "2,2,2,0,0,0,0,0,0,0,0,0,0,64,0,0";
            state = BoardState.Load(inputString);
            state.Right();
            stateString = state.GetStateString();
            targetOutput = "0,0,2,4,0,0,0,0,0,0,0,0,0,0,0,64";
            Assert.AreEqual(targetOutput, stateString);
        }
    }
}
