using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternProject.States;

public class Commited : IState
{
    private static Commited instanse;
    private Commited() { }
    public static Commited GetInstance()
    {
        instanse ??= new Commited();
        return instanse;
    }
    public void ChangeStatus(Component component)
    {
        component.SetState(UnderReview.GetInstance());
    }

    public string GetStatus()
    {
        return "Commited";
    }
}
