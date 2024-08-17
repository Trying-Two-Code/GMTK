#ifndef OUTLINE_INCLUDED
#define OUTLINE_INCLUDED


void Outline_float(float Threshold, float4 UV, out float Out)
{
    // The center depth of the current pixel
    float centerDepth = Linear01Depth(SHADERGRAPH_SAMPLE_SCENE_DEPTH(UV), _ZBufferParams);
    
    float leftDepth = Linear01Depth(SHADERGRAPH_SAMPLE_SCENE_DEPTH(UV + float4(-1, 0, 0, 0) / _ScreenParams), _ZBufferParams);
    float rightDepth = Linear01Depth(SHADERGRAPH_SAMPLE_SCENE_DEPTH(UV + float4(1, 0, 0, 0) / _ScreenParams), _ZBufferParams);
    float topDepth = Linear01Depth(SHADERGRAPH_SAMPLE_SCENE_DEPTH(UV + float4(0, 1, 0, 0) / _ScreenParams), _ZBufferParams);
    float bottomDepth = Linear01Depth(SHADERGRAPH_SAMPLE_SCENE_DEPTH(UV + float4(0, -1, 0, 0) / _ScreenParams), _ZBufferParams);

    // Calculate the depth differences between the center pixel and its neighbors
    float leftDiff = distance(centerDepth, leftDepth);
    float rightDiff = distance(centerDepth, rightDepth);
    float topDiff = distance(centerDepth, topDepth);
    float bottomDiff = distance(centerDepth, bottomDepth);

    // Calculate the average depth difference

    float avgDiff = (leftDiff + rightDiff + topDiff + bottomDiff) / 4;

    Out = 1 - clamp(avgDiff * Threshold, 0, 1);
}

#endif // OUTLINE_INCLUDED