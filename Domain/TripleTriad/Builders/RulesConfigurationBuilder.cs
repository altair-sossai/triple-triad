using System.Collections.Generic;
using TripleTriad.Commands;
using TripleTriad.Rules;

namespace TripleTriad.Builders
{
    public static class RulesConfigurationBuilder
    {
        public static List<IRule> BuildRules(this Configuration configuration)
        {
            var rules = new List<IRule>();

            if (configuration.Same)
                rules.Add(new SameRule());

            if (configuration.SameWall)
                rules.Add(new SameWallRule());

            if (configuration.Plus)
                rules.Add(new PlusRule());

            rules.Add(new CommonRule());

            return rules;
        }

        public static Configuration Build(NewGameCommand command)
        {
            var rules = Empty();

            if (command.EnableSameRule)
                rules = rules.EnableSame();

            if (command.EnableSameWallRule)
                rules = rules.EnableSameWall();

            if (command.EnablePlusRule)
                rules = rules.EnablePlus();

            if (command.EnableComboRule)
                rules = rules.EnableCombo();

            if (command.EnableElementalRule)
                rules = rules.EnableElemental(command.ProbabilityOfElementary);

            return rules;
        }

        public static Configuration Empty()
        {
            return new Configuration();
        }

        public static Configuration EnableSame(this Configuration configuration)
        {
            configuration.Same = true;

            return configuration;
        }

        public static Configuration EnableSameWall(this Configuration configuration)
        {
            configuration.SameWall = true;

            return configuration;
        }

        public static Configuration EnablePlus(this Configuration configuration)
        {
            configuration.Plus = true;

            return configuration;
        }

        public static Configuration EnableCombo(this Configuration configuration)
        {
            configuration.Combo = true;

            return configuration;
        }

        public static Configuration EnableElemental(this Configuration configuration, double probability = 0.2)
        {
            configuration.Elemental = true;
            configuration.ProbabilityOfElementary = probability;

            return configuration;
        }
    }
}