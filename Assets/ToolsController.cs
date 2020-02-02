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
    

    void Start()
    {
        if (surgicalTools.Length == 0 || !factorCtrl) return;
    }
    public void OnClickTool(int id) {
        Debug.Log("Medicine : "+id + "; affects"+ toolsFactors[id]);
        factorCtrl.GetMedicine(toolsFactors[id ]);

    }
    void InitAll() {
      
    }
    
}
