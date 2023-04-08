using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MattyCat.Core
{
    public class PersistantObject : MonoBehaviour
    {
        private void Awake()
        {
            var obj = FindObjectsOfType<PersistantObject>();
            if (obj.Length > 1)
            {
                DestroyImmediate(gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}