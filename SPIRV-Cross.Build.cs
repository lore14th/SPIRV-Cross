// Tinfoil Engine build script

using Sharpmake;
using System.IO;
using TinfoilBuildTool;

[BuildModule(typeof(TinfoilProject))]
public class SPIRV_Cross : TinfoilThirdPartyModuleDependency
{
	public SPIRV_Cross(ReadOnlyModuleRules rules) : base(rules)
	{
	}

	public override void ConfigureBuild(Project.Configuration config, ITarget target)
	{
		base.ConfigureBuild(config, target);

		config.IncludePaths.Add("[project.SharpmakeCsPath]");

		// C4065: switch without case labels
		config.Options.Add(new Options.Vc.Compiler.DisableSpecificWarnings("4065"));

		config.SourceFilesBuildExclude.AddRange(Directory.EnumerateFiles(Path.Combine(RootDirectory, "samples"), "*", SearchOption.AllDirectories));
		config.SourceFilesBuildExclude.AddRange(Directory.EnumerateFiles(Path.Combine(RootDirectory, "shaders-other"), "*", SearchOption.AllDirectories));
		config.SourceFilesBuildExclude.AddRange(Directory.EnumerateFiles(Path.Combine(RootDirectory, "tests-other"), "*", SearchOption.AllDirectories));
	}
}
