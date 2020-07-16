using UnityEngine;
using UnityEngine.UI;

public class Egg : MonoBehaviour
{
    public Event dropped;
    public Image icon;

    void Start()
    {

        dropped.Occurred(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
