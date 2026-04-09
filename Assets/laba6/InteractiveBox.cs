using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(BoxCollider))] // или любой другой коллайдер
public class InteractiveBox : MonoBehaviour
{
    public InteractiveBox next; // следующий в цепочке

    // Добавить ссылку на следующий бокс
    public void AddNext(InteractiveBox box)
    {
        if (box != null && box != this)
            next = box;
    }

    void Update()
    {
        if (next != null)
        {
            Vector3 start = transform.position;
            Vector3 end = next.transform.position;
            // Рисуем луч (виден в Game View при включённых Gizmos)
            Debug.DrawLine(start, end, Color.green);

            Vector3 direction = (end - start).normalized;
            float distance = Vector3.Distance(start, end);
            RaycastHit[] hits = Physics.RaycastAll(start, direction, distance);
            foreach (RaycastHit hit in hits)
            {
                IDamageable damageable = hit.collider.GetComponent<IDamageable>();
                // Не наносим урон себе и следующему боксу
                if (damageable != null &&
                ((Component)damageable).gameObject != gameObject &&
                ((Component)damageable).gameObject != next.gameObject)
                {
                    damageable.GetDamage(Time.deltaTime);
                }
            }
        }
    }
}