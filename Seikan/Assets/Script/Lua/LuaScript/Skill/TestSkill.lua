TestSkill = {}
TestSkill.new = function ()
    obj = {}
    obj.Action = function ()
        startCoroutine(function ()
            Skill.SystemMsg("skill used")
            local skill = CS.Star.Battle.ActionSkill.CurrentSkill
            coroutine.yield(skill:PlayEffect("Skill_01"))
            print("エフェクト終了")
            skill.IsEnd = true
        end)
    end
    return obj
end
TestSkill = TestSkill.new()