using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using UnityEngine;

public class JsonManager : MonoBehaviour
{
    private const string JSON_PATH = "JSON";
    private const string JSON_NAME = "structure.json";

    public TextAsset defaultData;
    public Structure structure = new Structure();  

    // Start is called before the first frame update
    void Start()
    {
        LoadStructureFromJSON();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadStructureFromJSON() {
        string filePath = System.IO.Path.Combine(Application.persistentDataPath, JSON_NAME);              

        if(!System.IO.File.Exists(filePath)) {
            defaultData = Resources.Load<TextAsset>(System.IO.Path.Combine(JSON_PATH, "structure"));
            byte[] data = defaultData.bytes;
            System.IO.File.WriteAllBytes(filePath, data);
        }
        string structureData = System.IO.File.ReadAllText(filePath);
        structure = JsonUtility.FromJson<Structure>(structureData);
    }
}

[Serializable]
public class Structure
{
    public string dataType;
    public List<string> content;
}
