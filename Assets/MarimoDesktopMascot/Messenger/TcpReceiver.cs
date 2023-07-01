using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MarimoDesktopMascot
{
    namespace Messenger
    {

        public class TcpReceiver : Base
        {
            override public byte[] ReadBytes()
            {
                Debug.Log("TcpReceiverのReadBytesが呼ばれました");
                return Encoding.UTF8.GetBytes("Receiver: This is a testだよ");
            }
            override public void WriteBytes(byte[] bytes)
            {
                Debug.Log("TcpReceiverのWriteBytesが呼ばれました");
            }
            override public void Communicate()
            {
                Debug.Log("TcpReceiverのCommunicateが呼ばれました");
                string responce = ReadStr();
                Debug.Log("ReasStrの結果: "+responce);
                WriteStr("OK!");
            }
        }
    }
}
