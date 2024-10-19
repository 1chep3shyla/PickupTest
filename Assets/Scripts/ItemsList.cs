using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ItemsList : MonoBehaviour
{
    public ItemData[] data;
    
    void Start()
    {
        for(int i = 0; i < data.Length;i++)
        {
            data[i].textCounter.text = data[i].name + ": " + data[i].curCount + "/" + data[i].maxCount;
        }
    }
    public void UpdateData(string name)
    {
        for(int i = 0; i < data.Length;i++)
        {
            if(name == data[i].name)
            {
                data[i].curCount++;
                data[i].textCounter.text = data[i].name + data[i].curCount + "/" + data[i].maxCount;
            }
        }
    }

    [System.Serializable]
    public class ItemData
    {
        public string name;
        public int curCount;
        public int maxCount;
        public TMP_Text textCounter;
    }
}
