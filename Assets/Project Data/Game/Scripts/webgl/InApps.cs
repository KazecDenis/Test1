// using System.Collections;
// using romanlee17.MirraGames;
// using TMPro;
// using UnityEngine;
//
// namespace webgl
// {
//     public class InApps : MonoBehaviour
//     {
//         [SerializeField] private TMP_Text _price5000;
//         [SerializeField] private TMP_Text _price20000;
//         [SerializeField] private TMP_Text _price100000;
//         [SerializeField] private TMP_Text _price1500000;
//         
//         private void Start()
//         {
//             MirraSDK.Payments.Fetch(true);
//             MirraSDK.Analytics.GameIsReady();
//             FillPrice();
//             StartCoroutine(LoadPrices());
//         }
//
//         public void BuyGold5000()
//         {
//             MirraSDK.Payments.Purchase(ProductsTemplate.ID_GOLD_5000);
//         }
//         
//         public void BuyGold20000()
//         {
//             MirraSDK.Payments.Purchase(ProductsTemplate.ID_GOLD_20000);
//         }
//         
//         public void BuyGold100000()
//         {
//             MirraSDK.Payments.Purchase(ProductsTemplate.ID_GOLD_100000);
//         }
//         
//         public void BuyGold1500000()
//         {
//             MirraSDK.Payments.Purchase(ProductsTemplate.ID_GOLD_1500000);
//         }
//
//         private void FillPrice()
//         {
//             _price5000.text = MirraSDK.Payments.GetProductPrice(ProductsTemplate.ID_GOLD_5000);
//             _price20000.text = MirraSDK.Payments.GetProductPrice(ProductsTemplate.ID_GOLD_20000);
//             _price100000.text = MirraSDK.Payments.GetProductPrice(ProductsTemplate.ID_GOLD_100000);
//             _price1500000.text = MirraSDK.Payments.GetProductPrice(ProductsTemplate.ID_GOLD_1500000);
//         }
//
//         private IEnumerator LoadPrices()
//         {
//             while (!MirraSDK.Payments.IsProductsReady)
//             {
//                 yield return null;
//             }
//             FillPrice();
//         }
//     }
// }
