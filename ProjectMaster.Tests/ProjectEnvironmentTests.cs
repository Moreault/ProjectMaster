namespace ProjectMaster.Tests;

public static class Names
{
    public const string Organization = "Bogus Corp";
    public const string Project = "Weirdapp";
}

[TestClass]
public class ProjectEnvironmentTests
{
    [TestClass]
    public class AllUsers_UnsetOrganization : Tester<UnsetOrganizationDummyProjectEnvironment>
    {
        [TestMethod]
        public void WhenOrganizationNameIsUnset_DoNotUseAny()
        {
            //Arrange
            var baseDataPath = Fixture.Create<string>();
            GetMock<IEnvironment>().Setup(x => x.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)).Returns(baseDataPath);

            //Act
            var result = Instance.AllUsers;

            //Assert
            result.Should().Be(Path.Combine(baseDataPath, Names.Project));
        }
    }

    [TestClass]
    public class AllUsers_UnsetProject : Tester<UnsetProjectDummyProjectEnvironment>
    {
        [TestMethod]
        public void WhenProjectNameIsUnset_Throw()
        {
            //Arrange

            //Act
            var action = () => Instance.AllUsers;

            //Assert
            action.Should().Throw<Exception>().WithMessage(Exceptions.ProjectNameIsNotSet);
        }
    }

    [TestClass]
    public class AllUsers : Tester<DummyProjectEnvironment>
    {
        [TestMethod]
        public void WhenNamesAreSet_Return()
        {
            //Arrange
            var baseDataPath = Fixture.Create<string>();
            GetMock<IEnvironment>().Setup(x => x.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)).Returns(baseDataPath);

            //Act
            var result = Instance.AllUsers;

            //Assert
            result.Should().Be(Path.Combine(baseDataPath, Names.Organization, Names.Project));
        }
    }

    [TestClass]
    public class LocalUser_UnsetOrganization : Tester<UnsetOrganizationDummyProjectEnvironment>
    {
        [TestMethod]
        public void WhenOrganizationNameIsUnset_Throw()
        {
            //Arrange
            var baseDataPath = Fixture.Create<string>();
            GetMock<IEnvironment>().Setup(x => x.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)).Returns(baseDataPath);

            //Act
            var result = Instance.LocalUser;

            //Assert
            result.Should().Be(Path.Combine(baseDataPath, Names.Project));
        }
    }

    [TestClass]
    public class LocalUser_UnsetProject : Tester<UnsetProjectDummyProjectEnvironment>
    {
        [TestMethod]
        public void WhenOrganizationNameIsUnset_Throw()
        {
            //Arrange

            //Act
            var action = () => Instance.LocalUser;

            //Assert
            action.Should().Throw<Exception>().WithMessage(Exceptions.ProjectNameIsNotSet);
        }
    }

    [TestClass]
    public class LocalUser : Tester<DummyProjectEnvironment>
    {
        [TestMethod]
        public void WhenNamesAreSet_Return()
        {
            //Arrange
            var baseDataPath = Fixture.Create<string>();
            GetMock<IEnvironment>().Setup(x => x.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)).Returns(baseDataPath);

            //Act
            var result = Instance.LocalUser;

            //Assert
            result.Should().Be(Path.Combine(baseDataPath, Names.Organization, Names.Project));
        }
    }

    [TestClass]
    public class RoamingUser_UnsetOrganization : Tester<UnsetOrganizationDummyProjectEnvironment>
    {
        [TestMethod]
        public void WhenOrganizationNameIsUnset_Throw()
        {
            //Arrange
            var baseDataPath = Fixture.Create<string>();
            GetMock<IEnvironment>().Setup(x => x.GetFolderPath(Environment.SpecialFolder.ApplicationData)).Returns(baseDataPath);

            //Act
            var result = Instance.RoamingUser;

            //Assert
            result.Should().Be(Path.Combine(baseDataPath, Names.Project));
        }
    }

    [TestClass]
    public class RoamingUser_UnsetProject : Tester<UnsetProjectDummyProjectEnvironment>
    {
        [TestMethod]
        public void WhenOrganizationNameIsUnset_Throw()
        {
            //Arrange

            //Act
            var action = () => Instance.RoamingUser;

            //Assert
            action.Should().Throw<Exception>().WithMessage(Exceptions.ProjectNameIsNotSet);
        }
    }

    [TestClass]
    public class RoamingUser : Tester<DummyProjectEnvironment>
    {
        [TestMethod]
        public void WhenNamesAreSet_Return()
        {
            //Arrange
            var baseDataPath = Fixture.Create<string>();
            GetMock<IEnvironment>().Setup(x => x.GetFolderPath(Environment.SpecialFolder.ApplicationData)).Returns(baseDataPath);

            //Act
            var result = Instance.RoamingUser;

            //Assert
            result.Should().Be(Path.Combine(baseDataPath, Names.Organization, Names.Project));
        }
    }

    [TestClass]
    public class TemporaryFiles_UnsetOrganization : Tester<UnsetOrganizationDummyProjectEnvironment>
    {
        [TestMethod]
        public void WhenOrganizationNameIsUnset_Throw()
        {
            //Arrange

            //Act
            var result = Instance.TemporaryFiles;

            //Assert
            result.Should().Be(Path.Combine(Path.GetTempPath(), Names.Project));
        }
    }

    [TestClass]
    public class TemporaryFiles_UnsetProject : Tester<UnsetProjectDummyProjectEnvironment>
    {
        [TestMethod]
        public void WhenOrganizationNameIsUnset_Throw()
        {
            //Arrange

            //Act
            var action = () => Instance.TemporaryFiles;

            //Assert
            action.Should().Throw<Exception>().WithMessage(Exceptions.ProjectNameIsNotSet);
        }
    }

    [TestClass]
    public class TemporaryFiles : Tester<DummyProjectEnvironment>
    {
        [TestMethod]
        public void WhenNamesAreSet_Return()
        {
            //Arrange

            //Act
            var result = Instance.TemporaryFiles;

            //Assert
            result.Should().Be(Path.Combine(Path.GetTempPath(), Names.Organization, Names.Project));
        }
    }

    [TestClass]
    public class PersonalDocuments_UnsetOrganization : Tester<UnsetOrganizationDummyProjectEnvironment>
    {
        [TestMethod]
        public void WhenOrganizationNameIsUnset_Throw()
        {
            //Arrange
            var baseDataPath = Fixture.Create<string>();
            GetMock<IEnvironment>().Setup(x => x.GetFolderPath(Environment.SpecialFolder.MyDocuments)).Returns(baseDataPath);

            //Act
            var result = Instance.PersonalDocuments;

            //Assert
            result.Should().Be(Path.Combine(baseDataPath, Names.Project));
        }
    }

    [TestClass]
    public class PersonalDocuments_UnsetProject : Tester<UnsetProjectDummyProjectEnvironment>
    {
        [TestMethod]
        public void WhenOrganizationNameIsUnset_Throw()
        {
            //Arrange

            //Act
            var action = () => Instance.PersonalDocuments;

            //Assert
            action.Should().Throw<Exception>().WithMessage(Exceptions.ProjectNameIsNotSet);
        }
    }

    [TestClass]
    public class PersonalDocuments : Tester<DummyProjectEnvironment>
    {
        [TestMethod]
        public void WhenNamesAreSet_Return()
        {
            //Arrange
            var baseDataPath = Fixture.Create<string>();
            GetMock<IEnvironment>().Setup(x => x.GetFolderPath(Environment.SpecialFolder.MyDocuments)).Returns(baseDataPath);

            //Act
            var result = Instance.PersonalDocuments;

            //Assert
            result.Should().Be(Path.Combine(baseDataPath, Names.Organization, Names.Project));
        }
    }

}