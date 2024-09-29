TestEnemy = {}
TestEnemy.new = function ()
    obj = {}
    obj.Thinking = function ()
        print("Attack")
    end
    return obj
end
TestEnemy = TestEnemy.new()