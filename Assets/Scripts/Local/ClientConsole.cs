using DeepSpace.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace DeepSpace.Local
{
    public delegate string ConsoleCallback<T>(T arg);

    public class ClientConsole : UnityEngine.MonoBehaviour
    {
        private void OnEnable()
        {
            Modules = new Dictionary<string, ConsoleCallback<object[]>>();
            OutputList = new Queue<string>();

            var modules = typeof(LocalModules)
            .GetMethods()
            .Where(m => m.GetCustomAttributes(typeof(LocalModuleAttribute), false).Length > 0)
            .ToArray() as MethodInfo[];

            foreach (MethodInfo m in modules)
            {
                var trigger = (m.GetCustomAttributes(false)[0] as LocalModuleAttribute).Trigger;
				var callback = Delegate.CreateDelegate(typeof(ConsoleCallback<object[]>), m);
				Modules.Add(trigger, callback as ConsoleCallback<object[]>);
            }
        }

        public static Dictionary<string, ConsoleCallback<object[]>> Modules;

        public static void ReadInput(string input)
        {
            if (input.StartsWith("!"))
            {
                var args = (input.TrimStart('!')).Split(' ');
                string module = args[0];

                if (Modules.ContainsKey(module))
                    PrintLine(Modules [module] (args));
            }
        }

        private static Queue<string> OutputList;

        public static void PrintLine(string message)
        {
            //TODO: Make this write to console.

            var text = AddLineToBuilder(message).ToString();
            Debug.Log(text);
        }

        private static StringBuilder AddLineToBuilder(string line)
        {
            //TODO: Add a scrollable window instead of removing outputs when they go out of range.

			if (OutputList.Count >= 25)
				OutputList.Dequeue();

			OutputList.Enqueue(line);

			StringBuilder sb = new StringBuilder();
			foreach (string s in OutputList)
			{
				sb.AppendLine(s);
			}

            return sb;
        }

        public static void PrintError(string error)
        {
            PrintLine("ERROR" + error);
        }
    }
}