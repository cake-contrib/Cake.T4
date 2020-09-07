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
	using Cake.Core;
	using Cake.Core.Annotations;
	using Cake.Core.IO;

	/// <summary>
	/// Provides a wrapper around the dotnet-t4 tool to expose its
	/// functionality inside cake scripts.
	/// </summary>
	/// <revisionHistory>
	/// <revision version="0.1.0">Initial implementation of text template tranformation.</revision>
	/// </revisionHistory>
	[CakeAliasCategory("Text Templates")]
	public static class T4Aliases
	{
		/// <summary>
		/// This command calls the dotnet-t4 executable with the given
		/// <paramref name="inputPath" /> to transform a single text template file.
		/// The output path will be the same directory, with the extension configured
		/// inside the text template (defaults to g.cs).
		/// </summary>
		/// <param name="context">The current cake context to use.</param>
		/// <param name="inputPath">The path to the text template to transform.</param>
		/// <example>
		/// <code>
		/// <![CDATA[
		/// Task("Transform-Template")
		/// 	.Does(() =>
		/// {
		/// 	T4("path/to/text/template.tt");
		/// })
		/// ]]>
		/// </code>
		/// </example>
		[CakeMethodAlias]
		public static void T4(this ICakeContext context, FilePath inputPath)
		{
			var settings = new T4Settings
			{
				InputPath = inputPath ?? throw new ArgumentNullException(nameof(inputPath)),
			};
			T4(context, settings);
		}

		/// <summary>
		/// This command calls the dotnet-t4 executable with the given
		/// <paramref name="inputPath" /> to transform a single text template file,
		/// and outputs the file to the specified <paramref name="outputPath" />.
		/// </summary>
		/// <param name="context">The current cake context to use.</param>
		/// <param name="inputPath">The path to the text template to transform.</param>
		/// <param name="outputPath">The path where the output of the transformation will be outputted.</param>
		/// <example>
		/// <code>
		/// <![CDATA[
		/// Task("Transform-Template")
		/// 	.Does(() =>
		/// {
		/// 	Tp("path/to/text-template.tt", "path/to/output.g.cs");
		/// })
		/// ]]>
		/// </code>
		/// </example>
		[CakeMethodAlias]
		public static void T4(this ICakeContext context, FilePath inputPath, FilePath outputPath)
		{
			var settings = new T4Settings
			{
				InputPath = inputPath ?? throw new ArgumentNullException(nameof(inputPath)),
				OutputPath = outputPath ?? throw new ArgumentNullException(nameof(outputPath)),
			};
			T4(context, settings);
		}

		private static void T4(ICakeContext context, T4Settings settings)
		{
			var runner = new T4Runner(
				context.FileSystem,
				context.Environment,
				context.ProcessRunner,
				context.Tools);

			runner.Run(settings);
		}
	}
}
