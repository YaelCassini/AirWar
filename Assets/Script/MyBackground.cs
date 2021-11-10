using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBackground : MonoBehaviour
{
    Transform bg1;
    Transform bg2;
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        // �������������ƶ��л����γ������ı���
        bg1 = GameObject.Find("/��Ϸ����/bg1").transform;
        bg2 = GameObject.Find("/��Ϸ����/bg2").transform;

        bg1.position = new Vector3(0, 0, 0);
        bg2.position = new Vector3(0, 10, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float dy = speed * Time.deltaTime;
        bg1.Translate(0, -dy, 0);
        bg2.Translate(0, -dy, 0);

        if (bg1.position.y <= -10)
        {
            bg1.Translate(0, 20, 0);
        }
        if (bg2.position.y <= -10)
        {
            bg2.Translate(0, 20, 0);
        }
    }
}
