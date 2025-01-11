TestEnemy = {}
TestEnemy.new = function ()
    local battleSystem = CS.Star.Battle.BattleSystem.Instance
    local enemyBridge = CS.Star.Character.EnemyLuaBridge.Instance -- もっと広い範囲のpublicにしてもいいかも
    obj = {}
    obj.Thinking = function ()
        if(battleSystem.CurrentTurn % 2 == 0) then
            print("Attack")
            enemyBridge:SelectAction("Attack")
        else
            print("Skill")
            enemyBridge:SelectAction("Skill/EnemySkill")
        end
    end
    return obj
end
TestEnemy = TestEnemy.new()