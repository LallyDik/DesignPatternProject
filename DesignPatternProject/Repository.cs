using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternProject;

public class Repository
{
    public string RepositoryName { get; set; }
    Dictionary<string,Branch> branches  = new() { { "main", new Branch("main","owner") } };
    public Branch GetBranch(string name)
    {
        return branches[name];
    }
    public void DeleteBranch(string name)
    {
       branches.Remove(name);
    }
    public Branch CreateBranch(string name, string userName)
    {
        var b = new Branch(name, userName);
        branches.Add(name, b);
        return b;
    }

    public Repository(string repositoryName)
    {
        RepositoryName = repositoryName;
    }
    public void Print()
    {
        Console.WriteLine($" I'm repo {this.RepositoryName} and my branches are:");
        foreach (var b in branches)
        {
            b.Value.Print();
        }
    }
}
