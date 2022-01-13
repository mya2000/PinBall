using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrpperController : MonoBehaviour
{
    private HingeJoint myHingeJoint;

    private float defaultAngle = 20;

    private float flickAngle = -20;
    // Start is called before the first frame update
    void Start()
    {
        this.myHingeJoint = GetComponent<HingeJoint>();

        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && tag == "LeftFripper tag")
        {
            SetAngle(this.flickAngle);
        }

        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && tag == "RightFripper tag")
        {
            SetAngle(this.flickAngle);
        }

        if ((Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A)) && tag == "LeftFripper tag")
        {
            SetAngle(this.defaultAngle);
        }

        if ((Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D)) && tag == "RightFripper tag")
        {
            SetAngle(this.defaultAngle);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            SetAngle(this.flickAngle);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            SetAngle(this.defaultAngle);
        }

        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                
                if (touch.phase == TouchPhase.Began)
                {
                    if (Input.mousePosition.x >= Screen.width / 2 && tag == "RightFripper tag")
                    { SetAngle(this.flickAngle); }

                    if (Input.mousePosition.x < Screen.width / 2 && tag == "LeftFripper tag")
                    { SetAngle(this.flickAngle); }
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    if (Input.mousePosition.x >= Screen.width / 2 && tag == "RightFripper tag")
                    { SetAngle(this.defaultAngle); }

                    if (Input.mousePosition.x < Screen.width / 2 && tag == "LeftFripper tag")
                    { SetAngle(this.defaultAngle); }
                }
            }

            
        }

    }

    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
