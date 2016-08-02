using UnityEngine;
using System.Collections;

public interface Status {

    void changeStatusSize(int use,int maxUse);

    void changeStatusColor();

    float Status { get; set; }


}
