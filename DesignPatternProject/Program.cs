using DesignPatternProject;

GITUser gitUser1 = new("Lally");
var repo1 = gitUser1.AddRepository("repo1");
var b1 = repo1.CreateBranch("b1", "Lally");
b1.AddFile(new Folder("folder1", "Lally"));
gitUser1.print();


