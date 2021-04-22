using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    [Header("角色名稱"), Tooltip("這是角色名稱")]
    public string cName = "波米";
    [Header("移動速度"), Range(1, 100)]
    public float speed = 10.5f;
    [Header("攻擊"), Range(1, 100)]
    public float attack = 20f;

    [Header("蛋糕"), Range(0, 1000)]
    public int cake = 0;
    [Header("虛擬搖桿")]
    public FixedJoystick joystick;
    [Header("變形元件")]
    public Transform tra;
    [Header("動畫元件")]
    public Animator ani;
    [Header("偵測攻擊範圍")]
    public float rangeAttack = 1.2f;
    [Header("音效來源")]
    public AudioSource aud;
    [Header("攻擊音效")]
    public AudioClip soundAttack;


    [Header("吃蛋糕音效")]
    public AudioClip SoundEat;
    [Header("吃蛋糕數量")]
    public Text textCake;


    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.2f);

        Gizmos.DrawSphere(transform.position, rangeAttack);
    }

    private void Move()
    {
        float h = joystick.Horizontal;
        float v = joystick.Vertical;
        /*if(h == 0.5f)
        {
            ani.SetFloat("靜止", h);
        }*/
        tra.Translate(h * speed * Time.deltaTime, v * speed * Time.deltaTime, 0);
        ani.SetFloat("水平", h);
        //ani.SetFloat("垂直", v);
    }

    private void Update()
    {
        Move();
    }

    public void Attack()
    {
        aud.PlayOneShot(soundAttack, 0.6f);

        RaycastHit2D hit = Physics2D.CircleCast(transform.position, rangeAttack, -transform.up, 0, 1 << 8);

        if (hit && hit.collider.tag == "道具")
        {
            hit.collider.GetComponent<item>().DropProp();
            print("碰到的物件:" + hit.collider.name);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.tag == "蛋糕")
        {
            cake++;
            aud.PlayOneShot(SoundEat);
            Destroy(collision.gameObject);
            textCake.text = "：" + cake;

        }
    }


}
