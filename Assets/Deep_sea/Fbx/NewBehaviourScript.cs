using UnityEngine;

public class MouseClickRaycast : MonoBehaviour
{
    public GameObject prefabToSpawn; // 需要生成的预制体

    void Update()
    {
        // 检测鼠标点击
        if (Input.GetMouseButtonDown(0))
        {
            // 获取鼠标点击位置
            Vector3 mousePosition = Input.mousePosition;
            // 将屏幕坐标转换为世界坐标
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10f));

            // 发射射线
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, worldPosition - Camera.main.transform.position, out hit))
            {
                // 检测到碰撞，获取碰撞点位置
                Vector3 collisionPosition = hit.point;
                // 获取碰撞到的游戏对象
                GameObject hitObject = hit.collider.gameObject;
                
                // 如果碰撞到的游戏对象不为空，且是你需要的模型
                if (hitObject != null && hitObject.CompareTag("Untagged"))
                {
                    // 在碰撞点位置生成预制体
                    Instantiate(prefabToSpawn, collisionPosition, Quaternion.identity);
                }
            }
        }
    }
}
