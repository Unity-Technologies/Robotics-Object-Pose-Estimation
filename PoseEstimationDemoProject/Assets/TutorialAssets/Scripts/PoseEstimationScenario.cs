using System;
using UnityEngine;
using UnityEngine.Perception.Randomization.Scenarios;

[Serializable]
public class PoseEstimationScenarioConstants : ScenarioConstants
{
    public int totalFrames = 1000;
}

public class PoseEstimationScenario : PerceptionScenario<PoseEstimationScenarioConstants>
{
    public bool automaticIteration = true;

    bool m_ShouldIterate;

    public void Move()
    {
        m_ShouldIterate = true;
    }

    protected override void IncrementIteration()
    {
        base.IncrementIteration();
        m_ShouldIterate = false;
    }

    protected override bool isIterationComplete => m_ShouldIterate || automaticIteration && currentIterationFrame >= 1;

    protected override bool isScenarioComplete => currentIteration >= constants.totalFrames;

    protected override void OnComplete()
    {
        if (automaticIteration)
            base.OnComplete();
    }
}


