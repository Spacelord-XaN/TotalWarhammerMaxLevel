using System.Linq;
using Xan.TotalWarhammerMaxLevel.Generator.Xml;

namespace Xan.TotalWarhammerMaxLevel.Generator.Tsv
{
    public class ModGenerator
    {
        private const string character_skill_key = "xan_skill_point_dump";
        private const string image_path = "battle_attack.png";
        private const string unlocked_at_rank = "5";
        private const string level = "200";
        private const string name = "Skill Point Dump";
        private const string description = "Skill Point Dump";

        private readonly TsvData _characterSkills = new TsvData { TableName = "character_skills", Value = "5" };
        private readonly TsvData _characterSkillLevelDetails = new TsvData { TableName = "character_skill_level_details", Value = "0" };
        private readonly TsvData _characterSkillLevelToEffectsJunctions = new TsvData { TableName = "character_skill_level_to_effects_junctions", Value = "1" };
        private readonly TsvData _characterSkillNodes = new TsvData { TableName = "character_skill_nodes", Value = "5" };
        private readonly TsvData _characterExperienceSkillTiers = new TsvData { TableName = "character_experience_skill_tiers", Value = "2" };

        private readonly string _outputDirectory;
        private readonly Database _db;

        public ModGenerator(Database db, string outputDirectory)
        {
            _outputDirectory = outputDirectory;
            _db = db;
        }

        public void Generate()
        {
            //  Skill point dump
            CreateCharacterSkills();
            CreateCharacterSkillLevelDetails();
            CreateCharacterSkillLevelToEffectsJunctions();
            CreateCharacterSkillNodes();

            //  Max levels
            CreateCharacterExperienceSkillTiers();

            SaveToDisk();
        }

        private void CreateCharacterSkills()
        {
            _characterSkills.Add(new[]
            {
                "image_path",
                "key",
                "localised_description",
                "localised_name",
                //"pre_battle_speech_paramter",
                "unlocked_at_rank",
                "is_background_skill",
                "is_female_only_background_skill",
                "is_male_only_background_skill",
                "background_weighting",
                "influence_cost"
            });
            _characterSkills.Add(new[]
            {
                image_path,
                character_skill_key,
                description,
                name,
                //"",
                unlocked_at_rank,
                "False",
                "False",
                "False",
                "0",
                "0"
            });
        }

        private void CreateCharacterSkillLevelDetails()
        {
            _characterSkillLevelDetails.Add(new[]
            {
                "campaign_key",
                "faction_key",
                "image_path",
                "level",
                "skill_key",
                "subculture_key",
                //"localised_name",
                //"localised_description",
                "unlocked_at_rank"
            });
            _characterSkillLevelDetails.Add(new[]
            {
                "",
                "",
                image_path,
                "1",
                character_skill_key,
                "",
                //"",
                //"",
                unlocked_at_rank
            });
        }

        private void CreateCharacterSkillLevelToEffectsJunctions()
        {
            _characterSkillLevelToEffectsJunctions.Add(new[]
            {
                "character_skill_key",
                "effect_key",
                "effect_scope",
                "level",
                "value",
                //"is_factionwide"
            });
            _characterSkillLevelToEffectsJunctions.Add(new[]
            {
                character_skill_key,
                "wh_main_effect_force_all_campaign_experience_base_all",
                "general_to_force_own",
                level,
                "0",
                //"False"
            });
            _characterSkillLevelToEffectsJunctions.Add(new[]
            {
                character_skill_key,
                "wh_main_effect_unit_recruitment_points",
                "force_to_province_own",
                level,
                "0",
                //"False"
            });
        }

        private void CreateCharacterSkillNodes()
        {
            _characterSkillNodes.Add(new[]
            {
                "campaign_key",
                "character_skill_key",
                "character_skill_node_set_key",
                "faction_key",
                "indent",
                "key",
                "tier",
                "subculture",
                "points_on_creation",
                "required_num_parents",
                "visible_in_ui"
            });

            foreach (var setKey in _db.GetCharacterSkillNodeSetKeys())
            {
                int indent;
                int tier;
                _db.SearchFreeIndetAndTier(setKey, out indent, out tier);

                _characterSkillNodes.Add(new[]
                {
                    "",
                    character_skill_key,
                    setKey,
                    "",
                    indent.ToString(),
                    $"{setKey}_{character_skill_key}",
                    tier.ToString(),
                    "",
                    "0",
                    "0",
                    "True"
                });
            }
        }

        private void CreateCharacterExperienceSkillTiers()
        {
            _characterExperienceSkillTiers.Add(new[]
            {
                "agent_key",
                "experience_threshold",
                "skill_points",
                "skill_rank",
                "optional_campaign_key",
                "for_army",
                "for_navy"
            });

            var maxLevelMap = _db.GetMaxLevelPerAgentType();

            foreach (var item in maxLevelMap.OrderBy(x => x.Key))
            {
                var xpThreshold = 900;
                var xpOffset = 1000;
                for (var level = 0; level < item.Value; level++)
                {
                    _characterExperienceSkillTiers.Add(new[]
                    {
                        item.Key,
                        $"{xpThreshold}",
                        "1",
                        $"{level}",
                        "",
                        "False",
                        "False"
                    });

                    xpThreshold += xpOffset;
                    xpOffset += 100;
                }
            }
        }

        private void SaveToDisk()
        {
            _characterSkills.Save(_outputDirectory);
            _characterSkillLevelDetails.Save(_outputDirectory);
            _characterSkillLevelToEffectsJunctions.Save(_outputDirectory);
            _characterSkillNodes.Save(_outputDirectory);
            _characterExperienceSkillTiers.Save(_outputDirectory);
        }
    }
}
