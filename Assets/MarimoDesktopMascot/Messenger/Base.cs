using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MarimoDesktopMascot
{
    namespace Messenger
    {
        public abstract class Base
        {
            public abstract byte[] ReadBytes();
            public string ReadStr()
            {
                return Encoding.UTF8.GetString(ReadBytes());
            }

            public abstract void WriteBytes(byte[] bytes);

            public void WriteStr(string str)
            {
                WriteBytes(Encoding.UTF8.GetBytes(str));
            }

            public abstract void Communicate();
        }
    }
}
