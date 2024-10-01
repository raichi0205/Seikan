local util = require 'xlua.util'

function async(func)
    local col = coroutine.create(func)  -- コルーチンの作成
    coroutine.resume(col)           -- コルーチンの実行
end

function await(co)
    return coroutine.yield(co)
end

-- コルーチンを開始する関数
function startCoroutine(routine)
    return csStartCoroutine(util.cs_generator(routine))
end

-- コルーチンを停止する関数
function stopCoroutine(coroutine)
    csStopCoroutine(coroutine)
end