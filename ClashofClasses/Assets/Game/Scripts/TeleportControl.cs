using UnityEngine;

public class TeleportControl : MonoBehaviour
{
   
    public void TeleportLocal(GameObject obj, Vector3 position)
    {
        obj.transform.position = position;
    }

    public void TeleportGlobal(GameObject obj, Vector3 position)
    {
        obj.transform.localPosition = position;
    }
}
