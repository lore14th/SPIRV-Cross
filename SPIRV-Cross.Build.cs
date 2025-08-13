// SPIRV-Cross Tinfoil build script

using Sharpmake;
using System;
using System.IO;
using System.Collections.Generic;

[Sharpmake.Generate]
public class SpirvCross : TinfoilProjectBase
{
	public SpirvCross()
	{
		Name = "SPIRV-Cross";
		SourceFiles.Add("SPIRV-Cross.Build.cs");
	}

	public override void ConfigureProject(Project.Configuration config, TinfoilTarget target)
	{
		config.Output = Configuration.OutputType.Lib;
		
		config.Options.Add(Options.Vc.Compiler.CppLanguageStandard.CPP17);
		config.Options.Add(Options.Vc.Compiler.Exceptions.EnableWithSEH);
		config.Options.Add(Options.Vc.Compiler.RTTI.Enable);
		config.Options.Add(Options.Vc.General.WindowsTargetPlatformVersion.Latest);
		config.Options.Add(Options.Vc.Librarian.TreatLibWarningAsErrors.Enable);

		// C4065: switch without case labels
		config.Options.Add(new Options.Vc.Compiler.DisableSpecificWarnings("4065"));

		config.IncludePaths.Add(@"");

		ExcludeFolder(config, target, "samples");
		ExcludeFolder(config, target, "shaders-other");
		ExcludeFolder(config, target, "tests-other");
	}
}
