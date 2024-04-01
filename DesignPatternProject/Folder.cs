using DesignPatternProject.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternProject;

public class Folder : Component, IFile
{
    private string _name;
    private IState _status;
    private string _owner;
    private Stack<Folder> history;
    public override string Name { get => _name; set => _name = value; }
    public override IState Status { get => _status; set => _status = value; }
    public override string Owner { get => _owner; set => _owner = value; }

    private Dictionary<string, IFile> files = new();

    public Folder(string name, string owner) : base(name, owner) { }
    public Dictionary<string, IFile> GetFiles()
    {
        return files;
    }
    public override void Merge(Component other)
    {
        if (other.Status.GetStatus() != "ready To Merge")
        {
            Console.WriteLine("can't merge, the status is not ready to merge");
            return;
        }
        if (other is Folder)
        {
            foreach (var file in ((Folder)other).GetFiles())
            {
                if (file is Folder)
                {
                    Merge((Folder)file.Value);
                }
                else
                {
                    if (files.ContainsKey(file.Value.Name))
                    {
                        MyFile f = (MyFile)files[file.Value.Name];
                        f.Merge((MyFile)file.Value);
                    }
                    else
                    {
                        files.Add(other.Name, (IFile)other);
                    }
                }
            }
            history.Push(this);
        }
        else if (other is MyFile)
        {
            files.Add(other.Name, (IFile) other);
            history.Push(this);
        }
        else
        {
            Console.WriteLine("can't merge folder with branch");
        }
    }

    public override void Undo()
    {
        Folder last = history.Pop();
        if (last == null) return;
        this.SetState(last.Status);
        this.files = last.files;
    }

    public void Print()
    {
        Console.WriteLine($"I'm folder {this.Name} and my files are:");
        foreach (var file in this.files)
        {
            file.Value.Print();
        }
    }
}
