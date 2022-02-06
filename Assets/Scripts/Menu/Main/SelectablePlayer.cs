using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectablePlayer : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public Text Description;
    public Image ArrowSelected;
    public void OnSelect(BaseEventData eventData)
    {
        transform.GetChild(0).GetComponent<Animator>().SetBool("selected", true);

        ArrowSelected.transform.position = new Vector2(transform.position.x, ArrowSelected.transform.position.y);
        Description.transform.position = new Vector2(transform.position.x, Description.transform.position.y);

        switch (gameObject.name)
        {
            case "P1":
                Description.text = "+50 EXTRA LIFE";
                PlayerPrefs.SetString("CurrentPlayer", "P1");
                PlayerPrefs.Save();
                break;
            case "P2":
                Description.text = "GAIN DOUBLE POINTS";
                PlayerPrefs.SetString("CurrentPlayer", "P2");
                PlayerPrefs.Save();
                break;
            case "P3":
                Description.text = "RUN 50% FASTER";
                PlayerPrefs.SetString("CurrentPlayer", "P3");
                PlayerPrefs.Save();
                break;
            case "P4":
                Description.text = "DONKEY BOOST +DURATION";
                PlayerPrefs.SetString("CurrentPlayer", "P4");
                PlayerPrefs.Save();
                break;
            case "P5":
                Description.text = "50% -DAMAGE FROM AUNTS";
                PlayerPrefs.SetString("CurrentPlayer", "P5");
                PlayerPrefs.Save();
                break;
        }
    }

    public void OnDeselect(BaseEventData data)
    {
        transform.GetChild(0).GetComponent<Animator>().SetBool("selected", false);
    }
}
