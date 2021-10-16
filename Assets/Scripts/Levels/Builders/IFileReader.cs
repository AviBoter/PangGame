
using System.Collections.Generic;
using UnityEngine;

namespace readers
{
    public interface IFileReader
    {
         Dictionary<string,ScriptableObject> ReadFromFile(string path);
    }
}