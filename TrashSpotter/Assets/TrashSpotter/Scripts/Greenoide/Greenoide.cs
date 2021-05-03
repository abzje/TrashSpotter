using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greenoide : MonoBehaviour
{
    [SerializeField] BodypartAvailable _BodypartAvailable = null;

    [SerializeField] Head _HeadAsset = null;
    [SerializeField] int _EyesAssetId;
    [SerializeField] int _MouthAssetId;
    [SerializeField] int _TattooAssetId;
    [SerializeField] int _TopHeadAssetId;
    [SerializeField] int _ClothesAssetId;
    [SerializeField] int _FaceOrnamentAssetId;
    [SerializeField] int _BodyOrnamentAssetId;

    [SerializeField] Bodypart _Head = null;
    [SerializeField] Bodypart _Eyes = null;
    [SerializeField] Bodypart _Mouth = null;
    [SerializeField] Bodypart _Tatto = null;
    [SerializeField] Bodypart _TopHeadOrnament = null;
    [SerializeField] Bodypart _Clothes = null;
    [SerializeField] Bodypart _FaceOrnament = null;
    [SerializeField] Bodypart _BodyOrnament = null;

    private void Start() 
    {
        if (_BodypartAvailable == null)
            return;
        
        if (_Head != null && _HeadAsset != null)
        {
            BodypartAsset headAsset = _BodypartAvailable.GetBodypartAsset(_HeadAsset._HeadAssetId);
            if (headAsset != null)
                _Head._Renderer.sprite = headAsset._Sprite;
        }

        if (_Eyes != null)
        {
            BodypartAsset EyesAsset = _BodypartAvailable.GetBodypartAsset(_EyesAssetId);
            if (EyesAsset != null)
                _Eyes._Renderer.sprite = EyesAsset._Sprite;
        }
    }
}
