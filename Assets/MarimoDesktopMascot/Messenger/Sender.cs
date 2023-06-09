﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarimoDesktopMascot
{
    namespace Messenger
    {
        public class Sender : Base
        {
            // TODO: こいつは本来動的に読み込むものなので後で修正
            TcpSender _sender;

            public Sender()
            {
                // TODO: こいつは本来動的に読み込むものなので後で修正
                _sender = new TcpSender("127.0.0.1", 8000);
            }


            override public byte[] ReadBytes()
            {
                return _sender.ReadBytes();
            }
            override public void WriteBytes(byte[] bytes)
            {
                _sender.WriteBytes(bytes);
            }
        }
    }
}
