using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternProject.States;

public interface IState
{
    public void ChangeStatus(Component component);
    public string GetStatus();
}
