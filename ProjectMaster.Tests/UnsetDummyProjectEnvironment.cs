namespace ProjectMaster.Tests;

public class UnsetOrganizationDummyProjectEnvironment : ProjectEnvironment
{
    protected override string OrganizationName { get; }

    protected override string ProjectName => Names.Project;

    public UnsetOrganizationDummyProjectEnvironment(IEnvironment environment) : base(environment)
    {
    }
}

public class UnsetProjectDummyProjectEnvironment : ProjectEnvironment
{
    protected override string OrganizationName => Names.Organization;

    protected override string ProjectName { get; }

    public UnsetProjectDummyProjectEnvironment(IEnvironment environment) : base(environment)
    {
    }
}
