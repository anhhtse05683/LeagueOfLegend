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
    public class Acc_Pickaxe : ModItem
    {
        public const int PRICE = 875;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault(string.Format("Pickaxe"));
            Tooltip.SetDefault(string.Format("[c/FF8C00:+25 Attack Damage]"));
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

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            AttackDamagePlayer modPlayer = AttackDamagePlayer.ModPlayer(player);
            modPlayer.attackBonus += 25;
        }
    }
}
