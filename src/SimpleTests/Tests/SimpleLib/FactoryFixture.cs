﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simple.ConfigSource;
using NUnit.Framework;
using System.IO;
using Simple.Logging;

namespace Simple.Tests.SimpleLib
{
    [TestFixture]
    public class FactoryFixture
    {
        [SetUp]
        public void Setup()
        {
            File.WriteAllText(XmlFileConfigSourceFixture.TEST_FILE_NAME, XmlConfigSourceFixture.SAMPLE_XML);
        }

        [TearDown]
        public void Teardown()
        {
            if (File.Exists(XmlFileConfigSourceFixture.TEST_FILE_NAME))
                File.Delete(XmlFileConfigSourceFixture.TEST_FILE_NAME);
        }

        [Test]
        public void SimpleFactoringTest()
        {
            IConfigSource<BasicTypesSampleWithoutAttr> src =
                new XmlConfigSource<BasicTypesSampleWithoutAttr>().Load(
                XmlConfigSourceFixture.SAMPLE_XML);
            
            BasicFactory b = new BasicFactory();
            b.Init(src);

            Assert.AreEqual(42, b.BuildInt());
            Assert.AreEqual("whatever", b.BuildString());
        }

        [Test]
        public void ExpiringFactoringTest()
        {
            using (var src = XmlConfig.LoadFile<BasicTypesSampleWithoutAttr>
                (XmlFileConfigSourceFixture.TEST_FILE_NAME))
            {
                BasicFactory b = new BasicFactory();
                b.Init(src);

                bool flag = false;

                src.Reloaded += x =>
                {
                    Assert.AreEqual(43, b.BuildInt());
                    Assert.AreEqual("whatever2", b.BuildString());
                    flag = true;
                };

                Assert.AreEqual(42, b.BuildInt());

                File.WriteAllText(XmlFileConfigSourceFixture.TEST_FILE_NAME, XmlFileConfigSourceFixture.SAMPLE_XML);

                long time = DateTime.Now.Ticks;
                while (!flag && new TimeSpan(DateTime.Now.Ticks - time).TotalSeconds < 3) ;

                Assert.IsTrue(flag);
            }
        }
    }
    #region Samples

    public class BasicFactory : Factory<BasicTypesSampleWithoutAttr>
    {
        string value1;
        int value2;

        protected override void InitializeObjects(BasicTypesSampleWithoutAttr config)
        {
            value1 = config.AString;
            value2 = config.AnIntegral;
        }

        public string BuildString()
        {
            return value1;
        }

        public int BuildInt()
        {
            return value2;
        }
    }

    #endregion
}