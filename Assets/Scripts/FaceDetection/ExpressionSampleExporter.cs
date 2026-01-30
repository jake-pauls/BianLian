using System;
using System.Collections.Generic;
using Mediapipe.Tasks.Components.Containers;
using UnityEditor;
using UnityEngine;

namespace FaceDetection
{
    public static class ExpressionSampleExporter 
    {
        public static void ExportCategories(IEnumerable<Category> categories, Texture sourceTexture)
        {
            // Take the incoming categories and convert them to serializable blend shapes.
            List<BlendShapeInfo> blendShapeInfos = CreateBlendShapeInfosFromCategories(categories);
        
            // Create a new scriptable object containing the categories and the reference texture.
            var sample = ScriptableObject.CreateInstance<ExpressionSample>();
            string name = sourceTexture is not null ? $"{sourceTexture.name}_ExpressionData" : "NewExpressionData";
            sample.Name = name;
            sample.Emotion = NEW_ASSET_EMOTION;
            sample.Source = sourceTexture as Texture2D;
            sample.BlendShapes = blendShapeInfos.ToArray();

            // Save it to the SAVE_FOLDER_PATH.
            string path = System.IO.Path.Combine(SAVE_FOLDER_PATH, $"{name}.asset");
            AssetDatabase.CreateAsset(sample, path);
            AssetDatabase.SaveAssets();
        
            Debug.Log($"Created new face sample data from image: {path}");
        }
        
        private static List<BlendShapeInfo> CreateBlendShapeInfosFromCategories(IEnumerable<Category> categories)
        {
            List<BlendShapeInfo> blendShapeInfos = new();
        
            foreach (Category category in categories)
            {
                BlendShapeInfo info = new()
                {
                    Name = category.categoryName,
                    Score = category.score,
                };
            
                blendShapeInfos.Add(info);
            }

            return blendShapeInfos;
        }
    
        private const string NEW_ASSET_EMOTION = "DefaultEmotion";
        private const string SAVE_FOLDER_PATH = "Assets/Data/FaceSampleData";
    }
}
