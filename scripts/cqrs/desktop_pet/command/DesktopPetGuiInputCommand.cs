using GFrameworkTemplate.scripts.system.desktop_pet;
using Godot;

namespace GFrameworkTemplate.scripts.cqrs.desktop_pet.command;

public sealed class DesktopPetGuiInputCommand : AbstractCommand
{
    public required Guid DesktopPetId { get; set; }
    public required InputEvent InputEvent { get; set; }

    protected override void OnExecute()
    {
        this.GetSystem<DesktopPetStateSystem>().GuiInput(DesktopPetId, InputEvent);
    }
}