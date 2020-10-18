using System;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ZanyBaka.Shared.Utils.Lib.Entities.Json
{
    public class JsonFieldSerializationPredicate : DefaultContractResolver
    {
        private readonly Func<object, bool> _objectPredicate;
        private readonly Func<JsonProperty, bool> _propertyPredicate;

        public JsonFieldSerializationPredicate(
            Func<JsonProperty, bool> propertyPredicate,
            Func<object, bool> objectPredicate)
        {
            _propertyPredicate = propertyPredicate;
            _objectPredicate   = objectPredicate;
        }

        protected override JsonProperty CreateProperty(
            MemberInfo member,
            MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            if (_propertyPredicate(property))
            {
                property.ShouldSerialize = instance => _objectPredicate(instance);
            }

            return property;
        }
    }
}