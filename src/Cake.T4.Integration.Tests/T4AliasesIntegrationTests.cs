namespace Cake.T4.Integration.Tests.T4AliasesIntegrationTests
{
	using System.IO;
	using System.Reflection;
	using Cake.Common.IO;
	using Cake.Core;
	using Cake.Frosting;
	using Cake.T4;
	using NUnit.Framework;

	[TestFixture]
	[TestOf(typeof(T4Aliases))]
	public class CakeT4IntegrationTests
	{
		private ICakeHost _host;
		private ICakeContext _context;

		[OneTimeSetUp]
		public void InitializeHost()
		{
			(_host, _context) = FrostingSetupper.BuildHost("--verbosity=Diagnostic");
			_context.DotNetCoreToolInstall("dotnet-t4", "2.0.5", "t4");
			if (_context.FileExists("basic.txt"))
			{
				_context.DeleteFile("basic.txt");
			}
		}

		[Test]
		public void Should_Transform_On_Input_Only()
		{
			const string filePath = "basic.tt";

			_context.T4(filePath);

			Assert.That(new FileInfo("basic.txt"), Does.Exist);
			Assert.That(File.ReadAllText("basic.txt").Trim(), Is.EqualTo("success"));
		}
	}
}
