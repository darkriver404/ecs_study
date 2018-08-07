using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour {

    Systems _systems;
    GameEntity _entity;

    void Start ()
    {
        // 获取Entitas的上下文对象，类似一个单例管理器
        var contexts = Contexts.sharedInstance;

        // 获取所需的System组
        _systems = new Feature("Systems")
            .Add(new DebugSystems(contexts));

        // 初始化System
        _systems.Initialize();

        // 测试，添加一些测试实体
        _entity = contexts.game.CreateEntity();
        _entity.AddDebugFPS(0);
    }
	
	void Update ()
    {
        _entity.ReplaceDebugFPS(1 / Time.deltaTime);
        _systems.Execute();
    }

    void OnDestroy()
    {
        _systems.TearDown();
    }
}
