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
    public class EffekseerEffekseerEmitterWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Effekseer.EffekseerEmitter);
			Utils.BeginObjectRegister(type, L, translator, 0, 17, 12, 10);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Play", _m_Play);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsEnd", _m_IsEnd);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Stop", _m_Stop);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "StopImmediate", _m_StopImmediate);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "StopRoot", _m_StopRoot);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetAllColor", _m_SetAllColor);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetTargetLocation", _m_SetTargetLocation);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetDynamicInput", _m_GetDynamicInput);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetDynamicInput", _m_SetDynamicInput);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetDynamicInputWithWorldPosition", _m_SetDynamicInputWithWorldPosition);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetDynamicInputWithLocalPosition", _m_SetDynamicInputWithLocalPosition);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetDynamicInputWithWorldDistance", _m_SetDynamicInputWithWorldDistance);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetDynamicInputWithLocalDistance", _m_SetDynamicInputWithLocalDistance);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SendTrigger", _m_SendTrigger);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdateSelf", _m_UpdateSelf);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Update", _m_Update);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "FixedUpdate", _m_FixedUpdate);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "paused", _g_get_paused);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "shown", _g_get_shown);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "speed", _g_get_speed);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "exists", _g_get_exists);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "instanceCount", _g_get_instanceCount);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "TimingOfUpdate", _g_get_TimingOfUpdate);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EmitterScale", _g_get_EmitterScale);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "TimeScale", _g_get_TimeScale);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "effectAsset", _g_get_effectAsset);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "playOnStart", _g_get_playOnStart);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "isLooping", _g_get_isLooping);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "handles", _g_get_handles);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "paused", _s_set_paused);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "shown", _s_set_shown);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "speed", _s_set_speed);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "TimingOfUpdate", _s_set_TimingOfUpdate);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "EmitterScale", _s_set_EmitterScale);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "TimeScale", _s_set_TimeScale);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "effectAsset", _s_set_effectAsset);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "playOnStart", _s_set_playOnStart);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "isLooping", _s_set_isLooping);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "handles", _s_set_handles);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					var gen_ret = new Effekseer.EffekseerEmitter();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Effekseer.EffekseerEmitter constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Play(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Effekseer.EffekseerEmitter gen_to_be_invoked = (Effekseer.EffekseerEmitter)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                        var gen_ret = gen_to_be_invoked.Play(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<Effekseer.EffekseerEffectAsset>(L, 2)) 
                {
                    Effekseer.EffekseerEffectAsset _effectAsset = (Effekseer.EffekseerEffectAsset)translator.GetObject(L, 2, typeof(Effekseer.EffekseerEffectAsset));
                    
                        var gen_ret = gen_to_be_invoked.Play( _effectAsset );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Effekseer.EffekseerEmitter.Play!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsEnd(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Effekseer.EffekseerEmitter gen_to_be_invoked = (Effekseer.EffekseerEmitter)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.IsEnd(  );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Stop(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Effekseer.EffekseerEmitter gen_to_be_invoked = (Effekseer.EffekseerEmitter)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Stop(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StopImmediate(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Effekseer.EffekseerEmitter gen_to_be_invoked = (Effekseer.EffekseerEmitter)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.StopImmediate(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StopRoot(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Effekseer.EffekseerEmitter gen_to_be_invoked = (Effekseer.EffekseerEmitter)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.StopRoot(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAllColor(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Effekseer.EffekseerEmitter gen_to_be_invoked = (Effekseer.EffekseerEmitter)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Color _color;translator.Get(L, 2, out _color);
                    
                    gen_to_be_invoked.SetAllColor( _color );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetTargetLocation(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Effekseer.EffekseerEmitter gen_to_be_invoked = (Effekseer.EffekseerEmitter)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _targetLocation;translator.Get(L, 2, out _targetLocation);
                    
                    gen_to_be_invoked.SetTargetLocation( _targetLocation );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetDynamicInput(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Effekseer.EffekseerEmitter gen_to_be_invoked = (Effekseer.EffekseerEmitter)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _index = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetDynamicInput( _index );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetDynamicInput(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Effekseer.EffekseerEmitter gen_to_be_invoked = (Effekseer.EffekseerEmitter)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _index = LuaAPI.xlua_tointeger(L, 2);
                    float _value = (float)LuaAPI.lua_tonumber(L, 3);
                    
                    gen_to_be_invoked.SetDynamicInput( _index, _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetDynamicInputWithWorldPosition(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Effekseer.EffekseerEmitter gen_to_be_invoked = (Effekseer.EffekseerEmitter)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _worldPos;translator.Get(L, 2, out _worldPos);
                    
                    gen_to_be_invoked.SetDynamicInputWithWorldPosition( ref _worldPos );
                    translator.PushUnityEngineVector3(L, _worldPos);
                        translator.UpdateUnityEngineVector3(L, 2, _worldPos);
                        
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetDynamicInputWithLocalPosition(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Effekseer.EffekseerEmitter gen_to_be_invoked = (Effekseer.EffekseerEmitter)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _localPos;translator.Get(L, 2, out _localPos);
                    
                    gen_to_be_invoked.SetDynamicInputWithLocalPosition( ref _localPos );
                    translator.PushUnityEngineVector3(L, _localPos);
                        translator.UpdateUnityEngineVector3(L, 2, _localPos);
                        
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetDynamicInputWithWorldDistance(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Effekseer.EffekseerEmitter gen_to_be_invoked = (Effekseer.EffekseerEmitter)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _worldPos;translator.Get(L, 2, out _worldPos);
                    
                    gen_to_be_invoked.SetDynamicInputWithWorldDistance( ref _worldPos );
                    translator.PushUnityEngineVector3(L, _worldPos);
                        translator.UpdateUnityEngineVector3(L, 2, _worldPos);
                        
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetDynamicInputWithLocalDistance(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Effekseer.EffekseerEmitter gen_to_be_invoked = (Effekseer.EffekseerEmitter)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _localPos;translator.Get(L, 2, out _localPos);
                    
                    gen_to_be_invoked.SetDynamicInputWithLocalDistance( ref _localPos );
                    translator.PushUnityEngineVector3(L, _localPos);
                        translator.UpdateUnityEngineVector3(L, 2, _localPos);
                        
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SendTrigger(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Effekseer.EffekseerEmitter gen_to_be_invoked = (Effekseer.EffekseerEmitter)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _index = LuaAPI.xlua_tointeger(L, 2);
                    
                    gen_to_be_invoked.SendTrigger( _index );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateSelf(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Effekseer.EffekseerEmitter gen_to_be_invoked = (Effekseer.EffekseerEmitter)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.UpdateSelf(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Update(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Effekseer.EffekseerEmitter gen_to_be_invoked = (Effekseer.EffekseerEmitter)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Update(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FixedUpdate(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Effekseer.EffekseerEmitter gen_to_be_invoked = (Effekseer.EffekseerEmitter)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.FixedUpdate(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_paused(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Effekseer.EffekseerEmitter gen_to_be_invoked = (Effekseer.EffekseerEmitter)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.paused);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_shown(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Effekseer.EffekseerEmitter gen_to_be_invoked = (Effekseer.EffekseerEmitter)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.shown);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_speed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Effekseer.EffekseerEmitter gen_to_be_invoked = (Effekseer.EffekseerEmitter)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.speed);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_exists(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Effekseer.EffekseerEmitter gen_to_be_invoked = (Effekseer.EffekseerEmitter)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.exists);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_instanceCount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Effekseer.EffekseerEmitter gen_to_be_invoked = (Effekseer.EffekseerEmitter)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.instanceCount);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TimingOfUpdate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Effekseer.EffekseerEmitter gen_to_be_invoked = (Effekseer.EffekseerEmitter)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.TimingOfUpdate);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EmitterScale(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Effekseer.EffekseerEmitter gen_to_be_invoked = (Effekseer.EffekseerEmitter)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.EmitterScale);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TimeScale(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Effekseer.EffekseerEmitter gen_to_be_invoked = (Effekseer.EffekseerEmitter)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.TimeScale);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_effectAsset(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Effekseer.EffekseerEmitter gen_to_be_invoked = (Effekseer.EffekseerEmitter)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.effectAsset);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_playOnStart(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Effekseer.EffekseerEmitter gen_to_be_invoked = (Effekseer.EffekseerEmitter)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.playOnStart);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isLooping(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Effekseer.EffekseerEmitter gen_to_be_invoked = (Effekseer.EffekseerEmitter)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.isLooping);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_handles(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Effekseer.EffekseerEmitter gen_to_be_invoked = (Effekseer.EffekseerEmitter)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.handles);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_paused(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Effekseer.EffekseerEmitter gen_to_be_invoked = (Effekseer.EffekseerEmitter)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.paused = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_shown(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Effekseer.EffekseerEmitter gen_to_be_invoked = (Effekseer.EffekseerEmitter)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.shown = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_speed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Effekseer.EffekseerEmitter gen_to_be_invoked = (Effekseer.EffekseerEmitter)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.speed = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TimingOfUpdate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Effekseer.EffekseerEmitter gen_to_be_invoked = (Effekseer.EffekseerEmitter)translator.FastGetCSObj(L, 1);
                Effekseer.EffekseerEmitterTimingOfUpdate gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.TimingOfUpdate = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_EmitterScale(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Effekseer.EffekseerEmitter gen_to_be_invoked = (Effekseer.EffekseerEmitter)translator.FastGetCSObj(L, 1);
                Effekseer.EffekseerEmitterScale gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.EmitterScale = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TimeScale(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Effekseer.EffekseerEmitter gen_to_be_invoked = (Effekseer.EffekseerEmitter)translator.FastGetCSObj(L, 1);
                Effekseer.EffekseerTimeScale gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.TimeScale = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_effectAsset(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Effekseer.EffekseerEmitter gen_to_be_invoked = (Effekseer.EffekseerEmitter)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.effectAsset = (Effekseer.EffekseerEffectAsset)translator.GetObject(L, 2, typeof(Effekseer.EffekseerEffectAsset));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_playOnStart(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Effekseer.EffekseerEmitter gen_to_be_invoked = (Effekseer.EffekseerEmitter)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.playOnStart = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_isLooping(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Effekseer.EffekseerEmitter gen_to_be_invoked = (Effekseer.EffekseerEmitter)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.isLooping = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_handles(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Effekseer.EffekseerEmitter gen_to_be_invoked = (Effekseer.EffekseerEmitter)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.handles = (System.Collections.Generic.List<Effekseer.EffekseerHandle>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<Effekseer.EffekseerHandle>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
