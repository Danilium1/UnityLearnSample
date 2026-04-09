using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractiveRaycast : MonoBehaviour
{
    public GameObject prefab; // кубик с компонентом InteractiveBox
    private InteractiveBox selectedBox; // запомненный бокс для связывания

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // левый клик
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // Клик по плоскости с тегом InteractivePlane
                if (hit.collider.CompareTag("InteractivePlane"))
                {
                    CreateObjectAtPoint(hit);
                }
                // Клик по объекту с InteractiveBox
                else if (hit.collider.TryGetComponent(out InteractiveBox box))
                {
                    if (selectedBox == null)
                    {
                        // Запоминаем первый бокс
                        selectedBox = box;
                    }
                    else if (selectedBox != box)
                    {
                        // Связываем запомненный с текущим
                        selectedBox.AddNext(box);
                        selectedBox = null; // сбрасываем
                    }
                }
            }
        }
        else if (Input.GetMouseButtonDown(1)) // правый клик
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.TryGetComponent(out InteractiveBox box))
                {
                    Destroy(box.gameObject);
                }
            }
        }
    }

    private void CreateObjectAtPoint(RaycastHit hit)
    {
        // Создаём объект в точке клика, с учётом нормали (чтобы не провалился в плоскость)
        Vector3 position = hit.point + hit.normal * 0.5f; // 0.5 – половина размера куба (если размер 1)
        GameObject newObj = Instantiate(prefab, position, Quaternion.identity);
        // Можно добавить дополнительную коррекцию, если размеры другие
    }
}
