import java.net.*;
import java.lang.String;
import java.rmi.*;
import java.rmi.server.*;
//pgm to implement interface
public class FirstImpl extends UnicastRemoteObject implements First
{
    
	public  FirstImpl()throws RemoteException
	{
	//	throw new RemoteException();
	}
	public int cmpr(String s1,String s2)throws RemoteException
 	{
		int l=s1.length();
		int l2=s2.length();
		int c=0;
		if(l==l2)//checking length of strings
		{
			for(int i=0;i<=l;i++)
			{
				if(s1.charAt(i)==s2.charAt(i))//checking each character in strings
				c++;
				else
				c=0;	
			}
		}
		return c;
		/*if(c!=0)
		{
			System.out.println("Strings are equal");
		}*/
		//else
		/*{
		      System.out.println("strings are not equal");
		}*/
		/*if(l>l2)
		{
			System.out.println("large string: "+s1);
		}*/
		//else
		/*{
			System.out.println("large string:"+s2);
		}*/
	}
	public String rvs(String s1)throws RemoteException
	{
		String rev="";
		int l=s1.length();
		for(int i=l-1;i>=0;i--)
		{
			rev=rev+s1.charAt(i);//aading character in reverse order to string rev
		}
		return rev;
	}
	public String ct(String s1,String s2)throws RemoteException
	{
		s1=s1+s2;
		return s1;
	}
	public String lcs(String s1)throws RemoteException
	{
		s1=s1.toLowerCase();
		return s1;
	}
	public String ucs(String s1)throws RemoteException
	{
		s1=s1.toUpperCase();
	 	return s1;
	}
	public void close()
	{
		System.exit(1);
	}
	
}
