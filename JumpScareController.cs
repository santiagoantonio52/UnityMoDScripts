using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class JumpScareController : MonoBehaviour
{
    public Canvas isJumpScareGhost;

    public float isJumpScareGhostCounter;

    private bool isJumpScareGhostBool = true;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isJumpScareGhostBool)
        {
            isJumpScareGhostCounter += Time.deltaTime;
            if(isJumpScareGhostCounter > 1)
                isJumpScareGhost.enabled = true;
            if (isJumpScareGhostCounter > 1.2f)
                isJumpScareGhost.enabled = false;
            if (isJumpScareGhostCounter > 1.6f)
                isJumpScareGhost.enabled = true;
            if (isJumpScareGhostCounter > 1.8f)
            {
                isJumpScareGhost.enabled = false;
                isJumpScareGhostCounter = 0;
            }
        }
    }
}
