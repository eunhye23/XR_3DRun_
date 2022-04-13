using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_HPBar : MonoBehaviour
{
    [SerializeField]
    private Slider hpbar;

    private float maxHp = 100;
    private float curHp = 100;

    
    void Start()
    {
        hpbar.value = (float)curHp / (float)maxHp;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (curHp > 0)
            {
                curHp -= 10;
            }
            else
            {
                curHp = 0;
            }
        }

        HPHandle();
    }

    private void HPHandle()
    {
        //������ ����� hp�ٰ� �ε巴�� ���̵��� ����
        hpbar.value =Mathf.Lerp(hpbar.value, (float)curHp / (float)maxHp, Time.deltaTime * 10);
    }
}
