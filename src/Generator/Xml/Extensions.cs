using System.Collections.Generic;
using System.Linq;

namespace Xan.TotalWarhammerMaxLevel.Generator.Xml
{
    public static class Extensions
    {
        public static IList<character_skill_node> NodesForSet(this character_skill_nodes data, string setKey)
        {
            return data.nodes.Where(x => x.visible_in_ui == 1 && x.character_skill_node_set_key == setKey).ToList();
        }

        public static int GetMaxLevel(this character_skill_level_to_effects_junctions data, string characterSkillKey)
        {
            var juncions = data.junctions.Where(x => x.character_skill_key == characterSkillKey).ToArray();
            if (juncions.Length <= 0)
            {
                return -1;
            }
            return juncions.Max(x => x.level);
        }
    }
}
