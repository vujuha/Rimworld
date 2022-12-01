using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse.Sound;
using Verse;

namespace SandPump
{
    public class CompTerrainPumpSand : CompTerrainPump
    {
        private Sustainer sustainer;

        private CompProperties_TerrainPumpSand Props => (CompProperties_TerrainPumpSand)props;

        protected override void AffectCell(IntVec3 c)
        {
            AffectCell(parent.Map, c);
        }

        public static void AffectCell(Map map, IntVec3 c)
        {
            TerrainDef terrain = c.GetTerrain(map);
            if (terrain == TerrainDefOf.Sand)
            {
                map.terrainGrid.SetTerrain(c, TerrainDefOf.Soil);
            }
        }

        public override void PostDeSpawn(Map map)
        {
            base.PostDeSpawn(map);
            if (sustainer != null && !sustainer.Ended)
            {
                sustainer.End();
            }
        }

        public override void CompTickRare()
        {
            base.CompTickRare();
            if (!Props.soundWorking.NullOrUndefined() && base.Working && base.CurrentRadius < Props.radius - 0.0001f)
            {
                if (sustainer == null || sustainer.Ended)
                {
                    sustainer = Props.soundWorking.TrySpawnSustainer(SoundInfo.InMap(parent));
                }
                sustainer.Maintain();
            }
            else if (sustainer != null && !sustainer.Ended)
            {
                sustainer.End();
            }
        }
    }
}