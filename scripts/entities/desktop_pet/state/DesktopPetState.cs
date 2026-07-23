using GFrameworkTemplate.scripts.enums.desktop_pet;

namespace GFrameworkTemplate.scripts.entities.desktop_pet.state;

public abstract class DesktopPetState : IDesktopPetState
{
    public DesktopPetStateType Type { get; set; }

    public IDesktopPet DesktopPet { get; set; }

    protected void ChangeTo(DesktopPetStateType state)
    {
        DesktopPet.ChangeTo(state);
    }

    public virtual void GuiInput(InputEvent inputEvent) { }

    public virtual void Enter() { }

    public virtual void Exit() { }

    public virtual void MouseEnter() { }

    public virtual void MouseExit() { }

    public virtual void MouseDown() { }

    public virtual void MouseUp() { }

    public virtual void Process(double delta) { }
}