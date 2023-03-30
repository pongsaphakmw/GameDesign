using System.Collections.Generic;
using UnityEngine;
 
public class DamageDealer : MonoBehaviour
{
    bool canDealDamage;
    List<GameObject> hasDealtDamage;
 
    [SerializeField] float weaponLength;
    [SerializeField] float weaponDamage;
    void Start()
    {
        canDealDamage = false;
        hasDealtDamage = new List<GameObject>();
    }
 
    void Update()
    {
        if (canDealDamage)
        {
            RaycastHit hit;
 
            int layerMask = 1 << 8;
            if (Physics.Raycast(transform.position, -transform.up, out hit, weaponLength, layerMask))
            {
            // Debug.Log("Hit " + hit.transform.gameObject.name);
                if (!hasDealtDamage.Contains(hit.transform.gameObject)){
                    Debug.Log("Hit " + hit.transform.gameObject.name);
                    hasDealtDamage.Add(hit.transform.gameObject);
                    DealDamage(hit.transform.gameObject.GetComponent<EnemyController>());
                }
            }
        }
    }
    public void StartDealDamage()
    {
        // Debug.Log("StartDealDamage");
        canDealDamage = true;
        hasDealtDamage.Clear();
    }
    public void EndDealDamage()
    {
        canDealDamage = false;
    }
 
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position - transform.up * weaponLength);
    }

    void DealDamage(EnemyController enemy)
    {
        enemy.TakeDamage(weaponDamage);
    }
}