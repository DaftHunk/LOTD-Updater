using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LoadStructureFromJSON();
    }

    public void LoadStructureFromJSON()
    {
        string filePath = System.IO.Path.Combine(
            Application.persistentDataPath,
            GlobalValues.JSON_NAME);

        if (!System.IO.File.Exists(filePath))
        {
            TextAsset defaultData = Resources.Load<TextAsset>(System.IO.Path.Combine(
                GlobalValues.JSON_PATH,
                "structure"));
            byte[] data = defaultData.bytes;
            System.IO.File.WriteAllBytes(filePath, data);
        }
        string structureData = System.IO.File.ReadAllText(filePath);
        StructureManager.Instance.StructureInitiator(JsonUtility.FromJson<Structure>(structureData));
    }

    public void SaveStructureToJSON()
    {
        string filePath = System.IO.Path.Combine(
            Application.persistentDataPath,
            GlobalValues.JSON_NAME);

        if (System.IO.File.Exists(filePath))
        {
            string structureData = JsonUtility
                .ToJson(StructureManager.Instance.Structure, true);
            System.IO.File.WriteAllText(filePath, structureData);
        }
        else
        {
            Debug.LogWarning("Error while saving structure.json");
        }
    }
}