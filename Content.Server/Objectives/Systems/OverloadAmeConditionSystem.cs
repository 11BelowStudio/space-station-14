using Content.Server.Ame.EntitySystems;
using Content.Server.Objectives.Components;
using Content.Shared.Mind;
using Content.Shared.Objectives.Components;

namespace Content.Server.Objectives.Systems;


public sealed partial class OverloadAmeConditionSystem : EntitySystem
{
    
    /// <inheritdoc/>
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<AmeOverloadedEvent>(OnAmeOverloadedEvent);
        SubscribeLocalEvent<OverloadAmeConditionComponent, ObjectiveGetProgressEvent>(OnGetProgress);
    }

    private void OnAmeOverloadedEvent(ref AmeOverloadedEvent ev)
    {
        var query = EntityQueryEnumerator<OverloadAmeConditionComponent>();
        while (query.MoveNext(out var comp))
        {
            comp.AmeOverloaded = true;
        }
    }

    private void OnGetProgress(EntityUid uid, OverloadAmeConditionComponent comp, ref ObjectiveGetProgressEvent args)
    {
        args.Progress = comp.AmeOverloaded ? 1 : 0;
    }
}