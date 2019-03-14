using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DelegateMethodParameters
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void DelegateHasSingleParameter()
        {
            Assert.IsTrue(HasParameters(GetDelegateWithTwoParameters<object>(), 1));
        }

        [TestMethod]
        public void DelegateHasTwoParameters()
        {
            Assert.IsTrue(HasParameters(GetDelegateWithTwoParameters<object>(), 2));
        }

        #region TO_IMPLEMENT
        private static Action<T> GetDelegateWithOneParameter<T>()
        {
            return null;
        }

        private static Action<T> GetDelegateWithTwoParameters<T>()
        {
            return null;
        }

        #endregion TO_IMPLEMENT

        private static bool HasParameters<T>(Action<T> @delegate, int numParameters)
        {
            return @delegate.Method.GetParameters().Length == numParameters;
        }
    }
}
