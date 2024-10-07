TestSkill = {}
TestSkill.new = function ()
    local effect = CS.Star.Effect.EffectSystem.Instance
    obj = {}
    obj.Action = function ()
        startCoroutine(function ()
            Skill.SystemMsg("skill used")
            local skill = CS.Star.Battle.ActionSkill.CurrentSkill
            local vec3 = CS.UnityEngine.Vector3.zero
            local emitter = skill:PlayEffect(vec3, "Laser01")
            coroutine.yield(effect:EndDelayToCoroutine(emitter))
            print("エフェクト終了")
            skill.IsEnd = true
        end)
    end
    return obj
end
TestSkill = TestSkill.new()