using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


namespace MarimoDesktopMascot
{
    namespace Messenger
    {
        public class Messenger
        {
            public Sender Sender;
            public Receiver Receiver;
            public Messenger()
            {
                Sender = new Sender();
                Receiver = new Receiver();
            }
        }
    }
}

