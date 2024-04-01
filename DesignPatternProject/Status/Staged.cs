using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternProject.States;

public class Staged : IState
{
    private static Staged instanse;
    private Staged() { }
    public static Staged GetInstance()
    {
        instanse ??= new Staged();
        return instanse;
    }
    public void ChangeStatus(Component component)
    {
        component.SetState(Commited.GetInstance());
    }

    public string GetStatus()
    {
        return "Staged";
    }
}
