using GFrameworkTemplate.scripts.cqrs.desktop_pet.command;

namespace GFrameworkTemplate.scripts.entities.desktop_pet;

public partial class DesktopPet
{
    private void ConnectSignal()
    {
        ButtonDown += OnButtonDown;
        ButtonUp += OnButtonUp;
        MouseEntered += OnMouseEntered;
        MouseExited += OnMouseExited;
    }

    private void OnButtonDown()
    {
        this.SendCommand(new DesktopPetMouseDownCommand { DesktopPetId = Id });
    }

    private void OnButtonUp()
    {
        this.SendCommand(new DesktopPetMouseUpCommand { DesktopPetId = Id });
    }

    private void OnMouseEntered()
    {
        this.SendCommand(new DesktopPetMouseEnterCommand { DesktopPetId = Id });
    }

    private void OnMouseExited()
    {
        this.SendCommand(new DesktopPetMouseExitCommand { DesktopPetId = Id });
    }
}