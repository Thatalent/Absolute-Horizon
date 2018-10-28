using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BaseStatusBar : MonoBehaviour, Status {

    //status bar gameobject

    protected GameObject statusBar;

    //user repersents the user that the status bar belongs to

    public GameObject user;

    //the max scale size of the status bar before it scales

    protected float maxStatusSize;

    //colors to use for possible shading

    public Color minColor;
    public Color maxColor;

    //the rendering compenont that holds the status bar sprite

    protected SpriteRenderer image;

    /// <summary>
    /// Determines which bar is filled first
    /// </summary>
    public int order;

	// Use this for initialization
	void Start () {
        statusBar = gameObject;
        maxStatusSize = statusBar.transform.localScale.x;
        image = GetComponent<SpriteRenderer>();
        
    }

    //changes size of status bar

    public void changeStatusSize(int use,int maxUse)
    {
        changeStatusSize((float)use, (float)maxUse);
    }

    public void changeStatusSize(float use, float maxUse)
    {
        // find ratio of current status amount to max

        float change;

        if(use > maxUse)
        {
            change = maxUse;
        }
        else if(use < 0)
        {
            change = 0;
        }
        else
        {
            change = (float)use / (float)maxUse;

        }

        // Debug.Log(maxUse + " : maxUse");

        //gets the left most position of status bar (change min to max to make the capture the right most position)

        float originalValue = image.bounds.min.x;

        // apply ratio to current status

        Status = maxStatusSize * change;

        //scale the bar

        statusBar.transform.localScale = new Vector3(Status, statusBar.transform.localScale.y, statusBar.transform.localScale.z);


        float newValue = image.bounds.min.x;

        //calculate difference
        float difference = newValue - originalValue;

        //move the bar to the left
        transform.Translate(new Vector3(-difference, 0f, 0f));

    }

    //used to change the color of the status based on condition

    public void changeStatusColor()
    {
        Status = statusBar.transform.localScale.x;
        if (Status / maxStatusSize <= .3)
        {
            
        }
    }

    //for possible use of status bar scale
    //Status = current scale size of the status bar (statusbar.transform.localScale.x)
    public float Status { get; set; }
}
