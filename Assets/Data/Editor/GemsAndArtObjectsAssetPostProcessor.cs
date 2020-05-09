using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
///
public class GemsAndArtObjectsAssetPostprocessor : AssetPostprocessor 
{
    private static readonly string filePath = "Assets/Data/DMG.xlsx";
    private static readonly string assetFilePath = "Assets/Data/GemsAndArtObjects.asset";
    private static readonly string sheetName = "GemsAndArtObjects";
    
    static void OnPostprocessAllAssets (string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        foreach (string asset in importedAssets) 
        {
            if (!filePath.Equals (asset))
                continue;
                
            GemsAndArtObjects data = (GemsAndArtObjects)AssetDatabase.LoadAssetAtPath (assetFilePath, typeof(GemsAndArtObjects));
            if (data == null) {
                data = ScriptableObject.CreateInstance<GemsAndArtObjects> ();
                data.SheetName = filePath;
                data.WorksheetName = sheetName;
                AssetDatabase.CreateAsset ((ScriptableObject)data, assetFilePath);
                //data.hideFlags = HideFlags.NotEditable;
            }
            
            //data.dataArray = new ExcelQuery(filePath, sheetName).Deserialize<GemsAndArtObjectsData>().ToArray();		

            //ScriptableObject obj = AssetDatabase.LoadAssetAtPath (assetFilePath, typeof(ScriptableObject)) as ScriptableObject;
            //EditorUtility.SetDirty (obj);

            ExcelQuery query = new ExcelQuery(filePath, sheetName);
            if (query != null && query.IsValid())
            {
                data.dataArray = query.Deserialize<GemsAndArtObjectsData>().ToArray();
                ScriptableObject obj = AssetDatabase.LoadAssetAtPath (assetFilePath, typeof(ScriptableObject)) as ScriptableObject;
                EditorUtility.SetDirty (obj);
            }
        }
    }
}
