using GFrameworkTemplate.scripts.system.desktop_pet;

namespace GFrameworkTemplate.scripts.cqrs.desktop_pet.command;

public sealed class DesktopPetProcessCommand : AbstractCommand
{
    public required Guid DesktopPetId { get; set; }
    public required double Delta { get; set; }

    protected override void OnExecute()
    {
        this.GetSystem<DesktopPetStateSystem>().Process(DesktopPetId, Delta);
    }
}