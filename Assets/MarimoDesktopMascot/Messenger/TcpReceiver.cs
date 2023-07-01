using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MarimoDesktopMascot
{
    namespace Messenger
    {

        public class TcpReceiver : TcpBase
        {
            public TcpReceiver(string host, int port) : base(host, port)
            {
                Debug.Log("TcpReceiverのコンストラクタが呼ばれました");
            }
        }
    }
}
