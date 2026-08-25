using Content.Server.Mind;
using Content.Server.Objectives.Components;
using Content.Shared.Anomaly.Components;
using Content.Shared.Objectives.Components;

namespace Content.Server.Objectives.Systems;

public sealed partial class SupercriticalAnomaliesConditionSystem : EntitySystem
{
    [Dependency] private MindSystem _mind = default!;
    [Dependency] private CounterConditionSystem _counterCondition = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<SupercriticalAnomaliesConditionComponent, AnomalyShutdownEvent>(OnAnomalySupercrit);
    }

    private void OnAnomalySupercrit(Entity<SupercriticalAnomaliesConditionComponent> ent, ref AnomalyShutdownEvent args)
    {
        if (!args.Supercritical)
            return;
        
        if (!_mind.TryGetMind(ent.Owner, out var mindUid, out var mind))
            return;

        foreach (var obj in _mind.EnumerateObjectives<SupercriticalAnomaliesConditionComponent>((mindUid, mind)))
        {
            _counterCondition.IncreaseCount(obj);
        }
    }
}
