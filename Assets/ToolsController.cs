using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolsController : MonoBehaviour
{


    public Image[] surgicalTools;
    //x heartRate  y bloodPressure  z breathing
    public Vector3Int[] toolsFactors;
    public int[] toolsLeftNum;
    public FactorController factorCtrl;
    List<Text> toolsNum;

    void Start()
    {
        if (surgicalTools.Length == 0 || !factorCtrl) return;
        toolsNum = new List<Text>();
        for (int i = 0; i < surgicalTools.Length; i++)
        {
            toolsNum.Add( surgicalTools[i].transform.Find("Text").GetComponent<Text>());
            toolsNum[i].text = toolsLeftNum[i].ToString();
        }

    }
    public void OnClickTool(int id) {
        Debug.Log("Medicine : "+id + "; affects"+ toolsFactors[id]);
        if (toolsLeftNum[id] > 0)
        {
            toolsLeftNum[id]--;
            toolsNum[id].text = toolsLeftNum[id].ToString();
            factorCtrl.GetMedicine(toolsFactors[id]);
        }
    }
    void InitAll() {
      
    }
    
}
