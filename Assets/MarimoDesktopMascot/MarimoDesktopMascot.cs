using MarimoDesktopMascot.Messenger;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniGLTF;
using UnityEngine;
using VRM;

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
            Debug.Log(command.args.name + "さんを" + command.args.path + "から呼んでいます...");
            RuntimeGltfInstance instance = null;
            async void LoadCharacter(string path)
            {
                try
                {
                    instance = await VrmUtility.LoadAsync(path);
                    instance.ShowMeshes();
                }
                catch (Exception E)
                {
                    Debug.LogException(E);
                }
            }
            LoadCharacter(command.args.path);
            Debug.Log("OK!");
            return ret;
        }
    }

    public class MarimoDesktopMascot : MonoBehaviour
    {
        Messenger.Messenger _messenger;
        Command _command;

        // FIXME: 仮実装
        Protocol.LoadCharacter _character;

        void Awake()
        {
            _messenger = new Messenger.Messenger();
            _command = new Command();
            UI.Window.TransparentWindow.DoTransparentWindow();
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
                    // キャラを実装するためにはメインスレッドから呼び出し処理を呼ぶ必要がある
                    // そのため、リファクタリングをする必要が生じたが、今はとりあえず動くようにする
                    // 具体的には、適当なメンバ変数にぶち込んで、Update でそれを実行するようにする
                    _character = JsonUtility.FromJson<Protocol.LoadCharacter>(json);
                    /*
                    return _command.LoadCharacter(character);
                    */
                    return "OK";
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

        private void Update()
        {
            if (_character ==null) { return; }
            _command.LoadCharacter(_character);
            _character = null;
        }
    }
}

