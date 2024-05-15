#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using LNE.Utilities.Constants;
using LNE.Combat.Abilities;

namespace LNE.Combat.Editors
{
  [CustomEditor(typeof(AbilityData), true)]
  public class AbilityDataEditor : Editor
  {
    private AbilityData _object;

    public override void OnInspectorGUI()
    {
      _object ??= (AbilityData)target;

      EditorGUILayout.LabelField(GameProperty.Id, _object.Id);

      if (GUILayout.Button(GameString.CopyId))
      {
        EditorGUIUtility.systemCopyBuffer = _object.Id;
      }

      if (GUILayout.Button(GameString.GenerateId))
      {
        _object.Id = System.Guid.NewGuid().ToString();
        EditorUtility.SetDirty(_object);
      }

      if (GUILayout.Button(GameString.InitStats))
      {
        _object.InitStats();
        EditorUtility.SetDirty(_object);
      }

      base.OnInspectorGUI();
    }
  }
}
#endif
