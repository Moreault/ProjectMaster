namespace ToolBX.ProjectMaster;

/// <summary>
/// Application-specific paths.
/// </summary>
public interface IProjectEnvironment
{
    /// <summary>
    /// Common data repository used by all users of the system.
    /// </summary>
    string AllUsers { get; }

    /// <summary>
    /// Data repository that is limited to the current system.
    /// </summary>
    string LocalUser { get; }

    /// <summary>
    /// Data repository that can be carried across networks on multiple systems that the user logs into.
    /// </summary>
    string RoamingUser { get; }

    /// <summary>
    /// Temporary data for the current local user.
    /// </summary>
    string TemporaryFiles { get; }

    /// <summary>
    /// The "My Documents" folder for the current user.
    /// </summary>
    string PersonalDocuments { get; }
}

public abstract class ProjectEnvironment : IProjectEnvironment
{
    protected virtual string OrganizationName => string.Empty;
    protected abstract string ProjectName { get; }

    public string AllUsers => _allUsers.Value;
    private readonly Lazy<string> _allUsers;

    public string LocalUser => _localUser.Value;
    private readonly Lazy<string> _localUser;

    public string RoamingUser => _roamingUser.Value;
    private readonly Lazy<string> _roamingUser;

    public string TemporaryFiles => _temporaryFiles.Value;
    private readonly Lazy<string> _temporaryFiles;

    public string PersonalDocuments => _personalDocuments.Value;
    private readonly Lazy<string> _personalDocuments;

    protected ProjectEnvironment(IEnvironment environment)
    {
        _allUsers = new Lazy<string>(() =>
        {
            EnsureProjectNameIsSet();
            return BuildPathWithRoot(environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
        });
        _localUser = new Lazy<string>(() =>
        {
            EnsureProjectNameIsSet();
            return BuildPathWithRoot(environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
        });
        _roamingUser = new Lazy<string>(() =>
        {
            EnsureProjectNameIsSet();
            return BuildPathWithRoot(environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
        });
        _temporaryFiles = new Lazy<string>(() =>
        {
            EnsureProjectNameIsSet();
            return BuildPathWithRoot(Path.GetTempPath());
        });
        _personalDocuments = new Lazy<string>(() =>
        {
            EnsureProjectNameIsSet();
            return BuildPathWithRoot(environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
        });
    }

    private void EnsureProjectNameIsSet()
    {
        if (string.IsNullOrWhiteSpace(ProjectName)) throw new Exception(Exceptions.ProjectNameIsNotSet);
    }

    private string BuildPathWithRoot(string root)
    {
        return string.IsNullOrWhiteSpace(OrganizationName) ? Path.Combine(root, ProjectName) : Path.Combine(root, OrganizationName, ProjectName);
    }
}