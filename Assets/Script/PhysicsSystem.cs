using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class PhysicsSystem : ComponentSystem
{

	private static float garvity = 9.8f;

	// Systemが要求するComponentData一覧
	struct Group
	{
		public int Length;
		public ComponentDataArray<WaterDate> Data;
		public ComponentDataArray<Position> pos;
		public ComponentDataArray<Rotation> rot;
	}

	[Inject] Group group; // 要求したComponentDataを注入

	// 毎フレーム呼び出される
	protected override void OnUpdate()
	{
		for (int i = 0; i < group.Length; i++)
		{
			var _Data = group.Data[i];
			var pos = group.pos[i];
			var rot = group.rot[i];

			pos.Value.y -= garvity;//落下


			pos.Value.z += _Data.Power;

			group.Data[i] = _Data;
			group.pos[i] = pos;
			group.rot[i] = rot;
		}
	}
}
