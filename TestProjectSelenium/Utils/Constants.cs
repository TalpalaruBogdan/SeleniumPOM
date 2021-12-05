using System.IO;

namespace TestProjectSelenium.Utils
{
    internal class Constants
    {
        public static string FormPageUrl { get; } = "https://localhost:7083/form";
        public static int DefaultWait { get; } = 30;
        public static string ChromeDriverPath { get; } =  Path.Combine(Directory.GetCurrentDirectory(), @"../../../Resources");
    }
}
