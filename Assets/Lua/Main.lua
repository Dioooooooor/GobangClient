--主入口函数。从这里开始lua逻辑
function Main()					
	print("logic start")	 		
end

--场景切换通知
function OnLevelWasLoaded(level)
	collectgarbage("collect")
	Time.timeSinceLevelLoad = 0
end

function OnApplicationQuit()
end

print("Do Main!")

function test_coroutine()    
    print("1111");
    coroutine.wait(1);	
    print("2222");
	
    local www = UnityEngine.WWW("http://bbs.ulua.org/readme.txt");
    coroutine.www(www);
    print(www.text);    	
end

coroutine.start(test_coroutine);

UnityEngine.Debug.Log("Debug")