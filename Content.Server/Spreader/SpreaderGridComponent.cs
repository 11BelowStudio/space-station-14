//using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom;

namespace Content.Server.Spreader;

[RegisterComponent]
//[AutoGenerateComponentPause]
public sealed partial class SpreaderGridComponent : Component
{
    [DataField]
    public float UpdateAccumulator = 1f;

    [DataField]
    public float SpreadCooldownSeconds = 1f;

    /*
    /// <summary>
    /// Time at which the next release will occur.
    /// This is automatically set when the grenade activates.
    /// </summary>
    [DataField(customTypeSerializer: typeof(TimeOffsetSerializer))]
    [AutoPausedField]
    public TimeSpan NextSpreadTime = TimeSpan.Zero;

    /// <summary>
    /// How often we will check for new emissions by default
    /// </summary>
    [DataField]
    public TimeSpan SpreadInterval = TimeSpan.FromSeconds(1);

    [DataField]
    public bool PendingRelease = false;
    */

}
