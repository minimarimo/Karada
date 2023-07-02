using MarimoDesktopMascot.Messenger;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


namespace MarimoDesktopMascot
{
    public class Command
    {
        public string Say(Protocol.Say command)
        {
            string ret = "OK";
            foreach (string message in command.args.message)
            {
                Debug.Log("Say: " + message);
            }
            return ret;
        }
        public string LoadCharacter(Protocol.LoadCharacter command)
        {
            string ret = "OK";
            Debug.Log("LoadCharacter: " + command.args.character);
            return ret;
        }
    }

    public class MarimoDesktopMascot : MonoBehaviour
    {
        Messenger.Messenger _messenger;
        Command _command;

        void Awake()
        {
            _messenger = new Messenger.Messenger();
            _command = new Command();
        }

        string ParseJsonAndExecuteCommand(string json)
        {
            string commandName;
            try
            {
                commandName = JsonUtility.FromJson<Protocol.Command>(json).command;
            }
            catch (Exception E)
            {
                Debug.LogException(E);
                Debug.Log("Json: " + json);
                return null;
            }
            switch (commandName)
            {
                case "LoadCharacter":
                    var loadCharacter = JsonUtility.FromJson<Protocol.LoadCharacter>(json);
                    Debug.Log("LoadCharacter: " + loadCharacter.args.character);
                    return null;
                case "Say":
                    var say = JsonUtility.FromJson<Protocol.Say>(json);
                    return _command.Say(say);
                default:
                    Debug.Log("Unknown command: " + commandName);
                    return null;
            }
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
                Debug.Log("raw: " + command);
                string result = ParseJsonAndExecuteCommand(command);
                // Project Settings -> Player -> Other Settings -> Configuration -> Api Compatibility Level -> .NET Framework
                // にすると、dynamic が使えるようになる
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

