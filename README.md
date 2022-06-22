![ProjectMaster](https://github.com/Moreault/ProjectMaster/blob/master/projectmaster.png)
# ProjectMaster
Provides a base class to format and access application data paths in an easy and straightforward way.

This package merely combines your data paths with your application name in a reusable class so that you don't have to repeat yourself.

```c#
//Instead of doing this
var path = Path.Combine(Environment.SpecialFolder.LocalApplicationData, "My Application");

//You can just do this
var path = _projectEnvironment.LocalUser;
```

## Getting started

### Setup

ProjectMaster works with DI so you're going to have to use the following method wherever you inject things to get it to work:

```c#
services.AddNetAbstractions();
```

You can skip the above line if you are already using either ToolBX.AutoInject or ToolBX.AssemblyInitializer.

### Creating your own ProjectEnvironment class

```c#
public class MyProjectEnvironment : ProjectEnvironment
{
    //Organization is optional and can be left blank
    protected override string OrganizationName => "My organization";

    //Project is mandatory and your ProjectEnvironment class WILL throw if it is omitted or left blank
    protected override string ProjectName => "My project";

    public DummyProjectEnvironment(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}
```

You can (should) take advantage of the AutoInject library this way but it is entirely up to you :

```c#
//It will automatically link to IProjectEnvironment so you don't even need to make your own interface!
[AutoInject]
public class MyProjectEnvironment : ProjectEnvironment
{
    ...
}
```

Otherwise, you can use the following to inject it manually :

```c#
services.AddSingleton<IProjectEnvironment, MyProjectEnvironment>();
```

## How do I use it?

Once you have your custom class and it is injected in your code :

```c#
private readonly IProjectEnvironment _projectEnvironment;

public SomeClass(IProjectEnvironment projectEnvironment)
{
    _projectEnvironment = projectEnvironment;
}

public void Something()
{
    //On windows would return something like : "c:/Users/Default/AppData/Local/My organization/My project/"
    var path = _projectEnvironment.AllUsers;

    //"c:/Users/YourName/AppData/Local/My organization/My project/"
    path = _projectEnvironment.LocalUser;

    //"c:/Users/YourName/AppData/Roaming/My organization/My project/"
    path = _projectEnvironment.RoamingUser;

    //"c:/Users/YourName/AppData/Local/Temp/My organization/My project/"
    path = _projectEnvironment.TemporaryFiles;
}
```

## I'm making a video game : where should save files go?
There is not a one-size fits all response to this. Some put it in the local user's app data but others put it in the user's Documents folder. I even hear that it's not uncommon to keep save files in the game's installation folder.

Steam seems to like putting it in 'Documents/My Games/Game name/'.

Personally, I put it in the roaming user's folder. This approach should work seamlessly across most (if not all) modern operating systems.