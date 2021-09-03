using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

class EventCreator : EditorWindow
{
    private bool showEffects = false;

    // Event vars
    private string _eventName = "";
    private string _flavourText = "";
    private bool _interaction = false;
    private string _interactionText = "";
    private Effect[] _effects;

    [MenuItem("Tools/Event Creator")]
    public static void ShowWindow() {
        GetWindow(typeof(EventCreator));
    }

    public void Awake()
    {
        _effects = new Effect[] { };
    }

    public void OnGUI() {

        GUILayout.Label("Create New Event", EditorStyles.boldLabel);

        _eventName = EditorGUILayout.TextField("Event Name", _eventName);
        GUILayout.Label("Flavour Text");
        _flavourText = EditorGUILayout.TextArea(_flavourText, GUILayout.ExpandHeight(true), GUILayout.MaxHeight(100f));

        showEffects = EditorGUILayout.Foldout(showEffects, "Effects", true);
        if (showEffects)
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            for (int index = 0; index < _effects.Length; index++)
            {
                EditorGUILayout.BeginHorizontal();

                _effects[index].effect = (EventEffect)EditorGUILayout.EnumPopup(_effects[index].effect);
                _effects[index].stat = (Stats)EditorGUILayout.EnumPopup(_effects[index].stat);
                GUILayout.Label("by");
                _effects[index].amount = EditorGUILayout.IntField(_effects[index].amount);
                GUILayout.Label("points");

                GUI.backgroundColor = Color.red;
                if (GUILayout.Button("Remove"))
                {
                    List<Effect> remove = new List<Effect>(_effects);
                    remove.RemoveAt(index);
                    _effects = remove.ToArray();
                }
                GUI.backgroundColor = Color.white;

                EditorGUILayout.EndHorizontal();
                EditorGUILayout.Separator();
            }

            if (GUILayout.Button("Add Effect +", GUILayout.MaxWidth(150f)))
            {
                Effect[] localEffects = _effects;
                Array.Resize(ref localEffects, localEffects.Length + 1);
                localEffects[localEffects.Length - 1] = new Effect();
                _effects = localEffects;
            }

            EditorGUILayout.EndVertical();
        }

        _interaction = EditorGUILayout.Toggle("Requires interaction?", _interaction);

        if (_interaction)
        {
            GUILayout.Label("Interaction Text");
            _interactionText = EditorGUILayout.TextArea(_interactionText, GUILayout.ExpandHeight(true), GUILayout.MaxHeight(100f));
        }

        if (GUILayout.Button("Save Event", GUILayout.MaxWidth(150f))) {
            SaveEvent();
        }

    }

    void SaveEvent()
    {
        string path = Application.dataPath + "/Data/events.json";

        Event newEvent = new Event(
            _eventName,
            _flavourText,
            _interaction,
            _interactionText,
            _effects
        );
        
        if (File.Exists(path))
        {
            string fileData = File.ReadAllText(path);
            EventSerializationWrapper fileEvents = JsonUtility.FromJson<EventSerializationWrapper>(fileData);

            Event[] ioEvents = fileEvents.events;
            Array.Resize(ref ioEvents, ioEvents.Length + 1);
            ioEvents[ioEvents.Length - 1] = newEvent;
            fileEvents.events = ioEvents;

            string eventData = JsonUtility.ToJson(fileEvents, true);
            Debug.Log(eventData);

            File.WriteAllText(path, eventData);
        }
        else
        {
            Event[] events = new Event[2];
            events[0] = newEvent;
            events[1] = newEvent;

            EventSerializationWrapper eSW = new EventSerializationWrapper();
            eSW.events = events;

            string eventData = JsonUtility.ToJson(eSW, true);
            Debug.Log(eventData);

            File.WriteAllText(path, eventData);
        }
    }
}
