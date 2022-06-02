using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshAttackArea : MonoBehaviour
{
    public List<Collider> colliders
    {
        get
        {
            if (0 < colliderList.Count)
            {
                //  현재 colliders 리스트에 객체중 null인 것은 제거하여 colliderList에 저장 후 반환
                colliderList.RemoveAll(c => c == null);
            }
            return colliderList;
        }
    }
    private List<Collider> colliderList = new List<Collider>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            colliders.Add(other);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            colliders.Remove(other);
        }
    }
}
