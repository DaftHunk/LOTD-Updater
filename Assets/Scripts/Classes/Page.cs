using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Page
{
    [SerializeField]
    private string nameVO;
    [SerializeField]
    private string nameVF;
    [SerializeField]
    private int order;
    [SerializeField]
    private Status status;

    public string NameVO { get => nameVO; set => nameVO = value; }
    public string NameVF { get => nameVF; set => nameVF = value; }
    public int Order { get => order; set => order = value; }
    public Status Status { get => status; set => status = value; }
}
