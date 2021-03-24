using System.Collections.Generic;
using UnityEngine;

namespace MarkyabaGames.Packages.EventSystem
{
    /// <summary>
    /// This scriptable object class creates a new asset file to manage custom events.
    /// </summary>
    [CreateAssetMenu(fileName = "NewGameEvent", menuName = "Game Event")]
    public class GameEvent : ScriptableObject
    {
	    private readonly List<GameEventListener> m_Listeners = new List<GameEventListener>();

        /// <summary>
        /// Raises all events listening to this game event.
        /// </summary>
        public void Raise()
        {
            for (int i = m_Listeners.Count - 1; i >= 0; i--)
            {
                m_Listeners[i].OnEventRaised();
            }
        }

        /// <summary>
        /// Register the listener to the game event.
        /// </summary>
        /// <param name="listener">The <see cref="GameEventListener"/> to register.</param>
        public void RegisterListener(GameEventListener listener)
        {
            if (!m_Listeners.Contains(listener))
            {
                m_Listeners.Add(listener);
                return;
            }

            Debug.LogWarning($"The game event listener {listener} is already registered to the game event." );
        }

        /// <summary>
        /// Unregister the listener out of the game event.
        /// </summary>
        /// <param name="listener">The <see cref="GameEventListener"/> to unregister.</param>
        public void UnregisterListener(GameEventListener listener)
        {
            if (m_Listeners.Contains(listener))
            {
                m_Listeners.Remove(listener);
                return;
            }

            Debug.LogWarning($"The game event listener {listener} is not registered to the game event.");
        }
    }
}