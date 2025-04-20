using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Console
{
    public class CrudServiceAsync<T> : ICrudServiceAsync<T> where T : class, IEntity
    {
        private readonly ConcurrentDictionary<Guid, T> _storage = new ConcurrentDictionary<Guid, T>();
        private readonly SemaphoreSlim _lock = new SemaphoreSlim(1, 1);
        private readonly string _filePath;

        public CrudServiceAsync(string filePath)
        {
            _filePath = filePath;
            LoadFromFile();
        }

        public Task<bool> CreateAsync(T element)
        {
            return Task.FromResult(_storage.TryAdd(element.Id, element));
        }

        public Task<T> ReadAsync(Guid id)
        {
            T value;
            _storage.TryGetValue(id, out value);
            return Task.FromResult(value);
        }

        public Task<IEnumerable<T>> ReadAllAsync()
        {
            return Task.FromResult<IEnumerable<T>>(_storage.Values.ToList());
        }

        public Task<IEnumerable<T>> ReadAllAsync(int page, int amount)
        {
            var items = _storage.Values
                .Skip((page - 1) * amount)
                .Take(amount)
                .ToList();

            return Task.FromResult<IEnumerable<T>>(items);
        }

        public Task<bool> UpdateAsync(T element)
        {
            if (!_storage.ContainsKey(element.Id))
                return Task.FromResult(false);

            _storage[element.Id] = element;
            return Task.FromResult(true);
        }

        public Task<bool> RemoveAsync(T element)
        {
            T removed;
            return Task.FromResult(_storage.TryRemove(element.Id, out removed));
        }

        public async Task<bool> SaveAsync()
        {
            await _lock.WaitAsync();
            try
            {
                var data = _storage.ToList();
                var json = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(_filePath, json, Encoding.UTF8);
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                _lock.Release();
            }
        }

        private void LoadFromFile()
        {
            if (!File.Exists(_filePath))
                return;

            try
            {
                var json = File.ReadAllText(_filePath, Encoding.UTF8);
                var data = JsonConvert.DeserializeObject<List<KeyValuePair<Guid, T>>>(json);
                if (data != null)
                {
                    foreach (var pair in data)
                        _storage[pair.Key] = pair.Value;
                }
            }
            catch
            {
                // ignore load errors
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _storage.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
