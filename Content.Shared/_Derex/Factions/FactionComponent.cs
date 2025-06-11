using Robust.Shared.GameObjects;
using Robust.Shared.IoC;

namespace Content.Shared.Factions
{
    [RegisterComponent]
    public sealed partial class FactionComponent : Component
    {
        [DataField("factionName")]
        public string FactionName { get; set; } = string.Empty;

        [DataField("isCreator")]
        public bool IsCreator { get; set; } = false;

        //[DataField("members")]
        //public List<EntityUid> Members { get; set; } = new();
    }
}