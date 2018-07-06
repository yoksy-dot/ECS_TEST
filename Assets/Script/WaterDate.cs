using Unity.Entities;

public struct WaterDate : IComponentData
{
	//水って書いたけど仕事はポンプ

	public bool IsOn;
	public int count;//一度に生産する個数
	public float Power;
	public float Interval;
}
