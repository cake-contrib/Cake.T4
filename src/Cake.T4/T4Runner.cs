/*
 * MIT License
 *
 * Copyright (c) 2020 Kim J. Nordmo
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

namespace Cake.T4
{
	using System;
	using System.Collections.Generic;
	using Cake.Core;
	using Cake.Core.IO;
	using Cake.Core.Tooling;

	/// <summary>
	/// The runner implementation responsible for
	/// passing the correct arguments to the T4 executable.
	/// </summary>
	/// <seealso cref="Tool{TSettings}" />
	public sealed class T4Runner : Tool<T4Settings>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T4Runner" /> class.
		/// </summary>
		/// <param name="fileSystem">The file system.</param>
		/// <param name="environment">The environment.</param>
		/// <param name="processRunner">The process runner.</param>
		/// <param name="tools">The tool locator.</param>
		/// <seealso cref="Tool{TSettings}" />
		public T4Runner(
			IFileSystem fileSystem,
			ICakeEnvironment environment,
			IProcessRunner processRunner,
			IToolLocator tools)
			: base(fileSystem, environment, processRunner, tools)
		{
		}

		/// <summary>
		/// Runs the tool using the specified <paramref name="settings" />.
		/// </summary>
		/// <param name="settings">The settings to use when running the tool.</param>
		public void Run(T4Settings settings)
		{
			if (settings == null)
			{
				throw new ArgumentNullException(nameof(settings));
			}

			if (settings.InputPath is null)
			{
				throw new ArgumentNullException(nameof(settings.InputPath), "T4: No input path have been specified!");
			}

			this.Run(settings, GetArguments(settings));
		}

		/// <inheritdoc/>
		protected override IEnumerable<string> GetToolExecutableNames()
			=> new[]
			{
				"t4.exe",
				"t4",
				"dotnet-t4.exe",
				"dotnet-t4",
			};

		/// <inheritdoc/>
		protected override string GetToolName()
		{
			return "T4";
		}

		private static ProcessArgumentBuilder GetArguments(T4Settings settings)
		{
			var builder = new ProcessArgumentBuilder();

			if (settings.OutputPath != null)
			{
				builder.AppendSwitchQuoted("--out", "=", settings.OutputPath.FullPath);
			}

			builder.AppendQuoted("{0}", settings.InputPath);

			return builder;
		}
	}
}
