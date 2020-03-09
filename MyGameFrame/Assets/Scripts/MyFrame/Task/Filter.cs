namespace Done{ 
public class Filter {

	private int num = 0;
	private float[] filters = new float[15];
	
	public Filter(){
		for(int i = 0;i<filters.Length; ++i){
			this.filters[i] = 0.015f;
		}
		
	}

	//获取平均的时间间隔
	public float interval(float d){
		this.filters[num] = d;
		num++;
		if(num >= 15)
			num = 0;
		float all = 0;
		for(int i =0; i<15; ++i){
			all += this.filters[i];
		}
		return (all/15);
		
	}
}

}