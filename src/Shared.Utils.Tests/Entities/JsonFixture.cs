using FluentAssertions;
using NUnit.Framework;
using ZanyBaka.Shared.Utils.Lib.Entities.Json;

namespace ZanyBaka.Shared.Utils.Tests.Entities
{
    [TestFixture]
    public class JsonFixture
    {
        public class TestClass
        {
            public int TestProp1;
            public string TestProp2;

            public TestClass()
            {
            }

            public TestClass(int testProp1, string testProp2)
            {
                TestProp1 = testProp1;
                TestProp2 = testProp2;
            }
        }

        [Test]
        public void EntityFromJson_Test()
        {
            TestClass entity = new EntityFromJson<TestClass>("{\"TestProp1\":1,\"TestProp2\":\"TestValue2\"}");
            entity.Should().BeEquivalentTo(new TestClass(1, "TestValue2"));
        }

        [Test]
        public void JsonFromEntity_Test()
        {
            var    obj  = new TestClass(1, "TestValue2");
            string json = new JsonFromEntity(obj);
            json.Should().Be("{\"TestProp1\":1,\"TestProp2\":\"TestValue2\"}");
        }

        [Test]
        public void JsonObject_AddKeyValue_Test()
        {
            var jsonObject = new JsonObject();
            jsonObject.AddKeyValue("key1", "value1");
            jsonObject.AddKeyValue("key2", "val\"ue2");
            jsonObject.ToString().Should().Be("{\"key1\":\"value1\",\"key2\":\"val\\\"ue2\"}");
        }

        [Test]
        public void JsonObject_Empty_Test()
        {
            var jsonObject = new JsonObject();
            jsonObject.IsEmpty.Should().BeTrue();
            jsonObject.ToString().Should().Be("{}");
        }
    }
}