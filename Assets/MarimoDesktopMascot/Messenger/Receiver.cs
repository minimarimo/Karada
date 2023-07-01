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
                _receiver = new TcpReceiver();
            }

            override public byte[] ReadBytes()
            {
                return _receiver.ReadBytes();
            }
            override public void WriteBytes(byte[] bytes)
            {
                _receiver.WriteBytes(bytes);
            }
            override public void Communicate()
            {
                _receiver.Communicate();
            }
        }
    }
}
