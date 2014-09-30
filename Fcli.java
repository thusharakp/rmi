import java.net.*;
import java.rmi.*;
import java.io.*;
import java.rmi.Naming.*;
public class Fcli
{	//client pgm
	public static void main(String args[])throws IOException,NotBoundException
	{
		First a=(First)Naming.lookup("//192.168.0.13/hello");
		InputStreamReader isr=new InputStreamReader(System.in);
		System.out.println("enter first string:");
		BufferedReader br=new BufferedReader(isr);
		BufferedReader br2=new BufferedReader(isr);
		String s1=br.readLine();
		System.out.println("enter second string:");
		String s2=br2.readLine();
		a.cmpr(s1,s2);
		a.rvs(s1);
		a.ct(s1,s2);
		a.cs(s1,s2);
	}
}
