using System.Text.RegularExpressions;
using ZanyBaka.Shared.Utils.Lib.Entities.Json;

namespace ZanyBaka.Shared.Utils.Lib.Entities
{
    public static class EntityFactory
    {
        public static TEntity Create<TEntity>(Match match, string[] groupNames, bool trim)
        {
            return new EntityFromJson<TEntity>(
                new JsonFromRegexMatch(match, groupNames, trim)
            );
        }
    }
}