using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MarimoDesktopMascot
{
    namespace Messenger
    {
        public class TcpSender : Base
        {
            public override byte[] ReadBytes()
            {
                Debug.Log("TcpSenderのReadBytesが呼ばれました");
                return Encoding.UTF8.GetBytes("Sender: This is a testだよ");
            }

            public override void WriteBytes(byte[] bytes)
            {
                Debug.Log("TcpSenderのWriteBytesが呼ばれました");
            }

            public override void Communicate()
            {
                Debug.Log("TcpSenderのCommunicateが呼ばれました");
                string responce = ReadStr();
                Debug.Log("ReasStrの結果: "+responce);
                WriteStr("OK!");
            }
        }
    }
}

