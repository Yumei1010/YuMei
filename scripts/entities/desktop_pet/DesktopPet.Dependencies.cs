using GFrameworkTemplate.global;
using GFrameworkTemplate.scripts.cqrs.desktop_pet.command;
using GFrameworkTemplate.scripts.enums.desktop_pet;
using Godot;

namespace GFrameworkTemplate.scripts.entities.desktop_pet;

public partial class DesktopPet
{
    private PopupMenu PopupMenu => GetNode<PopupMenu>("PopupMenu");

    private async Task ReadyAsync()
    {
        await GameEntryPoint.Architecture.WaitUntilReadyAsync().ConfigureAwait(false);

        this.SendCommand(new DesktopPetInitStateCommand { DesktopPet = this });
        ChangeTo(DesktopPetStateType.Idle);

        PopupMenu.IdPressed += OnPopupMenuIdPressed;
    }

    private void OnPopupMenuIdPressed(long id)
    {
        if (id == 0)
            GetTree().Quit();
    }
}