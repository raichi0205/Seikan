EnemySkill = {}
EnemySkill.new = function ()
    obj = {}
    obj.Action = function ()
        startCoroutine(function ()
            Skill.SystemMsg("単体目標スキル")
            local skill = CS.Star.Battle.ActionSkill.CurrentSkill
            local statusEnum = CS.Star.Character.Status
            local target = skill.Targets[0]
            local executor = skill.Executor

            coroutine.yield(skill:PlayEffect("Skill_01", -1))
            skill:PlayShake()
          
            local targetDef = target:GetCurrentStatus(statusEnum.DEF)
            local executorAtk = executor:GetCurrentStatus(statusEnum.ATK) * skill:GetCorrection(statusEnum.ATK).Rate

            local damage = executorAtk - targetDef
            
            if damage <= 0 then
                damage = 1
            end
            
            target:GrantState("Poison");

            target:AddCurrentStatus(statusEnum.HP, -damage)
            executor:AddCurrentStatus(statusEnum.SP, -skill:GetCorrection(statusEnum.SP).Value)

            coroutine.yield(skill:UpdateHPGage(target))
            skill.IsEnd = true
        end)
    end
    return obj
end
EnemySkill = EnemySkill.new()