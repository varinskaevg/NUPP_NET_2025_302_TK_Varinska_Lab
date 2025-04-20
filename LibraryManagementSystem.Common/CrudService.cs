using LibraryManagementSystem.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;


public class CrudService<T> : ICrudService<T> where T : class
{
    private Dictionary<Guid, T> storage = new Dictionary<Guid, T>();

    public void Create(T element)
    {
        var id = Guid.NewGuid();
        storage[id] = element;
    }

    public T Read(Guid id)
    {
        storage.TryGetValue(id, out var element);
        return element;
    }

    public IEnumerable<T> ReadAll()
    {
        return storage.Values;
    }

    public void Update(T element)
    {
        foreach (var key in storage.Keys)
        {
            if (storage[key].Equals(element))
            {
                storage[key] = element;
                break;
            }
        }
    }

    public void Remove(T element)
    {
        Guid toRemove = Guid.Empty;
        foreach (var pair in storage)
        {
            if (pair.Value.Equals(element))
            {
                toRemove = pair.Key;
                break;
            }
        }
        if (toRemove != Guid.Empty)
        {
            storage.Remove(toRemove);
        }
    }

    public void Save(string filePath)
    {
        var data = storage.ToList();
        var json = JsonConvert.SerializeObject(data, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }

    public void Load(string filePath)
    {
        if (!File.Exists(filePath)) return;

        var json = File.ReadAllText(filePath);
        var data = JsonConvert.DeserializeObject<List<KeyValuePair<Guid, T>>>(json);
        if (data != null)
        {
            storage = data.ToDictionary(pair => pair.Key, pair => pair.Value);
        }
    }
}