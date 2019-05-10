using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectPlayer : MonoBehaviour
{

    private UnityEngine.UI.Button[] Players;

    private void Awake()
    {
        Players = GetComponentsInChildren<UnityEngine.UI.Button>();
        gameObject.SetActive(false);
    }

    public void SetUp(List<DisablePlayer> personaggi)
    {
        for(int i = 0; i<personaggi.Count; i++)
        {
            Players[i].gameObject.GetComponent<Image>().sprite = personaggi[i].GetComponent<SpriteRenderer>().sprite;
        }
    }

    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(Players[ControllerManager.instance.playerEnable].gameObject);
    }

    private void OnDisable()
    {
        GameObject temp = EventSystem.current.currentSelectedGameObject;
        if(temp != null)
        {
            for(int i = 0; i < Players.Length; i++)
            {
                if (temp == Players[i].gameObject)
                {
                    ControllerManager.instance.ChangePlayer(i);
                }
            }
        }
    }


}
