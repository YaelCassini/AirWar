using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMonster : MonoBehaviour
{
    public float speed = 1.0f;
    public int value; 
    public int hp;
    private Transform hpNode;
    private Transform game;

    // Start is called before the first frame update
    void Start()
    {
        this.name = "Monster";
        game = GameObject.Find("游戏主控").transform;

        value = Random.Range(0, 5) + 1;
        hp = value;

        hpNode = transform.Find("hp/value");
        SetHealth(hp);
    }

    // Update is called once per frame
    void Update()
    {
        float dy = speed * Time.deltaTime;
        transform.Translate(0, -dy, 0);

        Vector3 sp = Camera.main.WorldToScreenPoint(transform.position);
        if (sp.y < 0)
        {
            Destroy(this.gameObject);
        }
    }

    // 设置图片显示
    public void SetSprite(Sprite sprite)
    {
        Transform monster = transform.Find("monster");
        SpriteRenderer renderer = monster.GetComponent<SpriteRenderer>();
        renderer.sprite = sprite;

        float imgWidth = sprite.rect.width; // 图像的实际宽度
        float scale = 80 / imgWidth; // 缩放比例
        monster.localScale = new Vector3(scale, scale, scale);
    }

    // 更新HP显示
    public void SetHealth(int hpValue)
    {
        hpNode.localScale = new Vector3(hpValue / 5f, 1, 1);
        float movex = -(1 - hpValue / 5f) / 2;
        hpNode.localPosition = new Vector3(movex, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("Bullet"))
        {
            hp -= 1;
            SetHealth(hp);

            // HP降为0
            if (hp <= 0)
            {
                Destroy(this.gameObject);
                game.SendMessage("AddScore", this.value);
            }
        }
    }
}
