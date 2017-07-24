using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.IO;
using System.ComponentModel;
using System.Threading.Tasks;

namespace pobieranie_synch_asynch
{
    class Program
    {
        static void Main(string[] args)
        {
            int wybor;
            String Trybstring;
           
            Console.WriteLine("Wybierz tryb:\n1-Pobieranie asynchroniczne\n2-Pobieranie synchroniczne \n 3-Pobieranie wielu plików synchronicznie\n 4-Pobieranie wielu plików asynchronicznie\n");
            Trybstring = Console.ReadLine();
            wybor = int.Parse(Trybstring);
            switch(wybor)
            {
                case 1:
                    pobieranie_asynch.pobieranie2();
                    break;

                case 2:
                pobieranie_synch.pobieranie1();
                    break;
                case 3:

                    break;
                case 4:

                    break;
            }
            Console.ReadKey();
            
        }
    }
    class pobieranie_synch
    {
        public static void pobieranie1()
        {
            WebClient klient = new WebClient();
            klient.DownloadFile("https://wolnelektury.pl/media/book/txt/przy-robocie.txt", Path.Combine(Environment.CurrentDirectory,"opowiadaniesync.txt"));
            klient.DownloadProgressChanged += klient_progres;
            klient.DownloadFileCompleted += klient_pobrane;

        }
        public static void klient_progres(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine(e.ProgressPercentage);
            Console.WriteLine(e.BytesReceived);
        }
        public static void klient_pobrane(object sender ,AsyncCompletedEventArgs e)
        {
            Console.WriteLine("Koniec");
           
        }
    }
    class pobieranie_asynch
    {
        public static void pobieranie2()
        {
            WebClient klient = new WebClient();
            klient.DownloadFileAsync(new Uri("https://wolnelektury.pl/media/book/txt/przy-robocie.txt"), Path.Combine(Environment.CurrentDirectory, "opowiadanieasync.txt"));
            klient.DownloadProgressChanged += klient_asyncprogres;
            klient.DownloadFileCompleted += klient_asynckoniec;
        }
        static void klient_asyncprogres(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine(e.ProgressPercentage+"%");
            Console.WriteLine(e.BytesReceived);

        }
        static void klient_asynckoniec(object sender, AsyncCompletedEventArgs e)
        {
            Console.WriteLine("Koniec");
            Console.ReadKey();

        }

        
    }
    class pobieraniesynch2
    {
       
            public static async Task pobieranie3(IEnumerable<string> urls)
        {
            try
            {
                await pobieraniezestron(urls);
                Console.WriteLine("ZAKONCZONO POBIERANIE");
                
            }
            catch
            {
                Console.WriteLine("Nie udalo sie pobrac danych");
            }

        }
        static async Task pobieraniezestron(IEnumerable<string> urls)
        {
            HttpClient klient = new HttpClient();

        }
    
  
    }
}
