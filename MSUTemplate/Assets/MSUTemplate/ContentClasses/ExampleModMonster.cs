﻿using MSU;
using R2API;
using RoR2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using RoR2.ContentManagement;

namespace MSUTemplate
{
    /// <summary>
    /// <inheritdoc cref="IMonsterContentPiece"/>
    /// </summary>
    public abstract class ExampleModMonster : IMonsterContentPiece, IContentPackModifier
    {
        public NullableRef<MonsterCardProvider> CardProvider { get; protected set; }
        public NullableRef<DirectorCardHolderExtended> DissonanceCard { get; protected set; }
        public MonsterAssetCollection AssetCollection { get; private set; }
        public NullableRef<GameObject> MasterPrefab { get; protected set; }

        NullableRef<DirectorCardHolderExtended> IMonsterContentPiece.DissonanceCard => DissonanceCard;
        CharacterBody IGameObjectContentPiece<CharacterBody>.Component => CharacterPrefab.GetComponent<CharacterBody>();
        NullableRef<MonsterCardProvider> IMonsterContentPiece.CardProvider => CardProvider;
        GameObject IContentPiece<GameObject>.Asset => CharacterPrefab;
        public GameObject CharacterPrefab { get; private set; }

        public abstract void Initialize();
        public abstract bool IsAvailable(ContentPack contentPack);

        public abstract MSUTAssetRequest<MonsterAssetCollection> AssetRequest { get; }

        

        public virtual IEnumerator LoadContentAsync()
        {
            MSUTAssetRequest<MonsterAssetCollection> request = AssetRequest;

            request.StartLoad();
            while (!request.isComplete)
                yield return null;

            AssetCollection = request.asset;

            CharacterPrefab = AssetCollection.bodyPrefab;
            MasterPrefab = AssetCollection.masterPrefab;
            CardProvider = AssetCollection.monsterCardProvider;
        }


        public virtual void ModifyContentPack(ContentPack contentPack)
        {
            contentPack.AddContentFromAssetCollection(AssetCollection);
        }
    }
}