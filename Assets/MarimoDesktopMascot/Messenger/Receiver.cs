using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MarimoDesktopMascot
{
    namespace Messenger
    {
        public class Receiver : Base
        {
            // TODO: こいつは本来動的に読み込むものなので後で修正
            TcpReceiver _receiver;
            public Receiver()
            {
                _receiver = new TcpReceiver("127.0.0.1", 8001);
            }

            public void Start()
            {
                _receiver.Start();
            }

            override public byte[] ReadBytes()
            {
                return _receiver.ReadBytes();
            }
            override public void WriteBytes(byte[] bytes)
            {
                _receiver.WriteBytes(bytes);
            }
        }
    }
}
