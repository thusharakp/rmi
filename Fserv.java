import java.rmi.*;
import java.rmi.server.*;
import java.rmi.Naming.*;
import java.rmi.registry.*;
import java.io.*;
//server pgm
public class Fserv
{
	public static void main(String args[])throws IOException
	{
		try
		{
			FirstImpl f=new FirstImpl();//creating object for class FirstImpl
			Naming.rebind("hello",f);
			System.out.println("server bound");
		}
		catch(Exception e)
		{
			System.out.println(e);		
		}
	}
}
