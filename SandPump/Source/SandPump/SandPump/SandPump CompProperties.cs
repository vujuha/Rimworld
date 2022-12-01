using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace SandPump
{
    public class CompProperties_TerrainPumpSand : CompProperties_TerrainPump
    {
        public SoundDef soundWorking;

        public CompProperties_TerrainPumpSand()
        {
            compClass = typeof(CompTerrainPumpSand);
        }
    }

}