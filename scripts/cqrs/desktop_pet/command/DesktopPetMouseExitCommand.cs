using GFrameworkTemplate.scripts.system.desktop_pet;

namespace GFrameworkTemplate.scripts.cqrs.desktop_pet.command;

public sealed class DesktopPetMouseExitCommand : AbstractCommand
{
    public required Guid DesktopPetId { get; set; }

    protected override void OnExecute()
    {
        this.GetSystem<DesktopPetStateSystem>().MouseExit(DesktopPetId);
    }
}