using BallSkinLoader;
using UnityEngine;

namespace Store
{
    public class StoreSlotViewFactory : MonoBehaviour   
    {
        [SerializeField] private StoreSlotView _prefab;
        [SerializeField] private Transform _contentTransform;

        public StoreSlotView GetSkinSlot(SkinType type)
        {
            var view = Instantiate(_prefab, _contentTransform);
            view.Construct(type);

            return view;
        }
    }
}