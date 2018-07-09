using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace LeagueOfLegend.Items.Accessories
{
    public class Acc_BamisCinder : ModItem
    {
        public const int PRICE = 900;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bami's Cinder");
            Tooltip.SetDefault(
                string.Format("[c/0596aa:+150 Health]" +
                "\n[c/b99d66:UNIQUE Passive - Immolate:]") +
                "\nDeals 5(+1 per 100 player's health)" +
                "\nmagic damage per second to nearby enemies." +
                "\nDeals 100% bonus damage while in desert biome.");
        }
        public override void SetDefaults()
        {
            item.accessory = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<Items.Gold>(), PRICE);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<Items.Accessories.Acc_RubyCrystal>(), 1);
            recipe.AddIngredient(mod.ItemType<Items.Gold>(), PRICE - Acc_RubyCrystal.PRICE);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 += 200;
            
            player.GetModPlayer<LeagueOfLegendPlayer>(mod).immolate = true;

        }
    }
}
