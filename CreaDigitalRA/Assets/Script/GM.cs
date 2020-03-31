using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GM : MonoBehaviour {



    List<float> whichWait1 = new List<float>() { 0,1,0,1,0, 1,0, 1, 0, 1, 0, 1,0,0,0,1, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 1, 1, 1, 1, 0, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1 };
    List<float> whichWait2 = new List<float>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,1,0,1,0,1,0,1,0,1,1,1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1,0,0,0,0 };
    List<float> whichWait3 = new List<float>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,1,1,1,0,0,0, 1, 0, 1, 0, 1, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1 };
    List<float> whichWait4 = new List<float>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,1, 1, 1, 1, 1, 0, 0, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1 };
    List<float> whichWait5 = new List<float>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,0,1,1,1, 1, 0, 1, 1, 1,0,0,0,0,1,1,1 };
    List<float> whichWait6 = new List<float>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  1,1,1,1,0,0,1,1,0};

    //lleva la cuenta de los aciertos y de la comida que recupera
    public Text score;
    public Text bonus;


    public bool gameRunning = true;

    public int noteMark = 0;
    

    public Transform noteObj;

    public string timerReset = "y";

    public float xPos;

    public static int winStreak=0;
    public static int winBonus = 0;
    public static bool match = false;

    public Transform fountainFW;

    public string fountainSpawnL = "n";
    public string fountainSpawnR = "n";

    // Use this for initialization
    void Start () {

        score = GameObject.Find("Score").GetComponentInChildren<Text>();
        score.text = ""+ winStreak;
        bonus = GameObject.Find("Coins").GetComponentInChildren<Text>();
        bonus.text = "" + winBonus;

    }
	
	// Update is called once per frame
	void Update () {
        if (timerReset == "y" )
        {
            // StartCoroutine(spawnNote());
           // for (int i = 1; i <= 5; i++) { 
            StartCoroutine(spawnNote());
           
            //}
            timerReset = "n";
        }

        
        
        if ((winStreak == 5) && (fountainSpawnL == "n")) {
            fountainSpawnL = "y";
            Instantiate(fountainFW, new Vector3(-3.73f, -0.61f, -3.35f), fountainFW.rotation);
        }
        if ((winStreak == 10) && (fountainSpawnR == "n"))
        {
            fountainSpawnR = "y";
            Instantiate(fountainFW, new Vector3(5f, -0.61f, -3.35f), fountainFW.rotation);
        }

        score.text = "" + winStreak;
        bonus.text = "" + winBonus;



    }


    

    //IEnumerator spawnNote() {

    //    yield return new WaitForSeconds(1);
    //    if (whichNote[noteMark] == 1)
    //    {
    //        xPos = -1.34f;
    //    }

    //    if(whichNote[noteMark] == 2)
    //    {
    //        xPos = -.7f;
    //    }
    //    if (whichNote[noteMark] == 3)
    //    {
    //        xPos = -.1f;
    //    }
    //    if (whichNote[noteMark] == 4)
    //    {
    //        xPos = .4f;
    //    }
    //    if (whichNote[noteMark] == 5)
    //    {
    //        xPos = .95f;
    //    }
    //    if (whichNote[noteMark] == 6)
    //    {
    //        xPos = 1.45f;
    //    }

    //    noteMark += 1;
    //    timerReset = "y";
    //    Instantiate(noteObj, new Vector3(xPos, 1.2f, -2.18f), noteObj.rotation);
    //}

    IEnumerator spawnNote()
    {

     
            yield return new WaitForSeconds(1);
            noteMark += 1;

        if (whichWait1[noteMark] == 1)
            {
            xPos = -1.5f;
            Instantiate(noteObj, new Vector3(xPos, 1.2f, -2.18f), noteObj.rotation);
        }
        if (whichWait2[noteMark] == 1)
        {
            xPos = -.86f;
            Instantiate(noteObj, new Vector3(xPos, 1.2f, -2.18f), noteObj.rotation);
        }
        if (whichWait3[noteMark] == 1)
        {
            xPos = -.26f;
            Instantiate(noteObj, new Vector3(xPos, 1.2f, -2.18f), noteObj.rotation);
        }
        if (whichWait4[noteMark] == 1)
        {
            xPos = .35f;
            Instantiate(noteObj, new Vector3(xPos, 1.2f, -2.18f), noteObj.rotation);
        }
        if (whichWait5[noteMark] == 1)
        {
            xPos = .95f;
            Instantiate(noteObj, new Vector3(xPos, 1.2f, -2.18f), noteObj.rotation);
        }

        if (whichWait6[noteMark] == 1)
        {
            xPos = 1.54f;
            Instantiate(noteObj, new Vector3(xPos, 1.2f, -2.18f), noteObj.rotation);
        }
        timerReset = "y";
          
        

    }

    //IEnumerator spawnNoteTime_2()
    //{

           
    //    yield return new WaitForSeconds(whichWait2[timeMark2]);
    //    timeMark2 += 1;
    //    timerReset = "y";
    //    xPos = -.86f;
    //    Instantiate(noteObj, new Vector3(xPos, 1.2f, -2.18f), noteObj.rotation);


    //}

    //IEnumerator spawnNoteTime_3()
    //{


    //    yield return new WaitForSeconds(whichWait3[timeMark3]);
    //    timeMark3 += 1;
    //    timerReset = "y";
    //    xPos = -.26f;
    //    Instantiate(noteObj, new Vector3(xPos, 1.2f, -2.18f), noteObj.rotation);


    //}

    //IEnumerator spawnNoteTime_4()
    //{


    //    yield return new WaitForSeconds(whichWait4[timeMark4]);
    //    timeMark4 += 1;
    //    timerReset = "y";
    //    xPos = .35f;
    //    Instantiate(noteObj, new Vector3(xPos, 1.2f, -2.18f), noteObj.rotation);


    //}
    //IEnumerator spawnNoteTime_5()
    //{


    //    yield return new WaitForSeconds(whichWait5[timeMark5]);
    //    timeMark5 += 1;
    //    timerReset = "y";
    //    xPos = .95f;
    //    Instantiate(noteObj, new Vector3(xPos, 1.2f, -2.18f), noteObj.rotation);


    //}

    //IEnumerator spawnNoteTime_6()
    //{


    //    yield return new WaitForSeconds(whichWait6[timeMark6]);
    //    timeMark6 += 1;
    //    timerReset = "y";
    //    xPos = 1.54f;
    //    Instantiate(noteObj, new Vector3(xPos, 1.2f, -2.18f), noteObj.rotation);


    //}

   

}
