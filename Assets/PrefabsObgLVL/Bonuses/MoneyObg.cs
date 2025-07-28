using UnityEngine;

public enum MoneyType
{
    Money = 0,
    Crystal = 1
}

public class MoneyObg : MonoBehaviour
{
    [SerializeField]
    private MoneyType moneyType;

    [Space]
    [SerializeField]
    private GameObject MoneyParent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            switch (moneyType)
            {
                case MoneyType.Money:
                    PlayerData.instance.AddMoney(1);
                    break;

                case MoneyType.Crystal:
                    PlayerData.instance.AddCrystal(1);
                    break;

            }



            MoneyParent.SetActive(false);

        }
    }
}
