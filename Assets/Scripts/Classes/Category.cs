using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class Category
{
    [SerializeField]
    private string nameVO;
    [SerializeField]
    private string nameVF;
    [SerializeField]
    private int order;
    [SerializeField]
    private Page page;

    public string NameVO { get => nameVO; set => nameVO = value; }
    public string NameVF { get => nameVF; set => nameVF = value; }
    public int Order { get => order; set => order = value; }
    public Page Page { get => page; set => page = value; }    
}
