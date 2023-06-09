﻿using System.IO;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using UnityEngine.Assertions.Must;

namespace MarimoDesktopMascot
{
    namespace Messenger
    {

        public class TcpBase : Base
        {
            protected NetworkStream _stream;
            protected TcpListener _client;

            // TODO: 引数はデータをあらわすクラスで渡すようにする
            protected TcpBase(string host, int port)
            {
                Debug.Log("TcpBaseのコンストラクタが呼ばれました");
                var ipAddr  = System.Net.IPAddress.Parse(host);
                _client = new TcpListener(ipAddr, port);
            }

            public void Start()
            {
                Debug.Log("Listenが呼ばれました");
                _client.Start();
                var client = _client.AcceptTcpClient();
                _stream = client.GetStream();
            }

            override public byte[] ReadBytes()
            {
                Debug.Log("TcpBaseのReadBytesが呼ばれました");
                // TODO: バイトで読め
                string responce = new StreamReader(_stream, Encoding.UTF8).ReadLine();
                return Encoding.UTF8.GetBytes(responce);
            }
            override public void WriteBytes(byte[] bytes)
            {
                Debug.Log("TcpBaseのWriteBytesが呼ばれました");
                byte[] clientDataBytes = Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(bytes) + "\n");
                _stream.Write(clientDataBytes, 0, clientDataBytes.Length);
                _stream.Flush();
            }
        }
    }
}

