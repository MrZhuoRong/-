using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BuildAssetsBundle : Editor
{
    [MenuItem("Bycw/BuildAssetsBundle")]//�½��˵�ѡ��
    static void BuildAllAssetsBundle()
    {
        Debug.Log("BuildAllAssetsBundle");
        BuildPipeline.BuildAssetBundles("./AssetsBundles/win64", BuildAssetBundleOptions.None,BuildTarget.StandaloneWindows64);//·����ѡ�Ŀ��ƽ̨
        //��ͬƽ̨��һ������Ҫѡ��ƽ̨,һ�㲻����Assets
    }
}
