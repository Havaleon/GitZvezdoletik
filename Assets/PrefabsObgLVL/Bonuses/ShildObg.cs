using UnityEngine;

public class ShildObg : BonusObg
{
    private int AddNumLives = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Dead_scr.Instance.AddExtraLives(1);

            Dead_scr.Instance.SetBonusExtraLives(AddNumLives, Duration);

            AddIndicator(Duration);

            ParentObg.SetActive(false);
        }
    }
}
