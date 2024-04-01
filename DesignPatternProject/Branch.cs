using DesignPatternProject.States;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternProject;

public class Branch : Component
{
    private string _name;
    private IState _status;
    private string _owner;
    private Stack<Branch> history;

    public Branch(string name, string owner) : base(name, owner)
    {
        _components = new();
        history = new();
        history.Push(this);
    }

    private Dictionary<string, IFile> _components; 
    public override string Name { get => _name; set =>_name = value ; }
    public override IState Status { get => _status; set => _status = value; }
    public override string Owner { get => _owner; set => _owner = value; }

    public Dictionary<string, IFile> GetComponents() { return _components; }
    public  void SetComponents(Dictionary<string, IFile> components) { _components = components; }
    public void AddFile(IFile file)
    {
        _components[file.Name] = file;
    }
    public override void Merge(Component other)
    {
        if (other is Branch)
        {
            if (other.Status.GetStatus() != "Ready To Merge")
            {
                Console.WriteLine("you can not merge");
                return;
            }
            foreach (var component in ((Branch)other).GetComponents())
            {

                if (!((Branch)other).GetComponents().ContainsKey(component.Key))
                {
                    if(component.Value is IFile)
                        AddFile(component.Value);
                }
                else
                {
                    if (component.Value is MyFile) {
                        var f = ((Branch)other).GetComponents().GetValueOrDefault(component.Key);
                        f.Merge(other);
                    }
                    if(component.Value is Folder)
                    {
                        bool v = ((Branch)other).GetComponents().TryGetValue(component.Key, out IFile f);
                        if (v) f.Merge(other);
                    }
                }
            }
            history.Push(this);
        }
        else
        {
            Console.WriteLine("can't merge branch with other things");
        }
    }
    public void Commit()
    {
        if (Status.GetStatus() == "Staged")
        {
            Status.ChangeStatus(this);
            history.Push(this);
        }
    }
    public override void Undo()
    {
        Branch last = history.Pop();
        if (last == null) return;
        this.Status = last.Status;
        this.SetComponents(last.GetComponents());
    }
    public void Print()
    {
        Console.WriteLine($" I'm Branch {this._name} and my Files are:");
        foreach (var c in _components)
        {
            c.Value.Print();
        }
    }
    //public bool Add(IFile file)
    //{
    //    if (!components.ContainsKey(file.Name))
    //    {
    //        components[file.Name] = file;
    //    }
    //}
}
