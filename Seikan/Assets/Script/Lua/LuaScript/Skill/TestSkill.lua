TestSkill = {}
TestSkill.new = function ()
    obj = {}
    obj.Action = function ()
        startCoroutine(function ()
            Skill.SystemMsg("skill used")
            local skill = CS.Star.Battle.ActionSkill.CurrentSkill
            local statusEnum = CS.Star.Character.Status
            coroutine.yield(skill:PlayEffect("Skill_01"))
            print("エフェクト終了")
            local target = skill.Target
            local executor = skill.Chara
            
            local targetDef = target:GetCurrentStatus(statusEnum.DEF)
            local executorAtk = executor:GetCurrentStatus(statusEnum.ATK) * 1.5
            --print("targetDef:"..targetDef)
            --print("executorAtk:"..executorAtk)
            local damage = executorAtk - targetDef
            
            if damage <= 0 then
                damage = 1
            end

            target:AddCurrentStatus(statusEnum.HP, -damage)
            executor:AddCurrentStatus(statusEnum.SP, -2)

            coroutine.yield(skill:UpdateHPGage())
            coroutine.yield(skill:UpdateSPGage())
            skill.IsEnd = true
        end)
    end
    return obj
end
TestSkill = TestSkill.new()