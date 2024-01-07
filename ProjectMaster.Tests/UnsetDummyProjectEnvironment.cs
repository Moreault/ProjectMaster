namespace ProjectMaster.Tests;

public class UnsetOrganizationDummyProjectEnvironment(IEnvironment environment) : ProjectEnvironment(environment)
{
    protected override string OrganizationName { get; } = string.Empty;

    protected override string ProjectName => Names.Project;
}

public class UnsetProjectDummyProjectEnvironment(IEnvironment environment) : ProjectEnvironment(environment)
{
    protected override string OrganizationName => Names.Organization;

    protected override string ProjectName { get; } = string.Empty;
}
