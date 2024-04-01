using DesignPatternProject.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DesignPatternProject;

public class MyFile : Component, IFile
{
    private string _code;
    private string _owner;
    private string _name;
    private IState _status;
    private Stack<MyFile> history= new();
    public MyFile(string name, string owner) : base(name, owner) { history.Push(this); }
    public override string Name { get => _name; set => _name = value; }
    public override IState Status { get => _status; set => _status = value; }
    public override string Owner { get => _owner; set => _owner = value; }
    public string GetCode() => _code;
    public override void Merge(Component other)
    {
        var f = (MyFile) other;
        _code += f.GetCode();
        history.Push(f);
    }

    public void Print()
    {
        Console.WriteLine($"I'm file {this._name}");
    }

    public override void Undo()
    {
        var last = history.Pop();
        if (last == null) return;
        this._code = last.GetCode();
        this.SetState(last.Status);
    }
}
