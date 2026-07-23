using GFramework.Core.Abstractions.enums;
using GFramework.Core.Abstractions.system;
using GFrameworkTemplate.scripts.cqrs.desktop_pet.@event;
using GFrameworkTemplate.scripts.entities.desktop_pet;
using GFrameworkTemplate.scripts.entities.desktop_pet.state;
using GFrameworkTemplate.scripts.enums.desktop_pet;
using GFrameworkTemplate.scripts.model.desktop_pet;

namespace GFrameworkTemplate.scripts.system.desktop_pet;

[Log]
[ContextAware]
public partial class DesktopPetStateSystem : ISystem
{
    private struct StateBundle
    {
        public Dictionary<DesktopPetStateType, IDesktopPetState> States;
        public IDesktopPetState CurrentState;
        public IDesktopPetState PreviousState;
    }

    private Dictionary<Guid, StateBundle> Bundles = [];

    public void OnArchitecturePhase(ArchitecturePhase phase)
    {
    }

    public void Init()
    {
        _log.Debug("System initialized: DesktopPetStateSystem");
    }

    public void Destroy()
    {
        _log.Debug("System destroyed: DesktopPetStateSystem");
    }

    public void InitStates(IDesktopPet desktopPet)
    {
        var states = new Dictionary<DesktopPetStateType, IDesktopPetState>
        {
            { DesktopPetStateType.Idle, new IdleState() },
            { DesktopPetStateType.Drag, new DragState() },
        };

        foreach (var (type, state) in states)
        {
            state.Type = type;
            state.DesktopPet = desktopPet;
        }

        Bundles[desktopPet.Id] = new StateBundle { States = states };
    }

    public void RemoveBundle(Guid id)
    {
        Bundles.Remove(id);
    }

    public void ChangeTo(Guid id, DesktopPetStateType target)
    {
        var b = Bundles[id];
        var next = b.States[target];

        if (b.CurrentState is null)
        {
            b.CurrentState = next;
            b.CurrentState.Enter();
            Bundles[id] = b;
            return;
        }

        if (b.CurrentState == next) return;

        b.CurrentState.Exit();
        b.PreviousState = b.CurrentState;
        b.CurrentState = next;
        b.CurrentState.Enter();
        Bundles[id] = b;

        this.SendEvent(new DesktopPetStateChangedEvent
        {
            Previous = b.PreviousState.Type,
            Current = b.CurrentState.Type
        });

        var model = this.GetModel<DesktopPetModel>()!;
        model.CurrentState = b.CurrentState;
        model.PreviousState = b.PreviousState;
    }

    public void Process(Guid id, double delta)
    {
        Bundles[id].CurrentState.Process(delta);
    }

    public void GuiInput(Guid id, InputEvent inputEvent)
    {
        Bundles[id].CurrentState.GuiInput(inputEvent);
    }

    public void MouseDown(Guid id)
    {
        Bundles[id].CurrentState.MouseDown();
    }

    public void MouseUp(Guid id)
    {
        Bundles[id].CurrentState.MouseUp();
    }

    public void MouseEnter(Guid id)
    {
        Bundles[id].CurrentState.MouseEnter();
    }

    public void MouseExit(Guid id)
    {
        Bundles[id].CurrentState.MouseExit();
    }
}