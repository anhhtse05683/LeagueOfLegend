using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LeagueOfLegend.Items.Accessories
{
    public class Acc_CatalystOfAeons : ModItem
    {
        public const int PRICE = 1100;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Catalyst of Aeons");
            Tooltip.SetDefault(string.Format(string.Format("[c/0596aa:+225 Health]" +
                "\n[c/96fa96:+300 mana]" +
                "\n" +
                "\nUNIQUE Passive - Eternity:" +
                "\n15% of damage taken gained as mana." +
                "\n" +
                "\nSpending mana restores 20% of the cost as health," +
                "\nup to 15 per spell cast." +
                "\n" +
                "\n(Toggled Spells heal for a maximum of 15 per second.)")));
        }

        public override void SetDefaults()
        {
            item.accessory = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<Gold>(), PRICE);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<Acc_RubyCrystal>());
            recipe.AddIngredient(mod.ItemType<Acc_SapphireCrystal>());
            recipe.AddIngredient(mod.ItemType<Gold>(), PRICE - Acc_SapphireCrystal.PRICE - Acc_RubyCrystal.PRICE);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 += 225;
            player.statManaMax2 += 300;

            player.GetModPlayer<LeagueOfLegendPlayer>(mod).eternity = true;
        }
    }
}
