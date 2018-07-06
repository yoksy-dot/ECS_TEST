using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine.UI;


public class ECSMain : MonoBehaviour {
	[SerializeField]
	Vector3 aaaa;

	EntityManager entityManager;
	EntityArchetype sampleArchetype;

	public int count = 0;
	public bool flag = false;

	// Use this for initialization
	void Start () {
		// EntityManagerを取得
		entityManager = World.Active.GetOrCreateManager<EntityManager>();

		// Entityのアーキタイプを定義
		sampleArchetype = entityManager.CreateArchetype(
			
			typeof(Position),
			typeof(Rotation),
			typeof(WaterDate)
			);

		// アーキタイプを元にEntityを実際に生成
		var obj = entityManager.CreateEntity(sampleArchetype);
		entityManager.SetComponentData<WaterDate>(obj, new WaterDate
		{
			IsOn = flag,
			count = 3,
			Power = 5,
			Interval = 1,
		});

		//entityManager.SetComponentData<Rotation>(obj, new Rotation
		//{
		//	Value = Quaternion.Euler(aaaa),
		//});

		//entityManager.SetComponentData<Position>(obj, new Position
		//{
		//	Value = new Vector3(),
		//});
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			flag = !flag;
		}
	}
}
