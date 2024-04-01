using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternProject.States;

public class ReadyToMerge : IState
{
    private static ReadyToMerge instanse;
    private ReadyToMerge() { }
    public static ReadyToMerge GetInstance()
    {
        instanse ??= new ReadyToMerge();
        return instanse;
    }
    public void ChangeStatus(Component component)
    {
        component.SetState(Merged.GetInstance());
    }

    public string GetStatus()
    {
        return "Ready To Marge";
    }
}
