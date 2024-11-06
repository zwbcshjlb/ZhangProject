using System;
using UnityEngine;
using UnityEngine.Rendering;

public class SetupZhangRP : MonoBehaviour
{
    public RenderPipelineAsset currentPipelineAsset;

    private void OnEnable()
    {
        GraphicsSettings.defaultRenderPipeline = currentPipelineAsset;
    }

    private void OnValidate()
    {
        GraphicsSettings.defaultRenderPipeline = currentPipelineAsset;
    }
}
