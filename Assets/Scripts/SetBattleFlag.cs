using UnityEngine;

public class SetBattleFlag : MonoBehaviour
{
    void Start()
    {
        if (ReplayManager.Instance != null)
        {
            ReplayManager.Instance.movedBattleScene = true;
        }
    }
}