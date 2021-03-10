using System;

namespace Attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            Type widgetType = typeof(Widget);

            object[] widgetClassAttributes = widgetType.GetCustomAttributes(typeof(HelpAttribute), false);

            if (widgetClassAttributes.Length > 0)
            {
                HelpAttribute attr = (HelpAttribute)widgetClassAttributes[0];
                Console.WriteLine($"Widget class help URL : {attr.Url} = Related topic : {attr.Topic}");
            }

            System.Reflection.MethodInfo displayMethod = widgetType.GetMethod(nameof(Widget.Display)); 
            object[] displayMethodAttributes = displayMethod.GetCustomAttributes(typeof(HelpAttribute), false);

            if(displayMethodAttributes.Length > 0)
            {
                HelpAttribute attr = (HelpAttribute)displayMethodAttributes[0];
                Console.WriteLine($"Display method help URL : {attr.Url} = Related topic . {attr.Topic}");
            }
        }
    }
}
