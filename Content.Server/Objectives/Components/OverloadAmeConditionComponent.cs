using Content.Server.Objectives.Systems;

namespace Content.Server.Objectives.Components;

/// <summary>
/// Objective condition that requires the player to overload the AME, blowing it up.
/// </summary>
[RegisterComponent, Access(typeof(OverloadAmeConditionSystem))]
public sealed partial class OverloadAmeConditionComponent : Component
{
    /// <summary>
    /// Whether an antimatter engine has been overloaded since the objective was granted
    /// </summary>
    [DataField]
    public bool AmeOverloaded = false;
}