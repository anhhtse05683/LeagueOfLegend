using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;

namespace LeagueOfLegend.NPCs
{
    public class NpcDrops : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (Main.player[npc.lastInteraction].active)
            {
                Item.NewItem((int)Main.player[npc.lastInteraction].position.X, (int)Main.player[npc.lastInteraction].position.Y, Main.player[npc.lastInteraction].width, Main.player[npc.lastInteraction].height, mod.ItemType("Gold"), (int)Math.Ceiling(npc.value / 10));
            }
        }
    }
}
