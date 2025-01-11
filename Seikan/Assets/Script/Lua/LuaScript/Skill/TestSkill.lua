TestSkill = {}
TestSkill.new = function ()
    obj = {}
    obj.Action = function ()
        startCoroutine(function ()
            Skill.SystemMsg("単体目標スキル")
            local skill = CS.Star.Battle.ActionSkill.CurrentSkill
            local statusEnum = CS.Star.Character.Status
            local target = skill.Targets[0]
            local executor = skill.Executor

            coroutine.yield(skill:PlayEffect("Skill_01", target.Num))
            print("エフェクト終了:"..target.Num)
          
            local targetDef = target:GetCurrentStatus(statusEnum.DEF)
            local executorAtk = executor:GetCurrentStatus(statusEnum.ATK) * skill:GetCorrection(statusEnum.ATK).Rate

            local damage = executorAtk - targetDef
            
            if damage <= 0 then
                damage = 1
            end

            target:AddCurrentStatus(statusEnum.HP, -damage)
            executor:AddCurrentStatus(statusEnum.SP, -skill:GetCorrection(statusEnum.SP).Value)

            coroutine.yield(skill:UpdateHPGage(target.Num))
            coroutine.yield(skill:UpdateSPGage())
            skill.IsEnd = true
        end)
    end
    return obj
end
TestSkill = TestSkill.new()