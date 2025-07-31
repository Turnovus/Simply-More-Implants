using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;

namespace SimplyMoreImplants
{
    class HediffComp_SeverityFromMeditation : HediffComp
    {

        public override void CompPostTick(ref float severityAdjustment)
        {
            base.CompPostTick(ref severityAdjustment);
            parent.Severity = Pawn.psychicEntropy.IsCurrentlyMeditating ? 1f : 0.001f;
        }
    }
}
