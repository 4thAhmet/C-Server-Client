using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace server
{
    class Program
    {
        static void Main(string[] args)
        {
            string ip, nick;
            int port;
            Console.Write("Nick giriniz: ");
            nick = Console.ReadLine();
            Console.Write("Açılacak Port: ");
            port = Convert.ToInt16(Console.ReadLine());
            TcpListener dinleyeci = new TcpListener(port);
            dinleyeci.Start();
            Console.WriteLine("Server Başladı");
            Console.WriteLine("Karşı Taraf Bekleniyor");
            Socket istemci = dinleyeci.AcceptSocket();
            Console.WriteLine("Karşı Taraf Bağlandı.");
            NetworkStream ağ = new NetworkStream(istemci);
            BinaryReader okuyucu = new BinaryReader(ağ);
            BinaryWriter yazıcı = new BinaryWriter(ağ);
            baslangıc:
            string mesaj, gmesaj = okuyucu.ReadString();
            Console.WriteLine("Gelen: " + gmesaj);
            Console.Write("mesajınız: ");
            mesaj = Console.ReadLine();
            yazıcı.Write(nick + " : " + mesaj);
            goto baslangıc;


        }
    }
}
