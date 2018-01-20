using UnityEngine;
using System.Collections;

public interface Status {

    void changeStatusSize(int use,int maxUse);

    void changeStatusSize(float use, float maxUse);

    void changeStatusColor();

    float Status { get; set; }


}
