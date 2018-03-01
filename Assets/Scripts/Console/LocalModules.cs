using DeepSpace.Local;
using System;

namespace DeepSpace.Console
{
	/// <summary>
	/// Defines a module execution method to be run locally. Return type must be string.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method)]
	public class LocalModuleAttribute : Attribute
	{
		public LocalModuleAttribute(string trigger) {Trigger = trigger;}
		public readonly string Trigger;
	}

	public static class LocalModules
	{
		//We can grab the Module data in this Class using a reflection process at runtime.
		//Only modules that will execute while not connected to a server should be defined here.
		//Local modules cannot be executed while connected and vice versa.

		[LocalModule("test")]
		public static string ModuleTest(object[] args)
		{
			//Arguments injected as method calling parameters.
			//Do whatever action(s) we need this module to do in here.

			//All modules should return a string to be printed in the Console.
			return "Test Successful";
		}
	}
}