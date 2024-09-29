TestEnemy = {}
TestEnemy.new = function ()
    local enemyBridge = CS.Star.Character.EnemyLuaBridge.Instance -- もっと広い範囲のpublicにしてもいいかも
    obj = {}
    obj.Thinking = function ()
        print("Attack")
        enemyBridge:SelectAction("Attack")
    end
    return obj
end
TestEnemy = TestEnemy.new()