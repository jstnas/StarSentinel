using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public List<Item> inventory = new List<Item>();
    private ItemDatabase database; 


	// Use this for initialization
	void Start () {
        database = GameObject.FindGameObjectsWithTag("Item Database").GetComponent<ItemDatabase>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
