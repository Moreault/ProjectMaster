namespace ProjectMaster.Tests;

public class DummyProjectEnvironment : ProjectEnvironment
{
    protected override string OrganizationName => Names.Organization;

    protected override string ProjectName => Names.Project;

    public DummyProjectEnvironment(IEnvironment environment) : base(environment)
    {
    }
}