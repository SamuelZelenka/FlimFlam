using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]

public class PlayerActions : MonoBehaviour
{

    Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            weaponAttack();
            Debug.Log("Attack");
        }
    }

    public void weaponAttack(){
        myAnimator.SetTrigger("WeaponAttack");
    }
}
