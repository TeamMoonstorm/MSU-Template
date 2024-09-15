using RoR2;
using UnityEngine;
using System.Collections.Generic;
using MSU;

namespace MSUTemplate
{
    [CreateAssetMenu(fileName = "EquipmentAssetCollection", menuName = "ExampleMod/AssetCollections/EquipmentAssetCollection")]
    public class EquipmentAssetCollection : ExtendedAssetCollection
    {
        public NullableRef<List<GameObject>> itemDisplayPrefabs;
        public EquipmentDef equipmentDef;
    }
}