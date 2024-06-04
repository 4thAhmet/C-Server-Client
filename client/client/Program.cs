using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            string ıp, nick;
            int port;
            Console.Write("Ip adress giriniz: ");
            ıp = Console.ReadLine();
            Console.Write("Port giriniz: ");
            port = Convert.ToInt16(Console.ReadLine());
            Console.Write("Nick giriniz: ");
            nick = Console.ReadLine();
            Socket bağlantı = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            bağlantı.Connect(IPAddress.Parse(ıp), port);
            NetworkStream ağ = new NetworkStream(bağlantı);
            BinaryReader okuyucu = new BinaryReader(ağ);
            BinaryWriter yazıcı = new BinaryWriter(ağ);
            baslangıc:
            string mesaj;
            Console.Write("Mesajınızı giriniz: ");
            mesaj = Console.ReadLine();
            yazıcı.Write(nick + " : " + mesaj);
            Console.Write("Karşı Taraf Mesajı Bekleyiniz.");
            string gelen = okuyucu.ReadString();
            Console.WriteLine(nick + " : " + gelen);
            goto baslangıc;
        }
    }
}
