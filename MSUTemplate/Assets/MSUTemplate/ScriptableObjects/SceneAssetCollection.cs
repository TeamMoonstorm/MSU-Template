using RoR2;
using UnityEngine;
namespace MSUTemplate
{
    [CreateAssetMenu(fileName = "SceneAssetCollection", menuName = "ExampleMod/AssetCollections/SceneAssetCollection")]
    public class SceneAssetCollection : ExtendedAssetCollection
    {
        public SceneDef sceneDef;
    }
}
