using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Class <c>EventHandler</c> статичный класс для регистрации и публикации эвентов издателей, а так же для подписки/отписки наблюдателей.
/// </summary>
public static class EventHandler
{
    private static readonly Dictionary<Type, List<Delegate>> eventHandlers = new Dictionary<Type, List<Delegate>>();

    public static void Subscribe<T>(Action<T> handler) where T : class
    {
        Type eventType = typeof(T);
        if (!eventHandlers.ContainsKey(eventType))
        {
            eventHandlers[eventType] = new List<Delegate>();
        }

        eventHandlers[eventType].Add(handler);
    }

    public static void Unsubscribe<T>(Action<T> handler) where T : class
    {
        Type eventType = typeof(T);
        if (eventHandlers.ContainsKey(eventType))
        {
            eventHandlers[eventType].Remove(handler);
        }
    }

    public static void Publish<T>(T eventData) where T : class
    {
        Type eventType = typeof(T);
        if (eventHandlers.ContainsKey(eventType))
        {
            foreach (Delegate handler in eventHandlers[eventType])
            {
                (handler as Action<T>)?.Invoke(eventData);
            }
        }
    }

    public static void ClearAllSubscriptions()
    {
        eventHandlers.Clear();
    }

}
