using System;

namespace Common
{
    public class CtorAndMethodComponent : IDomComponent
    {
        public CtorAndMethodComponent(string message)
        {
            Console.WriteLine("I was build with message: " + message);
        }

        public string Execute()
        {
            return "blah";
        }
    }
}