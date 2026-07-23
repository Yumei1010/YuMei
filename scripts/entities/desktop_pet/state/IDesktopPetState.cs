using GFrameworkTemplate.scripts.component.state_machine;
using GFrameworkTemplate.scripts.enums.desktop_pet;

namespace GFrameworkTemplate.scripts.entities.desktop_pet.state;

public interface IDesktopPetState : IState
{
    DesktopPetStateType Type { get; set; }

    IDesktopPet DesktopPet { get; set; }

    void GuiInput(InputEvent inputEvent);

    void MouseEnter();

    void MouseExit();

    void MouseDown();

    void MouseUp();
}