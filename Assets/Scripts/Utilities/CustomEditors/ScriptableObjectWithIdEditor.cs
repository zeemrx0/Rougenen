using UnityEngine;
using UnityEditor;
using LNE.Utilities.Constants;

namespace LNE.Utilities
{
  [CustomEditor(typeof(ScriptableObjectWithId), true)]
  public class ScriptableObjectWithIdEditor : Editor
  {
    private IContainsId _object;

    private void Awake()
    {
      _object = (IContainsId)target;
    }

    public override void OnInspectorGUI()
    {
      EditorGUILayout.LabelField(GameProperty.Id, _object.Id);
      base.OnInspectorGUI();
      if (GUILayout.Button(GameString.GenerateId))
      {
        _object.Id = System.Guid.NewGuid().ToString();
        EditorUtility.SetDirty(_object as Object);
      }
    }
  }
}
