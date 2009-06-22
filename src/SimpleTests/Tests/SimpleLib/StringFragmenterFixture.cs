﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simple.IO;
using Simple.Tests.SimpleLib.Sample;
using System.IO;

namespace Simple.Tests.SimpleLib
{
    [TestClass]
    public class StringFragmenterFixture
    {
        [TestMethod]
        public void SimpleTest1()
        {
            var s = StringFragmenter.Parse<TestStringClass1>("0123456789009876543210");

            Assert.AreEqual(1234, s.TestInt);
            Assert.AreEqual(5678.9m, s.TestDecimal);

            Assert.AreEqual(98765, s.TestInt2);
            Assert.AreEqual(43210m, s.TestDecimal2);

            string s2 = StringFragmenter.Write(s);
            Assert.AreEqual("0123456789009876543210", s2);
        }

        [TestMethod]
        public void SimpleTest2()
        {
            var s = StringFragmenter.Parse<TestStringClass2>("012345678,9098765432.1");

            Assert.AreEqual(1234, s.TestInt);
            Assert.AreEqual(5678.9m, s.TestDecimal);

            Assert.AreEqual(98765, s.TestInt2);
            Assert.AreEqual(432.1m, s.TestDecimal2);
        }

        [TestMethod]
        public void SimpleTestFormatException3()
        {
            var s = StringFragmenter.Parse<TestStringClass2>("012345678.9098765432.1");

            Assert.AreEqual(1234, s.TestInt);
            Assert.AreEqual(56789m, s.TestDecimal);

            Assert.AreEqual(98765, s.TestInt2);
            Assert.AreEqual(432.1m, s.TestDecimal2);
        }

        [TestMethod]
        public void SimpleTestFormatException4()
        {
            var s = StringFragmenter.Parse<TestStringClass2>("012345678,9098765432,1");

            Assert.AreEqual(1234, s.TestInt);
            Assert.AreEqual(5678.9m, s.TestDecimal);

            Assert.AreEqual(98765, s.TestInt2);
            Assert.AreEqual(4321m, s.TestDecimal2);
        }

        [TestMethod]
        public void ExtremeCaseAllInOne()
        {
            var s = StringFragmenter.Parse<TestStringClass3>("123,5.9999");

            Assert.AreEqual(123m, s.TestInt);
            Assert.AreEqual(123.5m, s.TestDecimal);
            Assert.AreEqual(123m, s.TestInt2);
            Assert.AreEqual(1235.9999m, s.TestDecimal2);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void FormatExceptionCase()
        {
            var s = StringFragmenter.Parse<TestStringClass4>("123,5");
        }

        [TestMethod]
        public void ParseIntAndDate()
        {
            var s = StringFragmenter.Parse<TestStringClass4>("1234520081112");
            Assert.AreEqual(12345, s.TestInt);
            Assert.AreEqual(new DateTime(2008, 12, 11), s.TestDateTime);

            string s2 = StringFragmenter.Write(s);
            Assert.AreEqual("1234520081112", s2);
        }


        [TestMethod]
        public void StreamTest()
        {
            string st = "0123456789009876543210\n0123456789009876543210\n0123456789009876543210\n";
            MemoryStream mem = new MemoryStream(Encoding.UTF8.GetBytes(st));

            IList<TestStringClass1> list = new List<TestStringClass1>(
                StringFragmenter.Parse<TestStringClass1>(mem));

            Assert.AreEqual(3, list.Count);
            foreach (var s in list)
            {
                Assert.AreEqual(1234, s.TestInt);
                Assert.AreEqual(5678.9m, s.TestDecimal);

                Assert.AreEqual(98765, s.TestInt2);
                Assert.AreEqual(43210m, s.TestDecimal2);
            }

            MemoryStream mem2 = new MemoryStream();
            StringFragmenter.WriteEnum(mem2, list);

            string st2 = Encoding.UTF8.GetString(mem2.ToArray());

            Assert.AreEqual(st.Replace("\r\n", "\n"), st2.Replace("\r\n", "\n"));
        }


        [TestMethod]
        public void ArrayTest()
        {
            string st = "0123456789009876543210\n0123456789009876543210\n0123456789009876543210";
            string[] mem = st.Split('\n');

            IList<TestStringClass1> list = new List<TestStringClass1>(
                StringFragmenter.Parse<TestStringClass1>(mem));

            Assert.AreEqual(3, list.Count);
            foreach (var s in list)
            {
                Assert.AreEqual(1234, s.TestInt);
                Assert.AreEqual(5678.9m, s.TestDecimal);

                Assert.AreEqual(98765, s.TestInt2);
                Assert.AreEqual(43210m, s.TestDecimal2);
            }
        }
    }
}
