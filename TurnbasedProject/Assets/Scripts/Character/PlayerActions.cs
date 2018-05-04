using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

public class PlayerActions
{


    private Moves[] actionsMenu1;
    private Moves[] actionsMenu2;
    private Moves[] actionsMenu3;
    private Moves[] actionsMenu4;
    private Moves[] actionsMenu5;
    private Moves[] specialMenu;
    /// <summary>
    /// The string keys are tied to the fields set on the object. Do not add new keys. 
    /// </summary>
    private Dictionary<string, Moves[]> unlockedMenus;

    public bool loadActionMove(Moves action)
    {
        foreach (string menuName in unlockedMenus.Keys)
        {
            int slotIndex = findEmptySlot(unlockedMenus[menuName]);
            if(slotIndex > -1)
            {
                PropertyInfo menuField = this.GetType().GetProperty(menuName);
                if(menuField != null)
                {
                    Moves[] menu = (Moves[])menuField.GetValue(this, null);
                    menu[slotIndex] = action;
                    menuField.SetValue(this, menu, null);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        return false;
    }

    static public int findEmptySlot(Moves[] actions)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            if (actions[i] == null)
            {
                return i;
            }
        }
    return -1;
    }

    public int numberOfUnlockedActionMenus()
    {
        return !isMenu5Locked ? 5 : !isMenu4Locked ? 4 : !isMenu3Locked ? 3 : !isMenu2Locked ? 2 : !isMenu1Locked ? 1 : 0;
    }

    public Dictionary<string, Moves[]> UnlockedMenus
    {
        get
        {
            this.unlockedMenus = new Dictionary<string, Moves[]>();
            int unlockedMenusNumber = numberOfUnlockedActionMenus();
            switch (unlockedMenusNumber) {
                case 1:
                    unlockedMenus.Add("actions1", ActionsMenu1);
                    break;
                case 2:
                    unlockedMenus.Add("actions2", ActionsMenu2);
                    goto case 1;
                case 3:
                    unlockedMenus.Add("actions3", ActionsMenu3);
                    goto case 2;
                case 4:
                    unlockedMenus.Add("actions4", ActionsMenu4);
                    goto case 3;
                case 5: unlockedMenus.Add("actions5", ActionsMenu5);
                    goto case 4;
                default: break;
        }
            return new Dictionary<string, Moves[]>(unlockedMenus);
        }
        set
        {
            int unlockedMenusNumber = numberOfUnlockedActionMenus();
            switch (unlockedMenusNumber)
            {
                case 1:
                    ActionsMenu1 = value.["actions1"];
                    break;
                case 2:
                    ActionsMenu2 = value["actions2"];
                    goto case 1;
                case 3:
                    ActionsMenu3 = value["actions3"];
                    goto case 2;
                case 4:
                    ActionsMenu4 = value["actions4"];
                    goto case 3;
                case 5:
                    ActionsMenu5 = value["actions5"];
                    goto case 4;
                default: break;
            }
        }
    }
    public bool isMenu1Locked { get; set; }
    public bool isMenu2Locked { get; set; }
    public bool isMenu3Locked { get; set; }
    public bool isMenu4Locked { get; set; }
    public bool isMenu5Locked { get; set; }
    public bool isSpecialMenuLocked { get; set; }
    public bool isSpecial1Locked { get; set; }
    public bool isSpecialLocked { get; set; }
    public bool isSpecial2Locked { get; set; }
    public bool isSpecial3Locked { get; set; }
    public bool isSpecial4Locked { get; set; }
    public bool isSpecial5Locked { get; set; }

    public Moves[] ActionsMenu1
    {
        get
        {
            if (this.actionsMenu1 == null)
            {
                this.actionsMenu1 = new Moves[3];
            }
            return (Moves[])this.actionsMenu1.Clone();
        }
        set
        {
            value.CopyTo(this.actionsMenu1, 0);
        }
    }

    public Moves[] ActionsMenu2
    {
        get
        {
            if (this.actionsMenu2 == null)
            {
                this.actionsMenu2 = new Moves[3];
            }
            return (Moves[])this.actionsMenu2.Clone();
        }
        set
        {
            value.CopyTo(this.actionsMenu2, 0);
        }
    }

    public Moves[] ActionsMenu3
    {
        get
        {
            if (this.actionsMenu3 == null)
            {
                this.actionsMenu3 = new Moves[3];
            }
            return (Moves[])this.actionsMenu3.Clone();
        }
        set
        {
            value.CopyTo(this.actionsMenu3, 0);
        }
    }

    public Moves[] ActionsMenu4
    {
        get
        {
            if (this.actionsMenu4 == null)
            {
                this.actionsMenu4 = new Moves[3];
            }
            return (Moves[])this.actionsMenu4.Clone();
        }
        set
        {
            value.CopyTo(this.actionsMenu4, 0);
        }
    }

    public Moves[] ActionsMenu5
    {
        get
        {
            if (this.actionsMenu5 == null)
            {
                this.actionsMenu5 = new Moves[3];
            }
            return (Moves[])this.actionsMenu5.Clone();
        }
        set
        {
            value.CopyTo(this.actionsMenu5, 0);
        }
    }

    public Moves[] SpecialMenu
    {
        get
        {
            if (this.specialMenu == null)
            {
                this.specialMenu = new Moves[5];
            }
            return (Moves[])this.specialMenu.Clone();
        }
        set
        {
            value.CopyTo(this.specialMenu, 0);
        }
    }

    //TODO: make convience method for setting and getting the number unlocked menus and specials

    public int UnlockedActionMenus
    {
        get
        {
            return numberOfUnlockedActionMenus();
        }
        set
        {
            switch(value){
                case 5 : isMenu5Locked = true; goto case 4;
                case 4 : isMenu4Locked = true; goto case 3;
                case 3 : isMenu3Locked = true; goto case 2;
                case 2 : isMenu2Locked = true; goto case 1;
                case 1 : isMenu1Locked = true; break;
                default : break;
            }
        }
    }

    public int UnlockedSpecialActions
    {
        get
        {
            return !isSpecial5Locked ? 5 : !isSpecial4Locked ? 4 : !isSpecial3Locked ? 3 : !isSpecial2Locked ? 2 : !isSpecial1Locked ? 1 : 0;
        }
        set
        {
            switch (value)
            {
                case 5: isSpecial5Locked = true; goto case 4;
                case 4: isSpecial4Locked = true; goto case 3;
                case 3: isSpecial3Locked = true; goto case 2;
                case 2: isSpecial2Locked = true; goto case 1;
                case 1: isSpecial1Locked = true; isSpecialMenuLocked = true; break;
                default:
                    isSpecial5Locked = false;
                    isSpecial4Locked = false; 
                    isSpecial3Locked = false; 
                    isSpecial2Locked = false;
                    isSpecial1Locked = false;
                    isSpecialMenuLocked = false;
                    break;
            }
        }
    }
}
