using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationNotification : MonoBehaviour
{
    public Transform box;

    public void OnEnable(){
        box.localPosition = new Vector2(0, -Screen.height);
        box.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().delay = 0.1f;
    }

    public void CloseDialog(){
        box.LeanMoveLocalY(-Screen.height, 0.5f).setEaseInExpo();
    }
}
