using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUi : MonoBehaviour
{
    private bool active = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clickcharacter()  // OnClick~~~로 바꾸기
    {
        active = !active;
        this.gameObject.SetActive(active);
    }
}
