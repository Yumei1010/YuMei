using GFrameworkTemplate.scripts.entities.desktop_pet;
using GFrameworkTemplate.scripts.system.desktop_pet;

namespace GFrameworkTemplate.scripts.cqrs.desktop_pet.command;

public sealed class DesktopPetInitStateCommand : AbstractCommand
{
    public required IDesktopPet DesktopPet { get; set; }

    protected override void OnExecute()
    {
        this.GetSystem<DesktopPetStateSystem>().InitStates(DesktopPet);
    }
}