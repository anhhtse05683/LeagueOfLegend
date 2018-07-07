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
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Gold"), (int)Math.Ceiling(npc.value / 10));
        }
    }
}
