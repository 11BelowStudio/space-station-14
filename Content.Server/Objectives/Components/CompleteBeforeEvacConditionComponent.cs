using Content.Server.Objectives.Systems;

namespace Content.Server.Objectives.Components;

/// <summary>
/// Attach this to objectives which need to be completed before the evac shuttle arrives.
/// </summary>
[RegisterComponent, Access(typeof(CompleteBeforeEvacConditionSystem))]
public sealed partial class CompleteBeforeEvacConditionComponent : Component
{
    [DataField] public bool EvacArrived = false;
    [DataField] public float ProgressAtEvac = 0f;
}