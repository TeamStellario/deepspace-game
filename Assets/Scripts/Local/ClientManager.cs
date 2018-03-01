using System;
using UnityEngine;

namespace DeepSpace.Local
{
    public enum ClientState
    {
        Null, NotConnected, Connected, Offline
    }

    public class ClientManager : MonoBehaviour
    {
        private void OnEnable()
        {
            //Called at runtime by System.Reflection. Put all synchronous
            //tasks that need to be executed at startup in here. When we
            //load up our game, create a new Client class from encoded XML
            //data stored in the Player's key, however for now we can just
            //hardcode the values for this.

            //TODO: Implement an object serialisation process for saving and loading encrypted Client data.

            m_client = new Client("Sam", 716838382799);
            
            m_reader = transform.GetComponent<ClientInputReader>();
            m_reader.Inputs = new ClientSettingsInput();

            State = ClientState.NotConnected;
        }

        private Client m_client;
        private ClientInputReader m_reader;

        public event Action<ClientState> OnClientStateChanged;

        private ClientState m_state;
        public ClientState State
        {
            get {return m_state;}
            set {m_state = value; OnClientStateChanged(m_state);}
        }

        public static bool OnClientConnectionAttempt(Client client)
        {
            return false;
        }

        public static bool OnClientDisconnectAttempt(Client client)
        {
            return false;
        }

        public void OnClientExit()
        {
        }
    }
}