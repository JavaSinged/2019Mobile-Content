using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateGet : MonoBehaviour
{
    public string Tomorrow;
    public string Present;
    public Text Attend;
    // Start is called before the first frame update
    void Start()
    {
        Tomorrow=System.DateTime.Now.AddDays(1).ToString("yyyy/MM/dd");
    }

    // Update is called once per frame
    void Update()
    {
        Present=System.DateTime.Now.ToString("yyyy/MM/dd");
        if(Present.ToString()!=Tomorrow.ToString()){
            Attend.text="출석확인 되지 않음";
        }else if(Present==Tomorrow){
            Attend.text="출석체크";
        }
    }
}
