using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class EventListing : EditorWindow
{
    private List<Event> _events;
    private List<bool> _foldout;
    private List<List<bool>> _effectFoldout;

    [MenuItem("Tools/Event Listing")]
    public static void ShowWindow()
    {
        GetWindow(typeof(EventListing));
    }

    public void Awake()
    {
        _foldout = new List<bool>();
        _effectFoldout = new List<List<bool>>();

        string path = Application.dataPath + "/Data/events.json";

        if (File.Exists(path))
        {
            string fileData = File.ReadAllText(path);
            EventSerializationWrapper fileEvents = JsonUtility.FromJson<EventSerializationWrapper>(fileData);

            _events = new List<Event>(fileEvents.events);
        }
        else
        {
            _events = new List<Event>();
        }
    }

    public void OnGUI()
    {
        GUILayout.Label("All Created Events", EditorStyles.boldLabel);

        int index = 0;
        foreach (Event currentEvent in _events)
        {
            _foldout.Add(false);
            _foldout[index] = EditorGUILayout.Foldout(_foldout[index], currentEvent._eventName, true);

            if (_foldout[index])
            {
                EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                GUILayout.Label(currentEvent._flavourText);

                //_effectFoldout.Add(new List<bool>());
                EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                for (int innerIndex = 0; innerIndex < currentEvent._effects.Length; innerIndex++)
                {
                    //_effectFoldout[index].Add(false);
                    //_effectFoldout[index][innerIndex] = EditorGUILayout.Foldout(_effectFoldout[index][innerIndex], currentEvent._eventName, true);

                    //if (_effectFoldout[index][innerIndex])
                    //{
                    string effect = currentEvent._effects[innerIndex].effect.ToString();
                    effect += " " + currentEvent._effects[innerIndex].stat.ToString();
                    effect += " by " + currentEvent._effects[innerIndex].amount;
                    GUILayout.Label(effect);
                    //}
                }
                EditorGUILayout.EndVertical();

                GUILayout.Label(currentEvent._interaction ? "Interaction required" : "No interaction required");
                if (currentEvent._interaction)
                {
                    GUILayout.Label(currentEvent._interactionText);
                }

                EditorGUILayout.EndVertical();
                EditorGUILayout.Separator();
            }

            index++;
        }
    }
}
