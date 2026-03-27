using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanAcelerator : MonoBehaviour
{

    public List<SampleScripDan> allScripts = new List<SampleScripDan>();
    private void Awake()
    {
        FindAndFillScripts();
    }
    private void FindAndFillScripts()
    {
        SampleScripDan[] foundScripts = FindObjectsByType<SampleScripDan>(FindObjectsSortMode.None);
        allScripts.Clear();
        allScripts.AddRange(foundScripts);

        Debug.Log($"Найдено скриптов: {allScripts.Count}");
    }


    public void RunAll()
    {
        foreach (SampleScripDan script in allScripts)
        {
            if (script != null)
            {
                script.Use();
            }
        }
        Debug.Log("RunAll() выполнен. Все скрипты получили команду Use()");
    }

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<SampleScripDan>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RunAll();
        }
    }
}
