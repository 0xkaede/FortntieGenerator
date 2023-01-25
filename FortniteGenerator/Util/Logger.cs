using K4os.Compression.LZ4;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortniteGenerator.Util
{
    public static class Logger
    {
        public static void Log(string message, LogLevel level = LogLevel.Info)
        {
            var method = new StackTrace().GetFrame(1).GetMethod();
            var typeName = method.ReflectedType.Name;
            var methodName = method.Name;

            if (methodName == ".ctor")
                methodName = "Constructor";

            if (typeName.Contains("Service"))
                typeName = typeName.Replace("Service", "");

            if (typeName.Contains('<'))
                typeName = typeName.Split("<")[1].Split(">")[0];

            if (level == LogLevel.Info)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[{DateTime.Now}] [Log{typeName}::{methodName} {level.GetDescription()}] {message}");
            }
            
            if (level == LogLevel.Error)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[{DateTime.Now}] [Log{typeName}::{methodName} {level.GetDescription()}] {message}");
            }
        }

        public static string GetDescription(this Enum value)
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            if (name == null)
                return null;

            var field = type.GetField(name);
            if (field == null)
                return null;

            if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attr)
                return attr.Description;

            return null;
        }

    }

    public enum LogLevel
    {
        [Description("DBG")]
        Debug,

        [Description("INF")]
        Info,

        [Description("WRN")]
        Warning,

        [Description("ERR")]
        Error,

        [Description("FTL")]
        Fatal
    }

}
