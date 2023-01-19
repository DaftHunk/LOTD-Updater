using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class ModManager : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField]
    private GameObject pagePrefab;
    [SerializeField]
    private GameObject categoryPrefab;
    [SerializeField]
    private GameObject modPrefab;

    [Header("StructurePrefabs")]
    [SerializeField]
    private GameObject pageStructurePrefab;
    [SerializeField]
    private GameObject categoryStructurePrefab;

    public List<GameObject> pagesInfo = new List<GameObject>();
    public List<GameObject> categoriesInfo = new List<GameObject>();
    public List<GameObject> modsInfo = new List<GameObject>();

    [Header("Parents")]
    [SerializeField]
    private Transform todoParent;
    [SerializeField]
    private Transform doingParent;
    [SerializeField]
    private Transform testingParent;
    [SerializeField]
    private Transform doneParent;
    [SerializeField]
    private Transform archivedParent;
    [SerializeField]
    private Transform structureParent;

    #region Singleton
    public static ModManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public void UpdateModStructure()
    {
        foreach (Page page in StructureManager.Instance.Structure.Content)
        {
            InstanciatePage(page);
        }
    }

    public void InstanciatePage(Page page)
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject pageInfoPrefab = Instantiate(
                Instance.pagePrefab,
                StatusParent(i));

            pagesInfo.Add(pageInfoPrefab);
            page.Status = (Status)i;

            PageInfo pageInfo = pageInfoPrefab.GetComponent<PageInfo>();
            pageInfo.Initiate(page);

            foreach (Category category in page.Content.OrderBy(x => x.Index))
            {
                InstanciateCategory(
                    category,
                    pageInfo);
            }
        }
    }

    public void InstanciateCategory(Category category, PageInfo pageInfo)
    {
        GameObject categoryInfoPrefab = Instantiate(
            categoryPrefab,
            pageInfo.ContentParent);

        CategoryInfo categoryInfo = categoryInfoPrefab.GetComponent<CategoryInfo>();
        categoryInfo.PageInfo = pageInfo;
        categoryInfo.Initiate(category);

        categoriesInfo.Add(categoryInfoPrefab);
    }

    public void InstanciateMod(TypeInfo typeInfo)
    {
        GameObject modInfoPrefab = Instantiate(
            Instance.modPrefab,
            typeInfo.transform);

        modInfoPrefab.GetComponent<ModInfo>()
            .Mod.ActionType = typeInfo.ActionType;

        modsInfo.Add(modInfoPrefab);
    }

    public Transform StatusParent(int status) => status switch
    {
        0 => todoParent,
        1 => doingParent,
        2 => testingParent,
        3 => doneParent,
        4 => archivedParent,
        _ => todoParent
    };
}
