using UnityEngine;

public class CollisionIgnore : MonoBehaviour
{
    void Start()
    {
        GameObject[] ignoreColliderPlayers = GameObject.FindGameObjectsWithTag("IgnoreColliderPlayer");
        GameObject[] props = GameObject.FindGameObjectsWithTag("Props");
        GameObject[] debris = GameObject.FindGameObjectsWithTag("Debris");
        GameObject[] dropAreas = GameObject.FindGameObjectsWithTag("DropArea");

        foreach (GameObject objA in ignoreColliderPlayers)
        {
            Collider colliderA = objA.GetComponent<Collider>();
            if (colliderA != null)
            {
                foreach (GameObject objB in props)
                {
                    Collider colliderB = objB.GetComponent<Collider>();
                    if (colliderB != null)
                    {
                        Physics.IgnoreCollision(colliderA, colliderB);
                    }
                }
            }
        }

        foreach (GameObject prop in props)
        {
            Collider propCollider = prop.GetComponent<Collider>();
            if (propCollider != null)
            {
                foreach (GameObject dropArea in dropAreas)
                {
                    Collider dropAreaCollider = dropArea.GetComponent<Collider>();
                    if (dropAreaCollider != null)
                    {
                        Physics.IgnoreCollision(propCollider, dropAreaCollider);
                    }
                }
            }
        }

        foreach (GameObject debrisObj in debris)
        {
            Collider debrisCollider = debrisObj.GetComponent<Collider>();
            if (debrisCollider != null)
            {
                foreach (GameObject dropArea in dropAreas)
                {
                    Collider dropAreaCollider = dropArea.GetComponent<Collider>();
                    if (dropAreaCollider != null)
                    {
                        Physics.IgnoreCollision(debrisCollider, dropAreaCollider);
                    }
                }
            }
        }
    }
}