using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    //ī�޶� ����ٴ� ���
    public Transform target;

    //ī�޶� ����� ���󰡴� �ӵ�
    public float smooth = 0.1f;

    public Vector3 adjustCamPos;
    //ī�޶� ��� ����
    public Vector2 minCamLimit;
    public Vector2 maxCamLimit;

    private void Update()
    {
        if(target == null) return;

        Vector3 pos = Vector3.Lerp(transform.position, target.position, smooth);

        // ���� �Ѱ� ��ġ�� ���� ī�޶� ��ġ
        transform.position = new Vector3(Mathf.Clamp(pos.x, minCamLimit.x, maxCamLimit.x) + adjustCamPos.x,
         Mathf.Clamp(pos.y, minCamLimit.y, maxCamLimit.y) + adjustCamPos.y,
         -10f + adjustCamPos.z);
    }

}
