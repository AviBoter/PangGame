using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFileWriter
{
     void WriteToFile(string path, ScriptableObject[] Data);
}
