using GFrameworkTemplate.scripts.enums.desktop_pet;

namespace GFrameworkTemplate.scripts.entities.desktop_pet;

public interface IDesktopPet
{
    Guid Id { get; }

    Vector2 GlobalPosition { get; set; }

    void ChangeTo(DesktopPetStateType state);

    Window GetWindow();

    Vector2 Size { get; }
}