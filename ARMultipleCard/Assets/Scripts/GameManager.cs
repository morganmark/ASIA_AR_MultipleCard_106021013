//using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //初始欄位
    [Header("位置")]
    public Transform rabbit;
    public Transform bat;
    [Header("虛擬搖桿")]
    public FixedJoystick joystick;
    [Header("速度")]
    [Range(0.1f, 20f)]//滑桿
    public float speed = 1.0f;
    [Header("大小")]
    [Range(0.1f, 5.0f)]//滑桿
    public float size = 0.2f;
    [Header("動畫")]
    public Animator aniRabbit;
    public Animator aniBat;

    public float v = 0;


    //初始
    private void Start()
    {
        //測試
        print("初始");
    }

    //更新>1秒60次
    private void Update()
    {
        //測試
        print("更新");
        print(joystick.Vertical);

        bat.Rotate(0, joystick.Horizontal*speed, 0);//旋轉
        rabbit.Rotate(0, joystick.Horizontal*speed, 0);
        if (joystick.Vertical == 0)
        {
            //bat.localScale = new Vector3(50, 50, 50);
            //rabbit.localScale = new Vector3(50, 50, 50);
        }
        else
        {
            v = Mathf.Clamp(joystick.Vertical, 0.3f, 1.0f);
            //bat.localScale = new Vector3(50, 50, 50) * Mathf.Abs(joystick.Vertical)*size; //新的區域尺寸
            //rabbit.localScale = new Vector3(50, 50, 50) * Mathf.Abs(joystick.Vertical)*size;
            print(v);
            bat.localScale = new Vector3(50, 50, 50) * v* size; //新的區域尺寸
            rabbit.localScale = new Vector3(50, 50, 50) * v* size;
        }
        
    }

    //Method
    public void Attack()//固定public
    {
        print("attack");
        aniBat.SetTrigger("BatAttack");//unity api animator>method>setTrigger
        aniRabbit.SetTrigger("RabbitAttack");
    }

    public void Move()//固定public
    {
        print("move");
        aniBat.SetTrigger("BatMove");
        aniRabbit.SetTrigger("RabbitMove");
    }

    public void Die()//固定public
    {
        print("die");
        aniBat.SetTrigger("BatDie");
        aniRabbit.SetTrigger("RabbitDie");
    }

    public void BatAni(string batAni)
    {
        print(batAni);
        aniBat.SetTrigger(batAni);
    }
    public void RabbitAni(string rabbitAni)
    {
        print(rabbitAni);
        aniRabbit.SetTrigger(rabbitAni);
    }
}


