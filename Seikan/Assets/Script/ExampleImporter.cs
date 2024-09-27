using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.AssetImporters;
using System.IO;

namespace Star.Editor
{
    [ScriptedImporter(1, "lua")]
    public class ExampleImporter : ScriptedImporter
    {
        public override void OnImportAsset(AssetImportContext ctx)
        {
            string text = File.ReadAllText(ctx.assetPath);
            TextAsset textAsset = new TextAsset(text);
            ctx.AddObjectToAsset("Main", textAsset);
            ctx.SetMainObject(textAsset);
        }
    }
}