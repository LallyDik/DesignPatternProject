using DesignPatternProject.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternProject;

public abstract class Component
{
    public abstract string Name { get; set; }
    public abstract IState Status { get; set; }
    public abstract string Owner { get; set; }
    public Component(string name, string owner)
    {
        Name = name;
        Owner = owner;
        Status = Draft.GetInstance();
    }
    public void SetState(IState state)
    {
       Status = state;
    }
    public abstract void Merge(Component other);
    public abstract void Undo();
    public void RequestReview()
    {
        if (Status == Commited.GetInstance())
        {
            Console.WriteLine($"The file {Name} wait to review");
        }
        Status.ChangeStatus(this);
        
    }

}
