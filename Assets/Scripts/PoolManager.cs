using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour 
{
	public int pooledAmount = 20; //Nombre max de balles stockables dans la piscine
	List<GameObject> bulletsList; //Liste contenant les balles
	public WeaponScript weaponScr;
	[HideInInspector]
	public bool canFire;

	void Start () 
	{
		canFire = false;
		bulletsList = new List<GameObject> ();
		for (int i = 0; i < pooledAmount; i++) //Remplissage de la piscine
		{
			GameObject obj = (GameObject)Instantiate (weaponScr.blastPrefab); //Instantiation de Gameobjects balles  
			obj.SetActive (false); //Les objets sont placés dans la liste mais non actifs (en attente)
			bulletsList.Add(obj); //Ajout des objets instantiés dans la liste
		}
	}

	void Update () 
	{
		Transform blastTransform = gameObject.transform;

		for(int i = 0; i < bulletsList.Count; i++) 
		{
			if (!bulletsList [i].activeInHierarchy) { // si une balle n'est pas actuellement active dans la scene
				canFire = true; // Set le booléen pour autoriser le tir
				weaponScr.Attack (true);
				bulletsList [i].transform.position = blastTransform.position; // On set sa position sur celle du vaisseau
				bulletsList [i].transform.rotation = blastTransform.rotation; // On set sa rotation sur celle du vaisseau
				bulletsList [i].SetActive (true); // On active la balle
				break;
			}
			else 
			{
				canFire = false; // Set le booléen pour interdire le tir
				weaponScr.Attack (false);
			}
		}
	}
}
