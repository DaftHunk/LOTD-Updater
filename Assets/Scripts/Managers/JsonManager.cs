using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonManager : MonoBehaviour
{
    public StructureManager StructureManager;

    // Start is called before the first frame update
    void Start()
    {
        StructureManager = GetComponent<StructureManager>();

        if (StructureManager == null)
        {
            Debug.LogWarning("No StructureManager found on " + gameObject.name);
            return;
        }
        LoadStructureFromJSON();
    }

    private void LoadStructureFromJSON()
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
        StructureManager.StructureInitiator(JsonUtility.FromJson<Structure>(structureData));
    }
}