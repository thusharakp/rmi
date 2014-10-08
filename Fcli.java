import java.net.*;
import java.rmi.*;
import java.io.*;
import java.rmi.Naming.*;
public class Fcli
{	//client pgm
	public static void main(String args[])throws IOException,NotBoundException
	{
		try
		{
		First a=(First)Naming.lookup("//192.168.1.33/hello");
		InputStreamReader isr=new InputStreamReader(System.in);
	//	System.out.println("1-compare 2-reverse 3-concatenate 4-lowercase 5-uppercase 6-exit");
	//	System.out.println("enter the choice:");
		BufferedReader br=new BufferedReader(isr);
	//	int c=Integer.parseInt(br.readLine());
		//System.out.println("enter first string:");
		//BufferedReader br=new BufferedReader(isr);
		//BufferedReader br2=new BufferedReader(isr);
		//String s1=br.readLine();
		//System.out.println("enter second string:");
		//String s2=br2.readLine();
	//	String r;
	       //	int g;
		do
		{
		System.out.println("1-compare 2-reverse 3-concatinate 4-lowercase 5-uppercase 6-exit");
                System.out.println("enter the choice:");
               // BufferedReader br=new BufferedReader(isr);
                int c=Integer.parseInt(br.readLine());
	         String r;
                          int g;
		switch(c)
		{
			case 1:System.out.println("enter first string:");
				//BufferedReader br1=new BufferedReader(isr);
				String s1=br.readLine();
				System.out.println("enter second string:");
			//	BufferedReader br=new BufferedReader(isr);
				String s2=br.readLine();
				g=a.cmpr(s1,s2);
				if(g==1)
				{
					System.out.println("strings are equal");		
				}
				else
				{
					System.out.println("strings are not equal");
				}
			       	break;
			case 2:System.out.println("enter the string to be reversed:");
				//BufferedReader br3=new BufferedReader(isr);
				String s3=br.readLine();
				r=a.rvs(s3);
				System.out.println("reverse is:"+r);
				break;
			case 3:System.out.println("enetr the first string:");
			//	BufferedReader br4=new BufferedReader(isr);
				String s4=br.readLine();
				System.out.println("enetr the second string:");
				BufferedReader br5=new BufferedReader(isr);
				String s5=br5.readLine();
				r=a.ct(s4,s5);
				System.out.println("concatinated string:"+r);
				break;
			case 4:System.out.println("enetr the string to cnovert:");
			//	BufferedReader br6=new BufferedReader(isr);
				String s6=br.readLine();
				r=a.lcs(s6);
				System.out.println("lowercase:"+r);
				break;
			case 5:System.out.println("enter the string to convert:");
			//	BufferedReader br7=new BufferedReader(isr);
				String s7=br.readLine();
				r=a.ucs(s7);
				System.out.println("uppercase:"+r);
				break;
			case 6:System.out.println("exit");
				a.close();
			default:System.out.println("invalid choice:");
			
	}
	}while(true);	
	}
	catch(Exception e)
	{}
}
}
