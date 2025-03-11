using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewUnit", menuName = "UnitData/Data")]

public class UnitData : ScriptableObject {

    public Sprite sprite;     // 아이템 이미지
    public AnimationClip anim; // 아이템 사용 시 재생할 애니메이션 클립

    public BoolArray[] size;  // 2D 배열 형태

    public float Dmg;
    public float AtkSpd;
    public int Grade;
    public int unitCode;
    /*
     * Grades
        1_common  
        4_uncommon
        8_rare
        16_unique
        32_legendary
        64_mythical

    * unitCode is GradeNum + Code
    *   ex) 6400 is mythical's 00
    */


    public UnitData[] needsToUp;

    [System.Serializable]
    public struct BoolArray
    {
        public bool[] row;
    }
}

