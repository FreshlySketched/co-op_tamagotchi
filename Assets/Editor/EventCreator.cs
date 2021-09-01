using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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

public struct Effect
{
    public EventEffect effect;
    public Stats stat;
    public int amount;
}

class EventCreator : EditorWindow
{
    private string eventName = "";
    private string flavourText = "";
    private string effect = "";
    private bool interaction = false;
    private string interactionText = "";

    private Effect[] effects = new Effect[] { };
    private bool showEffects = false;
    

    [MenuItem("Tools/Event Creator")]
    public static void ShowWindow() {
        GetWindow(typeof(EventCreator));
    }

    private void OnGUI() {
        GUILayout.Label("Create New Event", EditorStyles.boldLabel);

        eventName = EditorGUILayout.TextField("Event Name", eventName);
        GUILayout.Label("Flavour Text");
        flavourText = EditorGUILayout.TextArea(flavourText, GUILayout.ExpandHeight(true), GUILayout.MaxHeight(100f));

        showEffects = EditorGUILayout.Foldout(showEffects, "Effects", true);
        if (showEffects)
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            for (int index = 0; index < effects.Length; index++)
            {
                EditorGUILayout.BeginHorizontal();

                effects[index].effect = (EventEffect)EditorGUILayout.EnumPopup(effects[index].effect);
                effects[index].stat = (Stats)EditorGUILayout.EnumPopup(effects[index].stat);
                GUILayout.Label("by");
                effects[index].amount = EditorGUILayout.IntField(effects[index].amount);
                GUILayout.Label("points");

                GUI.backgroundColor = Color.red;
                if (GUILayout.Button("Remove"))
                {
                    List<Effect> remove = new List<Effect>(effects);
                    remove.RemoveAt(index);
                    effects = remove.ToArray();
                }
                GUI.backgroundColor = Color.white;

                EditorGUILayout.EndHorizontal();
                EditorGUILayout.Separator();
            }

            if (GUILayout.Button("Add Effect +", GUILayout.MaxWidth(150f)))
            {
                Array.Resize(ref effects, effects.Length + 1);
                effects[effects.Length - 1] = new Effect();
            }

            EditorGUILayout.EndVertical();
        }

        interaction = EditorGUILayout.Toggle("Requires interaction?", interaction);

        if (interaction)
        {
            GUILayout.Label("Interaction Text");
            interactionText = EditorGUILayout.TextArea(flavourText, GUILayout.ExpandHeight(true), GUILayout.MaxHeight(100f));
        }

    }
}
