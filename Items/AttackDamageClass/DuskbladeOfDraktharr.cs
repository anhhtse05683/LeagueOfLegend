using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using LeagueOfLegend.Items.Accessories;

namespace LeagueOfLegend.Items.AttackDamageClass
{
    public class DuskbladeOfDraktharr : AttackDamageItem
    {
        public const int PRICE = 2900;

        public override void SetStaticDefaults()
        {

        }
        public override void SafeSetDefaults()
        {
            item.damage = 55;
            item.crit = 0;
            item.knockBack = 0;
            item.useStyle = 1;
            item.useAnimation = 10;
            item.useTime = 10;
            item.autoReuse = true;
            item.useTurn = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<Items.Gold>(), PRICE);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<Items.Accessories.CaulfieldsWarhammer>());
            recipe.AddIngredient(mod.ItemType<Items.Accessories.SerratedDirk>());
            recipe.AddIngredient(mod.ItemType<Items.Gold>(), PRICE - CaulfieldsWarhammer.PRICE - SerratedDirk.PRICE);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
