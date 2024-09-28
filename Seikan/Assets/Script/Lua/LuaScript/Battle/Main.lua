Skill = {}
Skill.new = function ()
    local obj = {}

    obj.SystemMsg = function (msg)
        print("lua SystemMsg:"..msg)
        CS.Star.Battle.BattleSystem.Instance.SystemMsg = msg
    end
    return obj
end
Skill = Skill.new()