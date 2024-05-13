using System;
using System.Collections.Generic;
using UnityEngine;

namespace LNE.GameStats
{
  [Serializable]
  public class Stats
  {
    [field: SerializeField]
    private List<Stat> _list = new List<Stat>();

    private Dictionary<string, Stat> _dictionary =
      new Dictionary<string, Stat>();

    public void BuildDictionary()
    {
      _dictionary.Clear();
      foreach (var stat in _list)
      {
        _dictionary[stat.Name] = stat;
      }
    }

    public float Get(string name)
    {
      return _dictionary[name].Value;
    }

    public void Set(string name, float value)
    {
      _dictionary[name].Value = value;
    }

    public void Add(string name, float value)
    {
      _list.Add(new Stat { Name = name, Value = value });
      _dictionary[name] = _list[^1];
    }

    public void Remove(string name)
    {
      _list.Remove(_dictionary[name]);
      _dictionary.Remove(name);
    }

    public void Clear()
    {
      _list.Clear();
      _dictionary.Clear();
    }
  }
}
