using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tipograf;

namespace UnitTestDZ
{
    
    internal class TestTypographer
    {
        [Test]
        public void TestDontMoreSpace()
        {
            var typographer = new Typographer();
            string text = "Hello     Word";
            Assert.That(typographer.DontMoreSpace(text) == "Hello Word", Is.True);
        }
        [Test]
        public void TestNumericValuesInStaples()
        {
            var typographer = new Typographer();
            string text = "Приблизительное число: 90,01±0,001 ";
            Assert.That(typographer.NumericValuesInStaples(text) == "Приблизительное число: (90,01±0,001) ", Is.True);
        }
        [Test]
        public void TestNumericValuesInStaples2()
        {
            var typographer = new Typographer();
            string text = "Приблизительное число: 90,01∓0,001 ";
            Assert.That(typographer.NumericValuesInStaples2(text) == "Приблизительное число: (90,01∓0,001) ", Is.True);
        }
        [Test]
        public void TestValueOccurrenceIndexes()
        {
            string text = " 2±0,1 + 6±0,123 = ...±... ";
            var occurrences = new SearchOccurrences();
            Assert.That(occurrences.ValueOccurrenceIndexes(text).Count == 3, Is.True);
        }
        [Test]
        public void TestValueOccurrenceIndexes2()
        {
            string text = " 2∓0,1 + 6∓0,123 = ...∓... ";
            var occurrences = new SearchOccurrences();
            Assert.That(occurrences.ValueOccurrenceIndexes2(text).Count == 3, Is.True);
        }
        [Test]
        public void TestCheckPlusAndMinus() 
        {
            string text = " 2+-0,1 + 6+-0,123 = ...+-... ";
            var typographer = new Typographer();
            Assert.That(typographer.CheckPlusAndMinus(text) == " 2±0,1 + 6±0,123 = ...±... ", Is.True);
        }
        [Test]
        public void TestCheckMinusAndPlus()
        {
            string text = " 2-+0,1 + 6-+0,123 = ...-+... ";
            var typographer = new Typographer();
            Assert.That(typographer.CheckMinusAndPlus(text) == " 2∓0,1 + 6∓0,123 = ...∓... ", Is.True);
        }
        [Test]
        public void TestCheckDegreeSquare()
        {
            var typographer = new Typographer();
            string text = "2^2 = 4";
            Assert.That(typographer.CheckDegreeSquare(text) == "2² = 4", Is.True);
        }
        [Test]
        public void TestCheckDegreeCube()
        {
            var typographer = new Typographer();
            string text = "2^3 = 8";
            Assert.That(typographer.CheckDegreeCube(text) == "2³ = 8", Is.True);
        }
        [Test]
        public void ReplaceEllipsis()
        {
            var typographer = new Typographer();
            string text = "Продолжение следует...";
            Assert.That(typographer.ReplaceEllipsis(text) == "Продолжение следует…", Is.True);
        }

    }
}
