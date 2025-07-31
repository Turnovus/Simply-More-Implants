using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;

namespace SimplyMoreImplants
{
    public class HediffComp_SleepResearch : HediffComp
    {

        private HediffCompProperties_SleepResearch Props =>
            (HediffCompProperties_SleepResearch)props;

        public override void CompPostTick(ref float severityAdjustment)
        {
            base.CompPostTick(ref severityAdjustment);
            if (Find.ResearchManager.GetProject() == null ||
                (!Pawn.Faction.IsPlayer && !Pawn.IsPrisoner) || Pawn.Awake())
            {
                return;
            }

            float level =
                Pawn.skills.GetSkill(SkillDefOf.Intellectual).levelInt;
            float consciousness = Pawn.health.capacities.GetLevel(
                PawnCapacityDefOf.Consciousness);
            Find.ResearchManager.ResearchPerformed(
                // Equation for research points per tick per skill level
                0.08f + 0.115f * level * Props.mult * consciousness,
                Pawn
            );
        }
    }
}
