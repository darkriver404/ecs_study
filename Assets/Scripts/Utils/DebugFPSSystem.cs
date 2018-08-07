using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class DebugFPSSystem : ReactiveSystem<GameEntity>
{
    public DebugFPSSystem(Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        // 该控制器只关心含有DebugMessage组件的实体 
        return context.CreateCollector(GameMatcher.DebugFPS);
    }

    protected override bool Filter(GameEntity entity)
    {
        // 只有hasDebugMessage为true的实体才会触发下面的Execute函数
        return entity.hasDebugFPS;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        // 满足GetTrigger和Filter的实体保存在entities列表里
        foreach (var e in entities)
        {
            // 打印信息
            Debug.Log(e.debugFPS.message);
        }
    }
}
