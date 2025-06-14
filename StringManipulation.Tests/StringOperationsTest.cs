using Microsoft.Extensions.Logging;
using Moq;
using StringManipulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StringManipulationTest
{
    public class StringOperationsTest
    {
        [Fact]
        public void ConcatenateStrings()
        {
            //STRUCTURA TRIPLE AAA
            //Arrange
            var strOperation = new StringOperations();
            //Act
            var result = strOperation.ConcatenateStrings("Hola", "visual");
            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal("Hola visual", result);
        }

        [Fact(Skip = "Esta prueba no es valida en este momento, TICKET-0001 ")]
        public void ConcatenateStrings2()
        {
            //Arrange
            var strOperation = new StringOperations();
            //Act
            var result = strOperation.ConcatenateStrings("Hola", "visual");
            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal("Hola visual", result);
        }

        [Fact]
        public void ReverseString()
        {
            var strOperation = new StringOperations();
            var result = strOperation.ReverseString("Hola");
            Assert.Equal("aloH", result);
        }

        [Fact]
        public void GetStringLength_Exeption()
        {
            var strOperation = new StringOperations();
            Assert.ThrowsAny<ArgumentNullException>(()=>strOperation.GetStringLength(null));
        }

        [Fact]
        public void GetStringLength()
        {
            var strOperation = new StringOperations();
            var result = strOperation.GetStringLength("Hola");
            Assert.Equal(4, result);
        }

        [Fact]
        public void RemoveWhitespace()
        {
            var strStringManipulation = new StringOperations();
            var result = strStringManipulation.RemoveWhitespace("Hola, esta es una prueba");
            Assert.DoesNotContain(" ", result);
        }

        [Fact]
        public void IsPalindrome_True()
        {
            var strOperation = new StringOperations();
            var result = strOperation.IsPalindrome("ama");
            Assert.True(result);
        }

        [Fact]
        public void IsPalindrome_False()
        {
            var strOperation = new StringOperations();
            var result = strOperation.IsPalindrome("Hola");
            Assert.False(result);
        }

        [Fact]
        public void QuantintyInWords()
        {
            var strOperation = new StringOperations();
            var result = strOperation.QuantintyInWords("Cat", 10);
            Assert.StartsWith("diez", result);
            Assert.Contains("Cat",result);
        }

        [Theory]
        [InlineData("V",5)]
        [InlineData("X", 10)]
        //[InlineData("P", 1)]
        public void FromRomanToNumber(string romanNumber, int expected)
        {
            var strOperation = new StringOperations();
            var result = strOperation.FromRomanToNumber(romanNumber);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CountOccurrences()
        {
            var mockLogger = new Moq.Mock <ILogger<StringOperations>>();
            var strOperation = new StringOperations(mockLogger.Object);
            char a = 'a';
            var result = strOperation.CountOccurrences("Hello Platzi Team", a);
            Assert.Equal(2, result);
        }

        [Fact]
        public void ReadFile()
        {
            var strOperation = new StringOperations();
            var readFile = new Mock<IFileReaderConector>();
            //readFile.Setup(p => p.ReadString("information.txt")).Returns("Reading File");
            readFile.Setup(p => p.ReadString(It.IsAny<string>())).Returns("Reading File");


            var result = strOperation.ReadFile(readFile.Object, "file.txt");
            Assert.Equal("Reading File", result);
        }
    }
}


