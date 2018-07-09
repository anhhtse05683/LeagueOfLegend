using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using LeagueOfLegend.Items.AttackDamageClass;

namespace LeagueOfLegend.Items.Accessories
{
    public class Acc_DuskbladeOfDraktharr : ModItem
    {
        public const int PRICE = 2900;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Duskblade of Draktharr");
            Tooltip.SetDefault(string.Format("[c/FF8C00:+55 Attack Damage]" +
                "\n[c/b99d66:UNIQUE Passive:] +18 Lethality"));
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
            recipe.AddIngredient(mod.ItemType<Items.Accessories.Acc_CaulfieldsWarhammer>());
            recipe.AddIngredient(mod.ItemType<Items.Accessories.Acc_SerratedDirk>());
            recipe.AddIngredient(mod.ItemType<Items.Gold>(), PRICE - Acc_CaulfieldsWarhammer.PRICE - Acc_SerratedDirk.PRICE);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            AttackDamagePlayer modPlayer = AttackDamagePlayer.ModPlayer(player);
            modPlayer.attackBonus += 55;
            modPlayer.lethality += 18;
        }
    }
}
