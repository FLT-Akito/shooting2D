using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum POWERUPTYPE
{
    SPEED,
    MISSILE,
    DOUBLE,
    LASER,
    OPTION,
    OH,
    F_FILED
}

public class GameManager : MonoBehaviour
{
    public GameData gameData;
    public GameObject gameOverText;
    public GameObject returyText;
    public GameObject retryButton;
    public GameObject lifeUIpref;
    public Text playerLife;
    public Text ScoreText;
    public Text MissileText;
    public Text SpeedText;
    public Text LaserText;
    public Text DoubleText;
    public Text F_FieldText;
    public Text OptionText;
    public Text OhText;
    public POWERUPTYPE[] poweruplist;
    public int score = 0;
    int itemCount = 0;
    int lifeUpScore = 25000;
   public int lifeCount = 1;  
   public int maxLifeup = 6;
    Dictionary<POWERUPTYPE, Text> weaponText;
    GameObject[] items;
    GameObject[] itemsData;
   public GameObject lifeUILayout;
    GameObject obj;
   [SerializeField] Stack<GameObject> lifeUIList = new Stack<GameObject>();
    private bool deadFlag;
    public bool DeadFlag { get => deadFlag; }
    //private bool isWeaponTextErace;
    //public bool IsEraceText => isWeaponTextErace;

    //LayoutGroup使い方調べる
   
    void Start()
    {
        weaponText = new Dictionary<POWERUPTYPE, Text>()
        {
            [POWERUPTYPE.MISSILE] = MissileText,
            [POWERUPTYPE.SPEED] = SpeedText,
            [POWERUPTYPE.DOUBLE] = DoubleText,
            [POWERUPTYPE.F_FILED] = F_FieldText,
            [POWERUPTYPE.OPTION] = OptionText,
            [POWERUPTYPE.LASER] = LaserText
        };

        items = GameObject.FindGameObjectsWithTag("Item");
        itemsData = new GameObject[items.Length];
        gameOverText.SetActive(false);
        //PlayerPrefs.DeleteAll();
        //GameObject lifeuiobj = ;
        //StartLifeUI(2);
        lifeCount = 2;
        ShowLife(lifeCount);
        
    }

    //private void StartLifeUI(int value)
    //{
    //    for(int i = 0; i < value; i++)
    //    {
    //        lifeUIList.Push(Instantiate(lifeUIpref));
           
    //    }

    //    foreach(GameObject obj in lifeUIList)
    //    {          
            
    //        obj.transform.SetParent(lifeUILayout.transform);
    //    }
    //}
    
    private void Update()
    {
        //デバッグ：基底スコア時残存機増加（最大7機）
        if(Input.GetKeyDown(KeyCode.F3))
        {
            //AddScore(lifeUpScore);
            lifeCount++;          
            ShowLife(lifeCount);
            //if (score >= lifeUpScore && lifeUIList.Count < maxLifeup)
            //{
            //    GameObject uiobj = Instantiate(lifeUIpref);
            //    lifeUIList.Push(uiobj);             
            //    uiobj.transform.SetParent(lifeUILayout.transform);
                
            //}
            //if(lifeCount > maxLifeup - 1)
            //{
            //    lifeCount = maxLifeup - 1;
               
            //}
        }

        //デバッグ：残存機減少
        if (Input.GetKeyDown(KeyCode.F4))
        {
            lifeCount--;

            //foreach (GameObject obj in lifeUIList)
            //{
            //    var popLifeUI = lifeUIList.Pop();
            //    Destroy(popLifeUI);
                
            //}
            if(lifeCount <= 0)
            {
                lifeCount = 0;
            }
            ShowLife(lifeCount);
        }

        if(Input.GetKeyDown(KeyCode.F5))
        {
            lifeCount = 4;
            ShowLife(lifeCount);
        }

        if (Input.GetKeyDown(KeyCode.F6))
        {
            ShowLife(5);
        }

    }

    private void ShowLife(int life)
    {
        int loopCount = lifeUIList.Count;

        for (int i = 0; i < loopCount; i++)
        {
            var popLifeUI = lifeUIList.Pop();
            Destroy(popLifeUI);
            //Debug.Log($"Destroy:{i}");
        }

        for (int i = 0; i < life; i++)
        {
            GameObject obj = Instantiate(lifeUIpref);
            lifeUIList.Push(obj);
            obj.transform.SetParent(lifeUILayout.transform);
        }     
    }

    public void GameOver()
    {
        if (lifeCount <= 0)
        {
            gameOverText.SetActive(true);
            System.Threading.Thread.Sleep(2000);
            SceneManager.LoadScene("TitleScene");
        }
    }

    public void Retry()
    {
        returyText.SetActive(true);
        lifeCount--;

        if (lifeCount <= 0)
        {
            lifeCount = 0;
        }

        ShowLife(lifeCount);
    }

    public void OnPressRetryButton()
    {
       
        SceneManager.LoadScene("Stage1");       
    }

    public void AddScore(int _score)
    {
        score += _score;
        ScoreText.text = "SCORE:" + this.score;

        if (score >= lifeUpScore)
        {
            AddLifeUI();
        }
    }

    private void AddLifeUI()
    {      
        lifeUpScore += lifeUpScore;
        //Debug.Log($"lifeCount:{lifeCount},lifeUIList:{lifeUIList.Count}");
        if (lifeCount < maxLifeup)
        {          
                lifeCount++;
                ShowLife(lifeCount);
        }
        else
        {
            lifeCount = maxLifeup;
        }
        //lifeUpScore += lifeUpScore;
        //lifeUpIndex++;

        //if (lifeUpIndex < maxLifeup)
        //{
        //    //lifeUI[lifeUpIndex].SetActive(true);

        //}
        //else
        //{
        //    lifeUpIndex = maxLifeup - 1;
        //}

        //if (count < maxLifeup)
        //{
        //    GameObject uiobj = Instantiate(lifeUIpref);
        //    lifeUIList.Push(uiobj);
        //    uiobj.SetActive(true);
        //    uiobj.transform.SetParent(lifeUILayout.transform);
        //}
        //if (count > maxLifeup)
        //{
        //    count = maxLifeup;
        //    Debug.Log(count);
        //}

    }

    public void WeaponTextErace(POWERUPTYPE powerupType)
    {

        if (weaponText[powerupType].text != null)
        {
            weaponText[powerupType].text = "";
        }

    }

    public void ResetText()
    {
        MissileText.text = "MISSILE";
        SpeedText.text = "SPEED";
        DoubleText.text = "DOUBLE";
        LaserText.text = "LASER";
        F_FieldText.text = "F.FILED";
        OhText.text = "OH";
        OptionText.text = "OPTION";
    }

    public void SetItems()
    {
        itemCount++;
        if (itemCount > itemsData.Length)
        {
            itemCount = 1;
        }

        SetUpItem(itemCount);
    }

    public void SetUpItem(int itemIndex)
    {

        for (int i = 1; i < itemsData.Length + 1; i++)
        {

            var sr = items[i - 1].GetComponent<Image>();
            if (i == itemIndex)
            {
                sr.color = Color.green;
            }
            else
            {
                sr.color = Color.white;
            }
        }

    }

    public bool WeaponItemCount(out POWERUPTYPE poweruptype)
    {
        poweruptype = POWERUPTYPE.SPEED;
        if (itemCount > 0)
        {
            // Debug.Log(poweruplist[itemCount - 1]);
            poweruptype = poweruplist[itemCount - 1];
            itemCount = 0;
            SetUpItem(itemCount);
            return true;
        }
        return false;

    }

    //private void LoadGameData()
    //{
    //    //score = gameData.score;
    //    //lifeUpIndex = gameData.lifeUpIndex;
    //    PlayerPrefs.GetInt("Score");
    //    PlayerPrefs.GetInt("lifeUpindex");
    //}

    //private void SaveGamdeData()
    //{
    //    //gameData.score = score;
    //    //gameData.lifeUpIndex = lifeUpIndex;
    //    PlayerPrefs.SetInt("Score", score);
    //    PlayerPrefs.SetInt("lifeUpindex", lifeUpIndex);
    //    PlayerPrefs.Save();
    //}


}
