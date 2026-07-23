using GFramework.Core.model;
using GFrameworkTemplate.scripts.entities.desktop_pet.state;

namespace GFrameworkTemplate.scripts.model.desktop_pet;
public class DesktopPetModel : AbstractModel
{
    public IDesktopPetState CurrentState = null!;
    public IDesktopPetState PreviousState = null!;

    protected override void OnInit()
    {
        
    }
}