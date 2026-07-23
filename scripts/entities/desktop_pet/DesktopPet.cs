using GFramework.Core.Abstractions.controller;
using GFrameworkTemplate.scripts.cqrs.desktop_pet.command;
using GFrameworkTemplate.scripts.enums.desktop_pet;
using Godot;

namespace GFrameworkTemplate.scripts.entities.desktop_pet;

[Log]
[ContextAware]
public partial class DesktopPet : Button, IDesktopPet, IController
{
    public override void _Ready()
    {
        _ = ReadyAsync();
        ConnectSignal();
        RegisterEvent();
    }

    public override void _ExitTree()
    {
        this.SendCommand(new DesktopPetRemoveStateCommand { DesktopPetId = Id });
    }

    public override void _Process(double delta)
    {
        this.SendCommand(new DesktopPetProcessCommand { DesktopPetId = Id, Delta = delta });
    }

    public override void _GuiInput(InputEvent @event)
    {
        if (@event is InputEventMouseButton mouseBtn
            && mouseBtn.ButtonIndex == MouseButton.Right
            && mouseBtn.IsPressed())
        {
            PopupMenu.Position = new Vector2I((int)mouseBtn.GlobalPosition.X, (int)mouseBtn.GlobalPosition.Y);
            PopupMenu.Show();
            return;
        }

        this.SendCommand(new DesktopPetGuiInputCommand { DesktopPetId = Id, InputEvent = @event });
    }

    public void ChangeTo(DesktopPetStateType state)
    {
        this.SendCommand(new DesktopPetChangeStateCommand { DesktopPetId = Id, State = state });
    }
}