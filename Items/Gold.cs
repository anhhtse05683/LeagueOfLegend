using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using LeagueOfLegend.Items.Accessories;

namespace LeagueOfLegend.Items
{
    public class Gold : ModItem
    {
        public const float F = 0.7f;

        public override void SetDefaults()
        {
            item.width = 10;
            item.height = 12;
            item.maxStack = 9999;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<Items.Accessories.BamisCinder>());
            recipe.SetResult(this, (int)Math.Ceiling(BamisCinder.PRICE * F));
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<Items.Accessories.RubyCrystal>());
            recipe.SetResult(this, (int)Math.Ceiling(RubyCrystal.PRICE * F));
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<Items.Accessories.ClothArmor>());
            recipe.SetResult(this, (int)Math.Ceiling(ClothArmor.PRICE * F));
            recipe.AddRecipe();
        }
    }
}
