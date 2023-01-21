using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeInfo : MonoBehaviour
{
    public CategoryInfo CategoryInfo;

    public Transform ContentParent;

    [SerializeField]
    private ActionType actionType;

    public ActionType ActionType { get => actionType; set => actionType = value; }

    public void AddMod()
    {
        CategoryInfo.AddMod(this);
    }
}
