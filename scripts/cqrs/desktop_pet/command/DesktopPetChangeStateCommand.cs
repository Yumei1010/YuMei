using GFrameworkTemplate.scripts.enums.desktop_pet;
using GFrameworkTemplate.scripts.system.desktop_pet;

namespace GFrameworkTemplate.scripts.cqrs.desktop_pet.command;

public sealed class DesktopPetChangeStateCommand : AbstractCommand
{
    public required Guid DesktopPetId { get; set; }
    public required DesktopPetStateType State { get; set; }

    protected override void OnExecute()
    {
        this.GetSystem<DesktopPetStateSystem>().ChangeTo(DesktopPetId, State);
    }
}