using System;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DelegateMethodParameters
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void DelegateHasSingleParameter()
        {
            Assert.IsTrue(HasParameters(GetDelegateWithOneParameter<object>(), 1));
        }

        [TestMethod]
        public void DelegateHasTwoParameters()
        {
            Assert.IsTrue(HasParameters(GetDelegateWithTwoParameters<object>(), 2));
        }

        #region TO_IMPLEMENT
        private static Action<T> GetDelegateWithOneParameter<T>()
        {
            return x => { };
        }

        private static Action<T> GetDelegateWithTwoParameters<T>()
        {
            var lambda = Expression.Lambda(typeof(Action<T>), Expression.Empty(), Expression.Parameter(typeof(T)));
            return (Action<T>)lambda.Compile();
        }

        #endregion TO_IMPLEMENT

        private static bool HasParameters<T>(Action<T> @delegate, int numParameters)
        {
            return @delegate.Method.GetParameters().Length == numParameters;
        }
    }
}
