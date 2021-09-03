using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public enum EventEffect
{
    Increase,
    Decrease
};

public enum Stats
{
    Motivation,
    Tiredness,
    Happiness
}

[Serializable]
public struct Effect
{
    public EventEffect effect;
    public Stats stat;
    public int amount;
}

[Serializable]
public class Event
{
    public string _eventName = "";
    public string _flavourText = "";
    public bool _interaction = false;
    public string _interactionText = "";
    public Effect[] _effects;

    public Event(
        string eventName,
        string flavourText,
        bool interaction,
        string interactionText,
        Effect[] effects
    )
    {
        _eventName = eventName;
        _flavourText = flavourText;
        _interaction = interaction;
        _interactionText = interactionText;
        _effects = effects;
    }

    public override string ToString()
    {
        string ret = _eventName + ": " + _flavourText + "\n";
        ret += _interaction.ToString() + ": " + _interactionText;

        for (int index = 0; index < _effects.Length; index++)
        {
            ret += _effects[index].effect + "\n";
            ret += _effects[index].stat + "\n";
            ret += _effects[index].amount;
        }

        return ret;
    }
}

[Serializable]
public struct EventSerializationWrapper
{
    public Event[] events;
}
