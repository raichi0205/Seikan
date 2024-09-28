TestSkill = {}
TestSkill.new = function ()
    obj = {}
    obj.Action = function ()
        Skill.SystemMsg("skill used")        
    end
    return obj
end
TestSkill = TestSkill.new()