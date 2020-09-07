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

namespace Cake.T4.Tests
{
	using System;
	using Cake.Core;
	using Cake.Testing;
	using NUnit.Framework;

	[TestFixture]
	[TestOf(typeof(T4Runner))]
	public class T4RunnerTests
	{
		[Test]
		public void Should_Throw_If_Settings_Are_Null()
		{
			void runFixture()
			{
				var fixture = new T4RunnerFixture { Settings = null };
				fixture.Run();
			}

			Assert.That((Action)runFixture, Throws.ArgumentNullException.With.Message.Contains("settings"));
		}

		[Test]
		public void Should_Throw_If_T4_Executable_Was_Not_Found()
		{
			void result()
			{
				var fixture = new T4RunnerFixture();
				fixture.GivenDefaultToolDoNotExist();
				fixture.Settings = new T4Settings { InputPath = "some-path" };
				fixture.Run();
			}

			const string expectedMessage = "T4: Could not locate executable.";
			Assert.That((Action)result, Throws.TypeOf<CakeException>().With.Message.EqualTo(expectedMessage));
		}

		[Test]
		public void Should_Set_Input_Path_When_Supplied()
		{
			var settings = new T4Settings
			{
				InputPath = "some-kind/of/file.tt"
			};
			var fixture = new T4RunnerFixture();
			fixture.GivenSettingsToolPathExist();
			fixture.Settings = settings;

			var result = fixture.Run();

			Assert.That(result.Args, Is.EqualTo("\"some-kind/of/file.tt\""));
		}

		[Test]
		public void Should_Throw_Exception_When_TemplatePath_IsEmpty()
		{
			void result()
			{
				var settings = new T4Settings
				{
					InputPath = null,
				};
				var fixture = new T4RunnerFixture();
				fixture.GivenSettingsToolPathExist();
				fixture.Settings = settings;

				fixture.Run();
			}

			const string expectedMessage = "T4: No input path have been specified!";
			Assert.That((Action)result, Throws.TypeOf<ArgumentNullException>().With.Message.StartsWith(expectedMessage));
		}
	}
}
