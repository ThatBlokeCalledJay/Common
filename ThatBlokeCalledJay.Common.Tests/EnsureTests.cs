using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ThatBlokeCalledJay.Common.Tests
{
    [TestClass]
    public class EnsureTests
    {
        [TestMethod]
        public void Test_EnsureNotNullOrWhitespace()
        {
            var result = Ensure.NotNullOrWhiteSpace("", "", false);
            Assert.IsFalse(result);

            var result2 = Ensure.NotNullOrWhiteSpace("123", "", false);
            Assert.IsTrue(result2);

            var result3 = Ensure.NotNullOrWhiteSpace("123", "");
            Assert.IsTrue(result3);

            var result4 = Ensure.NotNullOrWhiteSpace(null, "", false);
            Assert.IsFalse(result4);

            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                Ensure.NotNullOrWhiteSpace("", "");
            });
        }

        [TestMethod]
        public void Test_EnsureNotNull()
        {
            var result = Ensure.NotNull(null, "", false);
            Assert.IsFalse(result);

            var result2 = Ensure.NotNull(new object(), "", false);
            Assert.IsTrue(result2);

            var result3 = Ensure.NotNull(new object(), "");
            Assert.IsTrue(result3);

            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                Ensure.NotNull(null, "");
            });
        }

        [TestMethod]
        public void Test_EnsureNotNullOrEmpty()
        {
            var testData = new List<string> { "test" };

            var result = Ensure.NotNullOrEmpty((List<string>)null, "", false);
            Assert.IsFalse(result);

            var result2 = Ensure.NotNullOrEmpty(testData, "", false);
            Assert.IsTrue(result2);

            var result3 = Ensure.NotNullOrEmpty(testData, "");
            Assert.IsTrue(result3);

            var result4 = Ensure.NotNullOrEmpty(new List<string>(), "", false);
            Assert.IsFalse(result4);

            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                Ensure.NotNullOrEmpty((List<string>)null, "");
            });

            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                Ensure.NotNullOrEmpty(new List<string>(), "");
            });
        }

        [TestMethod]
        public void Test_EnsureObjectIsOfType()
        {
            var result1 = Ensure.ObjectIsOfType<string>("", "");
            Assert.IsTrue(result1);

            var result2 = Ensure.ObjectIsOfType<string>("", "", true);
            Assert.IsTrue(result2);

            Assert.ThrowsException<ArgumentException>(() =>
            {
                Ensure.ObjectIsOfType<string>(1, "");
            });

            var result4 = Ensure.ObjectIsOfType<string>(1, "", false);
            Assert.IsFalse(result4);

            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                Ensure.ObjectIsOfType<string>(null, "");
            });
        }

        [TestMethod]
        public void Test_EnsureNotBelow_Int()
        {
            var result = Ensure.NotBelow(1, "", 1);
            Assert.IsTrue(result);

            result = Ensure.NotBelow(1, "", -10);
            Assert.IsTrue(result);

            result = Ensure.NotBelow(1, "", 0);
            Assert.IsTrue(result);
            ;
            result = Ensure.NotBelow(1, "", 10, false);
            Assert.IsFalse(result);

            result = Ensure.NotBelow(-10, "", -10);
            Assert.IsTrue(result);

            result = Ensure.NotBelow(-9, "", -10);
            Assert.IsTrue(result);

            result = Ensure.NotBelow(-11, "", -10, false);
            Assert.IsFalse(result);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                Ensure.NotBelow(-11, "", -10);
            });

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                Ensure.NotBelow(1, "", 10);
            });
        }

        [TestMethod]
        public void Test_EnsureNotBelow_Dec()
        {
            var result = Ensure.NotBelow(1M, "", 1M);
            Assert.IsTrue(result);

            result = Ensure.NotBelow(1M, "", -10M);
            Assert.IsTrue(result);

            result = Ensure.NotBelow(1M, "", 0.99M);
            Assert.IsTrue(result);
            ;
            result = Ensure.NotBelow(1M, "", 10.0M, false);
            Assert.IsFalse(result);

            result = Ensure.NotBelow(-10M, "", -10M);
            Assert.IsTrue(result);

            result = Ensure.NotBelow(-9M, "", -10M);
            Assert.IsTrue(result);

            result = Ensure.NotBelow(-11M, "", -10M, false);
            Assert.IsFalse(result);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                Ensure.NotBelow(-10.01M, "", -10M);
            });

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                Ensure.NotBelow(9.99M, "", 10M);
            });
        }

        [TestMethod]
        public void Test_EnsureNotAbove_Int()
        {
            var result = Ensure.NotAbove(1, "", 1);
            Assert.IsTrue(result);

            result = Ensure.NotAbove(-11, "", -10);
            Assert.IsTrue(result);

            result = Ensure.NotAbove(-1, "", 0);
            Assert.IsTrue(result);
            ;
            result = Ensure.NotAbove(11, "", 10, false);
            Assert.IsFalse(result);

            result = Ensure.NotAbove(-10, "", -10);
            Assert.IsTrue(result);

            result = Ensure.NotAbove(-11, "", -10);
            Assert.IsTrue(result);

            result = Ensure.NotAbove(-9, "", -10, false);
            Assert.IsFalse(result);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                Ensure.NotAbove(-9, "", -10);
            });

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                Ensure.NotAbove(11, "", 10);
            });
        }

        [TestMethod]
        public void Test_EnsureNotAbove_Dec()
        {
            var result = Ensure.NotAbove(1M, "", 1M);
            Assert.IsTrue(result);

            result = Ensure.NotAbove(-10.001M, "", -10M);
            Assert.IsTrue(result);

            result = Ensure.NotAbove(0.98M, "", 0.99M);
            Assert.IsTrue(result);
            ;
            result = Ensure.NotAbove(11.1M, "", 10.0M, false);
            Assert.IsFalse(result);

            result = Ensure.NotAbove(-10M, "", -10M);
            Assert.IsTrue(result);

            result = Ensure.NotAbove(-10.01M, "", -10M);
            Assert.IsTrue(result);

            result = Ensure.NotAbove(-9.99M, "", -10M, false);
            Assert.IsFalse(result);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                Ensure.NotAbove(-9.99M, "", -10M);
            });

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                Ensure.NotAbove(10.01M, "", 10M);
            });
        }

        [TestMethod]
        public void Test_EnsureBetween_Int()
        {
            var result = Ensure.IsBetween(1, "", 1, 2);
            Assert.IsTrue(result);

            result = Ensure.IsBetween(-1, "", -2, 0);
            Assert.IsTrue(result);

            result = Ensure.IsBetween(1, "", -2, 0, false);
            Assert.IsFalse(result);

            result = Ensure.IsBetween(-3, "", -2, 0, false);
            Assert.IsFalse(result);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                Ensure.IsBetween(-3, "", -2, 0);
            });

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                Ensure.IsBetween(1, "", -2, 0);
            });
        }

        [TestMethod]
        public void Test_EnsureBetween_Dec()
        {
            var result = Ensure.IsBetween(1M, "", 1m, 2m);
            Assert.IsTrue(result);

            result = Ensure.IsBetween(-1m, "", -2m, 0m);
            Assert.IsTrue(result);

            result = Ensure.IsBetween(1m, "", -2m, 0m, false);
            Assert.IsFalse(result);

            result = Ensure.IsBetween(-3m, "", -2m, 0m, false);
            Assert.IsFalse(result);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                Ensure.IsBetween(-3m, "", -2m, 0m);
            });

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                Ensure.IsBetween(1m, "", -2m, 0m);
            });
        }

        [TestMethod]
        public void Test_EnsureArrayNotNullOrEmpty()
        {

            var result = Ensure.NotNullOrEmpty(new[] { "" }, "");
            Assert.IsTrue(result);

            result = Ensure.NotNullOrEmpty((string[])null, "", false);
            Assert.IsFalse(result);

            result = Ensure.NotNullOrEmpty(new string[]{}, "", false);
            Assert.IsFalse(result);

            Assert.ThrowsException<ArgumentException>(() =>
            {
                Ensure.NotNullOrEmpty((string[])null, "");
            });

            Assert.ThrowsException<ArgumentException>(() =>
            {
                Ensure.NotNullOrEmpty(new string[] { }, "");
            });

        }
    }
}