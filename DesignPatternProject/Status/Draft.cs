using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternProject.States;

public class Draft : IState
{
    private static Draft instanse;
    private Draft() { }
    public static Draft GetInstance()
    {
        instanse ??= new Draft();
        return instanse;
    }
    public void ChangeStatus(Component component)
    {
        component.SetState(Staged.GetInstance());
    }

    public string GetStatus()
    {
        return "Draft";
    }
}
