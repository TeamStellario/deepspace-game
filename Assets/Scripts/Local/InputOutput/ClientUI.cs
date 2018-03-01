using System;
using System.Collections.Generic;
using UnityEngine;

namespace DeepSpace.Local
{
    public class ClientUI : MonoBehaviour
    {
        public GameObject Console;

        private void OnEnable() { m_objects = new Dictionary<long, GameObject>(); }

        //Assign callbacks here if necessary.
        //public event Action OnUIObjectDrawn;
        //public event Action OnUIObjectHidden;

        private Dictionary<long, GameObject> m_objects;
        private GameObject m_focused;
        private GameObject m_pointer;
        
        private long m_objCounter;
        public long DrawUIObject()
        {
            //For now, just draw Console GameObjects. We can implement
            //a centralised definitions system later down the line.

            m_objCounter++;

            var obj = Instantiate(Console, this.transform);
            m_objects.Add (m_objCounter, obj);

            return m_objCounter;
        }

        public long DrawUIObject(Action<ClientInterface>[] callbacks)
        {
            var clientInterface = m_objects [DrawUIObject()].GetComponent<ClientInterface>();

            clientInterface.OnMousePointerDownInterface += callbacks[0];
            clientInterface.OnMousePointerEnterInterface += callbacks[1];
            clientInterface.OnMousePointerExitInterface += callbacks[2];

            return m_objCounter;
        }

        public long? HideUIObject(long id)
        {
            if (m_objects.ContainsKey(id))
            {
                Destroy(m_objects[id]);
                m_objects.Remove(id);

                return null;
            }

            ClientConsole.PrintError("No UI object with given ID!");
            return id;
        }

        private void OnInterfaceFocus(ClientInterface clientInterface)
        {
            m_focused = clientInterface.gameObject;
        }

        private void OnInterfaceDefocus()
        {
            m_focused = null;
        }

        private void OnPointerEnter(ClientInterface clientInterface)
        {
            m_pointer = clientInterface.gameObject;
        }

        private void OnPointerExit(ClientInterface clientInterface)
        {
            m_pointer = null;
        }
    }
}