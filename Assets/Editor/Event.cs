using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

// Determines the effect applied to the related stat. Do not change the associated number
// when adding, updating, or removing these effects
public enum StatEffect
{
    Increase = 0,
    Decrease = 1
};

// Character stats. Do not change the associated number
// when adding, updating, or removing these stats
public enum Stats
{
    Motivation = 0,
    Tiredness = 1,
    Happiness = 2
}

// Defines a given effect by relating a change (increase/decrease) to a stat, and supplying an amount to change by
[Serializable]
public class Effect
{
    public StatEffect effect;
    public Stats stat;
    public int amount;
}

// Defines the structure of an event
[Serializable]
public class Event
{
    public string _eventName = ""; // Name of the event
    public string _flavourText = ""; // Description of the event displayed to the player
    public bool _interaction = false; // Determines whether interaction is required (Yes/No)
    public string _interactionText = ""; // Description of interaction effects if interaction is required
    public List<Effect> _effects; // List of all stat effects provided by this event

    // Constructor
    public Event(
        string eventName,
        string flavourText,
        bool interaction,
        string interactionText,
        List<Effect> effects
    )
    {
        _eventName = eventName;
        _flavourText = flavourText;
        _interaction = interaction;
        _interactionText = interactionText;
        _effects = effects;
    }

    // Used for debug - outputs variable values.
    public override string ToString()
    {
        string ret = _eventName + ": " + _flavourText + "\n";
        ret += _interaction.ToString() + ": " + _interactionText;

        for (int index = 0; index < _effects.Count; index++)
        {
            ret += _effects[index].effect + "\n";
            ret += _effects[index].stat + "\n";
            ret += _effects[index].amount;
        }

        return ret;
    }
}

// Wrapper used to serailise the list of ALL events. Wrapper only required for saving/loading
[Serializable]
public struct EventSerializationWrapper
{
    public Event[] events;
}

// Provides save and load functions for events
public static class EventLoader {

    // Save a new event to the JSON file
    public static void SaveEvent(Event newEvent)
    {
        // Location of event file
        string path = Application.dataPath + "/Data/events.json";
        
        if (File.Exists(path))
        {
            // Load all current events from the file
            string fileData = File.ReadAllText(path);
            EventSerializationWrapper fileEvents = JsonUtility.FromJson<EventSerializationWrapper>(fileData);

            // Get list of events, resize it, and add new event
            Event[] ioEvents = fileEvents.events;
            Array.Resize(ref ioEvents, ioEvents.Length + 1);
            ioEvents[ioEvents.Length - 1] = newEvent;
            fileEvents.events = ioEvents;

            // Convert event to JSON and save to file
            string eventData = JsonUtility.ToJson(fileEvents, true);
            File.WriteAllText(path, eventData);
        }
        else
        {
            // Add new event into a new wrapper
            Event[] events = new Event[1];
            events[0] = newEvent;
            EventSerializationWrapper eSW = new EventSerializationWrapper();
            eSW.events = events;

            // Convert event wrapper to JSON and save to file
            string eventData = JsonUtility.ToJson(eSW, true);
            File.WriteAllText(path, eventData);
        }
    }

    // Load all events from JSON file
    public static List<Event> LoadEvents() {
        //Location of save file
        string path = Application.dataPath + "/Data/events.json";

        if (File.Exists(path))
        {
            // Load all text from file, cast to List<Event>, and return
            string fileData = File.ReadAllText(path);
            EventSerializationWrapper fileEvents = JsonUtility.FromJson<EventSerializationWrapper>(fileData);

            return new List<Event>(fileEvents.events);
        }
        else
        {
            // Return empty list if file not present
            return new List<Event>();
        }
    }

}