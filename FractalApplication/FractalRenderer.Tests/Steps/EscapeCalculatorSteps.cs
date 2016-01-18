using FluentAssertions;
using FractalRenderer.Tests.Contexts;
using onetruejones.Domain;

namespace FractalRenderer.Tests.Steps
{
    using TechTalk.SpecFlow;

    [Binding]
    public class EscapeCalculatorSteps : Steps
    {
        private readonly EscapeCalculatorContext escapeCalculatorContext;

        public EscapeCalculatorSteps(EscapeCalculatorContext escapeCalculatorContext)
        {
            this.escapeCalculatorContext = escapeCalculatorContext;
        }

        [Given(@"I have a maximum iteration value of (.*)")]
        public void GivenIHaveAMaximumIterationValueOf(int maximumNumberOfIterations)
        {
            escapeCalculatorContext.MaximumIterations = maximumNumberOfIterations;
        }

        [Given(@"a start point of (.*) by (.*)")]
        public void GivenAStartPointOfBy(double x, double y)
        {
            escapeCalculatorContext.StartingPoint = new PointD(x, y);
        }

        [When(@"I run the iteration algorithm")]
        public void WhenIRunTheIterationAlgorithm()
        {
            escapeCalculatorContext.Iterations = escapeCalculatorContext.EscapeCalculator.Iterations(escapeCalculatorContext.StartingPoint,
                escapeCalculatorContext.MaximumIterations);
        }

        [Then(@"the number of iterations returned should be (.*)")]
        public void ThenTheNumberOfIterationsReturnedShouldBe(int expectedNumberOfIterations)
        {
            escapeCalculatorContext.Iterations.Should().Be(expectedNumberOfIterations);
        }
    }
}