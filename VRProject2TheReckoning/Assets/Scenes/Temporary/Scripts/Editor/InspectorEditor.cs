// InspectorEditor (Completed) - Shijun Guo
using UnityEngine;
using UnityEditor;

#region Other Editor
[CustomEditor(typeof(Renamer))]
public class RenamerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Renamer renamer = (Renamer)target;

        if (GUILayout.Button("Rename Children"))
        {
            renamer.RenameChildren();
        }
    }
}
#endregion