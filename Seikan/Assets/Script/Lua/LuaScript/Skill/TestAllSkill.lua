TestAllSkill = {}
TestAllSkill.new = function ()
    obj = {}
    obj.Action = function ()
        startCoroutine(function ()
            Skill.SystemMsg("全体攻撃")
            local skill = CS.Star.Battle.ActionSkill.CurrentSkill
            local statusEnum = CS.Star.Character.Status
            local targets = skill.Targets
            local executor = skill.Executor

            executor:AddCurrentStatus(statusEnum.SP, -skill:GetCorrection(statusEnum.SP).Value)
            coroutine.yield(skill:UpdateSPGage())

            coroutine.yield(skill:PlayEffect("Skill_01", -1))
            print("エフェクト終了")

            for i, target in pairs(targets) do
                local targetDef = target:GetCurrentStatus(statusEnum.DEF)
                local executorAtk = executor:GetCurrentStatus(statusEnum.ATK) * skill:GetCorrection(statusEnum.ATK).Rate
                local damage = executorAtk - targetDef
            
                if damage <= 0 then
                    damage = 1
                end

                target:AddCurrentStatus(statusEnum.HP, -damage)

                coroutine.yield(skill:UpdateHPGage(target))
            end
            skill.IsEnd = true
        end)
    end
    return obj
end
TestAllSkill = TestAllSkill.new()