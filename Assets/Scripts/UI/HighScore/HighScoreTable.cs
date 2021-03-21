using System.Collections.Generic;
using UnityEngine;

public class HighScoreTable : MonoBehaviour
{

    public GameObject rowTemplate;
    public Transform container;

    private HighScoreManager manager;
    public float offset = -20f;


    private void Start()
    {
        manager = HighScoreManager.instance;

        int i = 0;
        foreach (HighScoreRowData rowData in manager.getRows())
        {
            Vector3 offsetVec = new Vector3(0, offset * i, 0);
            GameObject row = Instantiate(rowTemplate, container.position + offsetVec, Quaternion.identity);
            row.transform.SetParent(container, false);
            
            row.GetComponent<TemplateRow>().setValues(i + 1, rowData.getName(), rowData.getTime(), rowData.getScore());

            i++;
        }
    }
}
