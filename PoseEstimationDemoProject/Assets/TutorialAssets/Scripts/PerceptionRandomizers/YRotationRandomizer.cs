using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Perception.Randomization.Parameters;
using UnityEngine.Perception.Randomization.Randomizers;
using UnityEngine.Perception.Randomization.Samplers;


[Serializable]
[AddRandomizerMenu("Perception/Y Rotation Randomizer")]
public class YRotationRandomizer : Randomizer
{
    public FloatParameter rotationRange = new FloatParameter { value = new UniformSampler(0f, 360f) }; // in range (0, 1)

    protected override void OnIterationStart()
    {
        IEnumerable<YRotationRandomizerTag> tags = tagManager.Query<YRotationRandomizerTag>();
        foreach (YRotationRandomizerTag tag in tags)
        {
            float yRotation = rotationRange.Sample();

            // sets rotation
            tag.SetYRotation(yRotation);
        }
    }
}
