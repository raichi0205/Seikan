function SystemMsg(msg)
    print("lua SystemMsg:"..msg)
    CS.Star.Battle.BattleSystem.Instance.SystemMsg = msg
end

SystemMsg("skill used")