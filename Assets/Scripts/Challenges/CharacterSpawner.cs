using System.Collections.Generic;
using LNE.Characters;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace LNE.GameChallenge
{
  public class CharacterSpawner : MonoBehaviour
  {
    [SerializeField]
    private Tilemap _tilemap;

    private List<Vector3> _canSpawnPositions = new List<Vector3>();

    private void Awake()
    {
      InitCanSpawnPositions();
    }

    private void InitCanSpawnPositions()
    {
      BoundsInt bounds = _tilemap.cellBounds;
      TileBase[] tiles = _tilemap.GetTilesBlock(bounds);
      Vector3 start = _tilemap.CellToWorld(bounds.min);

      _canSpawnPositions.Clear();
      for (int x = 0; x < bounds.size.x; x++)
      {
        for (int y = 0; y < bounds.size.y; y++)
        {
          if (tiles[x + y * bounds.size.x] != null)
          {
            _canSpawnPositions.Add(start + new Vector3(x, y, 0));
          }
        }
      }
    }

    public void Spawn(Character character)
    {
      Vector3 position = _canSpawnPositions[
        Random.Range(0, _canSpawnPositions.Count)
      ];

      Instantiate(character, position, Quaternion.identity);
    }
  }
}
