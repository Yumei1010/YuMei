using GFrameworkTemplate.scripts.entities.desktop_pet.state;

namespace GFrameworkTemplate.scripts.cqrs.desktop_pet.query.result;

public sealed class DesktopPetStateResult
{
    public required IDesktopPetState CurrentState { get; init; }
    public required IDesktopPetState PreviousState { get; init; }
}