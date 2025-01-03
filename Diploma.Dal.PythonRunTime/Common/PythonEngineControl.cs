using Python.Runtime;

namespace Diploma.Dal.PythonRunTime.Common
{
    public static class PythonEngineControl
    {
        public static void Initialize() 
        {
            if (PythonEngine.IsInitialized)
            {
                return;
            }

            Runtime.PythonDLL = @"C:\Users\User\AppData\Local\Programs\Python\Python312\python312.dll"; //TODO Replace
            PythonEngine.Initialize();
            PythonEngine.BeginAllowThreads();
        }

        public static void Execute(Action action)
        {
            Initialize();

            using (Py.GIL())
            {
                action();
            }
        }

        public static void Shutdown()
        {
            AppContext.SetSwitch("System.Runtime.Serialization.EnableUnsafeBinaryFormatterSerialization", true);
            PythonEngine.Shutdown();
            AppContext.SetSwitch("System.Runtime.Serialization.EnableUnsafeBinaryFormatterSerialization", false);
        }
    }
}
