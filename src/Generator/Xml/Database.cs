using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Xan.TotalWarhammerMaxLevel.Generator.Xml
{
    public class Database
    {
        private readonly string _dataDirectory;

        public Database(string dataDirectory)
        {
            _dataDirectory = dataDirectory;

            CharacterSkillLevelToEffectsJunctions = Deserialize<character_skill_level_to_effects_junctions>("character_skill_level_to_effects_junctions");
            CharacterSkillNodes = Deserialize<character_skill_nodes>("character_skill_nodes");
            CharacterSkillNodeSets = Deserialize<character_skill_node_sets>("character_skill_node_sets");
        }

        public character_skill_level_to_effects_junctions CharacterSkillLevelToEffectsJunctions { get; private set; }

        public character_skill_nodes CharacterSkillNodes { get; private set; }

        public character_skill_node_sets CharacterSkillNodeSets { get; private set; }

        public IDictionary<string, int> GetMaxLevelMap()
        {
            var result = new Dictionary<string, int>();
            foreach (var set in CharacterSkillNodeSets.node_sets)
            {
                var pointsNeeded = GetPointsForSet(set.key);

                if (!result.ContainsKey(set.agent_key))
                {
                    result.Add(set.agent_key, int.MinValue);
                }
                result[set.agent_key] = Math.Max(result[set.agent_key], pointsNeeded);
            }
            return result;
        }

        public int GetPointsForSet(string key)
        {
            var result = 0;

            foreach (var skillNode in CharacterSkillNodes.NodesForSet(key))
            {
                result += CharacterSkillLevelToEffectsJunctions.GetMaxLevel(skillNode.character_skill_key);
            }

            return result;
        }

        public void SearchFreeIndetAndTier(string setKey, out int indent, out int tier)
        {
            //  @todo look fot a free position in the set
            indent = 4;
            tier = 29;
        }

        public IEnumerable<string> GetCharacterSkillNodeSetKeys()
        {
            return CharacterSkillNodeSets.node_sets.Select(x => x.key);
        }

        private T Deserialize<T>(string tableName)
        {
            using (var fileStream = new FileStream(Path.Combine(_dataDirectory, $"{tableName}.xml"), FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(fileStream);
            }
        }
    }
}
