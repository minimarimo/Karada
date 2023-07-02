using MarimoDesktopMascot.Messenger;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


namespace MarimoDesktopMascot
{
    public class MarimoDesktopMascot : MonoBehaviour
    {
        Messenger.Messenger _messenger;

        void Awake()
        {
            _messenger = new Messenger.Messenger();
        }

        private void RunSender()
        {
            // TODO: 未実装
            // var sender = _messenger.Sender;
        }

        private void RunReceiver()
        {
            Receiver receiver = _messenger.Receiver;
            receiver.Start();
            while (true)
            {
                string command = receiver.ReadStr();
                Protocol.Say say = JsonUtility.FromJson<Protocol.Say>(command);
                Debug.Log("Received: " + say.args.message[0]);
                receiver.WriteStr("{\"text\": [\"Hello, World!\"]}");
                Debug.Log("sended");
            }
        }

        void Start()
        {
            // Task.Run(() => RunSender());
            Task.Run(() => RunReceiver());
        }
    }
}

