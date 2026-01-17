using System;
using System.Collections.Generic;

namespace SimForge.Games.BubbleShooter.Blaze
{



    public static class EventManager
    {
        static readonly Dictionary<Type, List<IBaseEventListener>> RegisteredListeners =
            new Dictionary<Type, List<IBaseEventListener>>();

        public static void RegisterListener<T>(IEventListener<T> listener) where T : struct
        {
            var type = typeof(T);

            if (!RegisteredListeners.ContainsKey(type))
                RegisteredListeners.Add(type, new List<IBaseEventListener>());

            RegisteredListeners[type].Add(listener);
        }

        public static void UnregisterListener<T>(IEventListener<T> listener) where T : struct
        {
            var type = typeof(T);

            RegisteredListeners[type].Remove(listener);
        }

        public static void RaiseEvent<T>(T evt)
        {
            var type = typeof(T);

            foreach (var listener in RegisteredListeners[type])
                ((IEventListener<T>)listener).HandleEvent(evt);
        }
    }

    public interface IBaseEventListener
    {
    }

    public interface IEventListener<in T> : IBaseEventListener
    {
        void HandleEvent(T evt);
    }
}
