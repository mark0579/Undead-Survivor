using UnityEngine;
using UnityEngine.UI;


public class HUD : MonoBehaviour
{
    public enum InfoType {Exp,Level,Kill,Time,Health } //enum 타입은 세미콜론 찍지 않음
    public InfoType type;

    Text myText;
    Slider mySlider;

    private void Awake()
    {
        myText = GetComponent<Text>();
        mySlider = GetComponent<Slider>();
    }

    private void LateUpdate()
    {
        switch (type)
        {
            case InfoType.Exp:
                float curExp = GameManager.instance.exp;
                float maxExp = GameManager.instance.nextExp[Mathf.Min(GameManager.instance.level, GameManager.instance.nextExp.Length - 1)];
                mySlider.value = curExp/maxExp;
                break;
            case InfoType.Level:
                myText.text = string.Format("Lv.{0:F0}",GameManager.instance.level);
                break; 
            case InfoType.Kill:
                myText.text = string.Format("{0:F0}", GameManager.instance.kill); //F0,1,2,3.. : 소숫점 나타내는 방식
                break;
            case InfoType.Time:
                float remainTime = GameManager.instance.maxGameTime - GameManager.instance.gameTime;
                int min = Mathf.FloorToInt(remainTime / 60);
                int sec = Mathf.FloorToInt(remainTime % 60);
                myText.text = string.Format("{0:D2}:{1:D2}",min,sec); //D0,1,2,3.. : 자리 수 지정
                break;
            case InfoType.Health:
                float curHealth = GameManager.instance.health;
                float maxHealth = GameManager.instance.maxHealth;
                mySlider.value = curHealth / maxHealth;
                break;           
        }
    }
}
