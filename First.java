import java.net.*;
import java.rmi.*;
public interface First extends Remote
{
	public int cmpr(String s1,String s2)throws RemoteException;//method to compare strings
	public String rvs(String s1)throws RemoteException;//method to find reverse of a string
	public String ct(String s1,String s2)throws RemoteException;//method to concatinate two strings
	public String lcs(String s1)throws RemoteException;//method to convert into lowercase
	public String ucs(String s1)throws RemoteException;//method to convert into uppercase
	public void close()throws RemoteException;//closing server
}
