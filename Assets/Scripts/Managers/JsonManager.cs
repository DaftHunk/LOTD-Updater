using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonManager : MonoBehaviour
{
    private const string JSON_PATH = "JSON";
    private const string JSON_NAME = "structure.json";

    public TextAsset DefaultData;
    public Structure Structure;

    // Start is called before the first frame update
    void Start()
    {
        LoadStructureFromJSON();
    }

    private void LoadStructureFromJSON()
    {
        string filePath = System.IO.Path.Combine(
            Application.persistentDataPath,
            JSON_NAME);

        if (!System.IO.File.Exists(filePath))
        {
            DefaultData = Resources.Load<TextAsset>(System.IO.Path.Combine(
                JSON_PATH,
                "structure"));
            byte[] data = DefaultData.bytes;
            System.IO.File.WriteAllBytes(filePath, data);
        }
        string structureData = System.IO.File.ReadAllText(filePath);
        Structure = JsonUtility.FromJson<Structure>(structureData);
    }
}

[Serializable]
public class Structure
{
    [SerializeField]
    private string dataType;
    [SerializeField]
    private List<Page> content;

    public string DataType { get => dataType; set => dataType = value; }
    public List<Page> Content { get => content; set => content = value; }
}