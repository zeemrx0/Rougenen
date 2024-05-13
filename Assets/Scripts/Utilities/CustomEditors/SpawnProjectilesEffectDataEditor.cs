using UnityEngine;
using UnityEditor;
using LNE.Utilities.Constants;
using LNE.Combat.Abilities;

namespace LNE.Utilities
{
  [CustomEditor(typeof(SpawnProjectilesEffectData), true)]
  public class SpawnProjectilesEffectDataEditor : Editor
  {
    private SpawnProjectilesEffectData _object;

    private void Awake()
    {
      _object = (SpawnProjectilesEffectData)target;
    }

    public override void OnInspectorGUI()
    {
      _object ??= (SpawnProjectilesEffectData)target;

      if (GUILayout.Button(GameString.InitStats))
      {
        _object.InitStats();
        EditorUtility.SetDirty(_object);
      }

      base.OnInspectorGUI();
    }
  }
}
