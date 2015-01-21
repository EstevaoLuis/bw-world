using UnityEngine;
using System.Collections;

public class GemsColor : MonoBehaviour {

	public Colour[] col, col2;

	// Use this for initialization
	private GameObject [] gems;
	public GameObject boss;
	private EnemyController enemy;
	public GameObject Icespell;
	private Gem [] g;
	private int numb_of_gems = 4;

	private bool isActivated = false;

	void Start () {
		/*
		gems = new GameObject[numb_of_gems];

		g = new Gem[numb_of_gems];
		col = new Colour[numb_of_gems];


		gems[0] = GameObject.Find("gem_to_color_1");
		gems[1] = GameObject.Find("gem_to_color_2");
		gems[2] = GameObject.Find("gem_to_color_3");
		gems[3] = GameObject.Find("gem_to_color_4");

		g[0] = gems[0].GetComponent<Gem>();
		g[1] = gems[1].GetComponent<Gem>();
		g[2] = gems[2].GetComponent<Gem>();
		g[3] = gems[3].GetComponent<Gem>();

		col[0] = gems[0].GetComponent<Colour>();
		col[1] = gems[1].GetComponent<Colour>();
		col[2] = gems[2].GetComponent<Colour>();
		col[3] = gems[3].GetComponent<Colour>();
		*/
	}





	bool triggered(){
		int i;
		for (i = 0; i < numb_of_gems; i++) {
			if(col[i].isColored()== false){
				return false;
			}
		}
		print ("triggered!!!!");
		return true;
	}

	// Update is called once per frame
	void Update () {
		bool tr = triggered ();
		
		if ( tr == true && !isActivated) {
			isActivated = true;
			Invoke ("decolorGems",2f);

		}

	}

	private void decolorGems() {

		Instantiate(Icespell,boss.transform.position,transform.rotation);
		enemy = boss.GetComponent<EnemyController>();
		int damage = 500 + Random.Range(-5,5);
		enemy.damageEnemy(damage);
		GameInstance.instance.playAnimation("Hit",boss.transform.position);
		GameInstance.instance.damageValueAnimation(damage,boss.transform.position);

		col[0].decolor();
		col[1].decolor();
		col[2].decolor();
		col[3].decolor();

		col2[0].decolor();
		col2[1].decolor();
		col2[2].decolor();
		col2[3].decolor();

		isActivated = false;
	}

}
