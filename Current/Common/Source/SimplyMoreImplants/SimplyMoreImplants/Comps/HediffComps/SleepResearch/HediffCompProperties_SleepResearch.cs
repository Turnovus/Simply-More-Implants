using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;

namespace SimplyMoreImplants
{
    class HediffCompProperties_SleepResearch : HediffCompProperties
    {
        public float mult = 1f;

        public HediffCompProperties_SleepResearch() =>
            compClass = typeof(HediffComp_SleepResearch);
    }
}
