using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
  public void MoveCamera(Vector3 pos)
    {
        transform.position = pos;
    }
}
