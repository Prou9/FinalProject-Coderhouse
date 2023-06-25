using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Mission : MonoBehaviour
{
    public TextMeshProUGUI missionText;
    private int isCompleted;
    public Animator anim;
    private void Awake()
    {        
        anim = GetComponent<Animator>();
    }
    public int IsCompleted => isCompleted;

    public void CompleteMission()
    {       
        isCompleted++;
       anim.SetBool("completed", true);
       Invoke(nameof(ChangeMission), 1);        
    }
    private void ChangeMission()
    {
        switch (isCompleted)
        {
            case 1:
                missionText.text = "Open the attic door";
                break;
            case 2:
                missionText.text = "Find the cursed artifacts";
                break;
            case 3:                
                missionText.gameObject.SetActive(false);
                break;
        }
       anim.SetBool("completed", false);
    }

}
