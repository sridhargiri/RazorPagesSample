using System;
using System.Collections.Generic;
namespace CustomCollection.Tests
{
    public interface IStringMap<TValue> where TValue : class
    {
        /// <summary>Returns number of elements in a map</summary>
        int Count { get; }

        /// <summary>
        /// If <c>GetValue</c> method is called but a given key is not in a map then <c>DefaultValue</c> is returned.
        /// </summary>
        TValue DefaultValue { get; set; }

        /// <summary>
        /// Adds a given key and value to a map.
        /// If the given key already exists in the map, then the value associated with this key should be overridden.
        /// </summary>
        /// <returns>true if the value for the key was overridden, otherwise false</returns>
        /// <exception cref="System.ArgumentNullException">If the key is null</exception>
        /// <exception cref="System.ArgumentException">If the key is an empty string</exception>
        /// <exception cref="System.ArgumentNullException">If the value is null</exception>
        bool AddElement(string key, TValue value);

        /// <summary>
        /// Removes a given key and associated value from a map.
        /// </summary>
        /// <returns>true if the key was in the map and was removed, otherwise false</returns>
        /// <exception cref="System.ArgumentNullException">If the key is null</exception>
        /// <exception cref="System.ArgumentException">If the key is an empty string</exception>
        bool RemoveElement(string key);

        /// <summary>
        /// Returns the value associated with a given key.
        /// </summary>
        /// <returns>The value associated with a given key or <c>DefaultValue</c> if the key does not exist in a map</returns>
        /// <exception cref="System.ArgumentNullException">If the key is null</exception>
        /// <exception cref="System.ArgumentException">If the key is an empty string</exception>
        TValue GetValue(string key);
    }

    // Do not change the name of this class
    public class StringMap<TValue> : IStringMap<TValue>
    where TValue : class
    {
        private Dictionary<string, TValue> dict;
        public StringMap()
        {
            this.dict = new Dictionary<string, TValue>();
        }

        /// <summary> Returns number of elements in a map</summary>
        public int Count => dict.Count;

        /// <summary>
        /// If <c>GetValue</c> method is called but a given key is not in a map then <c>DefaultValue</c> is returned.
        /// </summary>
        // Do not change this property
        public TValue DefaultValue { get; set; }
        /// <summary>
        /// Adds a given key and value to a map.
        /// If the given key already exists in a map, then the value associated with this key should be overriden.
        /// </summary>
        /// <returns>true if the value for the key was overriden otherwise false</returns>
        /// <exception cref="System.ArgumentNullException">If the key is null</exception>
        /// <exception cref="System.ArgumentException">If the key is an empty string</exception>
        /// <exception cref="System.ArgumentNullException">If the value is null</exception>
        public bool AddElement(string key, TValue value)
        {
            if (key == null || value == null)
            {
                throw new ArgumentNullException();
            }
            else if (key == string.Empty)
            {
                throw new ArgumentException();
            }
            else
            {
                if (dict.ContainsKey(key))
                {
                    dict[key] = value;
                    return true;
                }
                else
                {
                    dict.Add(key, value);
                    return false;
                }
            }
            // throw new NotImplementedException();

        }
        /// <summary>
        /// Removes a given key and associated value from a map.
        /// </summary>
        /// <returns>true if the key was in the map and was removed otherwise false</returns>
        /// <exception cref="System.ArgumentNullException">If the key is null</exception>
        /// <exception cref="System.ArgumentException">If the key is an empty string</exception>
        public bool RemoveElement(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException();
            }
            else if (key == string.Empty)
            {
                throw new ArgumentException();
            }
            else
            {
                if (dict.ContainsKey(key))
                {
                    dict.Remove(key);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            // throw new NotImplementedException();
        }
        /// <summary>
        /// Returns the value associated with a given key.
        /// </summary>
        /// <returns>The value associated with a given key or <c>DefaultValue</c> if the key does not exist in a map</returns>
        /// <exception cref="System.ArgumentNullException">If a key is null</exception>
        /// <exception cref="System.ArgumentException">If a key is an empty string</exception>
        public TValue GetValue(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException();
            }
            else if (key == string.Empty)
            {
                throw new ArgumentException();
            }
            else
            {
                if (dict.ContainsKey(key))
                {
                    return dict[key];
                }
                else
                {
                    return DefaultValue;
                }
            }
            // throw new NotImplementedException();
        }
    }
}