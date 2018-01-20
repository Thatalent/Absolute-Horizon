using UnityEngine;
using System.Collections;
using System;

public class MultiStatusBar : BaseStatusBar, MultiStatus{

    protected Status[] subStatusBars;
    public int maxBars;

    // Use this for initialization
    void Start () {
        statusBar = gameObject;
        maxStatusSize = statusBar.transform.localScale.x;
        image = GetComponent<SpriteRenderer>();
        subStatusBars = statusBar.GetComponentsInChildren<Status>(true);
        sortSubStatusBars();
    }

    private void sortSubStatusBars()
    {
        Status[] tempSubStatusBars = new Status[maxBars];

        foreach(BaseStatusBar subStatusBar in subStatusBars){
            if (this != subStatusBar)
            {
                tempSubStatusBars[subStatusBar.order - 1] = subStatusBar;
            }
        }

        subStatusBars = tempSubStatusBars;
    }

    public void updateSubStatus(float use, float maxUse, int maxStatus)
    {
        int currentBar = (int)(use / maxUse);
        bool barIsFull = false;

        if (currentBar >= maxStatus) 
        {
            currentBar = maxStatus-1;
            barIsFull = true;
        }

        for(int i = 0; i <= currentBar; i++)
        {
            float change = 0;
            if (i < currentBar || barIsFull)
            {
                change = maxUse;
            }
            else
            {
                change = use -  maxUse*(currentBar);
            }
            subStatusBars[i].changeStatusSize(change, maxUse);
        }
       
    }

    public void updateSubStatus(int use, int maxUse, int maxStatus)
    {
        updateSubStatus((float)use, (float)maxUse, maxStatus);
    }
}
