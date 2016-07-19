/*
 * Created by SharpDevelop.
 * User: Max
 * Date: 7/3/2016
 * Time: 1:16 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Text;
using System.IO;

namespace address2street
{
	class Program
	{
		public static void Main(string[] args)
		{			
			
			try
			{
				if(args[0].Equals(null))
					Console.Write("opopop...it`s impossible! realy, you must not to see this");
			}
			
			catch (Exception e)
	        {
	            //Console.WriteLine("{0} Exception caught.", e);
	            Console.Write("Ooops...  Seems like you didn`t put a parameter to program\n\n" +
				              "(drag input file on this .exe or put input-file-path as a parameter\nGood luck! )\n\n");
	        }
			
			
			var lines = File.ReadAllLines(args[0]);
			
			if (lines == null)
				throw new FileNotFoundException();
			
			for (Int32 line = 0; line < lines.Length; line++)
			{
				string[] address = lines[line].Split(',');
				
				using (System.IO.StreamWriter file =  new System.IO.StreamWriter(args[0]+".out.txt", true))
				{
					foreach ( var street in address )
					{
						if(	street.Contains("улица") || street.Contains("переулок") || street.Contains("ул.") ||
						   street.Contains("пер.") || street.Contains("проезд") || street.Contains("пр-кт") ||
						   street.Contains("Площадка") || street.Contains("шоссе") )
						{
							var str = street.Split(' ');
							
							if ( str[1].Contains("-Й") ||  str[1].Contains("-Я")  ||	// num name type
									str[1].Contains("-й") ||  str[1].Contains("-я")  )
							{
								
								Console.Write( "\n" + str[1] + " " + str[2] );
								file.WriteLine( str[1] + " " + str[2] );
							} 
							
							else if ( str[2].Contains("шоссе") || str[2].Contains("проезд") ||	// name type 
											str[2].Contains("переулок") )
								{
									Console.Write( "\n" + str[1] );
									file.WriteLine( str[1] );
								}
							
							else if ( str[1].Contains("улица") || str[1].Contains("ул.") || str[1].Contains("пр-кт") )
							{
								if ( str.Length == 3 )											// type name
								{Console.Write( "\n" + str[2] );
									file.WriteLine( str[2] );}
								
								if ( str.Length == 4 )											// type name name
								{Console.Write( "\n" + str[2] + " " + str[3] );
									file.WriteLine( str[2] + " " + str[3] );}
								
							}
							
						}
					}
				}
			}
			
			Console.Write("\n\n also was created an OUTPUT-file in the INPUT-file directory ");
			Console.Write("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}