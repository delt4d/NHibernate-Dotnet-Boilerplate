using System.Diagnostics;

namespace NDB.Infra
{
    public class UnitTestingDetector
    {
        private static readonly HashSet<string> UnitTestingAttributes;

        static UnitTestingDetector()
        {
            UnitTestingAttributes = [
                "Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute",
                "NUnit.Framework.TestFixtureAttribute"
            ];
        }

        public static bool IsRunningInUnitTest
        {
            get
            {
                foreach (var f in new StackTrace().GetFrames())
                {
                    var customAttributes = f.GetMethod()!.DeclaringType!.GetCustomAttributes(false);

                    if (customAttributes.Any(x => UnitTestingAttributes.Contains(x.GetType().FullName!)))
                        return true;
                }
                return false;
            }
        }
    }
}
