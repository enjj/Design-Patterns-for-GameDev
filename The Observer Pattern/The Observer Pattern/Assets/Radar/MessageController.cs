using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageController : MonoBehaviour
{
    Text message;
    // Start is called before the first frame update
    void Start()
    {
        message = this.GetComponent<Text>();
        message.enabled = false;
    }

    public void SetMessage(GameObject go)
    {
        message.text = "You picked up an item!!";
        message.enabled = true;
        Invoke("TurnOff", 2);
    }

    void TurnOff()
    {
        message.enabled = false;
    }
}
