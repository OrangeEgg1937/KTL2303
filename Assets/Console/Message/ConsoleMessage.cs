using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InGameCustomConsole
{
    namespace Message
    {
        [Serializable]
        [CreateAssetMenu(fileName = "MessageHandler", menuName = "InGameCustomConsole/MessageHandler")]
        public class MessageHandler : ScriptableObject
        {
            public List<MessageType> types = new List<MessageType>();

            // Finding the message type
            public GameObject getMessageTypeByName(String name)
            {
                foreach (MessageType type in types)
                {
                    if (type.Name.Equals(name))
                    {
                        return type.StylePrefab;
                    }
                }

                return null;
            }
        }

        [Serializable]
        public class MessageType
        {
            public String Name;
            public GameObject StylePrefab; 
        }
    }
}
