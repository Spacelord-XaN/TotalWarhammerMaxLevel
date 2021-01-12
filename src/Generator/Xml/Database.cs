using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Xan.TotalWarhammerMaxLevel.Generator.Xml
{
    public class Database
    {
        private readonly string _dataDirectory;

        public Database(string assemblyKitPath)
        {
            _dataDirectory = Path.Combine(assemblyKitPath, "raw_data", "db");

            AgentRecruitmentCategories = DeserializeItems<agent_recruitment_categories>();
            AgentSubtypes = DeserializeItems<agent_subtypes>();
            CharacterSkillLevelToEffectsJunctions = DeserializeItems<character_skill_level_to_effects_junctions>();
            CharacterSkillNodeSets = DeserializeItems<character_skill_node_sets>();
            CharacterSkillNodes = DeserializeItems<character_skill_nodes>();
            CharacterSkills = DeserializeItems<character_skills>();
            CulturesSubcultures = DeserializeItems<cultures_subcultures>();
            Effects = DeserializeItems<effects>();
            FactionAgentPermittedSubtypes = DeserializeItems<faction_agent_permitted_subtypes>();
            Factions = DeserializeItems<factions>();
        }


        public IReadOnlyCollection<agent_recruitment_categories> AgentRecruitmentCategories { get; }
        public IReadOnlyCollection<agent_subtypes> AgentSubtypes { get; }
        public IReadOnlyCollection<character_skill_level_to_effects_junctions> CharacterSkillLevelToEffectsJunctions { get; }
        public IReadOnlyCollection<character_skill_node_sets> CharacterSkillNodeSets { get; }
        public IReadOnlyCollection<character_skill_nodes> CharacterSkillNodes { get; }
        public IReadOnlyCollection<character_skills> CharacterSkills { get; }
        public IReadOnlyCollection<cultures_subcultures> CulturesSubcultures { get; }
        public IReadOnlyCollection<effects> Effects { get; }
        public IReadOnlyCollection<faction_agent_permitted_subtypes> FactionAgentPermittedSubtypes { get; }
        public IReadOnlyCollection<factions> Factions { get; }

        public IReadOnlyCollection<character_skills> GetBackgroundSkillsBySkillNodeSet(string skillNodeSetKey)
        {
            var result = new List<character_skills>();

            foreach (var characterSkillNode in CharacterSkillNodes.Where(c => c.character_skill_node_set_key == skillNodeSetKey))
            {
                var skill = CharacterSkills.FirstOrDefault(characterSkillNode.character_skill_key);
                if (skill == null)
                {
                    continue;
                }
                if (skill.is_background_skill == "1")
                {
                    result.Add(skill);
                }
            }

            return result;
        }

        public IDictionary<string, int> GetMaxLevelPerAgentType()
        {
            var result = new Dictionary<string, int>();
            foreach (var set in CharacterSkillNodeSets)
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

        public Dictionary<string, Dictionary<int, List<character_skill_node_sets>>> GetMaxLevelPerAgentTypeDetailed()
        {
            var result = new Dictionary<string, Dictionary<int, List<character_skill_node_sets>>>();
            foreach (var set in CharacterSkillNodeSets)
            {
                var pointsNeeded = GetPointsForSet(set.key);

                if (!result.ContainsKey(set.agent_key))
                {
                    result.Add(set.agent_key, new Dictionary<int, List<character_skill_node_sets>>());
                }
                if (!result[set.agent_key].ContainsKey(pointsNeeded))
                {
                    result[set.agent_key].Add(pointsNeeded, new List<character_skill_node_sets>());
                }

                result[set.agent_key][pointsNeeded].Add(set);
            }
            return result;
        }

        public int GetPointsForSet(string setKey)
        {
            var result = 0;

            foreach (var skillNode in CharacterSkillNodes.Where(x => x.visible_in_ui == "1" && x.character_skill_node_set_key == setKey))
            {
                result += CharacterSkillLevelToEffectsJunctions.GetMaxLevel(skillNode.character_skill_key);
            }

            return result;
        }

        public string GetSkillEffectDescription(string skillKey)
        {
            var sb = new StringBuilder();
            
            foreach (var effectJunction in CharacterSkillLevelToEffectsJunctions.Where(c => c.character_skill_key == skillKey))
            {
                var effect = Effects.First(effectJunction.effect_key);
                sb.AppendLine(effect.description.last_approved_text.Replace("%+n", effectJunction.value));
            }

            return sb.ToString();
        }

        public void SearchFreeIndetAndTier(string setKey, out int indent, out int tier)
        {
            //  @todo look fot a free position in the set
            indent = 4;
            tier = 29;
        }

        private T Deserialize<T>(string tableName)
        {
            using (var fileStream = new FileStream(Path.Combine(_dataDirectory, $"{tableName}.xml"), FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(fileStream);
            }
        }
        private IReadOnlyCollection<T> DeserializeItems<T>()
        {
            var tableName = typeof(T).Name;
            var dataroot = Deserialize<dataroot>(tableName);
            return dataroot.Items.Cast<T>().ToArray();
        }
    }
}
