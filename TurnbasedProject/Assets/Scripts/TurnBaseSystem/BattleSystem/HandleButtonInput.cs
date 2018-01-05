using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleButtonInput : MonoBehaviour {

	public GameObject attackButton;
	public GameObject magicButton;
	public GameObject runButton;
	public GameObject specialButton;
	public GameObject backButton;
	public GameObject heavyAttackButton;
	public GameObject attackSubButton;
	public GameObject specialAttackButton;
	public GameObject heavyMagicButton;
	public GameObject magicSubButton;
	public GameObject specialMagicButton;
	public GameObject magicSpecialButton;
	public GameObject physicalSpecialButton;
	public GameObject specialSubButton;
	public GameObject player;
	public GameObject attackSubMenuButtons;
	public GameObject magicSubMenuButtons;
	public GameObject runSubMenuButtons;
	public GameObject specialSubMenuButtons;
	public GameObject attackTextMenuButtons;
	public GameObject magicTextMenuButtons;
	public GameObject specialTextMenuButtons;

	private Vector2 attackStartPosition;
	private Vector2 magicStartPosition;
	private Vector2 runStartPosition;
	private Vector2 specialStartPosition;
	private Vector2 heavyAttackStartPosition;
	private Vector2 heavyMagicStartPosition;
	private Vector2 specialAttackStartPosition;
	private Vector2 attackSubStartPosition;
	private Vector2 magicSubStartPosition;
	private Vector2 backSubStartPosition;
	private Vector2 physicalSpecialStartPosition;
	private Vector2 magicSpecialStartPosition;
	private Vector2 specialMagicStartPosition;
	private Vector2 specialSubStartPosition;
	private Vector2 activePosition;
	private Vector2 activeSubPosition;
	private Vector2 backTextPosition;
	public bool inAttack = false;
	public bool inMagic = false;
	public bool inRun = false;
	public bool inSpecial = false;
	public bool inSubAttackMenu = false;
	public bool inSubHeavyAttackMenu = false;
	public bool inSubSpecialAttackMenu = false;
	public bool inSubMagicMenu = false;
	public bool inSubHeavyMagicMenu = false;
	public bool inSubSpecialMagicMenu = false;
	public bool inSubRunMenu = false;
	public bool inSubSpecialMenu = false;
	public bool inSubMagicSpecialMenu = false;
	public bool inSubPhysicalSpecialMenu = false;
	public bool inTextMenu = false;
	private List<GameObject> buttonObjects = new List<GameObject> ();

	// Use this for initialization
	void Start () {
		attackStartPosition = attackButton.transform.position;
		magicStartPosition = magicButton.transform.position;
		runStartPosition = runButton.transform.position;
		specialStartPosition = specialButton.transform.position;
		heavyAttackStartPosition = heavyAttackButton.transform.position;
		heavyMagicStartPosition = heavyMagicButton.transform.position;
		specialAttackStartPosition = specialAttackButton.transform.position;
		attackSubStartPosition = attackSubButton.transform.position;
		magicSubStartPosition = magicSubButton.transform.position;
		backSubStartPosition = backButton.transform.position;
		physicalSpecialStartPosition = physicalSpecialButton.transform.position;
		specialMagicStartPosition = specialMagicButton.transform.position;
		magicSpecialStartPosition = magicSpecialButton.transform.position;
		specialSubStartPosition = specialSubButton.transform.position;
		activePosition = new Vector2(player.transform.position.x, player.transform.position.y);
		activeSubPosition = new Vector2(player.transform.position.x + 1.3f, player.transform.position.y);
		backTextPosition = new Vector2(player.transform.position.x + 2.6f, player.transform.position.y);
		buttonObjects.Add(attackButton);
		buttonObjects.Add(magicButton);
		buttonObjects.Add(runButton);
		buttonObjects.Add(specialButton);
	}
	
	// Update is called once per frame
	void Update () {
		checkInput ();
	}

	#region Checks button input for battle UI
	private void checkInput()
	{
		if (!inRun && !inAttack && !inMagic && !inSpecial) 
		{
			if (Input.GetButtonUp ("attack")) 
			{
				attackButton.transform.position = activePosition;
				inAttack = true;
				hideButtons ();
			} else if (Input.GetButtonUp ("magic")) 
			{
				magicButton.transform.position = activePosition;
				inMagic = true;
				hideButtons ();
			} else if (Input.GetButtonUp ("cancel")) 
			{
				runButton.transform.position = activePosition;
				inRun = true;
				hideButtons ();
			} else if (Input.GetButtonUp ("special")) 
			{
				specialButton.transform.position = activePosition;
				inSpecial = true;
				hideButtons ();
			}
		} 
		else if (inAttack && !inSubAttackMenu && !inSubHeavyAttackMenu && !inSubSpecialAttackMenu) 
		{
			if (Input.GetButtonUp ("attack")) 
			{
				attackSubButton.transform.position = activeSubPosition;
				inSubAttackMenu = true;
				//TODO Set buttons to contain the three normal attack options
				hideSubButtons ();
			} else if (Input.GetButtonUp ("magic")) 
			{
				heavyAttackButton.transform.position = activeSubPosition;
				inSubHeavyAttackMenu = true;
				//TODO Set buttons to contain the three heavy attack options
				hideSubButtons ();
			} else if (Input.GetButtonUp ("cancel")) 
			{
				backButton.GetComponent<SpriteRenderer> ().enabled = false;
				inAttack = false;
				unHideButtons ();
			} else if (Input.GetButtonUp ("special")) 
			{
				specialAttackButton.transform.position = activeSubPosition;
				inSubSpecialAttackMenu = true;
				//TODO Set buttons to contain the three special attack options
				hideSubButtons ();
			}
		}
		else if (inMagic && !inSubMagicMenu && !inSubHeavyMagicMenu && !inSubSpecialMagicMenu) 
		{
			if (Input.GetButtonUp ("attack")) 
			{
				magicSubButton.transform.position = activeSubPosition;
				inSubMagicMenu = true;
				//TODO Set buttons to contain the three normal magic options
				hideSubButtons ();
			} else if (Input.GetButtonUp ("magic")) 
			{
				heavyMagicButton.transform.position = activeSubPosition;
				inSubHeavyMagicMenu = true;
				//TODO Set buttons to contain the three heavy magic options
				hideSubButtons ();
			} else if (Input.GetButtonUp ("cancel")) 
			{
				backButton.GetComponent<SpriteRenderer> ().enabled = false;
				inMagic = false;
				unHideButtons ();
			} else if (Input.GetButtonUp ("special")) 
			{
				magicSpecialButton.transform.position = activeSubPosition;
				inSubSpecialMagicMenu = true;
				//TODO Set buttons to contain the three special magic options
				hideSubButtons ();
			}
		}
		else if (inSpecial && !inSubSpecialMenu && !inSubMagicSpecialMenu && !inSubPhysicalSpecialMenu) 
		{
			if (Input.GetButtonUp ("attack")) 
			{
				physicalSpecialButton.transform.position = activeSubPosition;
				inSubPhysicalSpecialMenu = true;
				//TODO Set buttons to contain the three normal magic options
				hideSubButtons ();
			} else if (Input.GetButtonUp ("magic")) 
			{
				magicSpecialButton.transform.position = activeSubPosition;
				inSubMagicSpecialMenu = true;
				//TODO Set buttons to contain the three heavy magic options
				hideSubButtons ();
			} else if (Input.GetButtonUp ("cancel")) 
			{
				backButton.GetComponent<SpriteRenderer> ().enabled = false;
				inSpecial = false;
				unHideButtons ();
			} else if (Input.GetButtonUp ("special")) 
			{
				specialSubButton.transform.position = activeSubPosition;
				inSubSpecialMenu = true;
				//TODO Set buttons to contain the three special magic options
				hideSubButtons ();
			}
		}
		else if(inTextMenu)
		{
			if(Input.GetButtonUp("attack"))
			{
				if (inSubAttackMenu) 
				{
					//run the attack > attack > attack function
				} 
				else if (inSubHeavyAttackMenu) 
				{
					//run the attack > magic > attack function
				} 
				else if (inSubSpecialAttackMenu) 
				{
					//run the attack > special > attack function
				}
				else if (inSubMagicMenu) 
				{
					//run the magic > attack > attack function
				} 
				else if (inSubHeavyMagicMenu) 
				{
					//run the magic > magic > attack function
				} 
				else if (inSubMagicSpecialMenu) 
				{
					//run the magic > special > attack function
				}
				else if (inSubSpecialMenu) 
				{
					//run the special > special > attack function
				} 
				else if (inSubPhysicalSpecialMenu) 
				{
					//run the special > attack > attack function
				} 
				else if (inSubSpecialMagicMenu) 
				{
					//run the special > magic > attack function
				}

			}
			else if(Input.GetButtonUp("magic"))
			{
				if (inSubAttackMenu) 
				{
					//run the attack > attack > magic function
				} 
				else if (inSubHeavyAttackMenu) 
				{
					//run the attack > magic > magic function
				} 
				else if (inSubSpecialAttackMenu) 
				{
					//run the attack > special > magic function
				}
				else if (inSubMagicMenu) 
				{
					//run the magic > attack > magic function
				} 
				else if (inSubHeavyMagicMenu) 
				{
					//run the magic > magic > magic function
				} 
				else if (inSubMagicSpecialMenu) 
				{
					//run the magic > special > magic function
				}
				else if (inSubSpecialMenu) 
				{
					//run the special > special > magic function
				} 
				else if (inSubPhysicalSpecialMenu) 
				{
					//run the special > attack > magic function
				} 
				else if (inSubSpecialMagicMenu) 
				{
					//run the special > magic > magic function
				}
			}
			else if(Input.GetButtonUp("special"))
			{
				if (inSubAttackMenu) 
				{
					//run the attack > attack > special function
				} 
				else if (inSubHeavyAttackMenu) 
				{
					//run the attack > magic > special function
				} 
				else if (inSubSpecialAttackMenu) 
				{
					//run the attack > special > special function
				}
				else if (inSubMagicMenu) 
				{
					//run the magic > attack > attack function
				} 
				else if (inSubHeavyMagicMenu) 
				{
					//run the magic > magic > special function
				} 
				else if (inSubMagicSpecialMenu) 
				{
					//run the magic > special > special function
				}
				else if (inSubSpecialMenu) 
				{
					//run the special > special > attack function
				} 
				else if (inSubPhysicalSpecialMenu) 
				{
					//run the special > attack > special function
				} 
				else if (inSubSpecialMagicMenu) 
				{
					//run the special > magic > special function
				}
			}
			else if(Input.GetButtonUp("cancel"))
			{
				unHideSubButtons();
				resetSubMenus ();
			}
		}
		else /* In the run menu */
		{
			if (Input.GetButtonUp ("attack")) {
				//Quits for now but eventually will perform the Run(); method
				Debug.Log ("Quitting");
				Application.Quit ();
			}
						else if(Input.GetButtonUp("cancel"))
			{
				unHideButtons();
				resetSubMenus ();
			}
		}
	}
	#endregion "Checks button input for battle UI"

	private void resetButtonPositions() 
	{
		attackButton.transform.position = attackStartPosition;
		magicButton.transform.position = magicStartPosition;
		runButton.transform.position = runStartPosition;
		specialButton.transform.position = specialStartPosition;
		inAttack = false;
		inMagic = false;
		inRun = false;
		inSpecial = false;
	}

	private void resetSubMenus() 
	{
		inSubAttackMenu = false;
		inSubHeavyAttackMenu = false;
		inSubSpecialAttackMenu = false;
		inSubMagicMenu = false;
		inSubHeavyMagicMenu = false;
		inSubSpecialMagicMenu = false;
		inSubSpecialMenu = false;
		inSubMagicSpecialMenu = false;
		inSubPhysicalSpecialMenu = false;
	}

	private void hideButtons()
	{
		if(inAttack) 
		{
			magicButton.GetComponent<SpriteRenderer> ().enabled = false;
			specialButton.GetComponent<SpriteRenderer> ().enabled = false;
			runButton.GetComponent<SpriteRenderer> ().enabled = false;
			attackSubMenuButtons.SetActive(true);
		}
		else if(inMagic) 
		{
			attackButton.GetComponent<SpriteRenderer> ().enabled = false;
			specialButton.GetComponent<SpriteRenderer> ().enabled = false;
			runButton.GetComponent<SpriteRenderer> ().enabled = false;
			magicSubMenuButtons.SetActive(true);
		}
		else if(inRun) 
		{
			attackButton.GetComponent<SpriteRenderer> ().enabled = false;
			magicButton.GetComponent<SpriteRenderer> ().enabled = false;
			specialButton.GetComponent<SpriteRenderer> ().enabled = false;
			runSubMenuButtons.SetActive(true);
		}
		else if(inSpecial) 
		{
			attackButton.GetComponent<SpriteRenderer> ().enabled = false;
			magicButton.GetComponent<SpriteRenderer> ().enabled = false;
			runButton.GetComponent<SpriteRenderer> ().enabled = false;
			specialSubMenuButtons.SetActive(true);
		}
		backButton.GetComponent<SpriteRenderer> ().enabled = true;
	}

	private void hideSubButtons()
	{
		if(inSubAttackMenu) 
		{
			heavyAttackButton.GetComponent<SpriteRenderer> ().enabled = false;
			specialAttackButton.GetComponent<SpriteRenderer> ().enabled = false;
			backButton.transform.position = backTextPosition;
			attackSubButton.transform.position = activeSubPosition;
			attackTextMenuButtons.SetActive(true);
		}
		else if(inSubHeavyAttackMenu) 
		{
			attackSubButton.GetComponent<SpriteRenderer> ().enabled = false;
			specialAttackButton.GetComponent<SpriteRenderer> ().enabled = false;
			backButton.transform.position = backTextPosition;
			heavyAttackButton.transform.position = activeSubPosition;
			magicTextMenuButtons.SetActive(true);
		}
		else if(inSubSpecialAttackMenu) 
		{
			attackSubButton.GetComponent<SpriteRenderer> ().enabled = false;
			heavyAttackButton.GetComponent<SpriteRenderer> ().enabled = false;
			backButton.transform.position = backTextPosition;
			specialAttackButton.transform.position = activeSubPosition;
			specialTextMenuButtons.SetActive(true);
		}
		else if(inSubMagicMenu) 
		{
			heavyMagicButton.GetComponent<SpriteRenderer> ().enabled = false;
			specialMagicButton.GetComponent<SpriteRenderer> ().enabled = false;
			backButton.transform.position = backTextPosition;
			magicSubButton.transform.position = activeSubPosition;
			attackTextMenuButtons.SetActive(true);
		}
		else if(inSubHeavyMagicMenu) 
		{
			magicSubButton.GetComponent<SpriteRenderer> ().enabled = false;
			specialMagicButton.GetComponent<SpriteRenderer> ().enabled = false;
			backButton.transform.position = backTextPosition;
			heavyMagicButton.transform.position = activeSubPosition;
			magicTextMenuButtons.SetActive(true);
		}
		else if(inSubSpecialMagicMenu) 
		{
			magicSubButton.GetComponent<SpriteRenderer> ().enabled = false;
			heavyMagicButton.GetComponent<SpriteRenderer> ().enabled = false;
			backButton.transform.position = backTextPosition;
			specialMagicButton.transform.position = activeSubPosition;
			specialTextMenuButtons.SetActive(true);
		}
		else if(inSubRunMenu) 
		{
			attackButton.GetComponent<SpriteRenderer> ().enabled = false;
			magicButton.GetComponent<SpriteRenderer> ().enabled = false;
			specialButton.GetComponent<SpriteRenderer> ().enabled = false;
			runSubMenuButtons.SetActive(true);
		}
		else if(inSubSpecialMenu) 
		{
			magicSpecialButton.GetComponent<SpriteRenderer> ().enabled = false;
			physicalSpecialButton.GetComponent<SpriteRenderer> ().enabled = false;
			backButton.transform.position = backTextPosition;
			specialSubButton.transform.position = activeSubPosition;
			specialTextMenuButtons.SetActive(true);
		}
		else if(inSubPhysicalSpecialMenu) 
		{
			magicSpecialButton.GetComponent<SpriteRenderer> ().enabled = false;
			specialSubButton.GetComponent<SpriteRenderer> ().enabled = false;
			backButton.transform.position = backTextPosition;
			physicalSpecialButton.transform.position = activeSubPosition;
			attackTextMenuButtons.SetActive(true);
		}
		else if(inSubMagicSpecialMenu) 
		{
			physicalSpecialButton.GetComponent<SpriteRenderer> ().enabled = false;
			specialSubButton.GetComponent<SpriteRenderer> ().enabled = false;
			backButton.transform.position = backTextPosition;
			magicSpecialButton.transform.position = activeSubPosition;
			magicTextMenuButtons.SetActive(true);
		}

		inTextMenu = true;
	}

	private void unHideButtons()
	{
		attackButton.GetComponent<SpriteRenderer> ().enabled = true;
		magicButton.GetComponent<SpriteRenderer> ().enabled = true;
		runButton.GetComponent<SpriteRenderer> ().enabled = true;
		specialButton.GetComponent<SpriteRenderer> ().enabled = true;
		attackButton.transform.position = attackStartPosition;
		magicButton.transform.position = magicStartPosition;
		runButton.transform.position = runStartPosition;
		specialButton.transform.position = specialStartPosition;
		attackSubMenuButtons.SetActive(false);
		magicSubMenuButtons.SetActive(false);
		runSubMenuButtons.SetActive(false);
		specialSubMenuButtons.SetActive(false);
		backButton.GetComponent<SpriteRenderer> ().enabled = false;
		inAttack = false;
		inMagic = false;
		inRun = false;
		inSpecial = false;
	}

	private void unHideSubButtons()
	{
		attackSubButton.GetComponent<SpriteRenderer> ().enabled = true;
		magicSubButton.GetComponent<SpriteRenderer> ().enabled = true;
		specialSubButton.GetComponent<SpriteRenderer> ().enabled = true;
		heavyAttackButton.GetComponent<SpriteRenderer> ().enabled = true;
		heavyMagicButton.GetComponent<SpriteRenderer> ().enabled = true;
		magicSpecialButton.GetComponent<SpriteRenderer> ().enabled = true;
		physicalSpecialButton.GetComponent<SpriteRenderer> ().enabled = true;
		specialAttackButton.GetComponent<SpriteRenderer> ().enabled = true;
		heavyMagicButton.GetComponent<SpriteRenderer> ().enabled = true;
		magicSpecialButton.GetComponent<SpriteRenderer> ().enabled = true;
		specialMagicButton.GetComponent<SpriteRenderer> ().enabled = true;
		physicalSpecialButton.GetComponent<SpriteRenderer> ().enabled = true;
		specialAttackButton.GetComponent<SpriteRenderer> ().enabled = true;
		attackTextMenuButtons.SetActive(false);
		magicTextMenuButtons.SetActive(false);
		specialTextMenuButtons.SetActive(false);
		attackSubButton.transform.position = attackSubStartPosition;
		magicSubButton.transform.position = magicSubStartPosition;
		specialSubButton.transform.position = specialSubStartPosition;
		heavyAttackButton.transform.position = heavyAttackStartPosition;
		heavyMagicButton.transform.position = heavyMagicStartPosition;
		specialAttackButton.transform.position = specialAttackStartPosition;
		specialMagicButton.transform.position = specialMagicStartPosition;
		physicalSpecialButton.transform.position = physicalSpecialStartPosition;
		magicSpecialButton.transform.position = magicSpecialStartPosition;
		specialMagicButton.transform.position = specialMagicStartPosition;
		specialSubButton.transform.position = specialSubStartPosition;
		backButton.transform.position = backSubStartPosition;


		inTextMenu = false;
	}
}
