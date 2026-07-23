using GFramework.Core.query;
using GFrameworkTemplate.scripts.cqrs.desktop_pet.query.result;
using GFrameworkTemplate.scripts.model.desktop_pet;

namespace GFrameworkTemplate.scripts.cqrs.desktop_pet.query;

public sealed class GetDesktopPetStateQuery : AbstractQuery<DesktopPetStateResult>
{
    protected override DesktopPetStateResult OnDo()
    {
        var model = this.GetModel<DesktopPetModel>()!;
        return new DesktopPetStateResult
        {
            CurrentState = model.CurrentState,
            PreviousState = model.PreviousState
        };
    }
}