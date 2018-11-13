using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemButton : MonoBehaviour, IDragHandler, IEndDragHandler {

    public GameObject reset;

    public Button wood;
    public Button stone;
    public Button rope;
    public Button fabric;

    public Button btnBow;
    public Button btnWoodPlank;
    public Button btnWeight;
    public Button btnFirewood;
    public Button btnBigStone;

    public GameObject m_wood;
    public GameObject m_stone;
    public GameObject m_rope;
    public GameObject m_fabric;
    public GameObject s_wood;
    public GameObject s_stone;
    public GameObject s_rope;
    public GameObject s_fabric;

    public GameObject bow;
    public GameObject obj_bow;
    public GameObject woodPlank;
    public GameObject obj_woodPlank;
    public GameObject weight;
    public GameObject obj_weight;
    public GameObject firewood;
    public GameObject obj_firewood;
    public GameObject bigStone;
    public GameObject obj_bigStone;

    public int howManySlot = 0;

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
    }

	// Use this for initialization
	void Start () {
        Button woodBtn = wood.GetComponent<Button>();
        Button stoneBtn = stone.GetComponent<Button>();
        Button ropeBtn = rope.GetComponent<Button>();
        Button fabricBtn = fabric.GetComponent<Button>();

        Button bowBtn = btnBow.GetComponent<Button>();
        Button woodPlankBtn = btnWoodPlank.GetComponent<Button>();
        Button weightBtn = btnWeight.GetComponent<Button>();
        Button firewoodBtn = btnFirewood.GetComponent<Button>();
        Button bigStoneBtn = btnBigStone.GetComponent<Button>();

        Button resetBtn = reset.GetComponent<Button>();

        woodBtn.onClick.AddListener(WoodOnClick);
        stoneBtn.onClick.AddListener(StoneOnClick);
        ropeBtn.onClick.AddListener(RopeOnClick);
        fabricBtn.onClick.AddListener(FabricOnClick);

        bowBtn.onClick.AddListener(BowOnClick);
        woodPlankBtn.onClick.AddListener(WoodPlankOnClick);
        weightBtn.onClick.AddListener(WeightOnClick);
        firewoodBtn.onClick.AddListener(FirewoodOnClick);
        bigStoneBtn.onClick.AddListener(BigStoneOnClick);

        resetBtn.onClick.AddListener(ResetOnClick);
    }
	
	// Update is called once per frame
	void Update () {
        if (m_wood.activeSelf && s_rope.activeSelf)
        {
            firewood.SetActive(false);
            bow.SetActive(true);
        }            

        if (m_wood.activeSelf && s_wood.activeSelf)
        {
            firewood.SetActive(false);
            woodPlank.SetActive(true);
        }            

        if (m_stone.activeSelf && howManySlot == 1)
            weight.SetActive(true);

        if (m_wood.activeSelf && howManySlot == 1)
            firewood.SetActive(true);

        if (m_stone.activeSelf && s_stone.activeSelf)
        {
            weight.SetActive(false);
            bigStone.SetActive(true);
        }
            
	}

    void WoodOnClick()
    {
        if (howManySlot == 0)
        {
            m_wood.SetActive(true);
            howManySlot = 1;
        }            
        else if (howManySlot == 1)
        {
            s_wood.SetActive(true);
            howManySlot = 2;
        }
        else
        {
            Debug.Log("Slot is Full!");
        }
            
    }

    void StoneOnClick()
    {
        if (howManySlot == 0)
        {
            m_stone.SetActive(true);
            howManySlot = 1;
        }
        else if (howManySlot == 1)
        {
            s_stone.SetActive(true);
            howManySlot = 2;
        }
        else
        {
            Debug.Log("Slot is Full!");
        }
    }

    void RopeOnClick()
    {
        if (howManySlot == 0)
        {
            m_rope.SetActive(true);
            howManySlot = 1;
        }
        else if (howManySlot == 1)
        {
            s_rope.SetActive(true);
            howManySlot = 2;
        }
        else
        {
            Debug.Log("Slot is Full!");
        }
    }

    void FabricOnClick()
    {
        if (howManySlot == 0)
        {
            m_rope.SetActive(true);
            howManySlot = 1;
        }
        else if (howManySlot == 1)
        {
            s_rope.SetActive(true);
            howManySlot = 2;
        }
        else
        {
            Debug.Log("Slot is Full!");
        }
    }

    void BowOnClick()
    {
        Instantiate(obj_bow);
    }

    void WoodPlankOnClick()
    {
        Instantiate(obj_woodPlank);
    }

    void WeightOnClick()
    {

    }

    void FirewoodOnClick()
    {

    }

    void BigStoneOnClick()
    {

    }

    void ResetOnClick()
    {
        m_wood.SetActive(false);
        m_stone.SetActive(false);
        m_rope.SetActive(false);
        m_fabric.SetActive(false);

        s_wood.SetActive(false);
        s_stone.SetActive(false);
        s_rope.SetActive(false);
        s_fabric.SetActive(false);

        bow.SetActive(false);
        woodPlank.SetActive(false);
        weight.SetActive(false);
        firewood.SetActive(false);
        bigStone.SetActive(false);

        howManySlot = 0;
    }

}
