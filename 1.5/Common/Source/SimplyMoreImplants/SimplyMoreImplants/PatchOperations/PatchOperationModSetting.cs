using System.Reflection;
using System.Xml;
using Verse;

namespace SimplyMoreImplants
{
    public class PatchOperationModSetting : PatchOperation
    {
#pragma warning disable CS0649
        private bool invert = false;
        private string setting;
        private PatchOperation operation;
#pragma warning restore CS0649

        protected override bool ApplyWorker(XmlDocument xml)
        {
            SimplyMoreImplantsSettings settings = LoadedModManager.GetMod<SimplyMoreImplantsMod>()
                .GetSettings<SimplyMoreImplantsSettings>();
            FieldInfo field =
                typeof(SimplyMoreImplantsSettings).GetField(setting, BindingFlags.Public | BindingFlags.Instance);
            if (field == null || field.FieldType != typeof(bool))
                return false;

            bool b = (bool)field.GetValue(settings);
            if (invert)
                b = !b;

            if (b)
                return operation.Apply(xml);
            return true;
        }
    }
}