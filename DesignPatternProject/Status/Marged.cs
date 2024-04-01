using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternProject.States;

public class Merged : IState
{
    private static Merged instanse;
    private Merged() { }
    public static Merged GetInstance()
    {
        instanse ??= new Merged();
        return instanse;
    }
    public void ChangeStatus(Component component)
    {
        Console.WriteLine("maraged");
    }

    public string GetStatus()
    {
        throw new NotImplementedException();
    }
}
