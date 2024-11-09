TestAllSkill = {}
TestAllSkill.new = function ()
    obj = {}
    obj.Action = function ()
        startCoroutine(function ()
            Skill.SystemMsg("全体攻撃")
            local skill = CS.Star.Battle.ActionSkill.CurrentSkill
            local statusEnum = CS.Star.Character.Status
            coroutine.yield(skill:PlayEffect("Skill_01", -1))
            print("エフェクト終了")
            local targets = skill.Targets
            local executor = skill.Chara
            
            for i, target in pairs(targets) do
                local targetDef = target:GetCurrentStatus(statusEnum.DEF)
                local executorAtk = executor:GetCurrentStatus(statusEnum.ATK) * 2
                local damage = executorAtk - targetDef
            
                if damage <= 0 then
                    damage = 1
                end

                target:AddCurrentStatus(statusEnum.HP, -damage)
                executor:AddCurrentStatus(statusEnum.SP, -2)

                coroutine.yield(skill:UpdateHPGage(target.Num))
                coroutine.yield(skill:UpdateSPGage())
            end
            skill.IsEnd = true
        end)
    end
    return obj
end
TestAllSkill = TestAllSkill.new()