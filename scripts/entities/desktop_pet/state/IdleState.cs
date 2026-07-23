using GFrameworkTemplate.scripts.enums.desktop_pet;

namespace GFrameworkTemplate.scripts.entities.desktop_pet.state;

[Log]
[ContextAware]
public partial class IdleState : DesktopPetState
{
    public override void Enter()
    {
        
    }

    public override void MouseDown()
    {
        ChangeTo(DesktopPetStateType.Drag);
    }
}