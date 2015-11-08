using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConwaysGameOfLife;




namespace UnitTestsConwaysGameOfLife
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TwoOfTheSameBoardAreEqual()
        {
            bool[,] board1 = new bool[2, 2] { { false, true }, { true, true } };
            bool[,] board2 = new bool[2, 2] { { false, true }, { true, true } };
            CollectionAssert.AreEquivalent(board2, board1);
        }

        [TestMethod]
        public void TwoDifferentBoardsAreNotEqual()
        {
            bool[,] board1 = new bool[2, 2] { { false, true }, { true, true } };
            bool[,] board2 = new bool[2, 2] { { true, true }, { true, true } };
            CollectionAssert.AreNotEquivalent(board2, board1);
        }

        [TestMethod]
        public void RuleOneWithOneAliveInSmallSquare()
        {
            ConwaysGOL board1 = new ConwaysGOL( new bool[2, 2] { { false, true }, { true, true } });
            bool[,] board2 = new bool[2, 2] { { true, true }, { true, true } };
            CollectionAssert.AreEquivalent(board2, board1.RuleOne());
        }

        [TestMethod]
        public void RuleOneWithTwoAliveInSmallSquare()
        {
            ConwaysGOL board1 = new ConwaysGOL(new bool[2, 2] { { false, true }, { true, false } });
            bool[,] board2 = new bool[2, 2] { { true, true }, { true, true } };
            CollectionAssert.AreEquivalent(board2, board1.RuleOne());
        }

        [TestMethod]
        public void RuleOneWithOneAliveInBigSquare()
        {
            ConwaysGOL board1 = new ConwaysGOL(new bool[3, 3] { { true, true, true }, { true, false, true }, { true, true, true } });
            bool[,] board2 =new bool[3, 3] { { true, true, true }, { true, true, true }, { true, true, true } };
            CollectionAssert.AreEquivalent(board2, board1.RuleOne());
        }

        [TestMethod]
        public void RuleOneWithTwoNonneighborsAliveInBigSquare()
        {
            ConwaysGOL board1 = new ConwaysGOL(new bool[3, 3] { { false, true, true }, { true, true, true }, { true, true, false } });
            bool[,] board2 = new bool[3, 3] { { true, true, true }, { true, true, true }, { true, true, true } };
            CollectionAssert.AreEquivalent(board2, board1.RuleOne());
        }

        [TestMethod]
        public void RuleOneWithTwoNextToNeighborsAliveInBigSquare()
        {
            ConwaysGOL board1 = new ConwaysGOL(new bool[3, 3] { { false, false, true }, { true, true, true }, { true, true, true } });
            bool[,] board2 = new bool[3, 3] { { true, true, true }, { true, true, true }, { true, true, true } };
            CollectionAssert.AreEquivalent(board2, board1.RuleOne());
        }

        [TestMethod]
        public void RuleOneWithThreeNextToNeighborsAliveInBigSquare()
        {
            ConwaysGOL board1 = new ConwaysGOL(new bool[3, 3] { { false, false, true }, { false, true, true }, { true, true, true } });
            bool[,] board2 = new bool[3, 3] { { true, true, true }, { false, true, true }, { true, true, true } };
            CollectionAssert.AreEquivalent(board2, board1.RuleOne());
        }

        [TestMethod]
        public void RuleTwoWithTwoNeighbors()
        {
            ConwaysGOL board1 = new ConwaysGOL(new bool[3, 3] { { true, false, true }, { true, false, true }, { true, false, true } });
            bool[,] board2 = new bool[3, 3] { { true, true, true }, { true, false, true }, { true, true, true } };
            CollectionAssert.AreEquivalent(board2, board1.RuleTwo());
        }

        [TestMethod]
        public void RuleTwoWithThreeNeighbors()
        {
            ConwaysGOL board1 = new ConwaysGOL(new bool[3, 3] { { false, true, false }, { true, false, true }, { true, true, false } });
            bool[,] board2 = new bool[3, 3] { { true, true, true }, { true, false, true }, { true, true, true } };
            CollectionAssert.AreEquivalent(board2, board1.RuleTwo());
        }

        [TestMethod]
        public void RuleThreeWhereOneDies()
        {
            ConwaysGOL board1 = new ConwaysGOL(new bool[3, 3] { { false, true, false }, { false, false, false }, { false, true, false } });
            bool[,] board2 = new bool[3, 3] { { false, true, false }, { false, true, false }, { false, true, false } };
            CollectionAssert.AreEquivalent(board2, board1.RuleThree());
        }

        [TestMethod]
        public void RuleThreeWhereTwoDie()
        {
            ConwaysGOL board1 = new ConwaysGOL(new bool[3, 3] { { false, false, false }, { false, true, false }, { false, false, false } });
            bool[,] board2 = new bool[3, 3] { { false, true, false }, { true, true, true }, { false, true, false } };
            CollectionAssert.AreEquivalent(board2, board1.RuleThree());
        }

        [TestMethod]
        public void RuleFourSmallGrid()
        {
            ConwaysGOL board1 = new ConwaysGOL(new bool[2, 2] { { false, false }, { false, true } } );
            bool[,] board2 = new bool[2, 2] { { false, false},  { false, false } };
            CollectionAssert.AreEquivalent(board2, board1.RuleFour());
        }

        [TestMethod]
        public void RuleFourBigGrid()
        {
            ConwaysGOL board1 = new ConwaysGOL(new bool[3, 3] { { false, true, true }, { true, true, true }, { false, true, false } });
            bool[,] board2 = new bool[3, 3] { { true, true, true }, { true, false, true }, { true, true, true} };
            CollectionAssert.AreEquivalent(board2, board1.RuleFour());
        }

        [TestMethod]
        public void AllRulesTestOne()
        {
            ConwaysGOL board1 = new ConwaysGOL(new bool[3, 3] { { false, true, true }, { true, true, true }, { false, true, false } });
            bool[,] board2 = new bool[3, 3] { { true, true, true }, { true, false, true }, { true, true, true } };
            CollectionAssert.AreEquivalent(board2, board1.Play());
        }

        [TestMethod]
        public void AllRulesTestTwo()
        {
            ConwaysGOL board1 = new ConwaysGOL(new bool[3, 3] { { false, true, false }, { false, true, false }, { false, true, false } });
            bool[,] board2 = new bool[3, 3] { { true, true, true }, { false, false, false}, { true, true, true } };
            CollectionAssert.AreEquivalent(board2, board1.Play());
        }

    }
}
