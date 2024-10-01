#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class CysharpThreadingTasksUniTaskWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Cysharp.Threading.Tasks.UniTask);
			Utils.BeginObjectRegister(type, L, translator, 0, 5, 1, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAwaiter", _m_GetAwaiter);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SuppressCancellationThrow", _m_SuppressCancellationThrow);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ToString", _m_ToString);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Preserve", _m_Preserve);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AsAsyncUnitUniTask", _m_AsAsyncUnitUniTask);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "Status", _g_get_Status);
            
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 33, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "ToCoroutine", _m_ToCoroutine_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Yield", _m_Yield_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "NextFrame", _m_NextFrame_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "WaitForEndOfFrame", _m_WaitForEndOfFrame_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "WaitForFixedUpdate", _m_WaitForFixedUpdate_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "WaitForSeconds", _m_WaitForSeconds_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DelayFrame", _m_DelayFrame_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Delay", _m_Delay_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "FromException", _m_FromException_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "FromCanceled", _m_FromCanceled_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Create", _m_Create_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Lazy", _m_Lazy_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Void", _m_Void_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Action", _m_Action_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "UnityAction", _m_UnityAction_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Defer", _m_Defer_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Never", _m_Never_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "RunOnThreadPool", _m_RunOnThreadPool_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SwitchToMainThread", _m_SwitchToMainThread_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ReturnToMainThread", _m_ReturnToMainThread_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Post", _m_Post_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SwitchToThreadPool", _m_SwitchToThreadPool_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SwitchToTaskPool", _m_SwitchToTaskPool_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SwitchToSynchronizationContext", _m_SwitchToSynchronizationContext_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ReturnToSynchronizationContext", _m_ReturnToSynchronizationContext_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ReturnToCurrentSynchronizationContext", _m_ReturnToCurrentSynchronizationContext_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "WaitUntil", _m_WaitUntil_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "WaitWhile", _m_WaitWhile_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "WaitUntilCanceled", _m_WaitUntilCanceled_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "WhenAll", _m_WhenAll_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "WhenAny", _m_WhenAny_xlua_st_);
            
			
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "CompletedTask", Cysharp.Threading.Tasks.UniTask.CompletedTask);
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 3 && translator.Assignable<Cysharp.Threading.Tasks.IUniTaskSource>(L, 2) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3))
				{
					Cysharp.Threading.Tasks.IUniTaskSource _source = (Cysharp.Threading.Tasks.IUniTaskSource)translator.GetObject(L, 2, typeof(Cysharp.Threading.Tasks.IUniTaskSource));
					short _token = (short)LuaAPI.xlua_tointeger(L, 3);
					
					var gen_ret = new Cysharp.Threading.Tasks.UniTask(_source, _token);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
				if (LuaAPI.lua_gettop(L) == 1)
				{
				    translator.Push(L, default(Cysharp.Threading.Tasks.UniTask));
			        return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Cysharp.Threading.Tasks.UniTask constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToCoroutine_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.Func<Cysharp.Threading.Tasks.UniTask> _taskFactory = translator.GetDelegate<System.Func<Cysharp.Threading.Tasks.UniTask>>(L, 1);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.ToCoroutine( _taskFactory );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAwaiter(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Cysharp.Threading.Tasks.UniTask gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.GetAwaiter(  );
                        translator.Push(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SuppressCancellationThrow(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Cysharp.Threading.Tasks.UniTask gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.SuppressCancellationThrow(  );
                        translator.Push(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToString(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Cysharp.Threading.Tasks.UniTask gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.ToString(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Preserve(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Cysharp.Threading.Tasks.UniTask gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.Preserve(  );
                        translator.Push(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AsAsyncUnitUniTask(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Cysharp.Threading.Tasks.UniTask gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.AsAsyncUnitUniTask(  );
                        translator.Push(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Yield_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 0) 
                {
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.Yield(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<Cysharp.Threading.Tasks.PlayerLoopTiming>(L, 1)) 
                {
                    Cysharp.Threading.Tasks.PlayerLoopTiming _timing;translator.Get(L, 1, out _timing);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.Yield( _timing );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<System.Threading.CancellationToken>(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 1, out _cancellationToken);
                    bool _cancelImmediately = LuaAPI.lua_toboolean(L, 2);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.Yield( _cancellationToken, _cancelImmediately );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<System.Threading.CancellationToken>(L, 1)) 
                {
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 1, out _cancellationToken);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.Yield( _cancellationToken );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<Cysharp.Threading.Tasks.PlayerLoopTiming>(L, 1)&& translator.Assignable<System.Threading.CancellationToken>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    Cysharp.Threading.Tasks.PlayerLoopTiming _timing;translator.Get(L, 1, out _timing);
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 2, out _cancellationToken);
                    bool _cancelImmediately = LuaAPI.lua_toboolean(L, 3);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.Yield( _timing, _cancellationToken, _cancelImmediately );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<Cysharp.Threading.Tasks.PlayerLoopTiming>(L, 1)&& translator.Assignable<System.Threading.CancellationToken>(L, 2)) 
                {
                    Cysharp.Threading.Tasks.PlayerLoopTiming _timing;translator.Get(L, 1, out _timing);
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 2, out _cancellationToken);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.Yield( _timing, _cancellationToken );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Cysharp.Threading.Tasks.UniTask.Yield!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_NextFrame_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 0) 
                {
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.NextFrame(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<Cysharp.Threading.Tasks.PlayerLoopTiming>(L, 1)) 
                {
                    Cysharp.Threading.Tasks.PlayerLoopTiming _timing;translator.Get(L, 1, out _timing);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.NextFrame( _timing );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<System.Threading.CancellationToken>(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 1, out _cancellationToken);
                    bool _cancelImmediately = LuaAPI.lua_toboolean(L, 2);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.NextFrame( _cancellationToken, _cancelImmediately );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<System.Threading.CancellationToken>(L, 1)) 
                {
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 1, out _cancellationToken);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.NextFrame( _cancellationToken );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<Cysharp.Threading.Tasks.PlayerLoopTiming>(L, 1)&& translator.Assignable<System.Threading.CancellationToken>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    Cysharp.Threading.Tasks.PlayerLoopTiming _timing;translator.Get(L, 1, out _timing);
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 2, out _cancellationToken);
                    bool _cancelImmediately = LuaAPI.lua_toboolean(L, 3);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.NextFrame( _timing, _cancellationToken, _cancelImmediately );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<Cysharp.Threading.Tasks.PlayerLoopTiming>(L, 1)&& translator.Assignable<System.Threading.CancellationToken>(L, 2)) 
                {
                    Cysharp.Threading.Tasks.PlayerLoopTiming _timing;translator.Get(L, 1, out _timing);
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 2, out _cancellationToken);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.NextFrame( _timing, _cancellationToken );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Cysharp.Threading.Tasks.UniTask.NextFrame!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WaitForEndOfFrame_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& translator.Assignable<UnityEngine.MonoBehaviour>(L, 1)) 
                {
                    UnityEngine.MonoBehaviour _coroutineRunner = (UnityEngine.MonoBehaviour)translator.GetObject(L, 1, typeof(UnityEngine.MonoBehaviour));
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.WaitForEndOfFrame( _coroutineRunner );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.MonoBehaviour>(L, 1)&& translator.Assignable<System.Threading.CancellationToken>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.MonoBehaviour _coroutineRunner = (UnityEngine.MonoBehaviour)translator.GetObject(L, 1, typeof(UnityEngine.MonoBehaviour));
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 2, out _cancellationToken);
                    bool _cancelImmediately = LuaAPI.lua_toboolean(L, 3);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.WaitForEndOfFrame( _coroutineRunner, _cancellationToken, _cancelImmediately );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.MonoBehaviour>(L, 1)&& translator.Assignable<System.Threading.CancellationToken>(L, 2)) 
                {
                    UnityEngine.MonoBehaviour _coroutineRunner = (UnityEngine.MonoBehaviour)translator.GetObject(L, 1, typeof(UnityEngine.MonoBehaviour));
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 2, out _cancellationToken);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.WaitForEndOfFrame( _coroutineRunner, _cancellationToken );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Cysharp.Threading.Tasks.UniTask.WaitForEndOfFrame!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WaitForFixedUpdate_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 0) 
                {
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.WaitForFixedUpdate(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<System.Threading.CancellationToken>(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 1, out _cancellationToken);
                    bool _cancelImmediately = LuaAPI.lua_toboolean(L, 2);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.WaitForFixedUpdate( _cancellationToken, _cancelImmediately );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<System.Threading.CancellationToken>(L, 1)) 
                {
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 1, out _cancellationToken);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.WaitForFixedUpdate( _cancellationToken );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Cysharp.Threading.Tasks.UniTask.WaitForFixedUpdate!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WaitForSeconds_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)&& translator.Assignable<Cysharp.Threading.Tasks.PlayerLoopTiming>(L, 3)&& translator.Assignable<System.Threading.CancellationToken>(L, 4)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)) 
                {
                    float _duration = (float)LuaAPI.lua_tonumber(L, 1);
                    bool _ignoreTimeScale = LuaAPI.lua_toboolean(L, 2);
                    Cysharp.Threading.Tasks.PlayerLoopTiming _delayTiming;translator.Get(L, 3, out _delayTiming);
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 4, out _cancellationToken);
                    bool _cancelImmediately = LuaAPI.lua_toboolean(L, 5);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.WaitForSeconds( _duration, _ignoreTimeScale, _delayTiming, _cancellationToken, _cancelImmediately );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)&& translator.Assignable<Cysharp.Threading.Tasks.PlayerLoopTiming>(L, 3)&& translator.Assignable<System.Threading.CancellationToken>(L, 4)) 
                {
                    float _duration = (float)LuaAPI.lua_tonumber(L, 1);
                    bool _ignoreTimeScale = LuaAPI.lua_toboolean(L, 2);
                    Cysharp.Threading.Tasks.PlayerLoopTiming _delayTiming;translator.Get(L, 3, out _delayTiming);
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 4, out _cancellationToken);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.WaitForSeconds( _duration, _ignoreTimeScale, _delayTiming, _cancellationToken );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)&& translator.Assignable<Cysharp.Threading.Tasks.PlayerLoopTiming>(L, 3)) 
                {
                    float _duration = (float)LuaAPI.lua_tonumber(L, 1);
                    bool _ignoreTimeScale = LuaAPI.lua_toboolean(L, 2);
                    Cysharp.Threading.Tasks.PlayerLoopTiming _delayTiming;translator.Get(L, 3, out _delayTiming);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.WaitForSeconds( _duration, _ignoreTimeScale, _delayTiming );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    float _duration = (float)LuaAPI.lua_tonumber(L, 1);
                    bool _ignoreTimeScale = LuaAPI.lua_toboolean(L, 2);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.WaitForSeconds( _duration, _ignoreTimeScale );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    float _duration = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.WaitForSeconds( _duration );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)&& translator.Assignable<Cysharp.Threading.Tasks.PlayerLoopTiming>(L, 3)&& translator.Assignable<System.Threading.CancellationToken>(L, 4)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)) 
                {
                    int _duration = LuaAPI.xlua_tointeger(L, 1);
                    bool _ignoreTimeScale = LuaAPI.lua_toboolean(L, 2);
                    Cysharp.Threading.Tasks.PlayerLoopTiming _delayTiming;translator.Get(L, 3, out _delayTiming);
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 4, out _cancellationToken);
                    bool _cancelImmediately = LuaAPI.lua_toboolean(L, 5);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.WaitForSeconds( _duration, _ignoreTimeScale, _delayTiming, _cancellationToken, _cancelImmediately );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)&& translator.Assignable<Cysharp.Threading.Tasks.PlayerLoopTiming>(L, 3)&& translator.Assignable<System.Threading.CancellationToken>(L, 4)) 
                {
                    int _duration = LuaAPI.xlua_tointeger(L, 1);
                    bool _ignoreTimeScale = LuaAPI.lua_toboolean(L, 2);
                    Cysharp.Threading.Tasks.PlayerLoopTiming _delayTiming;translator.Get(L, 3, out _delayTiming);
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 4, out _cancellationToken);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.WaitForSeconds( _duration, _ignoreTimeScale, _delayTiming, _cancellationToken );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)&& translator.Assignable<Cysharp.Threading.Tasks.PlayerLoopTiming>(L, 3)) 
                {
                    int _duration = LuaAPI.xlua_tointeger(L, 1);
                    bool _ignoreTimeScale = LuaAPI.lua_toboolean(L, 2);
                    Cysharp.Threading.Tasks.PlayerLoopTiming _delayTiming;translator.Get(L, 3, out _delayTiming);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.WaitForSeconds( _duration, _ignoreTimeScale, _delayTiming );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    int _duration = LuaAPI.xlua_tointeger(L, 1);
                    bool _ignoreTimeScale = LuaAPI.lua_toboolean(L, 2);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.WaitForSeconds( _duration, _ignoreTimeScale );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    int _duration = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.WaitForSeconds( _duration );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Cysharp.Threading.Tasks.UniTask.WaitForSeconds!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DelayFrame_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<Cysharp.Threading.Tasks.PlayerLoopTiming>(L, 2)&& translator.Assignable<System.Threading.CancellationToken>(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    int _delayFrameCount = LuaAPI.xlua_tointeger(L, 1);
                    Cysharp.Threading.Tasks.PlayerLoopTiming _delayTiming;translator.Get(L, 2, out _delayTiming);
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 3, out _cancellationToken);
                    bool _cancelImmediately = LuaAPI.lua_toboolean(L, 4);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.DelayFrame( _delayFrameCount, _delayTiming, _cancellationToken, _cancelImmediately );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<Cysharp.Threading.Tasks.PlayerLoopTiming>(L, 2)&& translator.Assignable<System.Threading.CancellationToken>(L, 3)) 
                {
                    int _delayFrameCount = LuaAPI.xlua_tointeger(L, 1);
                    Cysharp.Threading.Tasks.PlayerLoopTiming _delayTiming;translator.Get(L, 2, out _delayTiming);
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 3, out _cancellationToken);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.DelayFrame( _delayFrameCount, _delayTiming, _cancellationToken );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<Cysharp.Threading.Tasks.PlayerLoopTiming>(L, 2)) 
                {
                    int _delayFrameCount = LuaAPI.xlua_tointeger(L, 1);
                    Cysharp.Threading.Tasks.PlayerLoopTiming _delayTiming;translator.Get(L, 2, out _delayTiming);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.DelayFrame( _delayFrameCount, _delayTiming );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    int _delayFrameCount = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.DelayFrame( _delayFrameCount );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Cysharp.Threading.Tasks.UniTask.DelayFrame!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Delay_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)&& translator.Assignable<Cysharp.Threading.Tasks.PlayerLoopTiming>(L, 3)&& translator.Assignable<System.Threading.CancellationToken>(L, 4)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)) 
                {
                    int _millisecondsDelay = LuaAPI.xlua_tointeger(L, 1);
                    bool _ignoreTimeScale = LuaAPI.lua_toboolean(L, 2);
                    Cysharp.Threading.Tasks.PlayerLoopTiming _delayTiming;translator.Get(L, 3, out _delayTiming);
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 4, out _cancellationToken);
                    bool _cancelImmediately = LuaAPI.lua_toboolean(L, 5);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.Delay( _millisecondsDelay, _ignoreTimeScale, _delayTiming, _cancellationToken, _cancelImmediately );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)&& translator.Assignable<Cysharp.Threading.Tasks.PlayerLoopTiming>(L, 3)&& translator.Assignable<System.Threading.CancellationToken>(L, 4)) 
                {
                    int _millisecondsDelay = LuaAPI.xlua_tointeger(L, 1);
                    bool _ignoreTimeScale = LuaAPI.lua_toboolean(L, 2);
                    Cysharp.Threading.Tasks.PlayerLoopTiming _delayTiming;translator.Get(L, 3, out _delayTiming);
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 4, out _cancellationToken);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.Delay( _millisecondsDelay, _ignoreTimeScale, _delayTiming, _cancellationToken );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)&& translator.Assignable<Cysharp.Threading.Tasks.PlayerLoopTiming>(L, 3)) 
                {
                    int _millisecondsDelay = LuaAPI.xlua_tointeger(L, 1);
                    bool _ignoreTimeScale = LuaAPI.lua_toboolean(L, 2);
                    Cysharp.Threading.Tasks.PlayerLoopTiming _delayTiming;translator.Get(L, 3, out _delayTiming);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.Delay( _millisecondsDelay, _ignoreTimeScale, _delayTiming );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    int _millisecondsDelay = LuaAPI.xlua_tointeger(L, 1);
                    bool _ignoreTimeScale = LuaAPI.lua_toboolean(L, 2);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.Delay( _millisecondsDelay, _ignoreTimeScale );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    int _millisecondsDelay = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.Delay( _millisecondsDelay );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 5&& translator.Assignable<System.TimeSpan>(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)&& translator.Assignable<Cysharp.Threading.Tasks.PlayerLoopTiming>(L, 3)&& translator.Assignable<System.Threading.CancellationToken>(L, 4)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)) 
                {
                    System.TimeSpan _delayTimeSpan;translator.Get(L, 1, out _delayTimeSpan);
                    bool _ignoreTimeScale = LuaAPI.lua_toboolean(L, 2);
                    Cysharp.Threading.Tasks.PlayerLoopTiming _delayTiming;translator.Get(L, 3, out _delayTiming);
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 4, out _cancellationToken);
                    bool _cancelImmediately = LuaAPI.lua_toboolean(L, 5);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.Delay( _delayTimeSpan, _ignoreTimeScale, _delayTiming, _cancellationToken, _cancelImmediately );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<System.TimeSpan>(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)&& translator.Assignable<Cysharp.Threading.Tasks.PlayerLoopTiming>(L, 3)&& translator.Assignable<System.Threading.CancellationToken>(L, 4)) 
                {
                    System.TimeSpan _delayTimeSpan;translator.Get(L, 1, out _delayTimeSpan);
                    bool _ignoreTimeScale = LuaAPI.lua_toboolean(L, 2);
                    Cysharp.Threading.Tasks.PlayerLoopTiming _delayTiming;translator.Get(L, 3, out _delayTiming);
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 4, out _cancellationToken);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.Delay( _delayTimeSpan, _ignoreTimeScale, _delayTiming, _cancellationToken );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<System.TimeSpan>(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)&& translator.Assignable<Cysharp.Threading.Tasks.PlayerLoopTiming>(L, 3)) 
                {
                    System.TimeSpan _delayTimeSpan;translator.Get(L, 1, out _delayTimeSpan);
                    bool _ignoreTimeScale = LuaAPI.lua_toboolean(L, 2);
                    Cysharp.Threading.Tasks.PlayerLoopTiming _delayTiming;translator.Get(L, 3, out _delayTiming);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.Delay( _delayTimeSpan, _ignoreTimeScale, _delayTiming );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<System.TimeSpan>(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    System.TimeSpan _delayTimeSpan;translator.Get(L, 1, out _delayTimeSpan);
                    bool _ignoreTimeScale = LuaAPI.lua_toboolean(L, 2);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.Delay( _delayTimeSpan, _ignoreTimeScale );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<System.TimeSpan>(L, 1)) 
                {
                    System.TimeSpan _delayTimeSpan;translator.Get(L, 1, out _delayTimeSpan);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.Delay( _delayTimeSpan );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<Cysharp.Threading.Tasks.DelayType>(L, 2)&& translator.Assignable<Cysharp.Threading.Tasks.PlayerLoopTiming>(L, 3)&& translator.Assignable<System.Threading.CancellationToken>(L, 4)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)) 
                {
                    int _millisecondsDelay = LuaAPI.xlua_tointeger(L, 1);
                    Cysharp.Threading.Tasks.DelayType _delayType;translator.Get(L, 2, out _delayType);
                    Cysharp.Threading.Tasks.PlayerLoopTiming _delayTiming;translator.Get(L, 3, out _delayTiming);
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 4, out _cancellationToken);
                    bool _cancelImmediately = LuaAPI.lua_toboolean(L, 5);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.Delay( _millisecondsDelay, _delayType, _delayTiming, _cancellationToken, _cancelImmediately );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<Cysharp.Threading.Tasks.DelayType>(L, 2)&& translator.Assignable<Cysharp.Threading.Tasks.PlayerLoopTiming>(L, 3)&& translator.Assignable<System.Threading.CancellationToken>(L, 4)) 
                {
                    int _millisecondsDelay = LuaAPI.xlua_tointeger(L, 1);
                    Cysharp.Threading.Tasks.DelayType _delayType;translator.Get(L, 2, out _delayType);
                    Cysharp.Threading.Tasks.PlayerLoopTiming _delayTiming;translator.Get(L, 3, out _delayTiming);
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 4, out _cancellationToken);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.Delay( _millisecondsDelay, _delayType, _delayTiming, _cancellationToken );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<Cysharp.Threading.Tasks.DelayType>(L, 2)&& translator.Assignable<Cysharp.Threading.Tasks.PlayerLoopTiming>(L, 3)) 
                {
                    int _millisecondsDelay = LuaAPI.xlua_tointeger(L, 1);
                    Cysharp.Threading.Tasks.DelayType _delayType;translator.Get(L, 2, out _delayType);
                    Cysharp.Threading.Tasks.PlayerLoopTiming _delayTiming;translator.Get(L, 3, out _delayTiming);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.Delay( _millisecondsDelay, _delayType, _delayTiming );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<Cysharp.Threading.Tasks.DelayType>(L, 2)) 
                {
                    int _millisecondsDelay = LuaAPI.xlua_tointeger(L, 1);
                    Cysharp.Threading.Tasks.DelayType _delayType;translator.Get(L, 2, out _delayType);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.Delay( _millisecondsDelay, _delayType );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 5&& translator.Assignable<System.TimeSpan>(L, 1)&& translator.Assignable<Cysharp.Threading.Tasks.DelayType>(L, 2)&& translator.Assignable<Cysharp.Threading.Tasks.PlayerLoopTiming>(L, 3)&& translator.Assignable<System.Threading.CancellationToken>(L, 4)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)) 
                {
                    System.TimeSpan _delayTimeSpan;translator.Get(L, 1, out _delayTimeSpan);
                    Cysharp.Threading.Tasks.DelayType _delayType;translator.Get(L, 2, out _delayType);
                    Cysharp.Threading.Tasks.PlayerLoopTiming _delayTiming;translator.Get(L, 3, out _delayTiming);
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 4, out _cancellationToken);
                    bool _cancelImmediately = LuaAPI.lua_toboolean(L, 5);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.Delay( _delayTimeSpan, _delayType, _delayTiming, _cancellationToken, _cancelImmediately );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<System.TimeSpan>(L, 1)&& translator.Assignable<Cysharp.Threading.Tasks.DelayType>(L, 2)&& translator.Assignable<Cysharp.Threading.Tasks.PlayerLoopTiming>(L, 3)&& translator.Assignable<System.Threading.CancellationToken>(L, 4)) 
                {
                    System.TimeSpan _delayTimeSpan;translator.Get(L, 1, out _delayTimeSpan);
                    Cysharp.Threading.Tasks.DelayType _delayType;translator.Get(L, 2, out _delayType);
                    Cysharp.Threading.Tasks.PlayerLoopTiming _delayTiming;translator.Get(L, 3, out _delayTiming);
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 4, out _cancellationToken);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.Delay( _delayTimeSpan, _delayType, _delayTiming, _cancellationToken );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<System.TimeSpan>(L, 1)&& translator.Assignable<Cysharp.Threading.Tasks.DelayType>(L, 2)&& translator.Assignable<Cysharp.Threading.Tasks.PlayerLoopTiming>(L, 3)) 
                {
                    System.TimeSpan _delayTimeSpan;translator.Get(L, 1, out _delayTimeSpan);
                    Cysharp.Threading.Tasks.DelayType _delayType;translator.Get(L, 2, out _delayType);
                    Cysharp.Threading.Tasks.PlayerLoopTiming _delayTiming;translator.Get(L, 3, out _delayTiming);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.Delay( _delayTimeSpan, _delayType, _delayTiming );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<System.TimeSpan>(L, 1)&& translator.Assignable<Cysharp.Threading.Tasks.DelayType>(L, 2)) 
                {
                    System.TimeSpan _delayTimeSpan;translator.Get(L, 1, out _delayTimeSpan);
                    Cysharp.Threading.Tasks.DelayType _delayType;translator.Get(L, 2, out _delayType);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.Delay( _delayTimeSpan, _delayType );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Cysharp.Threading.Tasks.UniTask.Delay!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FromException_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.Exception _ex = (System.Exception)translator.GetObject(L, 1, typeof(System.Exception));
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.FromException( _ex );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FromCanceled_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& translator.Assignable<System.Threading.CancellationToken>(L, 1)) 
                {
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 1, out _cancellationToken);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.FromCanceled( _cancellationToken );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 0) 
                {
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.FromCanceled(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Cysharp.Threading.Tasks.UniTask.FromCanceled!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Create_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& translator.Assignable<System.Func<Cysharp.Threading.Tasks.UniTask>>(L, 1)) 
                {
                    System.Func<Cysharp.Threading.Tasks.UniTask> _factory = translator.GetDelegate<System.Func<Cysharp.Threading.Tasks.UniTask>>(L, 1);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.Create( _factory );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<System.Func<System.Threading.CancellationToken, Cysharp.Threading.Tasks.UniTask>>(L, 1)&& translator.Assignable<System.Threading.CancellationToken>(L, 2)) 
                {
                    System.Func<System.Threading.CancellationToken, Cysharp.Threading.Tasks.UniTask> _factory = translator.GetDelegate<System.Func<System.Threading.CancellationToken, Cysharp.Threading.Tasks.UniTask>>(L, 1);
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 2, out _cancellationToken);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.Create( _factory, _cancellationToken );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Cysharp.Threading.Tasks.UniTask.Create!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Lazy_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.Func<Cysharp.Threading.Tasks.UniTask> _factory = translator.GetDelegate<System.Func<Cysharp.Threading.Tasks.UniTask>>(L, 1);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.Lazy( _factory );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Void_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& translator.Assignable<System.Func<Cysharp.Threading.Tasks.UniTaskVoid>>(L, 1)) 
                {
                    System.Func<Cysharp.Threading.Tasks.UniTaskVoid> _asyncAction = translator.GetDelegate<System.Func<Cysharp.Threading.Tasks.UniTaskVoid>>(L, 1);
                    
                    Cysharp.Threading.Tasks.UniTask.Void( _asyncAction );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<System.Func<System.Threading.CancellationToken, Cysharp.Threading.Tasks.UniTaskVoid>>(L, 1)&& translator.Assignable<System.Threading.CancellationToken>(L, 2)) 
                {
                    System.Func<System.Threading.CancellationToken, Cysharp.Threading.Tasks.UniTaskVoid> _asyncAction = translator.GetDelegate<System.Func<System.Threading.CancellationToken, Cysharp.Threading.Tasks.UniTaskVoid>>(L, 1);
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 2, out _cancellationToken);
                    
                    Cysharp.Threading.Tasks.UniTask.Void( _asyncAction, _cancellationToken );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Cysharp.Threading.Tasks.UniTask.Void!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Action_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& translator.Assignable<System.Func<Cysharp.Threading.Tasks.UniTaskVoid>>(L, 1)) 
                {
                    System.Func<Cysharp.Threading.Tasks.UniTaskVoid> _asyncAction = translator.GetDelegate<System.Func<Cysharp.Threading.Tasks.UniTaskVoid>>(L, 1);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.Action( _asyncAction );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<System.Func<System.Threading.CancellationToken, Cysharp.Threading.Tasks.UniTaskVoid>>(L, 1)&& translator.Assignable<System.Threading.CancellationToken>(L, 2)) 
                {
                    System.Func<System.Threading.CancellationToken, Cysharp.Threading.Tasks.UniTaskVoid> _asyncAction = translator.GetDelegate<System.Func<System.Threading.CancellationToken, Cysharp.Threading.Tasks.UniTaskVoid>>(L, 1);
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 2, out _cancellationToken);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.Action( _asyncAction, _cancellationToken );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Cysharp.Threading.Tasks.UniTask.Action!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UnityAction_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& translator.Assignable<System.Func<Cysharp.Threading.Tasks.UniTaskVoid>>(L, 1)) 
                {
                    System.Func<Cysharp.Threading.Tasks.UniTaskVoid> _asyncAction = translator.GetDelegate<System.Func<Cysharp.Threading.Tasks.UniTaskVoid>>(L, 1);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.UnityAction( _asyncAction );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<System.Func<System.Threading.CancellationToken, Cysharp.Threading.Tasks.UniTaskVoid>>(L, 1)&& translator.Assignable<System.Threading.CancellationToken>(L, 2)) 
                {
                    System.Func<System.Threading.CancellationToken, Cysharp.Threading.Tasks.UniTaskVoid> _asyncAction = translator.GetDelegate<System.Func<System.Threading.CancellationToken, Cysharp.Threading.Tasks.UniTaskVoid>>(L, 1);
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 2, out _cancellationToken);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.UnityAction( _asyncAction, _cancellationToken );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Cysharp.Threading.Tasks.UniTask.UnityAction!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Defer_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.Func<Cysharp.Threading.Tasks.UniTask> _factory = translator.GetDelegate<System.Func<Cysharp.Threading.Tasks.UniTask>>(L, 1);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.Defer( _factory );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Never_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 1, out _cancellationToken);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.Never( _cancellationToken );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RunOnThreadPool_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<System.Action>(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)&& translator.Assignable<System.Threading.CancellationToken>(L, 3)) 
                {
                    System.Action _action = translator.GetDelegate<System.Action>(L, 1);
                    bool _configureAwait = LuaAPI.lua_toboolean(L, 2);
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 3, out _cancellationToken);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.RunOnThreadPool( _action, _configureAwait, _cancellationToken );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<System.Action>(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    System.Action _action = translator.GetDelegate<System.Action>(L, 1);
                    bool _configureAwait = LuaAPI.lua_toboolean(L, 2);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.RunOnThreadPool( _action, _configureAwait );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<System.Action>(L, 1)) 
                {
                    System.Action _action = translator.GetDelegate<System.Action>(L, 1);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.RunOnThreadPool( _action );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<System.Func<Cysharp.Threading.Tasks.UniTask>>(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)&& translator.Assignable<System.Threading.CancellationToken>(L, 3)) 
                {
                    System.Func<Cysharp.Threading.Tasks.UniTask> _action = translator.GetDelegate<System.Func<Cysharp.Threading.Tasks.UniTask>>(L, 1);
                    bool _configureAwait = LuaAPI.lua_toboolean(L, 2);
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 3, out _cancellationToken);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.RunOnThreadPool( _action, _configureAwait, _cancellationToken );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<System.Func<Cysharp.Threading.Tasks.UniTask>>(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    System.Func<Cysharp.Threading.Tasks.UniTask> _action = translator.GetDelegate<System.Func<Cysharp.Threading.Tasks.UniTask>>(L, 1);
                    bool _configureAwait = LuaAPI.lua_toboolean(L, 2);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.RunOnThreadPool( _action, _configureAwait );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<System.Func<Cysharp.Threading.Tasks.UniTask>>(L, 1)) 
                {
                    System.Func<Cysharp.Threading.Tasks.UniTask> _action = translator.GetDelegate<System.Func<Cysharp.Threading.Tasks.UniTask>>(L, 1);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.RunOnThreadPool( _action );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<System.Action<object>>(L, 1)&& translator.Assignable<object>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)&& translator.Assignable<System.Threading.CancellationToken>(L, 4)) 
                {
                    System.Action<object> _action = translator.GetDelegate<System.Action<object>>(L, 1);
                    object _state = translator.GetObject(L, 2, typeof(object));
                    bool _configureAwait = LuaAPI.lua_toboolean(L, 3);
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 4, out _cancellationToken);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.RunOnThreadPool( _action, _state, _configureAwait, _cancellationToken );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<System.Action<object>>(L, 1)&& translator.Assignable<object>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    System.Action<object> _action = translator.GetDelegate<System.Action<object>>(L, 1);
                    object _state = translator.GetObject(L, 2, typeof(object));
                    bool _configureAwait = LuaAPI.lua_toboolean(L, 3);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.RunOnThreadPool( _action, _state, _configureAwait );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<System.Action<object>>(L, 1)&& translator.Assignable<object>(L, 2)) 
                {
                    System.Action<object> _action = translator.GetDelegate<System.Action<object>>(L, 1);
                    object _state = translator.GetObject(L, 2, typeof(object));
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.RunOnThreadPool( _action, _state );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<System.Func<object, Cysharp.Threading.Tasks.UniTask>>(L, 1)&& translator.Assignable<object>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)&& translator.Assignable<System.Threading.CancellationToken>(L, 4)) 
                {
                    System.Func<object, Cysharp.Threading.Tasks.UniTask> _action = translator.GetDelegate<System.Func<object, Cysharp.Threading.Tasks.UniTask>>(L, 1);
                    object _state = translator.GetObject(L, 2, typeof(object));
                    bool _configureAwait = LuaAPI.lua_toboolean(L, 3);
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 4, out _cancellationToken);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.RunOnThreadPool( _action, _state, _configureAwait, _cancellationToken );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<System.Func<object, Cysharp.Threading.Tasks.UniTask>>(L, 1)&& translator.Assignable<object>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    System.Func<object, Cysharp.Threading.Tasks.UniTask> _action = translator.GetDelegate<System.Func<object, Cysharp.Threading.Tasks.UniTask>>(L, 1);
                    object _state = translator.GetObject(L, 2, typeof(object));
                    bool _configureAwait = LuaAPI.lua_toboolean(L, 3);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.RunOnThreadPool( _action, _state, _configureAwait );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<System.Func<object, Cysharp.Threading.Tasks.UniTask>>(L, 1)&& translator.Assignable<object>(L, 2)) 
                {
                    System.Func<object, Cysharp.Threading.Tasks.UniTask> _action = translator.GetDelegate<System.Func<object, Cysharp.Threading.Tasks.UniTask>>(L, 1);
                    object _state = translator.GetObject(L, 2, typeof(object));
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.RunOnThreadPool( _action, _state );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Cysharp.Threading.Tasks.UniTask.RunOnThreadPool!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SwitchToMainThread_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& translator.Assignable<System.Threading.CancellationToken>(L, 1)) 
                {
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 1, out _cancellationToken);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.SwitchToMainThread( _cancellationToken );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 0) 
                {
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.SwitchToMainThread(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<Cysharp.Threading.Tasks.PlayerLoopTiming>(L, 1)&& translator.Assignable<System.Threading.CancellationToken>(L, 2)) 
                {
                    Cysharp.Threading.Tasks.PlayerLoopTiming _timing;translator.Get(L, 1, out _timing);
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 2, out _cancellationToken);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.SwitchToMainThread( _timing, _cancellationToken );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<Cysharp.Threading.Tasks.PlayerLoopTiming>(L, 1)) 
                {
                    Cysharp.Threading.Tasks.PlayerLoopTiming _timing;translator.Get(L, 1, out _timing);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.SwitchToMainThread( _timing );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Cysharp.Threading.Tasks.UniTask.SwitchToMainThread!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReturnToMainThread_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& translator.Assignable<System.Threading.CancellationToken>(L, 1)) 
                {
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 1, out _cancellationToken);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.ReturnToMainThread( _cancellationToken );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 0) 
                {
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.ReturnToMainThread(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<Cysharp.Threading.Tasks.PlayerLoopTiming>(L, 1)&& translator.Assignable<System.Threading.CancellationToken>(L, 2)) 
                {
                    Cysharp.Threading.Tasks.PlayerLoopTiming _timing;translator.Get(L, 1, out _timing);
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 2, out _cancellationToken);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.ReturnToMainThread( _timing, _cancellationToken );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<Cysharp.Threading.Tasks.PlayerLoopTiming>(L, 1)) 
                {
                    Cysharp.Threading.Tasks.PlayerLoopTiming _timing;translator.Get(L, 1, out _timing);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.ReturnToMainThread( _timing );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Cysharp.Threading.Tasks.UniTask.ReturnToMainThread!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Post_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<System.Action>(L, 1)&& translator.Assignable<Cysharp.Threading.Tasks.PlayerLoopTiming>(L, 2)) 
                {
                    System.Action _action = translator.GetDelegate<System.Action>(L, 1);
                    Cysharp.Threading.Tasks.PlayerLoopTiming _timing;translator.Get(L, 2, out _timing);
                    
                    Cysharp.Threading.Tasks.UniTask.Post( _action, _timing );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 1&& translator.Assignable<System.Action>(L, 1)) 
                {
                    System.Action _action = translator.GetDelegate<System.Action>(L, 1);
                    
                    Cysharp.Threading.Tasks.UniTask.Post( _action );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Cysharp.Threading.Tasks.UniTask.Post!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SwitchToThreadPool_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.SwitchToThreadPool(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SwitchToTaskPool_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.SwitchToTaskPool(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SwitchToSynchronizationContext_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<System.Threading.SynchronizationContext>(L, 1)&& translator.Assignable<System.Threading.CancellationToken>(L, 2)) 
                {
                    System.Threading.SynchronizationContext _synchronizationContext = (System.Threading.SynchronizationContext)translator.GetObject(L, 1, typeof(System.Threading.SynchronizationContext));
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 2, out _cancellationToken);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.SwitchToSynchronizationContext( _synchronizationContext, _cancellationToken );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<System.Threading.SynchronizationContext>(L, 1)) 
                {
                    System.Threading.SynchronizationContext _synchronizationContext = (System.Threading.SynchronizationContext)translator.GetObject(L, 1, typeof(System.Threading.SynchronizationContext));
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.SwitchToSynchronizationContext( _synchronizationContext );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Cysharp.Threading.Tasks.UniTask.SwitchToSynchronizationContext!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReturnToSynchronizationContext_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<System.Threading.SynchronizationContext>(L, 1)&& translator.Assignable<System.Threading.CancellationToken>(L, 2)) 
                {
                    System.Threading.SynchronizationContext _synchronizationContext = (System.Threading.SynchronizationContext)translator.GetObject(L, 1, typeof(System.Threading.SynchronizationContext));
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 2, out _cancellationToken);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.ReturnToSynchronizationContext( _synchronizationContext, _cancellationToken );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<System.Threading.SynchronizationContext>(L, 1)) 
                {
                    System.Threading.SynchronizationContext _synchronizationContext = (System.Threading.SynchronizationContext)translator.GetObject(L, 1, typeof(System.Threading.SynchronizationContext));
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.ReturnToSynchronizationContext( _synchronizationContext );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Cysharp.Threading.Tasks.UniTask.ReturnToSynchronizationContext!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReturnToCurrentSynchronizationContext_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 1)&& translator.Assignable<System.Threading.CancellationToken>(L, 2)) 
                {
                    bool _dontPostWhenSameContext = LuaAPI.lua_toboolean(L, 1);
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 2, out _cancellationToken);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.ReturnToCurrentSynchronizationContext( _dontPostWhenSameContext, _cancellationToken );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 1)) 
                {
                    bool _dontPostWhenSameContext = LuaAPI.lua_toboolean(L, 1);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.ReturnToCurrentSynchronizationContext( _dontPostWhenSameContext );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 0) 
                {
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.ReturnToCurrentSynchronizationContext(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Cysharp.Threading.Tasks.UniTask.ReturnToCurrentSynchronizationContext!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WaitUntil_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& translator.Assignable<System.Func<bool>>(L, 1)&& translator.Assignable<Cysharp.Threading.Tasks.PlayerLoopTiming>(L, 2)&& translator.Assignable<System.Threading.CancellationToken>(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    System.Func<bool> _predicate = translator.GetDelegate<System.Func<bool>>(L, 1);
                    Cysharp.Threading.Tasks.PlayerLoopTiming _timing;translator.Get(L, 2, out _timing);
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 3, out _cancellationToken);
                    bool _cancelImmediately = LuaAPI.lua_toboolean(L, 4);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.WaitUntil( _predicate, _timing, _cancellationToken, _cancelImmediately );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<System.Func<bool>>(L, 1)&& translator.Assignable<Cysharp.Threading.Tasks.PlayerLoopTiming>(L, 2)&& translator.Assignable<System.Threading.CancellationToken>(L, 3)) 
                {
                    System.Func<bool> _predicate = translator.GetDelegate<System.Func<bool>>(L, 1);
                    Cysharp.Threading.Tasks.PlayerLoopTiming _timing;translator.Get(L, 2, out _timing);
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 3, out _cancellationToken);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.WaitUntil( _predicate, _timing, _cancellationToken );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<System.Func<bool>>(L, 1)&& translator.Assignable<Cysharp.Threading.Tasks.PlayerLoopTiming>(L, 2)) 
                {
                    System.Func<bool> _predicate = translator.GetDelegate<System.Func<bool>>(L, 1);
                    Cysharp.Threading.Tasks.PlayerLoopTiming _timing;translator.Get(L, 2, out _timing);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.WaitUntil( _predicate, _timing );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<System.Func<bool>>(L, 1)) 
                {
                    System.Func<bool> _predicate = translator.GetDelegate<System.Func<bool>>(L, 1);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.WaitUntil( _predicate );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Cysharp.Threading.Tasks.UniTask.WaitUntil!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WaitWhile_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& translator.Assignable<System.Func<bool>>(L, 1)&& translator.Assignable<Cysharp.Threading.Tasks.PlayerLoopTiming>(L, 2)&& translator.Assignable<System.Threading.CancellationToken>(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    System.Func<bool> _predicate = translator.GetDelegate<System.Func<bool>>(L, 1);
                    Cysharp.Threading.Tasks.PlayerLoopTiming _timing;translator.Get(L, 2, out _timing);
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 3, out _cancellationToken);
                    bool _cancelImmediately = LuaAPI.lua_toboolean(L, 4);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.WaitWhile( _predicate, _timing, _cancellationToken, _cancelImmediately );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<System.Func<bool>>(L, 1)&& translator.Assignable<Cysharp.Threading.Tasks.PlayerLoopTiming>(L, 2)&& translator.Assignable<System.Threading.CancellationToken>(L, 3)) 
                {
                    System.Func<bool> _predicate = translator.GetDelegate<System.Func<bool>>(L, 1);
                    Cysharp.Threading.Tasks.PlayerLoopTiming _timing;translator.Get(L, 2, out _timing);
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 3, out _cancellationToken);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.WaitWhile( _predicate, _timing, _cancellationToken );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<System.Func<bool>>(L, 1)&& translator.Assignable<Cysharp.Threading.Tasks.PlayerLoopTiming>(L, 2)) 
                {
                    System.Func<bool> _predicate = translator.GetDelegate<System.Func<bool>>(L, 1);
                    Cysharp.Threading.Tasks.PlayerLoopTiming _timing;translator.Get(L, 2, out _timing);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.WaitWhile( _predicate, _timing );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<System.Func<bool>>(L, 1)) 
                {
                    System.Func<bool> _predicate = translator.GetDelegate<System.Func<bool>>(L, 1);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.WaitWhile( _predicate );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Cysharp.Threading.Tasks.UniTask.WaitWhile!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WaitUntilCanceled_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<System.Threading.CancellationToken>(L, 1)&& translator.Assignable<Cysharp.Threading.Tasks.PlayerLoopTiming>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 1, out _cancellationToken);
                    Cysharp.Threading.Tasks.PlayerLoopTiming _timing;translator.Get(L, 2, out _timing);
                    bool _completeImmediately = LuaAPI.lua_toboolean(L, 3);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.WaitUntilCanceled( _cancellationToken, _timing, _completeImmediately );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<System.Threading.CancellationToken>(L, 1)&& translator.Assignable<Cysharp.Threading.Tasks.PlayerLoopTiming>(L, 2)) 
                {
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 1, out _cancellationToken);
                    Cysharp.Threading.Tasks.PlayerLoopTiming _timing;translator.Get(L, 2, out _timing);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.WaitUntilCanceled( _cancellationToken, _timing );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<System.Threading.CancellationToken>(L, 1)) 
                {
                    System.Threading.CancellationToken _cancellationToken;translator.Get(L, 1, out _cancellationToken);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.WaitUntilCanceled( _cancellationToken );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Cysharp.Threading.Tasks.UniTask.WaitUntilCanceled!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WhenAll_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count >= 0&& (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 1) || translator.Assignable<Cysharp.Threading.Tasks.UniTask>(L, 1))) 
                {
                    Cysharp.Threading.Tasks.UniTask[] _tasks = translator.GetParams<Cysharp.Threading.Tasks.UniTask>(L, 1);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.WhenAll( _tasks );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<System.Collections.Generic.IEnumerable<Cysharp.Threading.Tasks.UniTask>>(L, 1)) 
                {
                    System.Collections.Generic.IEnumerable<Cysharp.Threading.Tasks.UniTask> _tasks = (System.Collections.Generic.IEnumerable<Cysharp.Threading.Tasks.UniTask>)translator.GetObject(L, 1, typeof(System.Collections.Generic.IEnumerable<Cysharp.Threading.Tasks.UniTask>));
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.WhenAll( _tasks );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Cysharp.Threading.Tasks.UniTask.WhenAll!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WhenAny_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count >= 0&& (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 1) || translator.Assignable<Cysharp.Threading.Tasks.UniTask>(L, 1))) 
                {
                    Cysharp.Threading.Tasks.UniTask[] _tasks = translator.GetParams<Cysharp.Threading.Tasks.UniTask>(L, 1);
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.WhenAny( _tasks );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<System.Collections.Generic.IEnumerable<Cysharp.Threading.Tasks.UniTask>>(L, 1)) 
                {
                    System.Collections.Generic.IEnumerable<Cysharp.Threading.Tasks.UniTask> _tasks = (System.Collections.Generic.IEnumerable<Cysharp.Threading.Tasks.UniTask>)translator.GetObject(L, 1, typeof(System.Collections.Generic.IEnumerable<Cysharp.Threading.Tasks.UniTask>));
                    
                        var gen_ret = Cysharp.Threading.Tasks.UniTask.WhenAny( _tasks );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Cysharp.Threading.Tasks.UniTask.WhenAny!");
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Status(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Cysharp.Threading.Tasks.UniTask gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.Push(L, gen_to_be_invoked.Status);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
