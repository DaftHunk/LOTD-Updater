using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Structure
{
    [SerializeField]
    private string dataType;
    [SerializeField]
    private List<Page> content;

    public string DataType { get => dataType; set => dataType = value; }
    public List<Page> Content { get => content; set => content = value; }
}
