public class Base62Encoder
{
	private const string Base62chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
	public static string encode(int num)
	{
		if(num==0)
			return 0;
		var sb = new StringBuilder();
		while(num>0)
		{
			sb.Insert(0,Base62chars[num%62]);
			num=num/62;
		}
		return sb.ToString();
	}
	
	public static int decode(string url)
	{
		int num=0;
		foreach(var c in url)
		{
			int val = Base62chars.IndexOf(c);
			num = num * 62 + val;
		}
		return num;
	}
}