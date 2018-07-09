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
    public class Acc_SapphireCrystal : ModItem
    {
        public const int PRICE = 350;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sapphire Crystal");
            Tooltip.SetDefault(string.Format("[c/96fa96:+250 mana]"));
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
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statManaMax2 += 250;
        }
    }
}
