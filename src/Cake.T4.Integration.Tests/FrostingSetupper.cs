namespace Cake.T4.Integration.Tests
{
	using System.Reflection;
	using Cake.Core;
	using Cake.Frosting;

	public class FrostingSetupper : IFrostingStartup
	{
		public static (ICakeHost, ICakeContext) BuildHost(params string[] arguments)
		{
			var host = new CakeHostBuilder()
				.WithArguments(arguments)
				.UseStartup<FrostingSetupper>()
				.Build();

			var context = host.GetType().GetField("_context", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(host);

			return (host, (ICakeContext)context);
		}

		public void Configure(ICakeServices services)
		{
			services.UseContext<FrostingContext>();
			services.UseLifetime<FrostingLifetime>();
			services.UseWorkingDirectory(".");
		}
	}

	public class FrostingLifetime : FrostingLifetime<FrostingContext>
	{
		public override void Setup(FrostingContext context)
		{
			context.DotNetCoreToolInstall("dotnet-t4", "2.0.5", "t4");

			base.Setup(context);
		}
	}
}
