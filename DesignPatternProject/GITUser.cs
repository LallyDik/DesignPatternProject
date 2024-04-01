using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternProject;

public class GITUser
{
    public string UserName { get; set; }
    public Dictionary<string, Repository> Repositories = new();
    public Repository AddRepository(string name)
    {
        var r = new Repository(name);
        Repositories.Add(name, r);
        return r;
    }

    public GITUser(string userName)
    {
        UserName = userName;
    }
    public void print()
    {
        Console.WriteLine($"I'm a git user {this.UserName} and my repos are:");
        foreach (var repo in Repositories)
        {
            repo.Value.Print();
        }
    }
}
