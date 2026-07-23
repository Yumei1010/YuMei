using GFrameworkTemplate.scripts.cqrs.desktop_pet.@event;
using GFrameworkTemplate.scripts.enums.desktop_pet;

namespace GFrameworkTemplate.scripts.entities.desktop_pet.state;

[Log]
[ContextAware]
public sealed partial class DragState : DesktopPetState
{
    private Vector2I _dragOffset;

    public override void Enter()
    {
        _dragOffset = DisplayServer.MouseGetPosition() - DesktopPet.GetWindow().Position;

        this.SendEvent(new DesktopPetDragStartedEvent());
        Input.SetMouseMode(Input.MouseModeEnum.ConfinedHidden);
    }

    public override void Exit()
    {
        this.SendEvent(new DesktopPetDragFinishedEvent());
        Input.SetMouseMode(Input.MouseModeEnum.Visible);
    }

    public override void Process(double delta)
    {
        if (!OS.HasFeature("editor"))
            DesktopPet.GetWindow().Position = DisplayServer.MouseGetPosition() - _dragOffset;
    }

    public override void MouseUp()
    {
        ChangeTo(DesktopPetStateType.Idle);
    }
}