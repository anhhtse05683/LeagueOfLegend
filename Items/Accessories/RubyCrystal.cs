using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace LeagueOfLegend.Items.Accessories
{
    public class RubyCrystal : ModItem
    {
        public const int PRICE = 400;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault(string.Format("[c/0596aa:+150 Health]"));
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.maxStack = 1;
            item.value = 400;
            item.rare = 1;
            item.accessory = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Gold"), PRICE);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 += 150;
            //player.statLifeMax += 150;
        }
    }
}
