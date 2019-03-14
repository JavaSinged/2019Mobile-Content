using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public bool check = false;
	public bool checkNow = false;
	public string Tomorrow;
    public string Present;
	public Text TomorrowText;
	Random random = new Random();

	void Start () {
		Present=System.DateTime.Now.ToString("yyyy/MM/dd");
		Tomorrow=PlayerPrefs.GetString("Tomorrow",Tomorrow);
		
		if(string.IsNullOrEmpty(Tomorrow)){
			check=true;
			Tomorrow=System.DateTime.Now.AddDays(1).ToString("yyyy/MM/dd");
		}
		else if(Present!=Tomorrow){
			check=false;
		}
		else if(Present==Tomorrow){
			check=true;
			checkNow=true;
			Tomorrow=System.DateTime.Now.AddDays(1).ToString("yyyy/MM/dd");
		}

		// yield return new WaitForSeconds (1f);
		if(check==true){
			Random random = new Random();
			int coin = Random.Range(1,5);
			DialogDataAlert alert = new DialogDataAlert ("오늘의 아이템", coin+"골드 얻음", delegate() {
			Debug.Log("OK Pressed!");
		});
		DialogManager.Instance.Push (alert);
		checkNow=false;
		}

		PlayerPrefs.SetString("Tomorrow",Tomorrow);
	}
	
	// Update is called once per frame
	void Update () {
		TomorrowText.text=Tomorrow;
		
	}
}
