using Content.Server.Objectives.Components;
using Content.Server.Shuttles.Systems;
using Content.Shared.Mind;
using Content.Shared.Objectives.Components;
using Content.Shared.Objectives.Systems;

namespace Content.Server.Objectives.Systems;

/// <summary>
/// This handles...
/// </summary>
public sealed partial class CompleteBeforeEvacConditionSystem : EntitySystem
{
    [Dependency] private EmergencyShuttleSystem _emergencyShuttle = default!;
    [Dependency] private SharedObjectivesSystem _sharedObjectivesSystem = default!;
    [Dependency] private SharedMindSystem _mind = default!;
    
    /// <inheritdoc/>
    public override void Initialize()
    {
        SubscribeLocalEvent<CompleteBeforeEvacConditionComponent, ObjectiveAssignedEvent>(OnObjectiveAssigned);
        SubscribeLocalEvent<CompleteBeforeEvacConditionComponent, EmergencyShuttleArrivedEvent>(OnEvacArrived);
    }

    private void OnObjectiveAssigned(Entity<CompleteBeforeEvacConditionComponent> ent, ref ObjectiveAssignedEvent args)
    {
        ent.Comp.EvacArrived = _emergencyShuttle.EmergencyShuttleArrived;
        if (ent.Comp.EvacArrived)
        {
            SaveProgress(ent);
        }
    }

    private void OnEvacArrived(Entity<CompleteBeforeEvacConditionComponent> ent, ref EmergencyShuttleArrivedEvent args)
    {
        ent.Comp.EvacArrived = true;
        SaveProgress(ent);
    }

    private void SaveProgress(Entity<CompleteBeforeEvacConditionComponent> ent)
    {
        if (!_mind.TryGetMind(ent.Owner, out var mindId, out var mind))
            return;

        var knownProgress = _sharedObjectivesSystem.GetProgress(ent.Owner, (mindId, mind));
        ent.Comp.ProgressAtEvac = knownProgress.GetValueOrDefault(0);
        SubscribeLocalEvent<CompleteBeforeEvacConditionComponent, ObjectiveGetProgressEvent>(GetProgress);
    }

    private void GetProgress(Entity<CompleteBeforeEvacConditionComponent> ent, ref ObjectiveGetProgressEvent args)
    { 
        args.Progress = ent.Comp.ProgressAtEvac;
    }
}