using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivesManager : MonoBehaviour
{
    public GameObject initialText;
    public GameObject firstRoomText;
    public GameObject secondRoomText;
    public GameObject thirdRoomText;
    public GameObject fourthRoomText;
    public GameObject treasureRoomText;

    public ObjectiveTrigger firstObjTrigger;
    public ObjectiveTrigger secondObjTrigger;
    public ObjectiveTrigger thirdObjTrigger;

    // Start is called before the first frame update
    void Start()
    {
        initialText.SetActive(true);
        firstRoomText.SetActive(false);
        secondRoomText.SetActive(false);
        thirdRoomText.SetActive(false);
        fourthRoomText.SetActive(false);
        treasureRoomText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
