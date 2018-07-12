using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using LeagueOfLegend.Items.AttackDamageClass;

namespace LeagueOfLegend.Items.Accessories
{
    public class Acc_AmplifyingTome : ModItem
    {
        public const int PRICE = 435;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault(string.Format("Amplifying Tome"));
            Tooltip.SetDefault(string.Format("+20 Ability Power"));
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.value = 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<Gold>(), PRICE);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
