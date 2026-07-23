using GFrameworkTemplate.scripts.system.desktop_pet;

namespace GFrameworkTemplate.scripts.cqrs.desktop_pet.command;

public sealed class DesktopPetMouseUpCommand : AbstractCommand
{
    public required Guid DesktopPetId { get; set; }

    protected override void OnExecute()
    {
        this.GetSystem<DesktopPetStateSystem>().MouseUp(DesktopPetId);
    }
}