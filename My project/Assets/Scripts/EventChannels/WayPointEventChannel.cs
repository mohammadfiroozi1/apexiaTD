using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Event Channels/WayPoints Event Channel", fileName = "WayPoints Event Channel")]

public class WayPointEventChannel : ScriptableObject
{
    public delegate List<Transform> WayPointGetterDelegate();
    public WayPointGetterDelegate GetWayPoints;
}
