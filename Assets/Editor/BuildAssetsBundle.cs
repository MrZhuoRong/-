using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BuildAssetsBundle : Editor
{
    [MenuItem("Bycw/BuildAssetsBundle")]//新建菜单选项
    static void BuildAllAssetsBundle()
    {
        Debug.Log("BuildAllAssetsBundle");
        BuildPipeline.BuildAssetBundles("./AssetsBundles/win64", BuildAssetBundleOptions.None,BuildTarget.StandaloneWindows64);//路径，选项，目标平台
        //不同平台不一样，需要选好平台,一般不放在Assets
    }
}
