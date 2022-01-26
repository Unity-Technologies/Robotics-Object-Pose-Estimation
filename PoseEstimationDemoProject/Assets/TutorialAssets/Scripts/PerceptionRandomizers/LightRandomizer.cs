using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Perception.Randomization.Parameters;
using UnityEngine.Perception.Randomization.Randomizers;
using UnityEngine.Perception.Randomization.Samplers;

[Serializable]
[AddRandomizerMenu("Perception/Light Randomizer")]
public class LightRandomizer : Randomizer
{
    public FloatParameter lightIntensityParameter = new FloatParameter { value = new UniformSampler(.9f, 1.1f) };

    public FloatParameter rotationX = new FloatParameter { value = new UniformSampler(40, 80) };

    public FloatParameter rotationY = new FloatParameter { value = new UniformSampler(-180, 180) };

    public ColorRgbParameter lightColorParameter = new ColorRgbParameter
    {
        red = new UniformSampler(.5f, 1f),
        green = new UniformSampler(.5f, 1f),
        blue = new UniformSampler(.5f, 1f),
        alpha = new ConstantSampler(1f)
    };

    protected override void OnIterationStart()
    {
        /*Runs at the start of every iteration*/
        IEnumerable<LightRandomizerTag> tags = tagManager.Query<LightRandomizerTag>();

        foreach (LightRandomizerTag tag in tags)
        {
            var light = tag.gameObject.GetComponent<Light>();
            light.intensity = lightIntensityParameter.Sample();
            light.color = lightColorParameter.Sample();

            Vector3 rotation = new Vector3(rotationX.Sample(), rotationY.Sample(), tag.gameObject.transform.eulerAngles.z);
            tag.gameObject.transform.rotation = Quaternion.Euler(rotation);
        }

    }
}
