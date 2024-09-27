namespace ProjectMaster.Tests;

public class GarbageProjectEnvironment : ProjectEnvironment
{
    protected override string OrganizationName => Names.Organization;

    protected override string ProjectName => Names.Project;

    public GarbageProjectEnvironment(IEnvironment environment) : base(environment)
    {
    }
}