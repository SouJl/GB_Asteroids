using System;
using System.Collections.Generic;
using UnityEngine;

namespace GB_Asteroids
{
    public class SerializavbleViewServise : MonoBehaviour, ISerializationCallbackReceiver
    {
        public List<string> _keys = new List<string>();
        public List<string> _values = new List<string>();

        public IViewBuilderService viewBuilder = new ViewBuilderService();


        public void OnBeforeSerialize()
        {
            _keys.Clear();
            _values.Clear();

            foreach (var kvp in viewBuilder.ViewCashe)
            {
                _keys.Add(kvp.Key);
                _values.Add(kvp.Value.ToString());
            }
        }

        public void OnAfterDeserialize()
        {

        }

    }
}
