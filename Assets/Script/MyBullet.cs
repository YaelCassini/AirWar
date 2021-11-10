using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MyBullet : MonoBehaviour
{
    public float speed = 5.5f;
    public Sprite[] images;
    private int index = 0;

    //是否有一次单击
    private bool hasOneClick = false;
    //默认双击时间间隔
    private float doubleClickInterval = 0.5f;
    //计时器
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.name = "Bullet";
    }

    // Update is called once per frame
    void Update()
    {
        float dy = speed * Time.deltaTime;
        transform.Translate(0, dy, 0, Space.Self);
        Vector3 sp = Camera.main.WorldToScreenPoint(transform.position);
        if (sp.y > Screen.height)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.name.Equals("Monster"))
        {
            // 销毁当前怪物
            Destroy(this.gameObject);
        }
    }
}
