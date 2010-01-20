using System;
using Xunit;

namespace Project.Core
{
    public class EnsureTests
    {
        [Fact]
        public void ApplicationRuleThrowsException()
        {
            const string msg = "my message";
            var ex = Assert.Throws<ApplicationException>(() => Ensure.ApplicationRule(false, msg));
            Assert.Equal(msg, ex.Message);
        }

        [Fact]
        public void ArgumentNotNullRuleThrowsException()
        {
            const string param = "paramName";
            var ex = Assert.Throws<ArgumentNullException>(() => Ensure.ArgumentNotNull(null, param));
            Assert.Contains(param, ex.Message);
            Assert.Contains(param, ex.ParamName);
        }

        [Fact]
        public void ArgumentNotNullOrEmptyRulesThrowsException()
        {
            const string param = "paramName";
            var ex = Assert.Throws<ArgumentException>(() => Ensure.ArgumentNotNullOrEmpty(null, param));
            Assert.Contains(param, ex.Message);
            Assert.Contains(param, ex.ParamName); 
            var ex2 = Assert.Throws<ArgumentException>(() => Ensure.ArgumentNotNullOrEmpty(string.Empty, param));
            Assert.Contains(param, ex2.Message);
            Assert.Contains(param, ex2.ParamName);
        }
    }
}
