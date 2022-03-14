using System.Collections.Generic;

namespace WinNcCopy
{
    class Session
    {
        private static Session instance;
        private static readonly object threadlock = new object();

        private List<string> original = new List<string>();
        private List<string> modified = new List<string>();

        private Session() { }

        public static Session Instance
        {
            get {
                    lock (threadlock)
                    {
                    if (instance == null)
                        instance = new Session();
                    return instance;
                    }
                }
        }

        public void SetOriginal(List<string> originalProgram)
        {
            original.Clear();
            original.AddRange(originalProgram);
        }

        public List<string> GetOriginal()
        {
            return original;
        }

        public void SetModified(List<string> modifiedProgram)
        {
            modified.Clear();
            modified.AddRange(modifiedProgram);
        }

        public List<string> GetModified()
        {
            return modified;
        }

    }
}
