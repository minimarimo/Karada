using System.Collections.Generic;

namespace MarimoDesktopMascot
{
    namespace Messenger
    {
        public class Protocol
        {

            [System.Serializable]
            public class Nest
            {
                public string key;
                public string message;
                public float time;
                public int number;
                public bool boolean;
                public List<string> hogeofoajweiojfoiaewiofeioawfoaw;
            }

            [System.Serializable]
            public class SayArgs
            {
                public List<string> message;
            }

            [System.Serializable]
            public class Say
            {
                public string command;
                public SayArgs args;
            }

            [System.Serializable]
            public class SleepArgs
            {
                public float time;
            }

            [System.Serializable]
            public class Sleep
            {
                public string command;
                public SleepArgs args;
            }

            [System.Serializable]
            public class TestArgs
            {
                public string message;
                public float time;
                public int number;
                public bool boolean;
                public List<string> list;
                public Nest nest;
            }

            [System.Serializable]
            public class Test
            {
                public string command;
                public TestArgs args;
            }
        }
    }
}