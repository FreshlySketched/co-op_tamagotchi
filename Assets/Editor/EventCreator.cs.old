using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

// Window for event creation
class EventCreator : EditorWindow
{
    private bool _showEffects = false; //Shows or hides the effect section
    private bool _unsaved = true; // Shows or hides the "has been saved" screen

    // Event variables
    private string _eventName = ""; // Event name
    private string _flavourText = ""; // Description of the event shown to the player
    private bool _interaction = false; // Determines whether the event requires interaction (Yes/No)
    private string _interactionText = ""; // Description of interaction effects for player
    private List<Effect> _effects; // List of all stat effects

    // Specify location in toolbar
    [MenuItem("Tools/Event Creator")]
    public static void ShowWindow() {
        GetWindow(typeof(EventCreator));
    }

    public void Awake()
    {
        _effects = new List<Effect> ();
    }

    public void OnGUI() {

        // If event hasn't been saved, display event creation
        if (_unsaved) {
            GUILayout.Label("Create New Event", EditorStyles.boldLabel);

            // Show event name field
            _eventName = EditorGUILayout.TextField("Event Name", _eventName);

            // Show event description field
            GUILayout.Label("Flavour Text");
            _flavourText = EditorGUILayout.TextArea(_flavourText, GUILayout.ExpandHeight(true), GUILayout.MaxHeight(100f));

            // Show list of event effects (accordion menu)
            _showEffects = EditorGUILayout.Foldout(_showEffects, "Effects", true);
            if (_showEffects)
            {
                // Enclose effect accordion in border
                EditorGUILayout.BeginVertical(EditorStyles.helpBox);

                // List all current event effects
                for (int index = 0; index < _effects.Count; index++)
                {
                    // Start row of controls
                    EditorGUILayout.BeginHorizontal();

                    // Show dropdown with stat effects listed
                    _effects[index].effect = (StatEffect)EditorGUILayout.EnumPopup(_effects[index].effect);
                    // Show dropdown with stats listed
                    _effects[index].stat = (Stats)EditorGUILayout.EnumPopup(_effects[index].stat);

                    // Show amount to affect stat by
                    GUILayout.Label("by");
                    _effects[index].amount = EditorGUILayout.IntField(_effects[index].amount);
                    GUILayout.Label("points");

                    // Show red button to delete effect from list
                    GUI.backgroundColor = Color.red;
                    if (GUILayout.Button("Remove"))
                    {
                        _effects.RemoveAt(index);
                    }
                    
                    // Reset colour so it doesn't affect other elements
                    GUI.backgroundColor = Color.white;

                    // End row of controls and add a space
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.Separator();
                }

                // Show button at end of effect accordion to add new effects
                if (GUILayout.Button("Add Effect +", GUILayout.MaxWidth(150f)))
                {
                    _effects.Add(new Effect());
                }

                // End border
                EditorGUILayout.EndVertical();
            }

            // Show interaction checkbox
            _interaction = EditorGUILayout.Toggle("Requires interaction?", _interaction);

            // Show interaction description if interaction is required
            if (_interaction)
            {
                GUILayout.Label("Interaction Text");
                _interactionText = EditorGUILayout.TextArea(_interactionText, GUILayout.ExpandHeight(true), GUILayout.MaxHeight(100f));
            }

            // Show save button
            if (GUILayout.Button("Save Event", GUILayout.MaxWidth(150f))) {

                // Create new Event from values provided
                Event newEvent = new Event(
                    _eventName,
                    _flavourText,
                    _interaction,
                    _interactionText,
                    _effects
                );

                // Save event
                EventLoader.SaveEvent(newEvent);

                // Hide event creation screen
                _unsaved = false;
            }
        }
        // If an event has been saved, show saved screen
        else {
            GUILayout.Label("Event saved", EditorStyles.boldLabel);

            // Show button for creating another event
            if (GUILayout.Button("Create new event +", GUILayout.MaxWidth(150f))) {
                // Reset event values
                _eventName = "";
                _flavourText = "";
                _interaction = false;
                _interactionText = "";
                _effects.Clear();
                
                // Show event page
                _unsaved = true;
            }
        }
    }
}
