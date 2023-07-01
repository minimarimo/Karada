using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MarimoDesktopMascot
{
    namespace Messenger
    {
        public class TcpSender : TcpBase
        {
            public TcpSender(string host, int port) : base(host, port)
            {
                Debug.Log("TcpSenderのコンストラクタが呼ばれました");
            }
        }
    }
}
