using System.Collections;
using System.Collections.Generic;
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

        void Start()
        {
            _messenger.communicate();
        }
    }
}

