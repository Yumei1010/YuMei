using GFrameworkTemplate.scripts.enums.desktop_pet;

namespace GFrameworkTemplate.scripts.cqrs.desktop_pet.@event;

public sealed class DesktopPetStateChangedEvent
{
    public required DesktopPetStateType Previous { get; init; }
    public required DesktopPetStateType Current { get; init; }
}