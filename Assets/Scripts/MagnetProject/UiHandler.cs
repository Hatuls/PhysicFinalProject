
using UnityEngine;
using UnityEngine.UI;

public class UiHandler : MonoSingleton<UiHandler>
{
    [SerializeField] Button replaybtn;
    [SerializeField] Text scoreTxt;
    [SerializeField] Text loseTxt;
    
    private void Start()
    {
        LoseSection(false);
    }


    public void LoseSection(bool toOpen) {
        loseTxt.gameObject.SetActive(toOpen);
        if (toOpen == true)
            loseTxt.text ="You LOSE \n"+ GameManager._Instance.GetScore;
        replaybtn.gameObject.SetActive(toOpen);
    }

    public void ResetUI() {
        LoseSection(false);
    }

    public void Score(int score) => scoreTxt.text = "Score : " + score; 

}
