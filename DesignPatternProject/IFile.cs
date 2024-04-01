using DesignPatternProject.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternProject;

public interface IFile
{
    string Name { get; }
    public void Merge(Component other);
    public void Undo();
    public void Print();

}
