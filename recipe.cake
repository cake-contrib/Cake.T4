#load nuget:https://ci.appveyor.com/nuget/cake-recipe?package=Cake.Recipe&version=2.0.0-alpha0433&prerelease

Environment.SetVariableNames();

BuildParameters.SetParameters(
	context: Context,
	buildSystem: BuildSystem,
	appVeyorAccountName: "cakecontrib",
	preferredBuildAgentOperatingSystem: PlatformFamily.Linux,
	repositoryName: "Cake.T4",
	repositoryOwner: "cake-contrib",
	shouldRunCodecov: true,
	shouldRunCoveralls: false,
	shouldRunDotNetCorePack: true,
	shouldUseDeterministicBuilds: true,
	shouldUseTargetFrameworkPath: false,
	sourceDirectoryPath: "./src",
	title: "Cake.T4"
);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context);

ToolSettings.SetToolPreprocessorDirectives(
	// Workaround until Cake.Kudu can resolve .NET Core edition
	kuduSyncGlobalTool: "#tool nuget:?package=KuduSync.NET&version=1.5.3"
);

Build.RunDotNetCore();
