﻿namespace Domain.Tests
{
    using System.Linq;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using onetruejones.Domain;

    [TestClass]
    public class MathsTests
    {
        [TestMethod]
        public void TestIntRangeWithTwoValues()
        {
            const int Steps = 2;
            const int Start = 1;
            const int End = 11;

            var intRange = Maths.IntRange(Steps, Start, End);

            intRange.Count().Should().Be(Steps);
            intRange.First().Should().Be(Start);
            intRange.Last().Should().Be(End);
        }

        [TestMethod]
        public void TestIntRangeWithThreeValues()
        {
            const int Steps = 3;
            const int Start = 1;
            const int End = 3;

            var intRange = Maths.IntRange(Steps, Start, End);

            intRange.Count().Should().Be(Steps);
            intRange.First().Should().Be(Start);
            intRange.Last().Should().Be(End);
            intRange.ToArray()[1].Should().Be(2);
        }

        [TestMethod]
        public void TestIntRangeWithFiveValues()
        {
            const int Steps = 5;
            const int Start = 1;
            const int End = 4;

            var intRange = Maths.IntRange(Steps, Start, End);

            intRange.Count().Should().Be(Steps);
            intRange.First().Should().Be(Start);
            intRange.Last().Should().Be(End);
        }

        [TestMethod]
        public void TestFloatRangeWithThreeValues()
        {
            var steps = 3;
            var start = 1f;
            var end = 3f;

            var floatRange = Maths.FloatRange(steps, start, end);
            floatRange.Length.Should().Be(steps);
            floatRange[0].Should().Be(start);
            floatRange[2].Should().Be(end);
            floatRange[1].Should().Be(2f);
        }
    }
}
