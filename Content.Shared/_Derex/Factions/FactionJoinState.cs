using Content.Shared.Eui;
using Robust.Shared.Serialization;

namespace Content.Shared._Derex.Factions;

[Serializable, NetSerializable]
public sealed class FactionJoinState (string converterName) : EuiStateBase
{
    public string ConverterName = converterName;
    public bool Close = false;
}