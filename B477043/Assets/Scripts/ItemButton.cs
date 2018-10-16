using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour {

    public int whatItem;
    public Button woodButton, stoneButton, ropeButton, fabricButton, bowButton;
    public GameObject bowStick, bowString, bow;
    private bool isBowStick, isBowString = false;

    public GameObject bowObj;
	// Use this for initialization
	void Start () {
        Button wood = woodButton.GetComponent<Button>();
        Button stone = stoneButton.GetComponent<Button>();
        Button rope = ropeButton.GetComponent<Button>();
        Button fabric = fabricButton.GetComponent<Button>();
        Button bow = bowButton.GetComponent<Button>();

        wood.onClick.AddListener(WoodClicked);
        rope.onClick.AddListener(RopeClicked);
        bow.onClick.AddListener(BowClicked);
    }
	
	// Update is called once per frame
	void Update () {
        if (isBowStick && isBowString)
            bow.SetActive(true);
	}

    void WoodClicked()
    {
        bowStick.SetActive(true);
        isBowStick = true;
    }

    void RopeClicked()
    {
        bowString.SetActive(true);
        isBowString = true;
    }

    void BowClicked()
    {
        Instantiate(bowObj);
    }
}
