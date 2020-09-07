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
	using Cake.Core.IO;
	using Cake.Core.Tooling;

	/// <summary>
	/// Defines the supported properties that can be passed to the dotnet-t4 utility.
	/// </summary>
	/// <seealso cref="ToolSettings" />
	public sealed class T4Settings : ToolSettings
	{
		/// <summary>
		/// Gets or sets the path to the template file to transform.
		/// </summary>
		/// <remarks>
		/// This property should not be set on the settings class directly.
		/// Instead the appropriate Cake Alias method should be used instead.
		/// </remarks>
		public FilePath? InputPath { get; set; }

		/// <summary>
		/// Gets or sets the name or path of the output &lt;file&gt;.
		/// </summary>
		/// <remarks>
		/// Defaults to the input filename with its extension changed to
		/// `.txt`.
		/// </remarks>
		public FilePath? OutputPath { get; set; }
	}
}
