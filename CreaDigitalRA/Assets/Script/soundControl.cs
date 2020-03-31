using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioSource))]
public class soundControl : MonoBehaviour
{
    public AudioSource pistaPrincipal;
    public AudioSource pistaGamer;
    
    


    void Start()
    {


        StartCoroutine(principal());
        StartCoroutine(gamer());
        
    }

    void Update()
    {
        pistaPrincipal.volume = 1;
    

        if (GM.match)
        {
            pistaGamer.volume = 1;
        }
        else
        {

            pistaGamer.volume = 0f;
        }
        if (GM.winStreak > 40) {

            pistaPrincipal.volume = 0;
            pistaGamer.volume = 0;

        }
        if (ControlGame.pauseState)
        {
            pistaPrincipal.volume = 0;
            pistaGamer.volume = 0;

        }
       
    }

    IEnumerator principal() {
        yield return new WaitForSeconds(4f);
        pistaPrincipal.Play();
        if (ControlGame.pauseState)
        {
            pistaPrincipal.Pause();
            pistaGamer.Pause();

        }

    }
    IEnumerator gamer()
    {
        yield return new WaitForSeconds(4f);
        pistaGamer.PlayDelayed(1);

    }
}