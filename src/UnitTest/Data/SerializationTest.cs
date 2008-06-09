using System;
using Lephone.Data;
using Lephone.UnitTest.Data.Objects;
using Lephone.Util;
using Lephone.Util.Coding;
using NUnit.Framework;

namespace Lephone.UnitTest.Data
{
    [TestFixture]
    public class SerializationTest
    {
        [SetUp]
        public void Setup()
        {
            Type t = typeof(DbEntry).Assembly.GetType("Lephone.Data.Common.MemoryTypeBuilder");
            ClassHelper.SetValue(t, "FieldPrifix", "_");
        }

        [Test]
        public void TestSerializedBase()
        {
            SerializedBase o = DynamicObject.NewObject<SerializedBase>("TOM");
            Assert.AreEqual("TOM", o.Name);
            SerializationCoding c = new SerializationCoding();
            SerializedBase o1 = (SerializedBase)c.Decode(c.Encode(o));
            Assert.AreEqual("TOM", o1.Name);
        }

        [Test]
        public void TestSerializedClassForSerialize()
        {
            SerializedClass o = new SerializedClass();
            o.Name = "TOM";
            SerializationCoding c = new SerializationCoding();
            c.Encode(o);
        }

        [Test]
        public void TestSerializedClass()
        {
            // SerializedClass
            SerializedClass o = new SerializedClass();
            o.Name = "TOM";
            SerializationCoding c = new SerializationCoding();
            byte[] bs = c.Encode(o);
            // trans to SerializedBase
            SerializedBase o1 = (SerializedBase)c.Decode(bs);
            Assert.AreEqual("TOM", o1.Name);
        }
    }
}
