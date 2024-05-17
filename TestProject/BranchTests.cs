using ExpressPost_CourseWork;

namespace TestProject;

public class BranchTests
{
    public DB_DataManager dataManager = new DB_DataManager();

    [SetUp]
    public void Setup()
    {
        dataManager.GetBranches();
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}