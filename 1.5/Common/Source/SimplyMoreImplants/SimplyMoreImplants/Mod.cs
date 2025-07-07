using UnityEngine;
using Verse;

namespace SimplyMoreImplants
{
    public class SimplyMoreImplantsMod : Mod
    {
        public const string KeyPrefix = "SimplyMoreImplants.";
        public const string TitlePostfix = ".Title";
        public const string DescriptionPostfix = ".Description";
        
        public SimplyMoreImplantsSettings settings;

        public SimplyMoreImplantsMod(ModContentPack content) : base(content)
        {
            settings = GetSettings<SimplyMoreImplantsSettings>();
        }
        
        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listing = new Listing_Standard();
            listing.Begin(inRect);

            DoSettingListing(listing, "DisableTechprints", ref settings.disableTechprints);

            listing.End();
        }

        public static void DoSettingListing(Listing_Standard list, string key, ref bool setting)
        {
            string t = KeyPrefix + key + TitlePostfix;
            string d = KeyPrefix + key + DescriptionPostfix;
            list.CheckboxLabeled(t.Translate(), ref setting, d.Translate());
        }

        public override string SettingsCategory()
        {
            return "Simply More Implants";
        }
    }

    public class SimplyMoreImplantsSettings : ModSettings
    {
        public bool disableTechprints = false;

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref disableTechprints, "disableTechprints");
        }
    }
}