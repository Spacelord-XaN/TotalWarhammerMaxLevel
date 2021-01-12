using System.Collections.Generic;
using System.Linq;

namespace Xan.TotalWarhammerMaxLevel.Generator.Xml
{
    public static class Extensions
    {
        public static agent_subtypes First(this IEnumerable<agent_subtypes> subTypes, string key) => subTypes.First(a => a.key == key);
        public static cultures_subcultures First(this IEnumerable<cultures_subcultures> subCultures, string key) => subCultures.First(s => s.subculture == key);
        public static effects First(this IEnumerable<effects> effects, string key) => effects.First(e => e.effect == key);
        public static factions First(this IEnumerable<factions> factions, string key) => factions.First(f => f.key == key);

        public static character_skills FirstOrDefault(this IEnumerable<character_skills> skills, string key) => skills.FirstOrDefault(s => s.key == key);

        public static character_skill_node_sets FirstOrDefaultByAgentSubType(this IEnumerable<character_skill_node_sets> sets, string agentSubTypeKey) => sets.FirstOrDefault(s => s.agent_subtype_key == agentSubTypeKey);

        public static int GetMaxLevel(this IEnumerable<character_skill_level_to_effects_junctions> junctions, string characterSkillKey)
        {
            var juncions = junctions.Where(x => x.character_skill_key == characterSkillKey).ToArray();
            if (juncions.Length <= 0)
            {
                return -1;
            }
            return juncions.Max(x => int.Parse(x.level));
        }
    }
}
