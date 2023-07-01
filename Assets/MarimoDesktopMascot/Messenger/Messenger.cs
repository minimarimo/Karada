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
            Sender _sender;
            Receiver _receiver;
            public Messenger()
            {
                _sender = new Sender();
                _receiver = new Receiver();
            }

            public void communicate()
            {
                Task.Run(() => _sender.Communicate());
                Task.Run(() => _receiver.Communicate());
            }
        }
    }
}

