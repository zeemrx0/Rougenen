#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using LNE.Utilities.Constants;

namespace LNE.Utilities
{
  [CustomEditor(typeof(ScriptableObjectWithId), true)]
  public class ScriptableObjectWithIdEditor : Editor
  {
    private IContainsId _object;

    public override void OnInspectorGUI()
    {
      _object ??= (IContainsId)target;

      EditorGUILayout.LabelField(GameProperty.Id, _object.Id);

      if (GUILayout.Button(GameString.CopyId))
      {
        EditorGUIUtility.systemCopyBuffer = _object.Id;
      }

      if (GUILayout.Button(GameString.GenerateId))
      {
        _object.Id = System.Guid.NewGuid().ToString();
        EditorUtility.SetDirty(_object as Object);
      }

      base.OnInspectorGUI();
    }
  }
}
#endif
