using UnityEngine;
using System.Collections;

public interface MultiStatus : Status {

    void updateSubStatus(int use, int maxUse, int maxStatus);

    void updateSubStatus(float use, float maxUse, int maxStatus);

}
