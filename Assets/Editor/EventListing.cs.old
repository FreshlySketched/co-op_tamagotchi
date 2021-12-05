using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class EventListing : EditorWindow
{
    private List<Event> _events; // List of all current events
    private List<bool> _foldout; // List of booleans that track collapsed events

    // Specify location in toolbar
    [MenuItem("Tools/Event Listing")]
    public static void ShowWindow()
    {
        GetWindow(typeof(EventListing));
    }

    public void Awake()
    {
        _foldout = new List<bool>();

        // Load in current effects when window opens
        _events = EventLoader.LoadEvents();
    }

    public void OnGUI()
    {
        // Start horizontal control section with main header
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("All Created Events", EditorStyles.boldLabel);

        // Show refresh button
        if (GUILayout.Button("Refresh list", GUILayout.MaxWidth(150f)))
        {
            // Refresh events in list
            _events = EventLoader.LoadEvents();
        }

        // End horizontal control section
        EditorGUILayout.EndHorizontal();

        // Loop through all events and display
        int index = 0;
        foreach (Event currentEvent in _events)
        {
            // Add a false to the list. This will cause events to start collapsed
            _foldout.Add(false);

            // Start accordion section, and start it collapsed
            _foldout[index] = EditorGUILayout.Foldout(_foldout[index], currentEvent._eventName, true);
            if (_foldout[index])
            {
                // Start bordered section with provided description
                EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                GUILayout.Label(currentEvent._flavourText);

                // Start a second bordered section and list all event effects
                EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                for (int innerIndex = 0; innerIndex < currentEvent._effects.Count; innerIndex++)
                {
                    // Create string with all effect details for each effect
                    string effect = currentEvent._effects[innerIndex].effect.ToString();
                    effect += " " + currentEvent._effects[innerIndex].stat.ToString();
                    effect += " by " + currentEvent._effects[innerIndex].amount;

                    // Show label with effect string
                    GUILayout.Label(effect);
                }

                // End effect list border
                EditorGUILayout.EndVertical();

                // Show label specifying if interaction is required
                GUILayout.Label(currentEvent._interaction ? "Interaction required" : "No interaction required");

                // If interaction is required, show the interaction description text
                if (currentEvent._interaction)
                {
                    GUILayout.Label(currentEvent._interactionText);
                }

                // End event border and add space between events
                EditorGUILayout.EndVertical();
                EditorGUILayout.Separator();
            }

            // Increment the index
            index++;
        }
    }
}
