using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Units : MonoBehaviour
{
    Animation anim;
    Collider2D coll;


    public AnimationClip idle;
    public Sprite baseSprite;
    public float Dmg;
    public float AtkSpd;
    public int Grade;
    




    private void Awake() {
        anim = GetComponent<Animation>();
        coll = GetComponent<Collider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
