using UnityEngine;

public class ShootingPlayerPivot : MonoBehaviour
{
    void Update()
    {
        Shooting();
    }
    private float delay = 0.3f, Speed = 100f, TimeShoot;
    [SerializeField]
    private GameObject Projectile;
    private void Shooting()
    {
        if (Time.time > TimeShoot)
        {
            GameObject g = LVL_Tools.Get_Pool(Projectile);
            g.transform.position = transform.position;
            g.GetComponent<Projectile>().Speed = Speed + player.inst.EndSpeed.z;

            TimeShoot = Time.time + delay;
        }
    }
}
