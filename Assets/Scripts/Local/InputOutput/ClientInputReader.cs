using System;
using UnityEngine;
using UnityEngine.UI;

namespace DeepSpace.Local
{
	public class ClientInputReader : MonoBehaviour
	{
		private void OnEnable()
		{
			m_manager = transform.GetComponent<ClientManager>();
			m_manager.OnClientStateChanged += UpdateState;

			m_ui = transform.GetComponentInChildren<ClientUI>();
		}

		public ClientSettingsInput Inputs;

		private ClientManager m_manager;
		private ClientUI m_ui;

		private ClientState m_state;
		private void UpdateState(ClientState state) { m_state = state; }

		//UI elements IDs.
		private long? m_consoleObjId;

		//Called every frame by Unity.
		private void Update()
		{
			if (Input.GetKeyDown(Inputs.Submit))
			{
				ClientConsole.ReadInput(m_ui.GetComponentInChildren<InputField>().text);
			}

			if (Input.GetKeyDown(Inputs.Console))
			{
				if (m_consoleObjId == null)
					m_consoleObjId = m_ui.DrawUIObject();
				else
					m_consoleObjId = m_ui.HideUIObject((long)m_consoleObjId);
			}
		}
	}
}