using UnityEngine;

public class ReplayButtonVisible : MonoBehaviour
{
    void Start()
    {
        bool show = false;

        if (ReplayManager.Instance != null)
        {
            show = ReplayManager.Instance.movedBattleScene;
        }

        gameObject.SetActive(show);
    }
}