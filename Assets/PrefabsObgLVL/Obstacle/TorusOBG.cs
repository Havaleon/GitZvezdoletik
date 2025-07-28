using NaughtyAttributes;
using UnityEngine;

public enum TorusType
{
    Torus1 = 1,
    Torus2 = 2
}

public class TorusOBG : MonoBehaviour
{
    [SerializeField]
    private TorusType TorusType;

    private void Awake()
    {
        Initialize();
    }

    private void OnEnable()
    {
        SpawnReward();
        EnableInitializeTorus2();
    }
    private void OnDisable()
    {
        ClearReward();
    }

    private void Initialize()
    {
        ParentPivot = GetComponent<DataObstacl>().Model.transform.parent;
    }
    private Transform ParentPivot;
    [SerializeField]
    private GameObject Crystal;
    private GameObject Reward;

    private void SpawnReward()
    {
        if (Random.value < 0.01f)
        {
            Reward = LVL_Tools.Get_Pool(Crystal);
            Reward.transform.parent = ParentPivot;
            Reward.transform.localPosition = Vector3.zero;
            Reward.transform.localScale = Vector3.one;

            Debug.Log(Reward);
        }
    }

    private void ClearReward()
    {
        if (Reward != null)
        {
            Reward.SetActive(false);
            Reward.transform.parent = null;
            Reward = null;
        }
    }

    [SerializeField, ShowIf("TorusType", TorusType.Torus2)]
    private GameObject torus1;

    private void EnableInitializeTorus2()
    {
        if (TorusType == TorusType.Torus2)
        {
            if (Random.value < 0.25f)
            {
                torus1.SetActive(true);
            }
            else
            {
                torus1.SetActive(false);
            }
        }
    }
}
