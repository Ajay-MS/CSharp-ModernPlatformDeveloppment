using CalculatorLib;

namespace CalculatorLibUnitTests
{
    public class CalculatorUnitTests
    {
        [Fact]
        public void TestAdding2And3()
        {
            // arranage 
            double a = 2;
            double b = 3;
            double expected = 5;
            Calculator calculator = new();

            // act 
            double actual = calculator.Add(a, b);

            // assert 
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestAdding2And2()
        {
            // arranage 
            double a = 2;
            double b = 2;
            double expected = 4;
            Calculator calculator = new();

            // act 
            double actual = calculator.Add(a, b);

            // assert 
            Assert.Equal(expected, actual);
        }
    }
}