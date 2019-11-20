using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatAct : MonoBehaviour
{
    Animator an;
    int act, actperiod;
    UnityEngine.AI.NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        an = gameObject.GetComponent<Animator>();
        agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
        act = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (act == -1)
        {
            act = Random.Range(1, 5);
            //actperiod = Random.Range(150, 300);
            actperiod = Random.Range(50, 100);
            Debug.Log(act + "/" + actperiod);
            //act = 4;
            switch (act)
            {
                case 1: //idle                    
                    gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>().target = null;
                    break;
                case 2: //walk                    
                    GameObject.Find("Cube").transform.position = new Vector3(Random.Range(10, 30), 6, Random.Range(40, 60));
                    gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>().SetTarget(GameObject.Find("Cube").transform);
                    agent.speed = 2;
                    if (an != null) an.SetBool("Walk", true);
                    break;
                case 3: //run                    
                    GameObject.Find("Cube").transform.position = new Vector3(Random.Range(10, 30), 6, Random.Range(40, 60));
                    gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>().SetTarget(GameObject.Find("Cube").transform);
                    agent.speed = 8;
                    if (an != null) an.SetBool("Run", true);
                    break;
                case 4:
                    if (an != null) an.SetTrigger("Attack");
                    break;
                default:
                    break;
            }
        }
        if (actperiod > 0)
        {
            actperiod--;
            if (act == 2 || act == 3)
            {
                if (agent.remainingDistance < agent.stoppingDistance && agent.remainingDistance != 0)
                {
                    //已抵達目的地，要把目前動畫關掉
                    if (an != null) an.SetBool("Walk", false);
                    if (an != null) an.SetBool("Run", false);
                }
            }
        }
        else
        {
            act = -1;
            //切換其他行為，要把目前動畫關掉
            if (an != null) an.SetBool("Walk", false);
            if (an != null) an.SetBool("Run", false);
            gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>().SetTarget(null);
        }
    }
}
