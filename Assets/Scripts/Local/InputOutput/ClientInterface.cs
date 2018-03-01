using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DeepSpace.Local
{
    public class ClientInterface : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
    {
        //The events we call when "things" happen.
        public event Action<ClientInterface> OnMousePointerDownInterface;
        public event Action<ClientInterface> OnMousePointerEnterInterface;
        public event Action<ClientInterface> OnMousePointerExitInterface;

        public void OnPointerDown(PointerEventData eventData)
        {
            if (OnMousePointerDownInterface != null)
                OnMousePointerDownInterface(this);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (OnMousePointerEnterInterface != null)
                OnMousePointerEnterInterface(this);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (OnMousePointerExitInterface != null)
                OnMousePointerExitInterface(this);
        }
    }
}