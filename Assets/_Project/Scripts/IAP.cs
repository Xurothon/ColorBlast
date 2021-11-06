using UnityEngine;
using UnityEngine.Purchasing;

public class IAP : MonoBehaviour
{
    public void OnPurchaseComplete(Product product)
    {
        switch (product.definition.id)
        {
            case "ads_off":
                {
                    DataWorker.Instance.SaveVip();
                    break;
                }
        }
    }
}
