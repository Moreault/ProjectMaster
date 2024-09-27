namespace ProjectMaster.Tests;

public class UnsetOrganizationGarbageProjectEnvironment(IEnvironment environment) : ProjectEnvironment(environment)
{
    protected override string OrganizationName { get; } = string.Empty;

    protected override string ProjectName => Names.Project;
}

public class UnsetProjectGarbageProjectEnvironment(IEnvironment environment) : ProjectEnvironment(environment)
{
    protected override string OrganizationName => Names.Organization;

    protected override string ProjectName { get; } = string.Empty;
}
