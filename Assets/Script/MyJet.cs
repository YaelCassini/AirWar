using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyJet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float moveSpeed = 0.005f;
    public float interval = 0.4f;
    private float count = 0;
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
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        // 定时逻辑
        count += Time.deltaTime;
        if (count >= interval)
        {
            count = 0;
            Fire();
        }

        Vector3 worldPos = transform.position;
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
        float speed = 0.005f;

        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Vector3 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                if(touchDeltaPosition.x>0)
                {
                    if ((screenPos[0] <= Screen.width - 32))
                        transform.Translate(touchDeltaPosition.x * speed, 0, 0, Space.World);
                }
                else
                {
                    if ((screenPos[0] >= 32))
                        transform.Translate(touchDeltaPosition.x * speed, 0, 0, Space.World);
                }
            }
        }

        //完成第一次点击，开始计时
        if (hasOneClick)
        {
            timer += Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (!hasOneClick)
            {
                //添加单击事件
                hasOneClick = true;
            }
            //当前是第二次点击
            else
            {
                //判断时间间隔是否超时	
                if (timer < doubleClickInterval)
                {
                    ChangeBullet();

                    //重置标志位,计时器归零
                    hasOneClick = false;
                    timer = 0;
                }
                //操作超时，判断它为下一次单击
                else
                {
                    //计时器归零
                    timer = 0;
                }
            }
        }
    }
    private void Fire()
    {
        Vector3 pos = transform.position + new Vector3(0, 1f, 0);
        GameObject bullet = Instantiate(bulletPrefab, pos, transform.rotation);
        SpriteRenderer renderer = bullet.GetComponent<SpriteRenderer>();
        renderer.sprite = images[index];

    }
    public void ChangeBullet()
    {
        index = index + 1;
        index = index % (images.Length);
    }
}
