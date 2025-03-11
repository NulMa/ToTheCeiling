using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject unit;
    public UnitTree treeData;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void testingButton() {
        int code = Random.Range(0, 3);
        unit.GetComponent<Units>().Dmg = treeData.mythicals[code].Dmg;
        unit.GetComponent<Units>().AtkSpd = treeData.mythicals[code].AtkSpd;
        unit.GetComponent<Units>().Grade = treeData.mythicals[code].Grade;
        unit.GetComponent<Units>().idle = treeData.mythicals[code].anim;
        unit.GetComponent<Units>().baseSprite = treeData.mythicals[code].sprite;
        unit.GetComponent<SpriteRenderer>().sprite = treeData.mythicals[code].sprite;

        Instantiate(unit, this.transform);
    }
}
