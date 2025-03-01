using CarNumberDll_Kuznetsov;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace REG_MARK_LIB_UnitTesting
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void CheckMark_IsCorrectMark()
        {
            bool result = CarNum.CheckMark("А982АА252");
            bool expected = true;
            Assert.AreEqual(expected, result);
        }
        
        [TestMethod]
        public void CheckMark_IsIncorrectMark()
        {
            bool result = CarNum.CheckMark("А982АА25222");
            bool expected = false;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CheckMark_IsCorrectMarkFromTwoLanguagewss()
        {
            bool result = CarNum.CheckMark("K982АА52");
            bool expected = true;
            Assert.AreEqual(expected, result);
        }
        
        [TestMethod]
        public void CheckMark_ResultIsNotNull()
        {
            bool result = CarNum.CheckMark("K982АА52");
            bool expected = true;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetNextMarkAfter_IsCorrect()
        {
            string result = CarNum.GetNextMarkAfter("A123BC77");
            string expected = "A124BC77";
            Assert.AreEqual(expected, result);
        }
  
        [TestMethod]
        public void GetNextMarkAfter_IsNotCorrect()
        {
            string result = CarNum.GetNextMarkAfter("A123BC7237");
            string expected = "Транспортный номер неправильно введён";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetNextMarkAfterInRange_ValidNextNumberInRange_ReturnsNextMark()
        {
            string result = CarNum.GetNextMarkAfterInRange("A123BC77", "A100BC77", "A150BC77");
            Assert.AreEqual("A124BC77", result);
        }

        [TestMethod]
        public void GetNextMarkAfterInRange_NextNumberOutOfRange_ReturnsNoNumbers()
        {
            string result = CarNum.GetNextMarkAfterInRange("A150BC77", "A100BC77", "A150BC77");
            Assert.AreEqual("Номеров нет", result);
        }

        [TestMethod]
        public void GetNextMarkAfterInRange_InvalidInput_ReturnsNoNumbers()
        {
            string result = CarNum.GetNextMarkAfterInRange("INVALID", "A000AA77", "X999YX77");
            Assert.AreEqual("Транспортный номер неправильно введён", result);
        }

        [TestMethod]
        public void GetCombinationsCountInRange_OneNumber_ReturnsOne()
        {
            int result = CarNum.GetCombinationsCountInRange("A123BC77", "A123BC77");
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void GetCombinationsCountInRange_TwoConsecutiveNumbers_ReturnsTwo()
        {
            int result = CarNum.GetCombinationsCountInRange("A123BC77", "A124BC77");
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void GetCombinationsCountInRange_FiveNumbersApart_ReturnsSix()
        {
            int result = CarNum.GetCombinationsCountInRange("A123BC77", "A128BC77");
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void GetCombinationsCountInRange_InvalidInput_ReturnsZero()
        {
            int result = CarNum.GetCombinationsCountInRange("INVALID", "A123BC77");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GetCombinationsCountInRange_FirstNumberHigher_ReturnsZero()
        {
            int result = CarNum.GetCombinationsCountInRange("A999BC77", "A100BC77");
            Assert.AreEqual(0, result);
        }


        [TestMethod]
        public void GetCombinationsCountInRange_IsNotNull()
        {
            var result = CarNum.GetCombinationsCountInRange("Б000КК33", "Б011КК33");
            Assert.IsNotNull(result);
        }
    }
}
