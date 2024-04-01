using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternProject.States;

public class UnderReview : IState
{
    private static UnderReview instanse;
    private UnderReview() { }
    public static UnderReview GetInstance()
    {
        instanse ??= new UnderReview();
        return instanse;
    }
    public void ChangeStatus(Component component)
    {
        component.SetState(ReadyToMerge.GetInstance());
    }

    public string GetStatus()
    {
        return "Under Review";
    }
}
