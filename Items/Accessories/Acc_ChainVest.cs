using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace LeagueOfLegend.Items.Accessories
{
    public class Acc_ChainVest : ModItem
    {
        public const int PRICE = 800;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chain Vest");
            Tooltip.SetDefault(string.Format("[c/0596aa:+40 Armor]"));
        }

        public override void SetDefaults()
        {
            item.accessory = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<Items.Gold>(), 800);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<Items.Accessories.Acc_ClothArmor>());
            recipe.AddIngredient(mod.ItemType<Items.Gold>(), PRICE - Acc_ClothArmor.PRICE);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statDefense += 40;
        }

    }
}
