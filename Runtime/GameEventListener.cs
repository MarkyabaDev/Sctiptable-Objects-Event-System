using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

namespace MarkyabaGames.Packages.EventSystem
{
    /// <summary>
    /// The listener class that listens to an event raised by <see cref="GameEvent"/> object.
    /// </summary>
    public class GameEventListener : MonoBehaviour
    {
        [SerializeField] [UsedImplicitly] private GameEvent m_Event = null;
        [SerializeField] [UsedImplicitly] private UnityEvent m_Response = null;

        private void OnEnable()
        {
            m_Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            m_Event.UnregisterListener(this);
        }

        /// <summary>
        /// Invokes all events added to the unity response event.
        /// </summary>
        public void OnEventRaised()
        {
            m_Response?.Invoke();
        }
    }
}
